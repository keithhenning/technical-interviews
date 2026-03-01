// Example for AWS Lambda with Redis
const Redis = require('ioredis');
let redis = null;
// Reuse connections across invocations
function getRedisClient() {
  if (redis) return redis;
  redis = new Redis({
    host: process.env.REDIS_HOST,
    port: process.env.REDIS_PORT,
    password: process.env.REDIS_PASSWORD,
    // Important for serverless
    keepAlive: 1000
  });
  return redis;
}
// Lambda execution context caching
const localCache = {};
exports.handler = async (event) => {
  const { productId } = event.pathParameters;
  const cacheKey = `product:${productId}`;
  // Check local cache first (fastest)
  if (localCache[cacheKey] &&
      localCache[cacheKey].expiry > Date.now()) {
    console.log('Local context cache hit');
    return {
      statusCode: 200,
      body: JSON.stringify(
        localCache[cacheKey].data
      )
    };
  }
  // Then check Redis cache
  try {
    const client = getRedisClient();
    const cachedData = await client.get(
      cacheKey
    );
    if (cachedData) {
      console.log('Redis cache hit');
      const data = JSON.parse(cachedData);
      // Update local cache
      localCache[cacheKey] = {
        data,
        expiry: Date.now() + 60000  // 1 min
      };
      return {
        statusCode: 200,
        body: JSON.stringify(data)
      };
    }
  } catch (err) {
    console.log('Redis error:', err);
  }
  // Cache miss - fetch from database
  try {
    console.log('Fetching from database');
    const data = await fetchFromDatabase(
      productId
    );
    // Update Redis (5 minute TTL)
    const client = getRedisClient();
    await client.set(
      cacheKey,
      JSON.stringify(data),
      'EX', 300
    );
    // Update local cache
    localCache[cacheKey] = {
      data,
      expiry: Date.now() + 60000
    };
    return {
      statusCode: 200,
      body: JSON.stringify(data)
    };
  } catch (err) {
    return {
      statusCode: 500,
      body: JSON.stringify({
        error: 'Failed to fetch data'
      })
    };
  }
};

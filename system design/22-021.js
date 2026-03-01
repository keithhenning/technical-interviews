// Using the browser's Cache API
async function fetchProductDetails(productId) {
  const cacheKey = `product-${productId}`;
  const cache = await caches.open(
    'product-cache'
  );
  // Try to get from cache first
  const cachedResponse = await cache.match(
    cacheKey
  );
  if (cachedResponse) {
    const data = await cachedResponse.json();
    // Check if cache is still fresh
    // (less than 5 minutes old)
    const cacheTime = new Date(
      data.cacheTimestamp
    );
    const now = new Date();
    if ((now - cacheTime) < 5 * 60 * 1000) {
      return data;
    }
  }
  // Fetch fresh data
  const response = await fetch(
    `/api/products/${productId}`
  );
  const data = await response.json();
  // Add cache timestamp
  data.cacheTimestamp =
    new Date().toISOString();
  // Store in cache
  const cacheResponse = new Response(
    JSON.stringify(data),
    {
      headers: {
        'Content-Type': 'application/json'
      }
    }
  );
  await cache.put(cacheKey, cacheResponse);
  return data;
}

import redis
# Connect to Redis
redis_client = redis.Redis(
    host='localhost',
    port=6379
)
def get_user(user_id):
    # Try to get from cache
    cached_user = redis_client.get(
        f"user:{user_id}"
    )
    if cached_user:
        # Cache hit - deserialize and return
        return json.loads(cached_user)
    # Cache miss - fetch from database
    user = database.query(
    f"SELECT * FROM users "
    f"WHERE id = {user_id}"
)
# Store in cache for future requests
# Expire after 1 hour
redis_client.setex(
    f"user:{user_id}",
    3600,
    json.dumps(user)
)
return user

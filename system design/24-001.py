import time
import redis
class RateLimiter:
    def __init__(self, redis_client):
        self.redis = redis_client
    def is_allowed(self, user_id, tier="free"):
        """
Check if a request from the user is allowed based on
their tier.
Returns True if allowed, False if rate limited.
"""
# Set rate limits based on user tier
if tier == "premium":
    max_tokens = 1000
    refill_rate = 1000 / 60  # 1000 tokens per 60
    seconds
else:  # free tier
    max_tokens = 100
    refill_rate = 100 / 60
                             # 100 tokens per 60
    seconds
# Keys for Redis
token_key = f"rate_limiter:{user_id}:tokens"
timestamp_key = f"rate_limiter:{user_id}:last_update"
# Use Lua script for atomic operations
script = """
local token_key = KEYS[1]
local timestamp_key = KEYS[2]
local max_tokens = tonumber(ARGV[1])
local refill_rate = tonumber(ARGV[2])
local current_time = tonumber(ARGV[3])
-- Get current tokens and last update time
local tokens = tonumber(redis.call('get', token_key)
or max_tokens)
local last_update = tonumber(redis.call('get',
timestamp_key) or 0)
-- Calculate token refill
local time_passed = current_time - last_update
local new_tokens = math.min(max_tokens, tokens +
(time_passed * refill_rate))
-- If we have at least one token, consume it
if new_tokens >= 1 then
    -- Update tokens and timestamp
    redis.call('set', token_key, new_tokens - 1)
    redis.call('set', timestamp_key, current_time)
    redis.call('expire', token_key, 90)  -- Set expiry
    to clean up
    redis.call('expire', timestamp_key, 90)
    return 1  -- Request allowed
else
    -- Calculate time until next token is available
    local wait_time = (1 - new_tokens) / refill_rate
    return 0  -- Request denied
end
"""
current_time = time.time()
keys = [token_key, timestamp_key]
args = [max_tokens, refill_rate, current_time]
# Execute the script
result = self.redis.eval(script, len(keys), *keys,
*args)
return result == 1

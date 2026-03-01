-- Token Bucket implementation in Redis Lua script
local key = KEYS[1]
local capacity = tonumber(ARGV[1])
local refillRate = tonumber(ARGV[2]) -- tokens per second
local now = tonumber(ARGV[3])
-- Get current bucket state
local bucketData = redis.call('HMGET', key, 'tokens',
'lastRefill')
local tokens = tonumber(bucketData[1]) or capacity
local lastRefill = tonumber(bucketData[2]) or 0
-- Calculate tokens to add based on time elapsed
local elapsedTime = now - lastRefill
local tokensToAdd = math.floor(elapsedTime * refillRate / 1000)
-- Refill bucket (up to max capacity)
tokens = math.min(capacity, tokens + tokensToAdd)
-- Try to consume a token
local allowed = 0
if tokens >= 1 then
    tokens = tokens - 1
    allowed = 1
end
-- Update bucket state
redis.call('HMSET', key, 'tokens', tokens, 'lastRefill', now)
redis.call('EXPIRE', key, 86400)  -- expire after a day
return {allowed, tokens}

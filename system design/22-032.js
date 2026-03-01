/ Example for Cloudflare Workers
addEventListener('fetch', event => {
  event.respondWith(handleRequest(event.request))
})
async function handleRequest(request) {
  const cacheKey = new URL(request.url)
  // Try to get from cache first
  const cache = caches.default
  let response = await cache.match(cacheKey)
  if (response) {
    // Check if cache is still valid
    const cachedTime = response.headers.get(
        'X-Cached-Time'
    )
    const now = Date.now()
    // If cached < 5 min ago, return cached
    if (cachedTime &&
        (now - parseInt(cachedTime)) <
        5 * 60 * 1000) {
      return response
    }
  }
  // Cache miss or stale, fetch from origin
  response = await fetch(request)
  // Clone response to modify headers
  const responseToCache = new Response(
    response.body, response
  )
  responseToCache.headers.set(
    'X-Cached-Time', Date.now().toString()
  )
  responseToCache.headers.set(
    'X-Cache', 'HIT from Edge'
  )
  // Cache for future with TTL
  event.waitUntil(
    cache.put(cacheKey, responseToCache)
  )
  return responseToCache
}

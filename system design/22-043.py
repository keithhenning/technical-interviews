class EdgeToCloudCache:
    def __init__(self, local_storage,
                 cdn_client, cloud_cache):
        self.local = local_storage
        self.cdn = cdn_client
        self.cloud = cloud_cache
    async def get(self, key, context):
        """Multi-tier get with context"""
        # Try local first for fastest response
        if context.has_local_storage:
            local_value = await self.local.get(key)
            if local_value:
                return {
                    'value': local_value,
                    'source': 'local'
                }
# Try CDN next for regional caching
if self._is_cdn_candidate(key):
    cdn_value = await self.cdn.get(key)
    if cdn_value:
        # Update local cache if available
        if context.has_local_storage:
            await self.local.set(
                key, cdn_value
            )
        return {
            'value': cdn_value,
            'source': 'cdn'
        }
# Finally try cloud cache
cloud_value = await self.cloud.get(key)
if cloud_value:
    # Update lower tiers
    if self._is_cdn_candidate(key):
        await self.cdn.set(key, cloud_value)
    if context.has_local_storage:
        await self.local.set(key, cloud_value)
    return {
        'value': cloud_value,
        'source': 'cloud'
    }
# Cache miss at all tiers
return {'value': None, 'source': None}

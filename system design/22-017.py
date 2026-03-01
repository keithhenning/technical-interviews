import redis
import json
import hashlib
import time
import logging
class ProductCatalogCache:
    def __init__(self, redis_host='localhost',
                 redis_port=6379):
        self.redis = redis.Redis(
            host=redis_host,
            port=redis_port
        )
        self.logger = logging.getLogger(
            'product_cache'
        )
        # Cache statistics
        self.hits = 0
        self.misses = 0
    def _generate_key(self, product_id=None,
                     category=None, filters=None):
        """
        Generate consistent cache key
        based on parameters
        """
        key_parts = ["product"]
        if product_id:
        key_parts.append(f"id:{product_id}")
    if category:
        key_parts.append(f"cat:{category}")
    if filters:
        # Sort filters for consistent keys
        filter_str = ":".join(
            f"{k}={v}" for k, v in
            sorted(filters.items())
        )
        filter_hash = hashlib.md5(
            filter_str.encode()
        ).hexdigest()[:8]
        key_parts.append(f"f:{filter_hash}")
    return ":".join(key_parts)
def get_product(self, product_id):
    """Get a single product by ID"""
    key = self._generate_key(
        product_id=product_id
    )
    # Try cache first
    cached = self.redis.get(key)
    if cached:
        self.hits += 1
        self.logger.debug(
            f"Cache hit for product "
            f"{product_id}"
        )
        return json.loads(cached)
    self.misses += 1
    self.logger.debug(
        f"Cache miss for product "
        f"{product_id}"
    )
    # Fetch from database
    product = self._fetch_product_from_db(
        product_id
    )
    # Cache for 1 hour
    if product:
        self.redis.setex(
            key, 3600, json.dumps(product)
        )
    return product
def invalidate_product(self, product_id):
    """Invalidate cache for product"""
    # Clear direct product cache
    key = self._generate_key(
        product_id=product_id
    )
    self.redis.delete(key)
    # Clear list caches containing product
    self.redis.eval("""
        local keys = redis.call(
            'keys', 'product:cat:*'
        )
        for i, key in ipairs(keys) do
            redis.call('del', key)
        end
        return #keys
    """, 0)
    self.logger.info(
        f"Invalidated cache for "
        f"product {product_id}"
    )

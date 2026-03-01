class ProductCatalogService:
    def __init__(self, redis_client, database, cdn_client):
        self.redis = redis_client
        self.db = database
        self.cdn = cdn_client
def get_product(self, product_id):
    """Get single product details"""
    # Try cache first
    cache_key = f"product:{product_id}"
    product = self._get_from_cache(cache_key)
    if product:
        return product
    # Cache miss - fetch from database
    product = self.db.query(f"SELECT * FROM products WHERE
    id = {product_id}")
    if product:
        # Cache with 1 hour TTL
        self._set_in_cache(cache_key, product, ttl=3600)
    return product
def get_category_products(self, category_id, page=1,
per_page=20):
    """Get paginated products for category"""
    # Different caching strategy for lists:
    # 1. Shorter TTL because lists change more frequently
    # 2. Cache each page separately
    cache_key =
    f"category:{category_id}:page:{page}:size:{per_page}"
    result = self._get_from_cache(cache_key)
    if result:
        return result
    # Cache miss - build from database
    offset = (page - 1) * per_page
    products = self.db.query(f"""
        SELECT * FROM products
        WHERE category_id = {category_id}
        ORDER BY popularity DESC
        LIMIT {per_page} OFFSET {offset}
    """)
    count = self.db.query_scalar(f"""
        SELECT COUNT(*) FROM products WHERE category_id =
        {category_id}
    """)
    result = {
        'products': products,
        'total': count,
        'page': page,
        'per_page': per_page,
        'total_pages': math.ceil(count / per_page)
    }
    # Cache with 10 minute TTL
    self._set_in_cache(cache_key, result, ttl=600)
    return result
def get_product_image_url(self, product_id, size='medium'):
    """Get CDN URL for product image"""
    # CDN-specific caching strategy
    image_path = f"products/{product_id}/{size}.jpg"
    # Check if image exists in CDN cache
    cdn_url = self.cdn.get_url(image_path)
    if not self.cdn.exists(image_path):
        # Not in CDN, generate and upload
        image_data =
        self.generate_product_image(product_id, size)
        self.cdn.upload(image_path, image_data)
    return cdn_url
def _get_from_cache(self, key):
    try:
        data = self.redis.get(key)
        return json.loads(data) if data else None
    except Exception as e:
        logging.error(f"Cache get error: {e}")
        return None
def _set_in_cache(self, key, data, ttl=None):
    try:
        json_data = json.dumps(data)
        if ttl:
            self.redis.setex(key, ttl, json_data)
        else:
            self.redis.set(key, json_data)
    except Exception as e:
        logging.error(f"Cache set error: {e}")

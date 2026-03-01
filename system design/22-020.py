# Using Flask-Caching for API responses
from flask import Flask
from flask_caching import Cache
app = Flask(__name__)
cache = Cache(
    app,
    config={
        'CACHE_TYPE': 'redis',
        'CACHE_REDIS_URL':
            'redis://localhost:6379/0'
    }
)
@app.route('/api/products/trending')
@cache.cached(timeout=300)  # 5 minutes
def get_trending_products():
    """Get currently trending products"""
# Expensive operation
products = calculate_trending_products()
return jsonify(products)

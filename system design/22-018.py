# Using SQLAlchemy with Redis caching
from sqlalchemy import create_engine
from sqlalchemy.orm import (
    scoped_session, sessionmaker
)
from dogpile.cache import make_region
from dogpile.cache.api import NO_VALUE
# Configure cache region
region = make_region().configure(
    'dogpile.cache.redis',
    arguments={
        'host': 'localhost',
        'port': 6379,
        'db': 0,
        'redis_expiration_time': 60*60*2,
    }
)
# Create engine and session
engine = create_engine(
    'postgresql://user:pass@localhost/dbname'
)
Session = scoped_session(
    sessionmaker(bind=engine)
)
# Function to cache query results
def get_products_cached(category_id,
                        min_price=None):
def generate_data():
    session = Session()
    query = session.query(Product).filter(
        Product.category_id == category_id
    )
    if min_price is not None:
        query = query.filter(
            Product.price >= min_price
        )
    return query.all()
cache_key = (
    f"products:cat:{category_id}:"
    f"min_price:{min_price}"
)
value = region.get(
    cache_key, createfunc=generate_data
)
return value

# Using Python's functools
# for in-memory function result caching
from functools import lru_cache
@lru_cache(maxsize=1000)
def calculate_product_recommendation(
    user_id, product_id
):
    """
    Calculate personalized
product recommendation score
"""
# Expensive calculation
similarity_score = compute_similarity(
    user_id, product_id
)
popularity_score = get_product_popularity(
    product_id
)
return (
    (0.7 * similarity_score) +
    (0.3 * popularity_score)
)

# Phase 1: Simple function-level caching
from functools import lru_cache
@lru_cache(maxsize=1000)
def get_user_preferences(user_id):
    """Fetch user preferences from database"""
    # Database query here
    return preferences

def is_allowed(self, user_id, tier="free"):
    try:
        # Normal rate limiting logic with Redis
        return self._check_rate_limit(user_id, tier)
    except redis.RedisError:
        # Fall back to local counter for premium users
        if tier == "premium":
            logger.warning(f"Rate limiter using local fallback
    for premium user {user_id}")
    return self._check_local_rate_limit(user_id, tier,
    conservative=True)
else:
    # Free users fail closed by default
    logger.warning(f"Rate limiter failing closed for
    free user {user_id}")
    return False

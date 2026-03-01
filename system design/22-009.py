def warm_user_cache():
    # Get IDs of most active users
    active_user_ids = database.query(
        "SELECT id FROM users "
        "WHERE last_login > "
        "NOW() - INTERVAL 1 DAY"
    )
    # Pre-populate cache
    for user_id in active_user_ids:
        # This will add to cache if not present
        get_user(user_id)

class SocialFeedService:
    def __init__(self, redis_client,
                 database, event_bus):
        self.redis = redis_client
        self.db = database
        self.events = event_bus
        # Subscribe to relevant events
        self.events.subscribe(
            'post.created',
            self.handle_new_post
        )
        self.events.subscribe(
            'post.liked',
            self.handle_post_interaction
    )
def get_user_feed(self, user_id,
                 page=1, page_size=20):
    """
    Get user's personalized feed
    with caching
    """
    # Feeds are dynamic, short TTL
    cache_key = f"feed:{user_id}:p{page}"
    # Try cache first
    feed = self._get_from_cache(cache_key)
    if feed:
        return feed
    # Cache miss - generate feed
    # Get user's following list
    following_ids = self.db.query(f"""
        SELECT followed_id FROM follows
        WHERE follower_id = {user_id}
    """)
    # Include user's own posts
    author_ids = [user_id] + following_ids
    # Get posts from these users
    offset = (page - 1) * page_size
    posts = self.db.query(f"""
        SELECT p.*, u.username, u.avatar_url
        FROM posts p
        JOIN users u ON p.user_id = u.id
        WHERE p.user_id IN
            ({','.join(map(str, author_ids))})
        ORDER BY p.created_at DESC
        LIMIT {page_size} OFFSET {offset}
    """)
    feed = {
        'posts': posts,
        'page': page,
        'has_more': len(posts) == page_size
    }
    # Cache with short TTL (2 minutes)
    self._set_in_cache(
        cache_key, feed, ttl=120
    )
    return feed
def handle_new_post(self, event):
    """
    Handle new post event -
    invalidate affected feeds
    """
    post = event['data']
    author_id = post['user_id']
    # Get followers whose feeds need
    # invalidation
    followers = self.db.query(f"""
        SELECT follower_id FROM follows
        WHERE followed_id = {author_id}
    """)
    # Invalidate first page of each feed
    for follower_id in followers:
        self.redis.delete(
            f"feed:{follower_id}:p1"
        )

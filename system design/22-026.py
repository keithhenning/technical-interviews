class GeoCache:
    def __init__(self, redis_client):
        self.redis = redis_client
    def add_location(self, object_id, lat, lng,
                    data=None):
        """Add object to geo index"""
        # Store object in geo index
        self.redis.geoadd(
            'geo:index', lng, lat, object_id
        )
        # Store associated data if provided
    if data:
        self.redis.set(
            f"geo:data:{object_id}",
            json.dumps(data)
        )
def find_nearby(self, lat, lng, radius=5,
               unit='km', limit=20):
    """Find objects within radius"""
    # Find IDs of nearby objects
    results = self.redis.georadius(
        'geo:index', lng, lat, radius, unit,
        withdist=True, withcoord=True,
        count=limit
    )
    # Format and enrich results
    nearby = []
    for obj_id, distance, coordinates in results:
        obj_id = (obj_id.decode('utf-8')
                 if isinstance(obj_id, bytes)
                 else obj_id)
        # Get stored data for object
        data = self.redis.get(
            f"geo:data:{obj_id}"
        )
        data = (json.loads(data) if data
               else {})
        nearby.append({
            'id': obj_id,
            'distance': distance,
            'coordinates': coordinates,
            'data': data
        })
    return nearby

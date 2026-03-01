class MicroserviceCache:
    def __init__(self, redis_client, service_name):
        self.redis = redis_client
        self.service = service_name
    def get(self, entity_type, entity_id):
        # Namespaced key to avoid collisions
        key = (f"{self.service}:{entity_type}:"
               f"{entity_id}")
        data = self.redis.get(key)
        return json.loads(data) if data else None
    def set(self, entity_type, entity_id,
            data, ttl=1800):
        key = (f"{self.service}:{entity_type}:"
               f"{entity_id}")
        self.redis.setex(
            key, ttl, json.dumps(data)
        )
    def invalidate_by_event(self, event):
        """Invalidate cache based on events"""
        if event['type'] == 'entity_updated':
            entity_type = event['entity_type']
            entity_id = event['entity_id']
            self.invalidate(entity_type, entity_id)
        # Invalidate related entities
        if 'related_entities' in event:
            for related in (
                event['related_entities']
            ):
                self.invalidate(
                    related['type'],
                    related['id']
                )
def invalidate(self, entity_type, entity_id):
    key = (f"{self.service}:{entity_type}:"
           f"{entity_id}")
    self.redis.delete(key)

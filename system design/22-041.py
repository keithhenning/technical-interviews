class SecureCache:
    def __init__(self, redis_client,
                 encryption_key):
        self.redis = redis_client
        self.cipher = AES.new(
            encryption_key, AES.MODE_GCM
        )
    def set(self, key, value, expire=None):
        """Store encrypted value in cache"""
        # Serialize value
        serialized = json.dumps(value)
        # Encrypt
        nonce = self.cipher.nonce
        ciphertext, tag = (
            self.cipher.encrypt_and_digest(
                serialized.encode('utf-8')
            )
        )
        # Store with metadata
        stored_value = {
            'nonce': base64.b64encode(
                nonce
            ).decode('utf-8'),
            'tag': base64.b64encode(
                tag
            ).decode('utf-8'),
            'data': base64.b64encode(
                ciphertext
            ).decode('utf-8')
        }
        # Set in Redis
        if expire:
            self.redis.setex(
        key, expire,
        json.dumps(stored_value)
    )
else:
    self.redis.set(
        key, json.dumps(stored_value)
    )

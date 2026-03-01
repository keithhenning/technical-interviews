import zlib
def set_compressed(cache, key, value,
                   compression_level=6, **kwargs):
    # Serialize and compress
    serialized = json.dumps(value).encode('utf-8')
    compressed = zlib.compress(
        serialized,
        compression_level
    )
    # Store compressed data
    cache.set(key, compressed, **kwargs)
def get_decompressed(cache, key):
# Get compressed data
compressed = cache.get(key)
if compressed:
    # Decompress and deserialize
    serialized = zlib.decompress(compressed)
    return json.loads(
        serialized.decode('utf-8')
    )
return None

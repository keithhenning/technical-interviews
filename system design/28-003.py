# The workflow
url = "https://example.com/very/long/path"
clean_url = canonicalize(url)
# Hash it, encode it, and grab the first 8
hash_val = sha256(clean_url)
short_code = base62_encode(hash_val)[:8]

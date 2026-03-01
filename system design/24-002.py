# Example usage in a Flask app
from flask import Flask, request, jsonify
app = Flask(__name__)
redis_client = redis.Redis(host='localhost', port=6379, db=0)
rate_limiter = RateLimiter(redis_client)
@app.route('/api/resource', methods=['GET'])
def get_resource():
    user_id = request.headers.get('X-API-Key',
    request.remote_addr)
    # Get user tier from a service or cache
    user_tier = get_user_tier(user_id)  # This would be a
    separate function
    if rate_limiter.is_allowed(user_id, user_tier):
        # Process the request
        return jsonify({"data": "Your requested resource"})
    else:
        # Rate limited
        retry_after = 60  # Simplified - in production
        calculate actual wait time
        return jsonify({
            "error": "Rate limit exceeded",
            "message": f"Please try again in {retry_after}
            seconds"
        }), 429, {'Retry-After': str(retry_after)}
def get_user_tier(user_id):
    # This would query a user service or database
    # For simplicity, we're returning a mock result
    return "premium" if user_id.startswith("premium_") else
    "free"
if __name__ == '__main__':
    app.run(debug=True)

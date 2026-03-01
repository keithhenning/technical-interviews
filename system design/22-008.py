from flask import Flask, request, make_response
import time
app = Flask(__name__)
@app.route('/api/articles')
def get_articles():
    # Get articles from database
    articles = database.get_articles()
    # Prepare response
response = make_response(
    json.dumps(articles)
)
# Set cache headers
response.headers['Content-Type'] = (
    'application/json'
)
# Cache for 5 minutes
response.headers['Cache-Control'] = (
    'max-age=300'
)
response.headers['ETag'] = (
    compute_etag(articles)
)
return response

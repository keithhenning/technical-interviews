# Example using AWS Lambda with API Gateway caching
def lambda_handler(event, context):
    # Check if we should use API Gateway cache
    use_cache = event.get('queryStringParameters',
    {}).get('cache', 'true').lower() == 'true'
    # Set cache headers based on parameter
    cache_control = 'max-age=300' if use_cache else 'no-cache'
    # Do expensive computation
    result = perform_expensive_calculation()
    return {
        'statusCode': 200,
        'headers': {
            'Content-Type': 'application/json',
            'Cache-Control': cache_control
        },
        'body': json.dumps(result)
    }

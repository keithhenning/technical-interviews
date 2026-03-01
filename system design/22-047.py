class FinancialDataService:
    def __init__(self, redis_client,
                 time_series_db, market_data_api):
        self.redis = redis_client
        self.tsdb = time_series_db
        self.market_api = market_data_api
        # Set up background refresh
        self._start_real_time_refresh()
    def get_stock_price(self, symbol):
        """
        Get latest stock price
        with real-time caching
        """
        cache_key = f"stock:price:{symbol}"
        # Real-time data has short TTL
        price_data = self._get_from_cache(
            cache_key
        )
        if price_data:
            return price_data
        # Fetch from market API
        price_data = self.market_api.get_quote(
            symbol
        )
        # Cache with 15-second TTL
        self._set_in_cache(
            cache_key, price_data, ttl=15
        )
    return price_data
def get_historical_prices(self, symbol,
                          period='1y'):
    """
    Get historical price data
    with longer-term caching
    """
    cache_key = (
        f"stock:history:{symbol}:{period}"
    )
    # Historical data cached longer
    history = self._get_from_cache(cache_key)
    if history:
        return history
    # Determine date range
    end_date = datetime.date.today()
    if period == '1m':
        start_date = end_date - (
            datetime.timedelta(days=30)
        )
    elif period == '3m':
        start_date = end_date - (
            datetime.timedelta(days=90)
        )
    elif period == '1y':
        start_date = end_date - (
            datetime.timedelta(days=365)
        )
    else:
        start_date = end_date - (
            datetime.timedelta(days=30)
        )
    # Fetch from time series DB
    history = self.tsdb.query(f"""
        SELECT date, open, high, low,
           close, volume
    FROM stock_prices
    WHERE symbol = '{symbol}'
    AND date BETWEEN
        '{start_date}' AND '{end_date}'
    ORDER BY date
""")
if history:
    # Add moving averages, etc.
    self._enrich_historical_data(history)
    # Determine TTL based on period
    if period == '1y':
        ttl = 86400  # 1 day
    elif period == '3m':
        ttl = 21600  # 6 hours
    else:
        ttl = 3600
                     # 1 hour
    self._set_in_cache(
        cache_key, history, ttl=ttl
    )
return history

req = requests.assign(hour=requests.local_ts.dt.hour,
                      dow=requests.local_ts.dt.dayofweek)
gap = (req.groupby(["zone_id", "dow", "hour"])
          .agg(requests=("request_id", "count"),
               completed=("completed", "sum"))
          .assign(fill_rate=lambda d: d.completed / d.requests)
          .reset_index())
worst = gap.query("requests >= 50").nsmallest(20, "fill_rate")

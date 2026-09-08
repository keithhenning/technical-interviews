def profile(df, name, key):
    dupes = df.duplicated(subset=key).mean()
    print(f"{name}: {len(df):,} rows, "
          f"{df[key[0]].nunique():,} unique {key[0]}, "
          f"dup rate {dupes:.2%}")
    print(df.isna().mean().round(3).to_string())

profile(requests, "requests", ["request_id"])

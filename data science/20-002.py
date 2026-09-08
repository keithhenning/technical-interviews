import lightgbm as lgb

ranker = lgb.LGBMRanker(
    objective="lambdarank",
    n_estimators=800,
    learning_rate=0.05,
    num_leaves=63,
    label_gain=[0, 1, 3, 10],   # none, click, cart, purchase
)
ranker.fit(X_train, y_train, group=session_sizes_train,
           eval_set=[(X_valid, y_valid)], eval_group=[session_sizes_valid],
           eval_at=[20])

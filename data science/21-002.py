import lightgbm as lgb

model = lgb.LGBMRanker(
    objective="lambdarank",
    metric="ndcg",
    n_estimators=1000,
    learning_rate=0.05,
    num_leaves=127,
    label_gain=[0, 1, 3, 7, 15],   # index equals grade, 4 maps to 15
    lambdarank_truncation_level=20,
)
model.fit(X_train, y_train, group=query_sizes_train,
          eval_set=[(X_valid, y_valid)],
          eval_group=[query_sizes_valid], eval_at=[10])

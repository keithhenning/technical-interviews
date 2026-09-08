import lightgbm as lgb

params = {
    "objective": "binary",
    "learning_rate": 0.05,
    "num_leaves": 63,
    "scale_pos_weight": 30,  # partial reweighting, not full 1/0.003
    "feature_fraction": 0.8,
    "metric": "average_precision",
}
model = lgb.train(params, train_set, valid_sets=[valid_set],
                  num_boost_round=2000,
                  callbacks=[lgb.early_stopping(100)])

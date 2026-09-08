import lightgbm as lgb

for spw in [1, 5, 20, 50, 125]:
    m = lgb.LGBMClassifier(n_estimators=2000, learning_rate=0.03,
                           num_leaves=31, min_child_samples=100,
                           scale_pos_weight=spw)
    m.fit(X_tr, y_tr, eval_set=[(X_val, y_val)],
          eval_metric="average_precision",
          callbacks=[lgb.early_stopping(100, verbose=False)])
    s = m.predict_proba(X_val)[:, 1]
    print(spw, round(average_precision_score(y_val, s), 4))

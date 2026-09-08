import lightgbm as lgb
from sklearn.linear_model import LogisticRegression
from sklearn.pipeline import make_pipeline
from sklearn.preprocessing import StandardScaler
from sklearn.metrics import average_precision_score

gbdt = lgb.LGBMClassifier(n_estimators=2000, learning_rate=0.03,
                          num_leaves=63, min_child_samples=200,
                          feature_fraction=0.8, scale_pos_weight=10)
gbdt.fit(X_tr, y_tr, eval_set=[(X_val, y_val)],
         callbacks=[lgb.early_stopping(100, verbose=False)])

lin = make_pipeline(StandardScaler(), LogisticRegression(C=0.1, max_iter=3000))
lin.fit(X_tr_encoded, y_tr)

for name, p in [("gbdt", gbdt.predict_proba(X_val)[:, 1]),
                ("linear", lin.predict_proba(X_val_encoded)[:, 1])]:
    print(name, round(average_precision_score(y_val, p), 4))

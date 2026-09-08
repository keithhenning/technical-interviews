import lightgbm as lgb
import numpy as np

def t_learner(X, y, w, X_score):
    # w = 1 treated, 0 control; assignment was random
    m1 = lgb.LGBMClassifier(n_estimators=300, learning_rate=0.05)
    m0 = lgb.LGBMClassifier(n_estimators=300, learning_rate=0.05)
    m1.fit(X[w == 1], y[w == 1])
    m0.fit(X[w == 0], y[w == 0])
    return m1.predict_proba(X_score)[:, 1] - m0.predict_proba(X_score)[:, 1]

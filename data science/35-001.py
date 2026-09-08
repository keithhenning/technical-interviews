import shap
from sklearn.inspection import permutation_importance

perm = permutation_importance(model, X_holdout, y_holdout,
                              scoring="roc_auc", n_repeats=10,
                              random_state=0, n_jobs=-1)
explainer = shap.TreeExplainer(model)
sv = explainer.shap_values(X_holdout)           # (n, n_features)
global_shap = np.abs(sv).mean(axis=0)
top = np.argsort(-global_shap)[:15]
for i in top:
    print(X_holdout.columns[i], round(global_shap[i], 4),
          round(perm.importances_mean[i], 4))

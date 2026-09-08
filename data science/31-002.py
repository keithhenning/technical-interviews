from sklearn.linear_model import LogisticRegression
from sklearn.model_selection import cross_val_score

for C in [0.001, 0.01, 0.1, 1, 10]:
    for penalty in ["l1", "l2"]:
        clf = LogisticRegression(C=C, penalty=penalty,
                                 solver="saga", max_iter=2000)
        auc = cross_val_score(clf, X_train, y_train,
                              cv=5, scoring="roc_auc").mean()
        nnz = (np.abs(clf.fit(X_train, y_train).coef_) > 1e-6).sum()
        print(C, penalty, round(auc, 4), nnz)

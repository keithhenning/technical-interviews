i = 41722                                      # one declined applicant
base = explainer.expected_value
contrib = sv[i]
order = np.argsort(contrib)[:5]                # most negative first
print("baseline logit", round(base, 3),
      "applicant logit", round(base + contrib.sum(), 3))
for j in order:
    print(X_holdout.columns[j], X_holdout.iloc[i, j], round(contrib[j], 3))

using System.Collections.Generic;

public static int Lcs(string X, string Y, int m, int n, Dictionary<(int, int), int> memo = null) {
    if (memo == null) {
        memo = new Dictionary<(int, int), int>();
    }
    
    var key = (m, n);
    if (memo.ContainsKey(key)) {
        return memo[key];
    }
    
    if (m == 0 || n == 0) {
        return 0;
    }
    
    int result;
    if (X[m-1] == Y[n-1]) {
        result = 1 + Lcs(X, Y, m-1, n-1, memo);
    } else {
        result = Math.Max(Lcs(X, Y, m, n-1, memo), Lcs(X, Y, m-1, n, memo));
    }
    
    memo[key] = result;
    return result;
}
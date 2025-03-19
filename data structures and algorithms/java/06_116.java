public static int lcs(String X, String Y, int m, int n, 
        Map<Pair<Integer, Integer>, Integer> memo) {
    if (memo == null) {
        memo = new HashMap<>();
    }
    
    Pair<Integer, Integer> key = new Pair<>(m, n);
    if (memo.containsKey(key)) {
        return memo.get(key);
    }
    
    if (m == 0 || n == 0) {
        return 0;
    }
    
    int result;
    if (X.charAt(m-1) == Y.charAt(n-1)) {
        result = 1 + lcs(X, Y, m-1, n-1, memo);
    } else {
        result = Math.max(lcs(X, Y, m, n-1, memo), 
                         lcs(X, Y, m-1, n, memo));
    }
    
    memo.put(key, result);
    return result;
}
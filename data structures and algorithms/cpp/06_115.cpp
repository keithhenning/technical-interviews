int lcs(const std::string& X, const std::string& Y, int m, int n,
         std::map<std::pair<int, int>, int>& memo) {
    std::pair<int, int> key = {m, n};
    
    if (memo.find(key) != memo.end()) {
        return memo[key];
    }
    if (m == 0 || n == 0) {
        return 0;
    }
    
    if (X[m-1] == Y[n-1]) {
        memo[key] = 1 + lcs(X, Y, m-1, n-1, memo);
    } else {
        memo[key] = std::max(lcs(X, Y, m, n-1, memo), 
                           lcs(X, Y, m-1, n, memo));
    }
    
    return memo[key];
}
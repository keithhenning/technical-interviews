int recursiveFunc(int m, int n, 
                   std::map<std::pair<int, int>, int>& memo) {
    // Check if result is already calculated
    std::pair<int, int> key = {m, n};
    if (memo.find(key) != memo.end()) {
        return memo[key];
    }
    
    // Calculate result
    int result = 0; // Replace with your actual calculation
    
    // Store in memo table
    memo[key] = result;
    return result;
}
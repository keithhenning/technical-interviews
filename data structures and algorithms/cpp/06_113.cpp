int recursiveFunc(int n, int depth = 0, 
                   std::unordered_map<int, int>& memo = {}) {
    std::string indent(depth * 2, ' ');
    std::cout << indent << "Computing f(" << n << ")" << std::endl;
    
    if (memo.find(n) != memo.end()) {
        std::cout << indent << "Found in cache: " << memo[n] 
                  << std::endl;
        return memo[n];
    }
    
    // Rest of function...
    int result = 0; // Replace with actual calculation
    
    memo[n] = result;
    return result;
}
std::vector<int> solution(const std::vector<int>& a) {
    int n = a.size();
    std::vector<int> result(n);
    
    for (int i = 0; i < n; i++) {
        int leftVal = (i-1 < 0) ? 0 : a[i-1];
        int rightVal = (i+1 >= n) ? 0 : a[i+1];
        result[i] = leftVal + a[i] + rightVal;
    }
    
    return result;
}
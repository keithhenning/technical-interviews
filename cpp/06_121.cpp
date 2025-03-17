std::vector<int> solution(int n, const std::vector<int>& a) {
    std::vector<int> padded(n + 2, 0);
    std::vector<int> result(n);
    
    // Copy array elements into padded array
    for (int i = 0; i < n; i++) {
        padded[i + 1] = a[i];
    }
    
    // Calculate sliding window sum
    for (int i = 0; i < n; i++) {
        result[i] = padded[i] + padded[i + 1] + padded[i + 2];
    }
    
    return result;
}
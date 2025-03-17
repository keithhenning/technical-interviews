#include <iostream>
#include <vector>

std::vector<int> mutation(int n, const std::vector<int>& a) {
    std::vector<int> b(n, 0);
    
    for (int i = 0; i < n; i++) {
        // Left neighbor (or 0 if out of bounds)
        int left = (i > 0) ? a[i-1] : 0;
        
        // Current element
        int current = a[i];
        
        // Right neighbor (or 0 if out of bounds)
        int right = (i < n-1) ? a[i+1] : 0;
        
        // Sum all three values
        b[i] = left + current + right;
    }
    
    return b;
}

int main() {
    std::vector<int> a = {4, 0, 1, -2, 3};
    int n = a.size();
    std::vector<int> result = mutation(n, a);
    
    // Print the result
    for (int val : result) {
        std::cout << val << " ";
    }
    // Output: 4 5 -1 2 1
    
    return 0;
}
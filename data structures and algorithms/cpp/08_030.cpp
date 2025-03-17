#include <vector>
#include <algorithm>

int maxArtworkValue(std::vector<int>& values) {
    int n = values.size();
    if (n == 0) return 0;
    if (n == 1) return values[0];
    
    int prev2 = values[0];
    int prev1 = std::max(values[0], values[1]);
    
    for (int i = 2; i < n; i++) {
        int current = std::max(prev1, prev2 + values[i]);
        prev2 = prev1;
        prev1 = current;
    }
    
    return prev1;
}
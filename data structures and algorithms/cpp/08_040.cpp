#include <vector>

bool findClearanceCode(
    std::vector<std::vector<int>>& matrix, 
    int target
) {
    if (matrix.empty() || matrix[0].empty()) {
        return false;
    }
    
    int rows = matrix.size();
    int cols = matrix[0].size();
    int left = 0;
    int right = rows * cols - 1;
    
    while (left <= right) {
        int mid = left + (right - left) / 2;
        int row = mid / cols;
        int col = mid % cols;
        
        if (matrix[row][col] == target) {
            return true;
        } else if (matrix[row][col] < target) {
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }
    
    return false;
}
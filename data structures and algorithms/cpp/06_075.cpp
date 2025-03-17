#include <iostream>
#include <vector>
#include <string>

class QuickSelect {
public:
    /**
     * Finds the kth smallest element in an unordered array
     * @param arr Input vector of integers
     * @param k The k-th smallest element to find (0-based)
     * @return The k-th smallest element in the array
     */
    static int quickselect(std::vector<int>& arr, int k) {
        return select(arr, 0, arr.size() - 1, k);
    }
    
private:
    static int partition(std::vector<int>& arr, int left, 
                         int right, int pivotIndex) {
        int pivotValue = arr[pivotIndex];
        // Move pivot to end
        std::swap(arr[pivotIndex], arr[right]);
        
        int storeIndex = left;
        for (int i = left; i < right; i++) {
            if (arr[i] < pivotValue) {
                std::swap(arr[storeIndex], arr[i]);
                storeIndex++;
            }
        }
        
        // Move pivot to its final place
        std::swap(arr[right], arr[storeIndex]);
        return storeIndex;
    }
    
    static int select(std::vector<int>& arr, int left, int right, 
                     int k) {
        if (left == right) {
            return arr[left];
        }
        
        // Choose pivot (using middle element for simplicity)
        int pivotIndex = (left + right) / 2;
        pivotIndex = partition(arr, left, right, pivotIndex);
        
        if (k == pivotIndex) {
            return arr[k];
        } else if (k < pivotIndex) {
            return select(arr, left, pivotIndex - 1, k);
        } else {
            return select(arr, pivotIndex + 1, right, k);
        }
    }
    
    // Helper function to convert vector to string for display
    static std::string vectorToString(const std::vector<int>& arr) {
        std::string result = "[";
        for (size_t i = 0; i < arr.size(); i++) {
            result += std::to_string(arr[i]);
            if (i < arr.size() - 1) {
                result += ", ";
            }
        }
        result += "]";
        return result;
    }
};

int main() {
    std::vector<int> arr = {3, 2, 1, 5, 6, 4};
    int k = 2;  // Find 3rd smallest element (0-based index)
    
    std::cout << "Original array: " 
              << QuickSelect::vectorToString(arr) << std::endl;
    int result = QuickSelect::quickselect(arr, k);
    std::cout << "The " << k+1 << "th smallest element is: " 
              << result << std::endl;
    std::cout << "Note: Array may be partially sorted after "
              << "running quickselect: " 
              << QuickSelect::vectorToString(arr) << std::endl;
    
    return 0;
}
#include <iostream>
#include <vector>

void bubbleSort(std::vector<int>& arr) {
    int n = arr.size();
    
    for (int i = 0; i < n; i++) {
        bool swapped = false;
        
        for (int j = 0; j < n - i - 1; j++) {
            if (arr[j] > arr[j + 1]) {
                // Swap using std::swap
                std::swap(arr[j], arr[j + 1]);
                swapped = true;
            }
        }
        
        if (!swapped) {
            break;
        }
    }
}

int main() {
    std::vector<int> numbers = {23, 16, 6, 59, 3, 11, 37};
    
    std::cout << "Original array: ";
    for (int num : numbers) std::cout << num << " ";
    std::cout << std::endl;
    
    bubbleSort(numbers);
    
    std::cout << "Sorted array: ";
    for (int num : numbers) std::cout << num << " ";
    std::cout << std::endl;
    
    return 0;
}
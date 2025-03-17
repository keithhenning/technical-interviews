#include <iostream>
#include <vector>

void quickSort(std::vector<int>& arr, int low, int high) {
    if (low < high) {
        // Partition function
        auto partition = [&arr](int low, int high) {
            int pivot = arr[high];
            int i = low - 1;
            
            for (int j = low; j < high; j++) {
                if (arr[j] <= pivot) {
                    i++;
                    std::swap(arr[i], arr[j]);
                }
            }
            
            std::swap(arr[i + 1], arr[high]);
            return i + 1;
        };
        
        int pi = partition(low, high);
        
        quickSort(arr, low, pi - 1);
        quickSort(arr, pi + 1, high);
    }
}

int main() {
    std::vector<int> numbers = {23, 16, 6, 59, 3, 11, 37};
    
    std::cout << "Original array: ";
    for (int num : numbers) std::cout << num << " ";
    std::cout << std::endl;
    
    quickSort(numbers, 0, numbers.size() - 1);
    
    std::cout << "Sorted array: ";
    for (int num : numbers) std::cout << num << " ";
    std::cout << std::endl;
    
    return 0;
}
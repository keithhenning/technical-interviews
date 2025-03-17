#include <iostream>
#include <vector>

void insertionSort(std::vector<int>& arr) {
    int n = arr.size();
    
    for (int i = 1; i < n; i++) {
        int key = arr[i];
        int j = i - 1;
        
        while (j >= 0 && arr[j] > key) {
            arr[j + 1] = arr[j];
            j--;
        }
        
        arr[j + 1] = key;
    }
}

int main() {
    std::vector<int> numbers = {23, 16, 6, 59, 3, 11, 37};
    
    std::cout << "Original array: ";
    for (int num : numbers) std::cout << num << " ";
    std::cout << std::endl;
    
    insertionSort(numbers);
    
    std::cout << "Sorted array: ";
    for (int num : numbers) std::cout << num << " ";
    std::cout << std::endl;
    
    return 0;
}
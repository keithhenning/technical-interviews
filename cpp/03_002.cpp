#include <iostream>
#include <vector>

int binarySearch(const std::vector<int>& arr, int target) {
    int left = 0, right = arr.size() - 1;
    while (left <= right) {
        int mid = (left + right) / 2;
        if (arr[mid] == target) {
            return mid;
        } else if (arr[mid] < target) {
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }
    return -1;
}

int main() {
    std::vector<int> numbers = {1, 2, 3, 4, 5, 6, 7, 8, 
                               9, 10};
    int target = 7;
    int index = binarySearch(numbers, target);
    if (index != -1) {
        std::cout << "Element " << target << " found at index " 
                 << index << std::endl;
    } else {
        std::cout << "Element " << target 
                 << " not found in the list" << std::endl;
    }
    return 0;
}
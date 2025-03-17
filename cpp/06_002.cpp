#include <iostream>
#include <vector>

void merge(std::vector<int>& array, int left, int mid, 
           int right) {
    int n1 = mid - left + 1;
    int n2 = right - mid;
    std::vector<int> leftArr(n1), rightArr(n2);
    
    // Copy data to temporary arrays
    for (int i = 0; i < n1; i++) 
        leftArr[i] = array[left + i];
    for (int j = 0; j < n2; j++) 
        rightArr[j] = array[mid + 1 + j];
    
    int i = 0, j = 0, k = left;
    
    // Merge the temporary arrays back into the original array
    while (i < n1 && j < n2) {
        if (leftArr[i] <= rightArr[j]) {
            array[k++] = leftArr[i++];
        } else {
            array[k++] = rightArr[j++];
        }
    }
    
    // Copy remaining elements of leftArr
    while (i < n1) 
        array[k++] = leftArr[i++];
    
    // Copy remaining elements of rightArr
    while (j < n2) 
        array[k++] = rightArr[j++];
}

void mergeSort(std::vector<int>& array, int left, int right) {
    if (left < right) {
        int mid = left + (right - left) / 2;
        mergeSort(array, left, mid);
        mergeSort(array, mid + 1, right);
        merge(array, left, mid, right);
    }
}

int main() {
    std::vector<int> array = {23, 16, 6, 59, 3, 11, 37};
    mergeSort(array, 0, array.size() - 1);
    
    for (int num : array) {
        std::cout << num << " ";
    }
    std::cout << std::endl;
    
    return 0;
}
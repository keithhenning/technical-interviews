template <typename T>
void insertionSort(std::vector<T>& arr, int low, int high) {
    for (int i = low + 1; i <= high; i++) {
        T key = arr[i];
        int j = i - 1;
        
        // Move elements greater than key to one position ahead
        while (j >= low && arr[j] > key) {
            arr[j + 1] = arr[j];
            j--;
        }
        arr[j + 1] = key;
    }
}

// Usage in quicksort or other algorithm
template <typename T>
void sortHelper(std::vector<T>& arr, int low, int high) {
    if (low < high) {
        if (high - low <= 10) {
            // More efficient for small arrays
            insertionSort(arr, low, high);
        }
        else {
            // Continue with regular sorting algorithm
            // ...
        }
    }
}
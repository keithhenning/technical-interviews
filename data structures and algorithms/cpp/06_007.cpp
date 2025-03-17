template <typename T>
void insertion_sort(std::vector<T>& arr) {
    for (size_t i = 1; i < arr.size(); i++) {
        T key = arr[i];
        int j = i - 1;
        
        while (j >= 0 && arr[j] > key) {
            arr[j + 1] = arr[j];
            j--;
        }
        arr[j + 1] = key;
    }
}

template <typename T>
int partition(std::vector<T>& arr, int low, int high) {
    T pivot = arr[high];
    int i = low - 1;
    
    for (int j = low; j < high; j++) {
        if (arr[j] <= pivot) {
            i++;
            std::swap(arr[i], arr[j]);
        }
    }
    std::swap(arr[i + 1], arr[high]);
    return i + 1;
}

template <typename T>
void quick_sort_impl(std::vector<T>& arr, int low, int high) {
    if (low < high) {
        int pi = partition(arr, low, high);
        quick_sort_impl(arr, low, pi - 1);
        quick_sort_impl(arr, pi + 1, high);
    }
}

template <typename T>
void quick_sort(std::vector<T>& arr) {
    if (!arr.empty()) {
        quick_sort_impl(arr, 0, arr.size() - 1);
    }
}

template <typename T>
void smart_sort(std::vector<T>& arr) {
    if (arr.size() <= 10) {
        insertion_sort(arr);  // Use insertion sort for small arrays
    } else {
        quick_sort(arr);      // Switch to quicksort for larger ones
    }
}
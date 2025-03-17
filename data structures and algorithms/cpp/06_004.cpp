// Median-of-three pivot selection
template <typename T>
T median(const T& a, const T& b, const T& c) {
    if (a > b) {
        if (b > c) return b;      // a > b > c
        if (a > c) return c;      // a > c > b
        return a;                 // c > a > b
    } else {
        if (a > c) return a;      // b > a > c
        if (b > c) return c;      // b > c > a
        return b;                 // c > b > a
    }
}

template <typename T>
T choose_pivot(std::vector<T>& arr, int low, int high) {
    int mid = (low + high) / 2;
    return median(arr[low], arr[mid], arr[high]);
}
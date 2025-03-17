template <typename T>
void update_sorted_list(std::vector<T>& sorted_arr, 
    const T& new_item) {
    // When maintaining an already sorted list
    sorted_arr.push_back(new_item);
    int i = sorted_arr.size() - 1;
    
    while (i > 0 && sorted_arr[i-1] > sorted_arr[i]) {
        std::swap(sorted_arr[i], sorted_arr[i-1]);
        i--;
    }
}
#include <vector>
#include <algorithm>

void bucketSort(std::vector<float>& arr) {
    if (arr.empty()) return;
    
    int n = arr.size();
    std::vector<std::vector<float>> buckets(n);
    
    // Find range
    float maxVal = *std::max_element(arr.begin(), arr.end());
    float minVal = *std::min_element(arr.begin(), arr.end());
    
    // Distribute elements
    for (float num : arr) {
        int index = (num - minVal) * (n - 1) / (maxVal - minVal);
        buckets[index].push_back(num);
    }
    
    // Sort individual buckets
    for (auto& bucket : buckets) {
        std::sort(bucket.begin(), bucket.end());
    }
    
    // Concatenate results
    arr.clear();
    for (const auto& bucket : buckets) {
        arr.insert(arr.end(), bucket.begin(), bucket.end());
    }
}
#include <vector>
#include <string>
#include <unordered_map>
#include <queue>

std::vector<std::string> topKTrendingHashtags(
        std::vector<std::string>& hashtags, int k) {
    // Count frequencies
    std::unordered_map<std::string, int> counter;
    for (const std::string& tag : hashtags) {
        counter[tag]++;
    }
    
    // Use priority queue (min heap)
    auto compare = [&counter](const std::string& a, 
                             const std::string& b) {
        return counter[a] > counter[b];
    };
    
    std::priority_queue<std::string, std::vector<std::string>,
                        decltype(compare)> heap(compare);
    
    for (const auto& pair : counter) {
        heap.push(pair.first);
        if (heap.size() > k) {
            heap.pop();
        }
    }
    
    // Build result vector
    std::vector<std::string> result(k);
    for (int i = k - 1; i >= 0; i--) {
        if (!heap.empty()) {
            result[i] = heap.top();
            heap.pop();
        }
    }
    
    return result;
}
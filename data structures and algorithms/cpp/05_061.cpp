#include <unordered_map>
#include <algorithm>
#include <string>

template<typename K, typename V>
class Cache {
private:
    size_t capacity;
    std::unordered_map<K, V> cache;
    std::unordered_map<K, int> usage;
    
public:
    Cache(size_t capacity) : capacity(capacity) {}
    
    V* get(const K& key) {
        if (cache.find(key) != cache.end()) {
            usage[key]++;
            return &cache[key];
        }
        return nullptr;
    }
    
    void put(const K& key, const V& value) {
        if (cache.size() >= capacity && 
            cache.find(key) == cache.end()) {
            // Remove least used item
            K least_used = std::min_element(
                usage.begin(), 
                usage.end(),
                [](const auto& a, 
                   const auto& b) { 
                    return a.second < b.second; 
                }
            )->first;
            
            cache.erase(least_used);
            usage.erase(least_used);
        }
        
        cache[key] = value;
        usage[key] = 1;
    }
};
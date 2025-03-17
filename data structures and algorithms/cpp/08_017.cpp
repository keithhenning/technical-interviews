#include <unordered_map>
#include <chrono>
#include <limits>

template <typename K, typename V>
class IntelligentCache {
private:
    struct CacheItem {
        K key;
        V value;
        int frequency;
        std::chrono::time_point
            std::chrono::steady_clock> lastAccess;
        
        CacheItem(K key, V value) 
            : key(key), value(value), frequency(1), 
              lastAccess(std::chrono::steady_clock::now()) {}
        
        void access() {
            frequency++;
            lastAccess = std::chrono::steady_clock::now();
        }
        
        double getScore() const {
            // Higher frequency and recency = higher score
            auto now = std::chrono::steady_clock::now();
            auto duration = std::chrono::duration_cast
                std::chrono::milliseconds>(
                    now - lastAccess).count();
            double recencyScore = 1.0 / 
                (1.0 + duration / 1000.0);
            return frequency * recencyScore;
        }
    };
    
    int capacity;
    std::unordered_map<K, CacheItem> cache;
    
    void evict() {
        if (cache.empty()) {
            return;
        }
        
        double minScore = 
            std::numeric_limits<double>::infinity();
        K minKey;
        bool initialized = false;
        
        for (const auto& [key, item] : cache) {
            double score = item.getScore();
            if (!initialized || score < minScore) {
                minScore = score;
                minKey = key;
                initialized = true;
            }
        }
        
        if (initialized) {
            cache.erase(minKey);
        }
    }
    
public:
    IntelligentCache(int capacity) : capacity(capacity) {}
    
    V get(const K& key) {
        auto it = cache.find(key);
        if (it == cache.end()) {
            // Use V() as a default value/null equivalent
            return V();
        }
        
        // Update frequency and last access time
        it->second.access();
        return it->second.value;
    }
    
    void put(const K& key, const V& value) {
        // If key already exists, update value and access info
        auto it = cache.find(key);
        if (it != cache.end()) {
            it->second.value = value;
            it->second.access();
            return;
        }
        
        // If cache is full, evict least valuable item
        if (cache.size() >= 
            static_cast<size_t>(capacity)) {
            evict();
        }
        
        // Add new item
        cache.emplace(key, CacheItem(key, value));
    }
};
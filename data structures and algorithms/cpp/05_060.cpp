#include <unordered_map>

template<typename K, typename V>
class HashMap {
private:
    struct Node {
        K key;
        V value;
        Node* next;
        Node(K k, V v) : key(k), value(v), next(nullptr) {}
    };
    
    std::vector<Node*> buckets;
    size_t size;
    
    size_t hash_function(const K& key) const {
        return std::hash<K>{}(key) % buckets.size();
    }

public:
    HashMap(size_t capacity = 16) : buckets(capacity, nullptr), size(0) {}
    
    void insert(const K& key, const V& value) {
        size_t index = hash_function(key);
        Node* current = buckets[index];
        
        while (current) {
            if (current->key == key) {
                current->value = value;
                return;
            }
            current = current->next;
        }
        
        Node* new_node = new Node(key, value);
        new_node->next = buckets[index];
        buckets[index] = new_node;
        size++;
    }
    
    ~HashMap() {
        for (Node* bucket : buckets) {
            while (bucket) {
                Node* next = bucket->next;
                delete bucket;
                bucket = next;
            }
        }
    }
};
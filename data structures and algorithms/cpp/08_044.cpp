#include <unordered_map>
#include <map>
#include <string>

class ConfigStore {
private:
    std::unordered_map<std::string, std::map<int, std::string>> store;
    
public:
    ConfigStore() {}
    
    void set(std::string feature, int version, std::string value) {
        store[feature][version] = value;
    }
    
    std::string get(std::string feature, int version) {
        if (store.find(feature) == store.end()) {
            return "";
        }
        
        auto& versions = store[feature];
        auto it = versions.upper_bound(version);
        
        if (it == versions.begin()) {
            return "";
        }
        
        --it;
        return it->second;
    }
};
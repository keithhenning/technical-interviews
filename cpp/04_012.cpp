#include <memory>

class ConfigManager {
private:
    static std::shared_ptr<ConfigManager> instance;
    
    // Private constructor to prevent direct instantiation
    ConfigManager() {}
    
public:
    // Prevent copy and assignment
    ConfigManager(const ConfigManager&) = delete;
    ConfigManager& operator=(const ConfigManager&) = delete;
    
    static std::shared_ptr<ConfigManager> getInstance() {
        if (!instance) {
            instance = std::shared_ptr<ConfigManager>(
                new ConfigManager());
        }
        return instance;
    }
};

// Initialize static member
std::shared_ptr<ConfigManager> ConfigManager::instance = nullptr;
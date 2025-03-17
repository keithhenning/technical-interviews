#include <memory>

class NewSystem {
public:
    virtual ~NewSystem() = default;
    virtual void processData() = 0;
};

class OldSystem {
public:
    void processLegacyData() {
        // old logic
    }
};

class SystemAdapter : public NewSystem {
private:
    std::unique_ptr<OldSystem> oldSystem;
    
public:
    SystemAdapter(std::unique_ptr<OldSystem> system) 
        : oldSystem(std::move(system)) {}
    
    void processData() override {
        oldSystem->processLegacyData();
    }
};
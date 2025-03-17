#include <string>
#include <memory>

class Computer {
private:
    std::string cpu;
    std::string ram;
    
    // Private constructor only accessible by Builder
    Computer(const Builder& builder);
    
public:
    class Builder {
    private:
        std::string cpu;
        std::string ram;
        
    public:
        Builder& setCPU(const std::string& c) {
            cpu = c;
            return *this;
        }
        
        Builder& setRAM(const std::string& r) {
            ram = r;
            return *this;
        }
        
        Computer build() {
            return Computer(*this);
        }
        
        friend class Computer;
    };
};

Computer::Computer(const Builder& builder) : 
    cpu(builder.cpu), ram(builder.ram) {
    // Build computer with specifications
}
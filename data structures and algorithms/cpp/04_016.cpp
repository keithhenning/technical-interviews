#include <memory>

class Coffee {
public:
    virtual ~Coffee() = default;
    virtual double getCost() = 0;
};

class SimpleCoffee : public Coffee {
public:
    double getCost() override {
        return 1.0;
    }
};

class MilkDecorator : public Coffee {
private:
    std::unique_ptr<Coffee> coffee;
    
public:
    MilkDecorator(std::unique_ptr<Coffee> c) 
        : coffee(std::move(c)) {}
    
    double getCost() override {
        return coffee->getCost() + 0.5;
    }
};
#include <memory>

class PaymentStrategy {
public:
    virtual ~PaymentStrategy() = default;
    virtual void pay(int amount) = 0;
};

class CreditCardStrategy : public PaymentStrategy {
public:
    void pay(int amount) override {
        // Process credit card payment
    }
};
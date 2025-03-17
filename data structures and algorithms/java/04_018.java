public interface PaymentStrategy {
    void pay(int amount);
}

public class CreditCardStrategy implements PaymentStrategy {
    public void pay(int amount) {
        // Process credit card payment
    }
}
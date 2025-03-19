public interface IPaymentStrategy
{
    void Pay(int amount);
}

public class CreditCardStrategy : IPaymentStrategy
{
    public void Pay(int amount)
    {
        // Process credit card payment
    }
}

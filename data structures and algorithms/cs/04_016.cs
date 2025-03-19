public interface ICoffee
{
    double GetCost();
}

public class SimpleCoffee : ICoffee
{
    public double GetCost() { return 1.0; }
}

public class MilkDecorator : ICoffee
{
    private ICoffee coffee;

    public MilkDecorator(ICoffee coffee)
    {
        this.coffee = coffee;
    }

    public double GetCost()
    {
        return coffee.GetCost() + 0.5;
    }
}

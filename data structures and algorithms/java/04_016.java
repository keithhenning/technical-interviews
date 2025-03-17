public interface Coffee {
    double getCost();
}

public class SimpleCoffee implements Coffee {
    public double getCost() { return 1.0; }
}

public class MilkDecorator implements Coffee {
    private Coffee coffee;
    public double getCost() {
        return coffee.getCost() + 0.5;
    }
}
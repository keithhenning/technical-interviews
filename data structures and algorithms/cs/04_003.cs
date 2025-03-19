class Rectangle {
    protected int width;
    protected int height;

    public void SetWidth(int width) {
        this.width = width;
    }

    public void SetHeight(int height) {
        this.height = height;
    }

    public int GetArea() {
        return width * height;
    }
}

class Square : Rectangle {
    public new void SetWidth(int width) {
        this.width = width;
        this.height = width;
    }

    public new void SetHeight(int height) {
        this.height = height;
        this.width = height;
    }
}

public class LSPExample {
    public static void Main(string[] args) {
        Rectangle rectangle = new Rectangle();
        rectangle.SetWidth(5);
        rectangle.SetHeight(10);
        int rectangleArea = rectangle.GetArea();
        Console.WriteLine("Area of rectangle: " + rectangleArea);

        Square square = new Square();
        square.SetWidth(5);
        int squareArea = square.GetArea();
        Console.WriteLine("Area of square: " + squareArea);
    }
}

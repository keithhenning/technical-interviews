class Rectangle {
    protected int width;
    protected int height;
 
    public void setWidth(int width) {
        this.width = width;
    }
 
    public void setHeight(int height) {
        this.height = height;
    }
 
    public int getArea() {
        return width * height;
    }
}
 
class Square extends Rectangle {
    @Override
    public void setWidth(int width) {
        this.width = width;
        this.height = width;
    }
 
    @Override
    public void setHeight(int height) {
        this.height = height;
        this.width = height;
    }
}
 
public class LSPExample {
    public static void main(String[] args) {
        Rectangle rectangle = new Rectangle();
        rectangle.setWidth(5);
        rectangle.setHeight(10);
        int rectangleArea = rectangle.getArea();
        System.out.println("Area of rectangle: " + rectangleArea);
 
        Square square = new Square();
        square.setWidth(5);
        int squareArea = square.getArea();
        System.out.println("Area of square: " + squareArea);
    }
}
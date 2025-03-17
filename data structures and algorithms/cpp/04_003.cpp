#include <iostream>

class Rectangle {
protected:
    int width;
    int height;
 
public:
    Rectangle() : width(0), height(0) {}
    
    virtual void setWidth(int w) {
        width = w;
    }
 
    virtual void setHeight(int h) {
        height = h;
    }
 
    int getArea() {
        return width * height;
    }
};
 
class Square : public Rectangle {
public:
    void setWidth(int w) override {
        width = w;
        height = w;
    }
 
    void setHeight(int h) override {
        height = h;
        width = h;
    }
};
 
int main() {
    Rectangle rectangle;
    rectangle.setWidth(5);
    rectangle.setHeight(10);
    int rectangleArea = rectangle.getArea();
    std::cout << "Area of rectangle: " << rectangleArea 
             << std::endl;
 
    Square square;
    square.setWidth(5);
    int squareArea = square.getArea();
    std::cout << "Area of square: " << squareArea << std::endl;
    
    return 0;
}
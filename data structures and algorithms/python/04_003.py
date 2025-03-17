class Rectangle:
    def __init__(self):
        self.width = 0
        self.height = 0
    
    def set_width(self, width):
        self.width = width
    
    def set_height(self, height):
        self.height = height
    
    def get_area(self):
        return self.width * self.height

class Square(Rectangle):
    def set_width(self, width):
        self.width = width
        self.height = width
    
    def set_height(self, height):
        self.height = height
        self.width = height

def main():
    rectangle = Rectangle()
    rectangle.set_width(5)
    rectangle.set_height(10)
    rectangle_area = rectangle.get_area()
    print(f"Area of rectangle: {rectangle_area}")
    
    square = Square()
    square.set_width(5)
    square_area = square.get_area()
    print(f"Area of square: {square_area}")

if __name__ == "__main__":
    main()
from abc import ABC, abstractmethod

class Coffee(ABC):
    @abstractmethod
    def get_cost(self):
        pass

class SimpleCoffee(Coffee):
    def get_cost(self):
        return 1.0

class MilkDecorator(Coffee):
    def __init__(self, coffee):
        self.coffee = coffee
    
    def get_cost(self):
        return self.coffee.get_cost() + 0.5
from abc import ABC, abstractmethod

class PaymentStrategy(ABC):
    @abstractmethod
    def pay(self, amount):
        pass

class CreditCardStrategy(PaymentStrategy):
    def pay(self, amount):
        # Process credit card payment
        pass
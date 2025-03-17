from abc import ABC, abstractmethod

class NewSystem(ABC):
    @abstractmethod
    def process_data(self):
        pass

class OldSystem:
    def process_legacy_data(self):
        # old logic
        pass

class SystemAdapter(NewSystem):
    def __init__(self, old_system):
        self.old_system = old_system
    
    def process_data(self):
        self.old_system.process_legacy_data()
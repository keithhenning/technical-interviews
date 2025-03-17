class Computer:
    def __init__(self, builder):
        # Build computer with specifications
        self.cpu = builder.cpu
        self.ram = builder.ram

class ComputerBuilder:
    def __init__(self):
        self.cpu = None
        self.ram = None
    
    def set_cpu(self, cpu):
        self.cpu = cpu
        return self
    
    def set_ram(self, ram):
        self.ram = ram
        return self
    
    def build(self):
        return Computer(self)
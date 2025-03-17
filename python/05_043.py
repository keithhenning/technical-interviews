class FileSystemNode:
    def __init__(self, name, is_directory=False):
        self.name = name
        self.is_directory = is_directory
        self.children = [] if is_directory else None
        
    def add_child(self, child):
        if self.is_directory:
            self.children.append(child)
            
    def print_structure(self, level=0):
        indent = "  " * level
        print(f"{indent}{self.name}/")
        if self.is_directory:
            for child in self.children:
                child.print_structure(level + 1)
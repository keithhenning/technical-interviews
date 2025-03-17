# Basic usage
my_dict = {}
my_dict['name'] = 'Jane'
my_dict['age'] = 25

# Dictionary comprehension
square_map = {x: x*x for x in range(5)}

# Custom implementation for learning
class HashMap:
    def __init__(self, size=100):
        self.size = size
        self.map = [[] for _ in range(size)]
    
    def _get_hash(self, key):
        return hash(key) % self.size
    
    def put(self, key, value):
        key_hash = self._get_hash(key)
        key_value = [key, value]
        
        if not self.map[key_hash]:
            self.map[key_hash] = [key_value]
            return
        
        for pair in self.map[key_hash]:
            if pair[0] == key:
                pair[1] = value
                return
        self.map[key_hash].append(key_value)
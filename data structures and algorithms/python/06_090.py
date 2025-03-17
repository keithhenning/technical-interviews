def get_component(self, x):
  root = self.find(x)
  return [i for i in range(len(self.parent)) 
          if self.find(i) == root]
class ClothingItem:
  def __init__(self, type, popularity):
     self.type = type
     self.popularity = popularity

class FashionStack:
  def __init__(self):
     self.mainStack = []
     self.tempStack = []
  
  def addItem(self, type, popularity):
     self.mainStack.append(ClothingItem(type, popularity))
  
  def removeTopItem(self):
     if not self.mainStack:
        return None
     return self.mainStack.pop()
  
  def findAndRemoveType(self, targetType):
     if not self.mainStack:
        return None
     
     mostPopular = None
     mostPopularIndex = -1
     
     # Find most popular item of the target type
     for i in range(len(self.mainStack) - 1, -1, -1):
        if self.mainStack[i].type == targetType:
           if (mostPopular is None or 
               self.mainStack[i].popularity >                
                      mostPopular.popularity):
              mostPopular = self.mainStack[i]
              mostPopularIndex = i
     
     if mostPopularIndex == -1:
        return None
     
     # Move items to temp stack until reaching target item
     for _ in range(len(self.mainStack) - mostPopularIndex - 1):
        self.tempStack.append(self.mainStack.pop())
     
     # Remove the target item
     result = self.mainStack.pop()
     
     # Restore items from temp stack
     while self.tempStack:
        self.mainStack.append(self.tempStack.pop())
     
     return result
  
  def reorganizeByPopularity(self):
     if not self.mainStack:
        return
     
     # Move all items to temp stack
     while self.mainStack:
        self.tempStack.append(self.mainStack.pop())
     
     # Sort items by popularity and restore to main stack
     sortedItems = sorted(
        self.tempStack, 
        key=lambda x: x.popularity, 
        reverse=True
     )
     self.tempStack = []
     
     for item in sortedItems:
        self.mainStack.append(item)
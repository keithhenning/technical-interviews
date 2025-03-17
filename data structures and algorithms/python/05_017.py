class Stack:
  """
  Stack implementation using a list.
  """
  def __init__(self):
     # Initialize with empty list
     self.stack = []
  
  @property
  def length(self):
     # Return stack length as property
     return len(self.stack)
  
  def push(self, item):
     # Add item to top
     self.stack.append(item)
     return item  # For method chaining
  
  def pop(self):
     # Remove and return top item
     if not self.isEmpty():
        return self.stack.pop()
     return None  # Handle empty case
  
  def peek(self):
     # View top item without removing
     if not self.isEmpty():
        return self.stack[-1]
     return None
  
  def isEmpty(self):
     # Check if empty
     return self.length == 0

# Test implementation
if __name__ == "__main__":
  album = Stack()
  album.push("album 1")
  album.push("album 2")
  album.push("album 3")
  
  print(f"Top album is: {album.peek()}")  # album 3
  album.pop()  # Remove top
  print(f"Now the top album is: {album.peek()}")  # album 2
  print(f"Total albums in stack: {album.length}")  # 2
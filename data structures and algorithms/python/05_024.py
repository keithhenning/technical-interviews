class Node:
   """Node in a singly linked list."""
   def __init__(self, data):
      # Store data and next node reference
      self.data = data
      self.next = None

class LinkedList:
   """Singly linked list with head/tail tracking."""
   def __init__(self):
      # Initialize empty list
      self.head = None
      self.tail = None
      self.length = 0
   
   def push(self, data):
      """Add node to list end."""
      # Create new node
      new_node = Node(data)
      
      # Handle empty list
      if not self.head:
         self.head = new_node
         self.tail = new_node
      
      # Append to existing list
      else:
         self.tail.next = new_node
         self.tail = new_node
      
      # Update list metadata
      self.length += 1
      return self
   
   def display(self):
      """Print list contents."""
      # Traverse and print nodes
      current = self.head
      while current:
         print(current.data, end=" -> ")
         current = current.next
      print("None")

# Demonstrate linked list usage
if __name__ == "__main__":
   # Create and populate list
   list_demo = LinkedList()
   list_demo.push(1).push(2).push(3)
   list_demo.display()
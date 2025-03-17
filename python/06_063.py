class TrieNode:
   """
   A node in the Trie data structure.
   
   Each node contains a dictionary mapping characters to 
   child nodes and a flag for end of word.
   """
   def __init__(self):
      # Dictionary mapping characters to child nodes
      self.children = {}  
      # Flag to mark end of a word
      self.is_end = False  

class Trie:
   """
   A Trie (prefix tree) implementation for efficient word 
   storage and retrieval.
   """
   def __init__(self):
      # Initialize with empty root node
      self.root = TrieNode()
   
   def insert(self, word: str) -> None:
      """
      Insert a word into the trie.
      
      Args:
         word (str): The word to insert
      """
      # Start from the root node
      node = self.root
      
      # Traverse the trie character by character
      for char in word:
         # Create node if character doesn't exist
         if char not in node.children:
            node.children[char] = TrieNode()
         # Move to the child node
         node = node.children[char]
      
      # Mark the end of the word
      node.is_end = True
   
   def search(self, word: str) -> bool:
      """
      Search for a word in the trie.
      
      Args:
         word (str): The word to search for
         
      Returns:
         bool: True if word exists, False otherwise
      """
      # Start from the root node
      node = self.root
      
      # Traverse the trie character by character
      for char in word:
         # Word not in trie if character doesn't exist
         if char not in node.children:
            return False
         # Move to the child node
         node = node.children[char]
      
      # Check if this path forms a complete word
      return node.is_end
   
   def startsWith(self, prefix: str) -> bool:
      """
      Check if any word starts with the given prefix.
      
      Args:
         prefix (str): The prefix to check
         
      Returns:
         bool: True if prefix exists, False otherwise
      """
      # Start from the root node
      node = self.root
      
      # Traverse the trie character by character
      for char in prefix:
         # Prefix not in trie if character doesn't exist
         if char not in node.children:
            return False
         # Move to the child node
         node = node.children[char]
      
      # Return True if prefix path exists
      return True
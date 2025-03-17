class TrieNode:
   def __init__(self):
      self.children = {}
      self.is_end_of_word = False
      self.last_searched = -1  # Timestamp for history

class SearchSuggestionSystem:
   def __init__(self, dictionary=None):
      self.dictionary_trie = TrieNode()
      self.history_trie = TrieNode()
      self.search_count = 0  # Acts as timestamp for recency
      
      # Initialize with dictionary words if provided
      if dictionary:
         for word in dictionary:
            self.add_to_dictionary(word)
   
   def add_to_dictionary(self, word):
      node = self.dictionary_trie
      for char in word:
         if char not in node.children:
            node.children[char] = TrieNode()
         node = node.children[char]
      node.is_end_of_word = True
   
   def add_to_history(self, words):
      for word in words:
         self.search_count += 1
         node = self.history_trie
         for char in word:
            if char not in node.children:
               node.children[char] = TrieNode()
            node = node.children[char]
         node.is_end_of_word = True
         node.last_searched = self.search_count  # Update timestamp
         
         # Also ensure it's in the dictionary
         self.add_to_dictionary(word)
   
   def suggest(self, prefix):
      results = []
      
      # First, get all matching words from history
      history_matches = []
      self._collect_suggestions(
         self.history_trie, prefix, "", history_matches, True
      )
      
      # Then get all matching words from dictionary
      dict_matches = []
      self._collect_suggestions(
         self.dictionary_trie, prefix, "", dict_matches, False
      )
      
      # Combine results (history first, then dictionary,
      # without duplicates)
      seen = set()
      # Sort by recency (descending)
      for word, _ in sorted(
            history_matches, key=lambda x: -x[1]
      ):  
         if word not in seen:
            results.append(word)
            seen.add(word)
      
      for word in sorted(dict_matches):  # Sort alphabetically
         if word not in seen:
            results.append(word)
            seen.add(word)
      
      return results
   
   def _collect_suggestions(
         self, root, prefix, current_word, results, is_history
   ):
      node = root
      
      # Navigate to the node corresponding to the prefix
      for char in prefix:
         if char not in node.children:
            return  # Prefix not found
         node = node.children[char]
         current_word += char
      
      # DFS to collect all words with this prefix
      self._dfs_collect(node, current_word, results, is_history)
   
   def _dfs_collect(
         self, node, current_word, results, is_history
   ):
      if node.is_end_of_word:
         if is_history:
            results.append((current_word, node.last_searched))
         else:
            results.append(current_word)
      
      # Sort alphabetically
      for char, child_node in sorted(node.children.items()):
         self._dfs_collect(
            child_node, current_word + char, results, is_history
         )
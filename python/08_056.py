class TrieNode:

    def __init__(self):
        self.children = {}
        self.is_end_of_word = False

class FuzzyWordFinder:
    def __init__(self, dictionary):
        self.root = TrieNode()
        
        # Build the trie from the dictionary
        for word in dictionary:
            self.insert(word)
    
    def insert(self, word):
        node = self.root
        for char in word:
            if char not in node.children:
                node.children[char] = TrieNode()
            node = node.children[char]
        node.is_end_of_word = True
    
    def search(self, query, k):
        # Store results as (word, substitutions) pairs
        results = []
        
        def dfs(node, index, current_word, substitutions):
            # Base case: reached the end of the query
            if index == len(query):
                if node.is_end_of_word:
                    results.append((current_word, substitutions))
                return
            
            # Process current character
            current_char = query[index]
            
            # Try all possible paths in the trie
            for next_char, next_node in node.children.items():
                # Exact match - no substitution needed
                if next_char == current_char:
                    dfs(
                        next_node, 
                        index + 1, 
                        current_word + next_char, 
                        substitutions
                    )
                # Substitution needed
                elif substitutions < k:
                    dfs(
                        next_node, 
                        index + 1, 
                        current_word + next_char, 
                        substitutions + 1
                    )
        
        dfs(self.root, 0, "", 0)
        
        # Sort by substitutions, then alphabetically
        results.sort(key=lambda x: (x[1], x[0]))
        return [word for word, _ in results]
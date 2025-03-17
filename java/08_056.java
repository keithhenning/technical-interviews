import java.util.*;
import java.util.stream.Collectors;

public class FuzzyWordFinder {
   private final TrieNode root;

   // Nested TrieNode class
   private static class TrieNode {
      Map<Character, TrieNode> children;
      boolean isEndOfWord;
      
      TrieNode() {
         children = new HashMap<>();
         isEndOfWord = false;
      }
   }

   // Constructor builds trie from dictionary
   public FuzzyWordFinder(List<String> dictionary) {
      root = new TrieNode();
      dictionary.forEach(this::insert);
   }
   
   // Insert word into trie
   private void insert(String word) {
      TrieNode node = root;
      for (char c : word.toCharArray()) {
         // Add character if not exists
         node.children.putIfAbsent(c, 
            new TrieNode());
         node = node.children.get(c);
      }
      node.isEndOfWord = true;
   }
   
   // Search with fuzzy matching
   public List<String> search(String query, 
         int k) {
      List<Result> matches = new ArrayList<>();
      dfs(root, query, 0, new StringBuilder(), 
          0, matches, k);
      
      // Sort matches by substitutions
      Collections.sort(matches, (a, b) -> 
         a.substitutions != b.substitutions ? 
            Integer.compare(a.substitutions, 
               b.substitutions) : 
            a.word.compareTo(b.word)
      );
      
      // Extract matched words
      return matches.stream()
         .map(r -> r.word)
         .collect(Collectors.toList());
   }
   
   // Depth-first search for fuzzy matches
   private void dfs(TrieNode node, String query, 
         int index, StringBuilder currentWord, 
         int substitutions, List<Result> results, 
         int k) {
      // Base case: end of query
      if (index == query.length()) {
         if (node.isEndOfWord) {
            results.add(new Result(
               currentWord.toString(), 
               substitutions));
         }
         return;
      }
      
      char currentChar = query.charAt(index);
      
      // Explore trie paths
      for (Map.Entry<Character, TrieNode> entry : 
            node.children.entrySet()) {
         char nextChar = entry.getKey();
         TrieNode nextNode = entry.getValue();
         
         // Exact match
         if (nextChar == currentChar) {
            currentWord.append(nextChar);
            dfs(nextNode, query, index + 1, 
                currentWord, substitutions, 
                results, k);
            // Backtrack
            currentWord.deleteCharAt(
               currentWord.length() - 1);
         }
         // Substitution allowed
         else if (substitutions < k) {
            currentWord.append(nextChar);
            dfs(nextNode, query, index + 1, 
                currentWord, substitutions + 1, 
                results, k);
            // Backtrack
            currentWord.deleteCharAt(
               currentWord.length() - 1);
         }
      }
   }
   
   // Result container
   private static class Result {
      String word;
      int substitutions;
      
      Result(String word, int substitutions) {
         this.word = word;
         this.substitutions = substitutions;
      }
   }
}
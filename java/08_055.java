import java.util.*;

/**
 * Trie node for storing words
 */
class TrieNode {
   Map<Character, TrieNode> children;
   boolean isEndOfWord;
   int lastSearched;  // Timestamp for history
   
   public TrieNode() {
      children = new HashMap<>();
      isEndOfWord = false;
      lastSearched = -1;
   }
}

/**
 * Search suggestion system with history and dictionary support
 */
public class SearchSuggestionSystem {
   private TrieNode dictionaryTrie;
   private TrieNode historyTrie;
   private int searchCount;  // Timestamp for recency
   
   /**
    * Initialize with dictionary words
    */
   public SearchSuggestionSystem(List<String> dictionary) {
      dictionaryTrie = new TrieNode();
      historyTrie = new TrieNode();
      searchCount = 0;
      
      // Add dictionary words
      if (dictionary != null) {
         for (String word : dictionary) {
            addToDictionary(word);
         }
      }
   }
   
   /**
    * Add a word to the dictionary
    */
   public void addToDictionary(String word) {
      TrieNode node = dictionaryTrie;
      for (char c : word.toCharArray()) {
         node.children.putIfAbsent(c, new TrieNode());
         node = node.children.get(c);
      }
      node.isEndOfWord = true;
   }
   
   /**
    * Add words to search history
    */
   public void addToHistory(List<String> words) {
      for (String word : words) {
         searchCount++;
         TrieNode node = historyTrie;
         for (char c : word.toCharArray()) {
            node.children.putIfAbsent(c, new TrieNode());
            node = node.children.get(c);
         }
         node.isEndOfWord = true;
         node.lastSearched = searchCount;  // Update timestamp
         
         // Ensure word is in dictionary too
         addToDictionary(word);
      }
   }
   
   /**
    * Suggest words based on prefix
    */
   public List<String> suggest(String prefix) {
      List<String> results = new ArrayList<>();
      
      // Get matching words from history
      List<Pair<String, Integer>> historyMatches = 
            new ArrayList<>();
      collectSuggestions(historyTrie, prefix, 
            new StringBuilder(), historyMatches, true);
      
      // Get matching words from dictionary
      List<String> dictMatches = new ArrayList<>();
      collectSuggestions(dictionaryTrie, prefix, 
            new StringBuilder(), dictMatches, false);
      
      // Track seen words to avoid duplicates
      Set<String> seen = new HashSet<>();
      
      // Sort history matches by recency (newest first)
      historyMatches.sort((a, b) -> 
            Integer.compare(b.getValue(), a.getValue()));
      for (Pair<String, Integer> pair : historyMatches) {
         String word = pair.getKey();
         if (!seen.contains(word)) {
            results.add(word);
            seen.add(word);
         }
      }
      
      // Add dictionary matches alphabetically
      Collections.sort(dictMatches);
      for (String word : dictMatches) {
         if (!seen.contains(word)) {
            results.add(word);
            seen.add(word);
         }
      }
      
      return results;
   }
   
   /**
    * Navigate to prefix node and collect suggestions
    */
   private void collectSuggestions(TrieNode root, String prefix, 
         StringBuilder currentWord, List<?> results, 
         boolean isHistory) {
      TrieNode node = root;
      
      // Navigate to prefix node
      for (char c : prefix.toCharArray()) {
         if (!node.children.containsKey(c)) {
            return;  // Prefix not found
         }
         node = node.children.get(c);
         currentWord.append(c);
      }
      
      // DFS to collect all words with this prefix
      dfsCollect(node, new StringBuilder(currentWord), 
            results, isHistory);
   }
   
   /**
    * DFS to collect words with given prefix
    */
   @SuppressWarnings("unchecked")
   private void dfsCollect(TrieNode node, StringBuilder currentWord, 
         List<?> results, boolean isHistory) {
      if (node.isEndOfWord) {
         if (isHistory) {
            ((List<Pair<String, Integer>>) results).add(
               new Pair<>(currentWord.toString(), 
                     node.lastSearched));
         } else {
            ((List<String>) results).add(currentWord.toString());
         }
      }
      
      // Process children in alphabetical order
      List<Character> sortedChars = 
         new ArrayList<>(node.children.keySet());
      Collections.sort(sortedChars);
      
      for (char c : sortedChars) {
         currentWord.append(c);
         dfsCollect(node.children.get(c), currentWord, 
               results, isHistory);
         // Backtrack
         currentWord.deleteCharAt(currentWord.length() - 1);
      }
   }
   
   /**
    * Helper class for key-value pairs
    */
   static class Pair<K, V> {
      private K key;
      private V value;
      
      public Pair(K key, V value) {
         this.key = key;
         this.value = value;
      }
      
      public K getKey() { return key; }
      public V getValue() { return value; }
   }
}
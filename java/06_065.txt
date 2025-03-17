class TrieNode {
   // Map from character to TrieNode
   Map<Character, TrieNode> children;
   boolean isEnd;
   
   public TrieNode() {
       this.children = new HashMap<>();
       this.isEnd = false;
   }
}

class Trie {
   private TrieNode root;
   
   public Trie() {
       this.root = new TrieNode();
   }
   
   // Your implementation
   public void insert(String word) {
       
   }
   
   // Your implementation  
   public boolean search(String word) {
       
   }
   
   // Your implementation
   public boolean startsWith(String prefix) {
       
   }
}
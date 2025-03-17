// Creating a trie and inserting words
Trie trie = new Trie();
trie.insert("apple");
trie.insert("app");
trie.insert("apricot");
System.out.println(trie.search("apple"));    // true
System.out.println(trie.search("app"));      // true
System.out.println(trie.search("appl"));     // false
System.out.println(trie.startsWith("app"));  // true
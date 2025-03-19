// Creating a trie and inserting words
Trie trie = new Trie();
trie.Insert("apple");
trie.Insert("app");
trie.Insert("apricot");
Console.WriteLine(trie.Search("apple"));    // true
Console.WriteLine(trie.Search("app"));      // true
Console.WriteLine(trie.Search("appl"));     // false
Console.WriteLine(trie.StartsWith("app"));  // true
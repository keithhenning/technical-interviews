int main() {
    // Creating a trie and inserting words
    Trie trie;
    trie.insert("apple");
    trie.insert("app");
    trie.insert("apricot");
    std::cout << std::boolalpha;
    std::cout << trie.search("apple") << std::endl;    // true
    std::cout << trie.search("app") << std::endl;      // true
    std::cout << trie.search("appl") << std::endl;     // false
    std::cout << trie.startsWith("app") << std::endl;  // true
    
    return 0;
}
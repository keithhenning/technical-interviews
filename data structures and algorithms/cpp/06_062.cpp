#include <iostream>
#include <string>
#include <vector>

class TrieNode {
public:
    std::vector<TrieNode*> children;
    bool isEndOfWord;
    
    TrieNode() {
        children = std::vector<TrieNode*>(26, nullptr);
        isEndOfWord = false;
    }
};

class Trie {
private:
    TrieNode* root;
    
public:
    Trie() {
        root = new TrieNode();
    }
    
    void insert(std::string word) {
        TrieNode* current = root;
        
        for (char c : word) {
            int index = c - 'a';
            if (current->children[index] == nullptr) {
                current->children[index] = new TrieNode();
            }
            current = current->children[index];
        }
        
        current->isEndOfWord = true;
    }
    
    bool search(std::string word) {
        TrieNode* node = searchPrefix(word);
        return node != nullptr && node->isEndOfWord;
    }
    
    bool startsWith(std::string prefix) {
        return searchPrefix(prefix) != nullptr;
    }
    
private:
    TrieNode* searchPrefix(std::string prefix) {
        TrieNode* current = root;
        
        for (char c : prefix) {
            int index = c - 'a';
            if (current->children[index] == nullptr) {
                return nullptr;
            }
            current = current->children[index];
        }
        
        return current;
    }
};
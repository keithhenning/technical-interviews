#include <unordered_map>
#include <vector>
#include <string>
#include <algorithm>

struct TrieNode {
    std::unordered_map<char, TrieNode*> children;
    bool isEndOfWord;
    
    TrieNode() : isEndOfWord(false) {}
    
    ~TrieNode() {
        for (auto& pair : children) {
            delete pair.second;
        }
    }
};

class FuzzyWordFinder {
private:
    TrieNode* root;
    
    void dfs(TrieNode* node, const std::string& query, 
            int index, std::string currentWord,
            int substitutions, 
            std::vector<std::pair<std::string, int>>& results, 
            int k) {
        // Base case: reached the end of the query
        if (index == query.length()) {
            if (node->isEndOfWord) {
                results.push_back({currentWord, substitutions});
            }
            return;
        }
        
        // Process current character
        char currentChar = query[index];
        
        // Try all possible paths in the trie
        for (const auto& entry : node->children) {
            char nextChar = entry.first;
            TrieNode* nextNode = entry.second;
            
            // Exact match - no substitution needed
            if (nextChar == currentChar) {
                dfs(nextNode, query, index + 1, 
                    currentWord + nextChar, substitutions, 
                    results, k);
            }
            // Substitution needed
            else if (substitutions < k) {
                dfs(nextNode, query, index + 1, 
                    currentWord + nextChar, substitutions + 1, 
                    results, k);
            }
        }
    }
    
public:
    FuzzyWordFinder(const std::vector<std::string>& dictionary)
            : root(new TrieNode()) {
        // Build the trie from the dictionary
        for (const std::string& word : dictionary) {
            insert(word);
        }
    }
    
    ~FuzzyWordFinder() {
        delete root;
    }
    
    void insert(const std::string& word) {
        TrieNode* node = root;
        for (char c : word) {
            if (node->children.find(c) == 
                    node->children.end()) {
                node->children[c] = new TrieNode();
            }
            node = node->children[c];
        }
        node->isEndOfWord = true;
    }
    
    std::vector<std::string> search(const std::string& query, 
            int k) {
        // Store results as pairs of (word, substitutions)
        std::vector<std::pair<std::string, int>> matches;
        
        dfs(root, query, 0, "", 0, matches, k);
        
        // Sort by substitutions, then alphabetically
        std::sort(matches.begin(), matches.end(), 
                [](const std::pair<std::string, int>& a, 
                   const std::pair<std::string, int>& b) {
                    if (a.second != b.second) {
                        return a.second < b.second;
                    }
                    return a.first < b.first;
                });
        
        // Extract just the words
        std::vector<std::string> results;
        for (const auto& match : matches) {
            results.push_back(match.first);
        }
        
        return results;
    }
};
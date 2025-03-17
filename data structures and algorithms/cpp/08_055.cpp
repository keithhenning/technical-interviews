#include <unordered_map>
#include <vector>
#include <string>
#include <set>
#include <algorithm>

struct TrieNode {
    std::unordered_map<char, TrieNode*> children;
    bool isEndOfWord;
    int lastSearched;  // Timestamp for history
    
    TrieNode() : isEndOfWord(false), lastSearched(-1) {}
    
    ~TrieNode() {
        for (auto& pair : children) {
            delete pair.second;
        }
    }
};

class SearchSuggestionSystem {
private:
    TrieNode* dictionaryTrie;
    TrieNode* historyTrie;
    int searchCount;  // Acts as a timestamp for recency
    
    void collectSuggestions(
            TrieNode* root, 
            const std::string& prefix, 
            std::string currentWord,
            std::vector<std::pair<std::string, int>>& histResults,
            std::vector<std::string>& dictResults, 
            bool isHistory) {
        TrieNode* node = root;
        
        // Navigate to the node corresponding to the prefix
        for (char c : prefix) {
            if (node->children.find(c) == 
                node->children.end()) {
                return;  // Prefix not found
            }
            node = node->children[c];
            currentWord += c;
        }
        
        // DFS to collect all words with this prefix
        dfsCollect(node, currentWord, histResults, 
                  dictResults, isHistory);
    }
    
    void dfsCollect(
            TrieNode* node, 
            std::string currentWord,
            std::vector<std::pair<std::string, int>>& histResults,
            std::vector<std::string>& dictResults, 
            bool isHistory) {
        if (node->isEndOfWord) {
            if (isHistory) {
                histResults.push_back(
                    {currentWord, node->lastSearched});
            } else {
                dictResults.push_back(currentWord);
            }
        }
        
        // Process children in alphabetical order
        std::vector<char> sortedChars;
        for (const auto& pair : node->children) {
            sortedChars.push_back(pair.first);
        }
        std::sort(sortedChars.begin(), sortedChars.end());
        
        for (char c : sortedChars) {
            dfsCollect(node->children[c], currentWord + c, 
                      histResults, dictResults, isHistory);
        }
    }
    
public:
    SearchSuggestionSystem(
            const std::vector<std::string>& dictionary = {}) 
        : dictionaryTrie(new TrieNode()), 
          historyTrie(new TrieNode()), 
          searchCount(0) {
        
        // Initialize with dictionary words if provided
        for (const std::string& word : dictionary) {
            addToDictionary(word);
        }
    }
    
    ~SearchSuggestionSystem() {
        delete dictionaryTrie;
        delete historyTrie;
    }
    
    void addToDictionary(const std::string& word) {
        TrieNode* node = dictionaryTrie;
        for (char c : word) {
            if (node->children.find(c) == 
                node->children.end()) {
                node->children[c] = new TrieNode();
            }
            node = node->children[c];
        }
        node->isEndOfWord = true;
    }
    
    void addToHistory(const std::vector<std::string>& words) {
        for (const std::string& word : words) {
            searchCount++;
            TrieNode* node = historyTrie;
            for (char c : word) {
                if (node->children.find(c) == 
                    node->children.end()) {
                    node->children[c] = new TrieNode();
                }
                node = node->children[c];
            }
            node->isEndOfWord = true;
            node->lastSearched = searchCount;  // Update timestamp
            
            // Also ensure it's in the dictionary
            addToDictionary(word);
        }
    }
    
    std::vector<std::string> suggest(
            const std::string& prefix) {
        std::vector<std::string> results;
        
        // First, get all matching words from history
        std::vector<std::pair<std::string, int>> histMatches;
        std::vector<std::string> dictMatches;
        
        collectSuggestions(historyTrie, prefix, "", 
                          histMatches, dictMatches, true);
        collectSuggestions(dictionaryTrie, prefix, "", 
                          histMatches, dictMatches, false);
        
        // Combine results (history first, then dictionary)
        std::set<std::string> seen;
        
        // Sort history matches by recency (descending)
        std::sort(histMatches.begin(), histMatches.end(),
                 [](const std::pair<std::string, int>& a, 
                    const std::pair<std::string, int>& b) {
                     return a.second > b.second;
                 });
        
        for (const auto& pair : histMatches) {
            const std::string& word = pair.first;
            if (seen.find(word) == seen.end()) {
                results.push_back(word);
                seen.insert(word);
            }
        }
        
        // Sort dictionary matches alphabetically
        std::sort(dictMatches.begin(), dictMatches.end());
        
        for (const std::string& word : dictMatches) {
            if (seen.find(word) == seen.end()) {
                results.push_back(word);
                seen.insert(word);
            }
        }
        
        return results;
    }
};
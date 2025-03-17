#include <vector>
#include <string>
#include <unordered_map>
#include <algorithm>

std::vector<std::vector<std::string>> groupWordPatterns(std::vector<std::string>& words) {
    std::unordered_map<std::string, std::vector<std::string>> groups;
    
    for (const std::string& word : words) {
        // Generate key by sorting characters
        std::string key = word;
        std::sort(key.begin(), key.end());
        
        // Add word to its group
        groups[key].push_back(word);
    }
    
    // Return lists of grouped words
    std::vector<std::vector<std::string>> result;
    for (const auto& pair : groups) {
        result.push_back(pair.second);
    }
    
    return result;
}
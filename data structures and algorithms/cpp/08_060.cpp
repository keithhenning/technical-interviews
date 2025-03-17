#include <vector>
#include <string>
#include <unordered_map>
using namespace std;

class Solution {
public:
    // Group anagrams based on character frequency
    vector<vector<string>> groupAnagramsByFrequency(
            vector<string>& strs) {
        // Map to store groups of anagrams
        unordered_map<string, vector<string>> groups;
        // Result vector to return
        vector<vector<string>> result;
        
        for (string& s : strs) {
            // Create frequency counter for each string
            vector<int> freq(26, 0);
            for (char c : s) {
                freq[c - 'a']++;
            }
            
            // Convert frequency array to string for map key
            string key = "";
            for (int i = 0; i < 26; i++) {
                key += '#' + to_string(freq[i]);
            }
            
            // Create new entry if key doesn't exist
            if (groups.find(key) == groups.end()) {
                groups[key] = vector<string>();
                result.push_back(vector<string>());
                // Track order of appearance
                result.back() = groups[key];
            }
            // Add string to its group
            groups[key].push_back(s);
        }
        
        return result;
    }
};
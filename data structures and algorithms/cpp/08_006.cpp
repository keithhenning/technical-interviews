#include <string>
#include <unordered_map>
using namespace std;

class Solution {
public:
    string optimalDocumentSegment(string document, string tokens) {
        if (document.empty() || tokens.empty()) {
            return "";
        }
        
        // Count frequencies of tokens
        unordered_map<char, int> tokenCount;
        for (char c : tokens) {
            tokenCount[c]++;
        }
        
        // Initialize variables
        unordered_map<char, int> windowCount;
        int requiredTokens = tokenCount.size();
        int formed = 0;
        
        // Result tracking
        int minLen = INT_MAX;
        int resultStart = 0;
        
        // Window pointers
        int left = 0, right = 0;
        
        // Expand window
        while (right < document.length()) {
            // Add right character to window
            char c = document[right];
            windowCount[c]++;
            
            // Check if this character satisfies a token requirement
            if (tokenCount.count(c) && 
                windowCount[c] == tokenCount[c]) {
                formed++;
            }
            
            // Try to contract window from left
            while (left <= right && formed == requiredTokens) {
                c = document[left];
                
                // Update result if current window is smaller
                if (right - left + 1 < minLen) {
                    minLen = right - left + 1;
                    resultStart = left;
                }
                
                // Remove left character from window
                windowCount[c]--;
                
                // Removing this character breaks requirement?
                if (tokenCount.count(c) && 
                    windowCount[c] < tokenCount[c]) {
                    formed--;
                }
                
                left++;
            }
            
            right++;
        }
        
        return minLen == INT_MAX ? "" : 
               document.substr(resultStart, minLen);
    }
};
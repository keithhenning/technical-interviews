using System.Collections.Generic;

public class Solution {
    public string OptimalDocumentSegment(string document, string tokens) {
        if (string.IsNullOrEmpty(document) || string.IsNullOrEmpty(tokens)) {
            return "";
        }
        
        // Count frequencies of tokens
        Dictionary<char, int> tokenCount = new Dictionary<char, int>();
        foreach (char c in tokens) {
            if (tokenCount.ContainsKey(c)) {
                tokenCount[c]++;
            } else {
                tokenCount[c] = 1;
            }
        }
        
        // Initialize variables
        Dictionary<char, int> windowCount = new Dictionary<char, int>();
        int requiredTokens = tokenCount.Count;
        int formed = 0;
        
        // Result tracking
        int minLen = int.MaxValue;
        int resultStart = 0;
        
        // Window pointers
        int left = 0, right = 0;
        
        // Expand window
        while (right < document.Length) {
            // Add right character to window
            char c = document[right];
            if (windowCount.ContainsKey(c)) {
                windowCount[c]++;
            } else {
                windowCount[c] = 1;
            }
            
            // Check if this character satisfies a token requirement
            if (tokenCount.ContainsKey(c) && windowCount[c] == tokenCount[c]) {
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
                
                // Check if removing this character breaks a token requirement
                if (tokenCount.ContainsKey(c) && windowCount[c] < tokenCount[c]) {
                    formed--;
                }
                
                left++;
            }
            
            right++;
        }
        
        return minLen == int.MaxValue ? "" : document.Substring(resultStart, minLen);
    }
}
import java.util.HashMap;
import java.util.Map;

public class Solution {
    public String optimalDocumentSegment(String document, 
                                        String tokens) {
        if (document == null || tokens == null || 
            document.isEmpty() || tokens.isEmpty()) {
            return "";
        }
        
        // Count frequencies of tokens
        Map<Character, Integer> tokenCount = new HashMap<>();
        for (char c : tokens.toCharArray()) {
            tokenCount.put(c, tokenCount.getOrDefault(c, 0) + 1);
        }
        
        // Initialize variables
        Map<Character, Integer> windowCount = new HashMap<>();
        int requiredTokens = tokenCount.size();
        int formed = 0;
        
        // Result tracking
        int minLen = Integer.MAX_VALUE;
        int resultStart = 0;
        
        // Window pointers
        int left = 0, right = 0;
        
        // Expand window
        while (right < document.length()) {
            // Add right character to window
            char c = document.charAt(right);
            windowCount.put(c, windowCount.getOrDefault(c, 0) + 1);
            
            // Check if this character satisfies a token requirement
            if (tokenCount.containsKey(c) && 
                windowCount.get(c).intValue() == 
                tokenCount.get(c).intValue()) {
                formed++;
            }
            
            // Try to contract window from left
            while (left <= right && formed == requiredTokens) {
                c = document.charAt(left);
                
                // Update result if current window is smaller
                if (right - left + 1 < minLen) {
                    minLen = right - left + 1;
                    resultStart = left;
                }
                
                // Remove left character from window
                windowCount.put(c, windowCount.get(c) - 1);
                
                // Check if removing this character breaks a token 
                // requirement
                if (tokenCount.containsKey(c) && 
                    windowCount.get(c) < tokenCount.get(c)) {
                    formed--;
                }
                
                left++;
            }
            
            right++;
        }
        
        return minLen == Integer.MAX_VALUE ? "" : 
            document.substring(resultStart, resultStart + minLen);
    }
}
#include <iostream>
#include <string>

std::string longestPalindrome(std::string s) {
    if (s.empty()) return "";
    
    int start = 0;
    int max_length = 1;
    
    // Helper function to expand around center
    auto expandAroundCenter = [&](int left, int right) {
        while (left >= 0 && right < s.size() && 
               s[left] == s[right]) {
            int current_length = right - left + 1;
            if (current_length > max_length) {
                max_length = current_length;
                start = left;
            }
            left--;
            right++;
        }
    };
    
    // Check each position as potential center
    for (int i = 0; i < s.size(); i++) {
        // Odd length palindromes (like "aba")
        expandAroundCenter(i, i);
        // Even length palindromes (like "abba")
        expandAroundCenter(i, i + 1);
    }
    
    return s.substr(start, max_length);
}

int main() {
    std::cout << longestPalindrome("babad") << std::endl;  
                                            // "bab" or "aba"
    std::cout << longestPalindrome("cbbd") << std::endl;   
                                            // "bb"
    return 0;
}
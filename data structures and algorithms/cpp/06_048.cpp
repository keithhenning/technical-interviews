bool isPalindrome(const std::string& s) {
    int left = 0;
    int right = s.length() - 1;
    
    while (left < right) {
        // Skip non-alphanumeric characters
        while (left < right && !std::isalnum(s[left])) {
            left++;
        }
        while (left < right && !std::isalnum(s[right])) {
            right--;
        }
        
        if (std::tolower(s[left]) != std::tolower(s[right])) {
            return false;
        }
        
        left++;
        right--;
    }
    
    return true;
}
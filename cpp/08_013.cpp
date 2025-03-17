#include <iostream>
#include <string>
#include <unordered_map>

int firstUniqChar(std::string s) {
    std::unordered_map<char, int> charCount;
    
    // Count the occurrences of each character
    for (char c : s) {
        charCount[c]++;
    }
    
    // Find the first character with count 1
    for (int i = 0; i < s.length(); i++) {
        if (charCount[s[i]] == 1) {
            return i;
        }
    }
    
    return -1;  // No unique character found
}

int main() {
    std::cout << firstUniqChar("apples") << std::endl;      // 0
    std::cout << firstUniqChar("loveapples") << std::endl;  // 1
    std::cout << firstUniqChar("aabb") << std::endl;        // -1
    return 0;
}
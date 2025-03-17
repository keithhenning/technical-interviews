#include <string>
#include <unordered_map>

bool hasSamePattern(std::string str1, std::string str2) {
    if (str1.length() != str2.length()) {
        return false;
    }
    
    std::unordered_map<char, char> map1;
    std::unordered_map<char, char> map2;
    
    for (int i = 0; i < str1.length(); i++) {
        char c1 = str1[i];
        char c2 = str2[i];
        
        // Check mapping from str1 to str2
        if (map1.find(c1) != map1.end()) {
            if (map1[c1] != c2) {
                return false;
            }
        } else {
            map1[c1] = c2;
        }
        
        // Check mapping from str2 to str1
        if (map2.find(c2) != map2.end()) {
            if (map2[c2] != c1) {
                return false;
            }
        } else {
            map2[c2] = c1;
        }
    }
    
    return true;
}
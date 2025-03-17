#include <iostream>
#include <vector>
#include <string>

std::vector<std::string> get_permutations(
        const std::string& str) {
    // Base case
    if (str.length() <= 1) {
        return {str};
    }
    
    // Recursive case
    std::vector<std::string> perms;
    for (size_t i = 0; i < str.length(); i++) {
        char ch = str[i];
        std::string remaining = str.substr(0, i) 
                              + str.substr(i + 1);
        
        for (const std::string& p : get_permutations(remaining)) {
            perms.push_back(ch + p);
        }
    }
    
    return perms;
}

// Example usage
int main() {
    std::vector<std::string> result = get_permutations("abc");
    for (const std::string& perm : result) {
        std::cout << perm << " ";
    }
    std::cout << std::endl;  // Outputs: abc acb bac bca cab cba
    
    return 0;
}
import java.util.HashMap;
import java.util.Map;

public boolean hasSamePattern(String str1, String str2) {
    if (str1.length() != str2.length()) {
        return false;
    }
    
    Map<Character, Character> map1 = new HashMap<>();
    Map<Character, Character> map2 = new HashMap<>();
    
    for (int i = 0; i < str1.length(); i++) {
        char c1 = str1.charAt(i);
        char c2 = str2.charAt(i);
        
        // Check mapping from str1 to str2
        if (map1.containsKey(c1)) {
            if (map1.get(c1) != c2) {
                return false;
            }
        } else {
            map1.put(c1, c2);
        }
        
        // Check mapping from str2 to str1
        if (map2.containsKey(c2)) {
            if (map2.get(c2) != c1) {
                return false;
            }
        } else {
            map2.put(c2, c1);
        }
    }
    
    return true;
}
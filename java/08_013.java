import java.util.HashMap;
import java.util.Map;

public class FirstNonRepeatingChar {
    public static int firstUniqChar(String s) {
        Map<Character, Integer> charCount = new HashMap<>();
        
        // Count the occurrences of each character
        for (char c : s.toCharArray()) {
            charCount.put(c, charCount.getOrDefault(c, 0) + 1);
        }
        
        // Find the first character with count 1
        for (int i = 0; i < s.length(); i++) {
            if (charCount.get(s.charAt(i)) == 1) {
                return i;
            }
        }
        
        return -1;  // No unique character found
    }
    
    public static void main(String[] args) {
        System.out.println(firstUniqChar("apple"));      // 0
        System.out.println(firstUniqChar("loveapples")); // 1
        System.out.println(firstUniqChar("aabb"));       // -1
    }
}
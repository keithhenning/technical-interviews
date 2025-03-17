import java.util.*;

public List<List<String>> groupWordPatterns(String[] words) {
    Map<String, List<String>> groups = new HashMap<>();
    
    for (String word : words) {
        // Generate key by sorting characters
        char[] chars = word.toCharArray();
        Arrays.sort(chars);
        String key = new String(chars);
        
        // Add word to its group
        if (!groups.containsKey(key)) {
            groups.put(key, new ArrayList<>());
        }
        groups.get(key).add(word);
    }
    
    // Return lists of grouped words
    return new ArrayList<>(groups.values());
}
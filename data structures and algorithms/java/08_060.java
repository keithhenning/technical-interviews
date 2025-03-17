import java.util.*;

public class Solution {
   public List<List<String>> groupAnagramsByFrequency(
         String[] strs) {
      Map<String, List<String>> groups = 
         new HashMap<>();
      List<List<String>> result = 
         new ArrayList<>();
      
      for (String s : strs) {
         // Count character frequencies
         int[] freq = new int[26];
         for (char c : s.toCharArray()) {
            freq[c - 'a']++;
         }
         
         // Create frequency key
         StringBuilder sb = new StringBuilder();
         for (int i = 0; i < 26; i++) {
            sb.append('#').append(freq[i]);
         }
         String key = sb.toString();
         
         // Group anagrams
         if (!groups.containsKey(key)) {
            groups.put(key, new ArrayList<>());
            // Track order of appearance
            result.add(groups.get(key));
         }
         groups.get(key).add(s);
      }
      
      return result;
   }
}
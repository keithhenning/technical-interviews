import java.util.ArrayList;
import java.util.List;

public class StringPermutations {
  public static List<String> getPermutations(String string) {
     // Base case
     List<String> result = new ArrayList<>();
     if (string.length() <= 1) {
        result.add(string);
        return result;
     }
     
     // Recursive case
     for (int i = 0; i < string.length(); i++) {
        char currentChar = string.charAt(i);
        String remaining = string.substring(0, i) + 
           string.substring(i + 1);
        
        for (String perm : getPermutations(remaining)) {
           result.add(currentChar + perm);
        }
     }
     
     return result;
  }
  
  public static void main(String[] args) {
     List<String> result = getPermutations("abc");
     System.out.println(result);  // [abc, acb, bac, bca, cab, cba]
  }
}
import java.util.*;

/**
 * Generates valid bracket expressions from given expression
 */
public class Solution {
   /**
    * Generate valid bracket expressions by adding pairs
    */
   public List<String> generateBracketExpressions(String expr) {
      Set<String> result = new HashSet<>();
      String[] brackets = {"()", "[]", "{}"};
      
      // Insert a bracket pair at various positions
      for (int i = 0; i <= expr.length(); i++) {
         for (String bracket : brackets) {
            // Insert opening bracket
            String newExpr = expr.substring(0, i) + bracket.charAt(0) 
                  + expr.substring(i);
            
            // Try all positions for closing bracket
            for (int j = i + 1; j <= newExpr.length(); j++) {
               String candidate = newExpr.substring(0, j) 
                     + bracket.charAt(1) 
                     + newExpr.substring(j);
               if (isValid(candidate)) {
                  result.add(candidate);
               }
            }
         }
      }
      
      // Add bracket pairs around entire expression
      for (String bracket : brackets) {
         String wrapped = bracket.charAt(0) + expr + 
               bracket.charAt(1);
         if (isValid(wrapped)) {
            result.add(wrapped);
         }
      }
      
      return new ArrayList<>(result);
   }
   
   /**
    * Check if expression has valid bracket pairing
    */
   private boolean isValid(String expr) {
      Stack<Character> stack = new Stack<>();
      Map<Character, Character> bracketMap = new HashMap<>();
      bracketMap.put(')', '(');
      bracketMap.put(']', '[');
      bracketMap.put('}', '{');
      
      for (char c : expr.toCharArray()) {
         if (c == '(' || c == '[' || c == '{') {
            stack.push(c);
         } else if (c == ')' || c == ']' || c == '}') {
            if (stack.isEmpty() || 
                  stack.pop() != bracketMap.get(c)) {
               return false;
            }
         }
      }
      
      return stack.isEmpty();
   }
}
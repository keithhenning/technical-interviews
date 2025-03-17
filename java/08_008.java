public class LongestPalindromicSubstring {
   /**
    * Find the longest palindromic substring in a string
    */
   public static String longestPalindrome(String s) {
      if (s == null || s.length() < 1) {
         return "";
      }
      
      int start = 0;
      int maxLength = 1;
      
      for (int i = 0; i < s.length(); i++) {
         // Odd length palindromes (like "aba")
         int[] oddResult = expandAroundCenter(s, i, i);
         // Even length palindromes (like "abba")
         int[] evenResult = expandAroundCenter(s, i, i + 1);
         
         // Update if we found a longer palindrome
         if (oddResult[1] > maxLength) {
            start = oddResult[0];
            maxLength = oddResult[1];
         }
         
         if (evenResult[1] > maxLength) {
            start = evenResult[0];
            maxLength = evenResult[1];
         }
      }
      
      return s.substring(start, start + maxLength);
   }
   
   /**
    * Expand around center to find palindrome
    * @return int[2] with start index and length
    */
   private static int[] expandAroundCenter(String s, int left, 
         int right) {
      // Expand while characters match
      while (left >= 0 && right < s.length() && 
            s.charAt(left) == s.charAt(right)) {
         left--;
         right++;
      }
      
      // Calculate palindrome boundaries
      left++;  // Adjust to valid position
      int start = left;
      int length = right - left;
      
      return new int[]{start, length};
   }
   
   public static void main(String[] args) {
      System.out.println(longestPalindrome("babad"));  // "bab"
      System.out.println(longestPalindrome("cbbd"));   // "bb"
      System.out.println(longestPalindrome("racecar")); // "racecar"
   }
}
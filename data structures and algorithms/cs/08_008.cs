public class LongestPalindromicSubstring
{
   /**
    * Find the longest palindromic substring in a string
    */
   public static string LongestPalindrome(string s)
   {
      if (string.IsNullOrEmpty(s) || s.Length < 1)
      {
         return "";
      }

      int start = 0;
      int maxLength = 1;

      for (int i = 0; i < s.Length; i++)
      {
         // Odd length palindromes (like "aba")
         int[] oddResult =
            ExpandAroundCenter(s, i, i);
         // Even length palindromes (like "abba")
         int[] evenResult =
            ExpandAroundCenter(s, i, i + 1);

         if (oddResult[1] > maxLength)
         {
            start = oddResult[0];
            maxLength = oddResult[1];
         }

         if (evenResult[1] > maxLength)
         {
            start = evenResult[0];
            maxLength = evenResult[1];
         }
      }

      return s.Substring(start, maxLength);
   }

   /**
    * Expand around center to find palindrome
    * @return int[2] with start index and length
    */
   private static int[] ExpandAroundCenter(
      string s,
      int left,
      int right)
   {
      while (left >= 0 &&
         right < s.Length &&
         s[left] == s[right])
      {
         left--;
         right++;
      }

      left++;  // Adjust to valid position
      int start = left;
      int length = right - left;

      return new int[] { start, length };
   }

   public static void Main(string[] args)
   {
      Console.WriteLine(
         LongestPalindrome("babad"));  // "bab"
      Console.WriteLine(
         LongestPalindrome("cbbd"));   // "bb"
      Console.WriteLine(
         LongestPalindrome("racecar")); // "racecar"
   }
}
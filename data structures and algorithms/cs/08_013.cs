using System;
using System.Collections.Generic;

public class FirstNonRepeatingChar {
    public static int FirstUniqChar(string s) {
        Dictionary<char, int> charCount = new Dictionary<char, int>();
        
        // Count the occurrences of each character
        foreach (char c in s) {
            if (charCount.ContainsKey(c)) {
                charCount[c]++;
            } else {
                charCount[c] = 1;
            }
        }
        
        // Find the first character with count 1
        for (int i = 0; i < s.Length; i++) {
            if (charCount[s[i]] == 1) {
                return i;
            }
        }
        
        return -1;  // No unique character found
    }
    
    public static void Main(string[] args) {
        Console.WriteLine(FirstUniqChar("apple"));      // 0
        Console.WriteLine(FirstUniqChar("loveapples")); // 1
        Console.WriteLine(FirstUniqChar("aabb"));       // -1
    }
}
using System;
using System.Collections.Generic;

public List<List<string>> GroupWordPatterns(string[] words) {
    Dictionary<string, List<string>> groups = new Dictionary<string, List<string>>();
    
    foreach (string word in words) {
        // Generate key by sorting characters
        char[] chars = word.ToCharArray();
        Array.Sort(chars);
        string key = new string(chars);
        
        // Add word to its group
        if (!groups.ContainsKey(key)) {
            groups[key] = new List<string>();
        }
        groups[key].Add(word);
    }
    
    // Return lists of grouped words
    return new List<List<string>>(groups.Values);
}
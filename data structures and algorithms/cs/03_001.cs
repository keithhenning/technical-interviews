using System;
using System.Collections.Generic;

public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int n = s.Length;
        int ans = 0;
        Dictionary<char, int> map = new Dictionary<char, int>();
        for (int j = 0, i = 0; j < n; j++) {
            if (map.ContainsKey(s[j])) {
                i = Math.Max(map[s[j]], i);
            }
            ans = Math.Max(ans, j - i + 1);
            map[s[j]] = j + 1;
        }
        return ans;
    }
}

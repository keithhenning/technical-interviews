// Optimized Valid Anagram
bool is_anagram_optimized(std::string s, std::string t) {
    std::sort(s.begin(), s.end());
    std::sort(t.begin(), t.end());
    return s == t;  // Clean but mention the tradeoffs!
}
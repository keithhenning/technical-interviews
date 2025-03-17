// Common pattern I use for state tracking

// For sum-based problems
int windowSum = 0;

// For character frequency
std::unordered_map<char, int> windowChars;

// For maximum calculations
int maxSeen = std::numeric_limits<int>::min();

// For minimum calculations
int minSeen = std::numeric_limits<int>::max();
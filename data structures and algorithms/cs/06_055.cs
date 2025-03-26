using System;
using System.Collections.Generic;

// Common patterns I use for state tracking

// For sum-based problems
int windowSum = 0;

// For character frequency
Dictionary<char, int> windowChars = new Dictionary<char, int>();

// For maximum calculations
int maxSeen = int.MinValue;

// For minimum calculations
int minSeen = int.MaxValue;
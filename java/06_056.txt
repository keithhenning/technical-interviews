// Adding to window
windowSum += arr[windowEnd];

// For character frequency
windowChars.put(s[windowEnd], 
       windowChars.getOrDefault(s[windowEnd], 0) + 1);

// Removing from window
windowSum -= arr[windowStart];

// For character frequency
windowChars.put(s[windowStart], 
       windowChars.get(s[windowStart]) - 1);
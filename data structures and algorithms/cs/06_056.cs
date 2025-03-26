// Adding to window
windowSum += arr[windowEnd];

// For character frequency
windowChars[s[windowEnd]] =
   windowChars.GetValueOrDefault(s[windowEnd], 0) + 1;

// Removing from window
windowSum -= arr[windowStart];

// For character frequency
windowChars[s[windowStart]] = windowChars[s[windowStart]] - 1;
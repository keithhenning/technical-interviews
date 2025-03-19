using System;
using System.Collections.Generic;

public static int RecursiveFunc(int n, int depth, Dictionary<int, int> memo = null) {
  // Initialize memo if null
  if (memo == null) {
     memo = new Dictionary<int, int>();
  }
  
  // Create indentation based on recursion depth
  string indent = new string(' ', depth * 2);
  Console.WriteLine(indent + "Computing f(" + n + ")");
  
  // Return cached result if available
  if (memo.ContainsKey(n)) {
     Console.WriteLine(indent + "Found in cache: " + memo[n]);
     return memo[n];
  }
  
  // Rest of function...
}
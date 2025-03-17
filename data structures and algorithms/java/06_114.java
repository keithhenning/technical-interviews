public static int recursiveFunc(int n, int depth, 
     Map<Integer, Integer> memo) {
  // Initialize memo if null
  if (memo == null) {
     memo = new HashMap<>();
  }
  
  // Create indentation based on recursion depth
  String indent = "  ".repeat(depth);
  System.out.println(indent + "Computing f(" + n + ")");
  
  // Return cached result if available
  if (memo.containsKey(n)) {
     System.out.println(indent + "Found in cache: " + 
        memo.get(n));
     return memo.get(n);
  }
  
  // Rest of function...
}
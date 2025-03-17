int fibonacci(int n) {  // O(2&#x207f;)
   if (n <= 1) {
       return n;
   }
   return fibonacci(n-1) + fibonacci(n-2);
}
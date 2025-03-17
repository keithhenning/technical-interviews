def lcs(X, Y, m, n, memo=None):
   # Initialize memo dictionary if None
   if memo is None:
      memo = {}
   
   # Return memoized result if available
   if (m, n) in memo:
      return memo[(m, n)]
   
   # Base case: empty string
   if m == 0 or n == 0:
      return 0
   
   # If characters match, add 1 to result
   if X[m-1] == Y[n-1]:
      memo[(m, n)] = 1 + lcs(X, Y, m-1, n-1, memo)
   else:
      # Take maximum of two possible subproblems
      memo[(m, n)] = max(lcs(X, Y, m, n-1, memo), 
                       lcs(X, Y, m-1, n, memo))
   
   return memo[(m, n)]
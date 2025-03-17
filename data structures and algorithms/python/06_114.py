from functools import lru_cache

def fib_slow(n):
   # Naive recursive fibonacci
   if n <= 1:
      return n
   return fib_slow(n-1) + fib_slow(n-2)

def fib_memo(n, memo={}):
   # Memoized recursive fibonacci
   if n in memo:
      return memo[n]
   if n <= 1:
      return n
   memo[n] = fib_memo(n-1, memo) + fib_memo(n-2, memo)
   return memo[n]

@lru_cache(maxsize=None)
def fib_lru(n):
   # LRU cached fibonacci
   if n <= 1:
      return n
   return fib_lru(n-1) + fib_lru(n-2)

# Example usage
if __name__ == "__main__":
   print(f"Slow Fib(30): {fib_slow(30)}")
   print(f"Memoized Fib(30): {fib_memo(30)}")
   print(f"LRU Cached Fib(40): {fib_lru(40)}")
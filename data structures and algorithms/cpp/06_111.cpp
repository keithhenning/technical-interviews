#include <iostream>
#include <unordered_map>
using namespace std;

// Fibonacci with memoization
unordered_map<int, long long> fib_memo;

long long fibonacci(int n) {
    if (fib_memo.find(n) != fib_memo.end()) {
        return fib_memo[n];
    }
    
    long long result;
    if (n <= 1) {
        result = n;
    } else {
        result = fibonacci(n-1) + fibonacci(n-2);
    }
    
    fib_memo[n] = result;
    return result;
}
int main() {
    cout << fibonacci(40) << endl; 
    return 0;
}
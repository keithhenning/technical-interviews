#include <iostream>
#include <vector>
#include <iomanip>

void demonstrate_complexity(
        const std::vector<int>& sizes = {10, 100, 1000}) {
    for (int n : sizes) {
        int operations = n * n;
        std::cout << "Size " << n << ": " << std::fixed 
                 << std::setprecision(0) 
                 << std::setw(1) 
                 << std::put_money(operations, false) 
                 << " operations" << std::endl;
    }
}
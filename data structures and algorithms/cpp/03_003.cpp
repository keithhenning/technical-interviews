#include <iostream>
#include <vector>

class LinearTime {
public:
    static int findMaximum(const std::vector<int>& arr) {
        int maxValue = arr[0];
        for (int num : arr) {
            if (num > maxValue) {
                maxValue = num;
            }
        }
        return maxValue;
    }
};

int main() {
    std::vector<int> numbers = {3, 1, 4, 1, 5, 9, 2, 6, 5, 
                               3, 5};
    std::cout << "Maximum value: " 
             << LinearTime::findMaximum(numbers) 
             << std::endl;  // Output: 9
    return 0;
}
class SlidingWindow {
public:
    int maxSumSubarray(vector<int>& arr, int k) {
        if (arr.empty() || arr.size() < k) {
            return -1;
        }
        
        int windowSum = 0;
        for (int i = 0; i < k; i++) {
            windowSum += arr[i];
        }
        
        int maxSum = windowSum;
        
        for (int i = k; i < arr.size(); i++) {
            windowSum = windowSum + arr[i] - arr[i - k];
            maxSum = max(maxSum, windowSum);
        }
        
        return maxSum;
    }

    void runTests() {
        // Test Case 1: Alternating numbers
        vector<int> arr1 = {1, -1, 2, -2, 3, -3, 4, -4};
        int k1 = 3;
        cout << "Test 1: Alternating numbers\n";
        cout << "Array: ";
        printVector(arr1);
        cout << "Window size: " << k1 << "\n";
        cout << "Expected: 4\n";
        cout << "Result: " << maxSumSubarray(arr1, k1) << "\n\n";

        // Test Case 2: Single element windows
        vector<int> arr2 = {5, 2, 9, 1, 7};
        int k2 = 1;
        cout << "Test 2: Single element windows\n";
        cout << "Array: ";
        printVector(arr2);
        cout << "Window size: " << k2 << "\n";
        cout << "Expected: 9\n";
        cout << "Result: " << maxSumSubarray(arr2, k2) << "\n\n";

        // Test Case 3: Large numbers
        vector<int> arr3 = {1000000, 1000000, 1000000, 1000000};
        int k3 = 2;
        cout << "Test 3: Large numbers\n";
        cout << "Array: ";
        printVector(arr3);
        cout << "Window size: " << k3 << "\n";
        cout << "Expected: 2000000\n";
        cout << "Result: " << maxSumSubarray(arr3, k3) << "\n\n";
    }

private:
    void printVector(const vector<int>& vec) {
        cout << "[";
        for (size_t i = 0; i < vec.size(); i++) {
            cout << vec[i];
            if (i < vec.size() - 1) cout << ", ";
        }
        cout << "]\n";
    }
};

int main() {
    SlidingWindow solution;
    solution.runTests();
    return 0;
}
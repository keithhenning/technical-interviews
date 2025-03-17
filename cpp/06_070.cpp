#include <iostream>
#include <vector>

std::vector<int> bucketSort(const std::vector<int>& arr, int k) {
   // Create k+1 buckets (for numbers 0 to k)
   std::vector<int> count(k + 1, 0);
   
   // Count occurrences of each element
   for (int num : arr) {
       count[num]++;
   }
   
   // Reconstruct the sorted array
   std::vector<int> sortedArr(arr.size());
   int index = 0;
   for (int i = 0; i <= k; i++) {
       for (int j = 0; j < count[i]; j++) {
           sortedArr[index++] = i;
       }
   }
   
   return sortedArr;
}

int main() {
   std::vector<int> arr = {3, 1, 4, 1, 5, 9, 2, 6, 5, 3};
   int k = 9; // Maximum value in the array
   
   std::vector<int> sorted = bucketSort(arr, k);
   
   std::cout << "Sorted array: ";
   for (int num : sorted) {
       std::cout << num << " ";
   }
   std::cout << std::endl;
   
   return 0;
}
#include <iostream>
#include <vector>
#include <algorithm>
#include <cmath>

// Find kth smallest element using median-of-medians
// k is 0-based: k=0 returns smallest, k=1 second smallest
int medianOfMedians(std::vector<int>& arr, int k) {
   // Base case: small arrays, sort and return kth
   if (arr.size() <= 5) {
      std::sort(arr.begin(), arr.end());
      return arr[k];
   }
   
   // Divide array into groups of 5, find median of each
   std::vector<int> medians;
   for (size_t i = 0; i < arr.size(); i += 5) {
      std::vector<int> group;
      for (size_t j = i; 
           j < std::min(i + 5, arr.size()); 
           j++) {
         group.push_back(arr[j]);
      }
      std::sort(group.begin(), group.end());
      medians.push_back(group[group.size() / 2]);
   }
   
   // Find median of medians recursively
   int pivot = medians.size() <= 1 
      ? medians[0] 
      : medianOfMedians(medians, medians.size() / 2);
   
   // Partition array around pivot
   std::vector<int> left, middle, right;
   for (int num : arr) {
      if (num < pivot) {
         left.push_back(num);
      } else if (num == pivot) {
         middle.push_back(num);
      } else {
         right.push_back(num);
      }
   }
   
   // Recursively find kth element in partition
   if (k < left.size()) {
      return medianOfMedians(left, k);
   } else if (k < left.size() + middle.size()) {
      return pivot;
   } else {
      return medianOfMedians(
         right, 
         k - left.size() - middle.size()
      );
   }
}

int main() {
   std::vector<int> arr = {9, 1, 8, 2, 7, 3, 6, 4, 5};
   
   // Find 4th smallest element (index 3)
   int result = medianOfMedians(arr, 3);
   std::cout << "4th smallest: " << result 
             << std::endl;
   
   // Find array median
   int medianIndex = arr.size() / 2;
   int median = medianOfMedians(arr, medianIndex);
   std::cout << "Array median: " << median 
             << std::endl;
   
   return 0;
}
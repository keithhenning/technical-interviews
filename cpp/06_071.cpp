#include <iostream>
#include <vector>
#include <algorithm>

std::vector<float> bucketSortFloat(const std::vector<float>& arr) {
   int n = arr.size();
   std::vector<std::vector<float>> buckets(n);
   
   // Initialize buckets (already done by vector constructor)
   
   // Place elements into buckets
   for (float num : arr) {
       int bucketIdx = (int)(n * num);
       buckets[bucketIdx].push_back(num);
   }
   
   // Sort individual buckets
   for (std::vector<float>& bucket : buckets) {
       std::sort(bucket.begin(), bucket.end());
   }
   
   // Concatenate all buckets
   std::vector<float> result(n);
   int index = 0;
   for (const std::vector<float>& bucket : buckets) {
       for (float num : bucket) {
           result[index++] = num;
       }
   }
   
   return result;
}

int main() {
   std::vector<float> arr = {0.42f, 0.32f, 0.33f, 0.52f, 0.37f, 
                            0.47f, 0.51f, 0.78f, 0.11f, 0.25f};
   
   std::vector<float> sorted = bucketSortFloat(arr);
   
   std::cout << "Sorted array: ";
   for (float num : sorted) {
       std::cout << num << " ";
   }
   std::cout << std::endl;
   
   return 0;
}
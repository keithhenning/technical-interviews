#include <iostream>
#include <vector>
#include <deque>
#include <climits>

std::vector<int> kSort(const std::vector<int>& arr, int k) {
   int n = arr.size();
   std::vector<int> result;
   
   // Create buckets for the range of possible values
   std::vector<std::deque<int>> buckets(k+1);
   
   // Process elements in order
   for (int i = 0; i < n; i++) {
       // Place elements in appropriate buckets
       int bucketIdx = std::min(k, i);
       buckets[bucketIdx].push_back(arr[i]);
       
       // If we have filled k+1 buckets, start extracting
       if (i >= k) {
           int minBucket = getMinBucketIndex(buckets);
           result.push_back(buckets[minBucket].front());
           buckets[minBucket].pop_front();
       }
   }
   
   // Extract remaining elements
   while (anyBucketsNotEmpty(buckets)) {
       int minBucket = getMinBucketIndex(buckets);
       result.push_back(buckets[minBucket].front());
       buckets[minBucket].pop_front();
   }
   
   return result;
}

int getMinBucketIndex(const std::vector<std::deque<int>>& buckets) {
   int minValue = INT_MAX;
   int minBucket = 0;
   
   for (int i = 0; i < buckets.size(); i++) {
       if (!buckets[i].empty() && 
           buckets[i].front() < minValue) {
           minValue = buckets[i].front();
           minBucket = i;
       }
   }
   
   return minBucket;
}

bool anyBucketsNotEmpty(
       const std::vector<std::deque<int>>& buckets) {
   for (const std::deque<int>& bucket : buckets) {
       if (!bucket.empty()) {
           return true;
       }
   }
   return false;
}

int main() {
   std::vector<int> arr = {6, 5, 3, 2, 8, 10, 9};
   int k = 3;
   
   std::vector<int> sorted = kSort(arr, k);
   
   std::cout << "K-sorted array: ";
   for (int num : sorted) {
       std::cout << num << " ";
   }
   std::cout << std::endl;
   
   return 0;
}
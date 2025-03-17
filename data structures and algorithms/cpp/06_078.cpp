int medianOfThree(std::vector<int>& arr, int low, int high) {
   int mid = (low + high) / 2;
   
   // Find median of first, middle, and last elements
   if (arr[low] > arr[mid]) {
       std::swap(arr[low], arr[mid]);
   }
   if (arr[mid] > arr[high]) {
       std::swap(arr[mid], arr[high]);
   }
   if (arr[low] > arr[mid]) {
       std::swap(arr[low], arr[mid]);
   }
   
   // Return the median as pivot (place it at position high-1)
   std::swap(arr[mid], arr[high-1]);
   return arr[high-1];
}
public static float[] bucketSortFloat(float[] arr) {
   int n = arr.length;
   List<List<Float>> buckets = new ArrayList<>(n);
   
   // Initialize buckets
   for (int i = 0; i < n; i++) {
       buckets.add(new ArrayList<>());
   }
   
   // Place elements into buckets
   for (float num : arr) {
       int bucketIdx = (int)(n * num);
       buckets.get(bucketIdx).add(num);
   }
   
   // Sort individual buckets
   for (List<Float> bucket : buckets) {
       // Can use insertion sort for small buckets
       Collections.sort(bucket);
   }
   
   // Concatenate all buckets
   float[] result = new float[n];
   int index = 0;
   for (List<Float> bucket : buckets) {
       for (float num : bucket) {
           result[index++] = num;
       }
   }
   
   return result;
}
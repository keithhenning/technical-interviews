public static void testPerformance() {
   int[] largeArr = new int[1000000];
   for (int i = 0; i < largeArr.length; i++) {
       largeArr[i] = i % 100;
   }
   int k = 1000;
   long startTime = System.currentTimeMillis();
   int result = maxSumSubarray(largeArr, k);
   long endTime = System.currentTimeMillis();
   System.out.println("Time taken: " + 
           (endTime - startTime) / 1000.0 + " seconds");
}
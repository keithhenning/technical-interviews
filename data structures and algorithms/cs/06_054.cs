using System;

public static class TestPerformance
{
   public static void TestPerformanceMethod()
   {
      int[] largeArr = new int[1000000];
      for (int i = 0; i < largeArr.Length; i++)
      {
         largeArr[i] = i % 100;
      }
      int k = 1000;
      long startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
      int result = MaxSumSubarray(largeArr, k);
      long endTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
      Console.WriteLine("Time taken: " +
         (endTime - startTime) / 1000.0 + " seconds");
   }
}
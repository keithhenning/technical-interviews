using System;
using System.Collections.Generic;

public class CircularArrayRotation {
    public static List<int> QueryRotatedArray(int[] arr, int[][] queries) {
        int n = arr.Length;
        var results = new List<int>();

        foreach (var query in queries) {
            int rotation = query[0];
            int index = query[1];

            int effectiveRotation = rotation % n;
            int originalPosition = (index - effectiveRotation + n) % n;
            results.Add(arr[originalPosition]);
        }

        return results;
    }

    public static void Main(string[] args) {
        int[] arr = { 3, 7, 1, 9, 5 };
        int[][] queries = { new int[] { 2, 1 }, new int[] { 4, 3 }, new int[] { 0, 2 } };

        var results = QueryRotatedArray(arr, queries);
        Console.WriteLine(string.Join(", ", results)); // Output: [3, 3, 1]
    }
}
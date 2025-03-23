using System;
using System.Collections.Generic;

public class MainClass
{
    public static void Main(string[] args)
    {
        // Create a mutable List directly
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

        // Dynamic operations on the same list
        numbers.Add(6);      // Adds to end
        numbers.Insert(0, 0);   // Adds at beginning

        Console.WriteLine(string.Join(", ", numbers)); // [0, 1, 2, 3, 4, 5, 6]
    }
}
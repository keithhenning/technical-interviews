using System;

public class MainClass
{
   public static void Main(string[] args)
   {
      // Main method code goes here
   }

   public int GoodHash(object key)
   {
      // Use built-in hash for strings
      if (key is string)
      {
         return key.GetHashCode();
      }
      // Custom hash for arrays
      if (key is object[])
      {
         return ((object[])key).GetHashCode();
      }

      return key.GetHashCode();
   }

   public void PrintHash(object key)
   {
      Console.WriteLine(GoodHash(key));
   }
}

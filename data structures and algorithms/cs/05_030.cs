using System;
using System.Collections.Generic;

public class MainClass
{
   public static void Main(string[] args)
   {
      // Main method code goes here
   }

   /**
    * Example storing user movie favorites in a HashMap
    */
   public void MovieFavorites()
   {
      // Create map of user to favorite movies
      Dictionary<string, List<string>> movieFavorites = new Dictionary<string, List<string>>();

      // Add user favorites as immutable lists
      movieFavorites["Billy"] = new List<string> { "Rocky III", "China Town" };
      movieFavorites["Kathryn"] = new List<string> { "China Town", "Planet of the Apes" };
   }

   public void PrintMovieFavorites(Dictionary<string, List<string>> movieFavorites)
   {
      foreach (var entry in movieFavorites)
      {
         Console.Write(entry.Key + ": ");
         foreach (var movie in entry.Value)
         {
            Console.Write(movie + " ");
         }
         Console.WriteLine();
      }
   }
}

using System;
using System.Collections.Generic;

public class MainClass {
   public static void Main(string[] args) {
      // Main method code goes here
   }
   
   public void PetOwnerRelationships() {
      // Pet-Owner relationships
      Dictionary<string, List<string>> 
         relationships = new Dictionary<string, List<string>>();
      
      // Wendesday is Keith's cat
      relationships["Wednesday"] = 
         new List<string> { "Keith" };     
      
      // Keith is Wednesday's human
      relationships["Keith"] = 
         new List<string> { "Wednesday" };     
      
      // Whiskers is Tom's cat
      relationships["Whiskers"] = 
         new List<string> { "Tom" };  
      
      // Tom is Whiskers' human
      relationships["Tom"] = 
         new List<string> { "Whiskers" };  
   }

   public void PrintRelationships(
      Dictionary<string, List<string>> relationships) {
      foreach (var entry in relationships) {
         Console.Write(entry.Key + ": ");
         foreach (var value in entry.Value) {
            Console.Write(value + " ");
         }
         Console.WriteLine();
      }
   }
}

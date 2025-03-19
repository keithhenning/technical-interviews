using System;
using System.IO;
using System.Linq;

public class DirectoryExplorer
{
   public void ExploreDirectory(string path, int depth)
   {
      // Validate directory path
      if (!Directory.Exists(path))
      {
         return;
      }

      // Display current directory with indentation
      Console.WriteLine(new string(' ', depth * 2) + new DirectoryInfo(path).Name);

      // Explore subdirectories using DFS approach
      try
      {
         foreach (var item in Directory.GetFileSystemEntries(path))
         {
            ExploreDirectory(item, depth + 1);
         }
      }
      catch (Exception e)
      {
         Console.Error.WriteLine("Error accessing directory: " + e.Message);
      }
   }
}

import java.io.File;
import java.nio.file.Files;
import java.nio.file.Path;

/**
 * Recursively explore directory structure
 */
public void exploreDirectory(String path, int depth) {
   // Validate directory path
   if (!Files.isDirectory(Path.of(path))) {
      return;
   }
   
   // Display current directory with indentation
   System.out.println("  ".repeat(depth) + 
      new File(path).getName());
   
   // Explore subdirectories using DFS approach
   try {
      for (File item : new File(path).listFiles()) {
         String fullPath = item.getPath();
         exploreDirectory(fullPath, depth + 1);
      }
   } catch (Exception e) {
      System.err.println("Error accessing directory: " + 
         e.getMessage());
   }
}
import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;

public class Main {
   public static void main(String[] args) {
      // Main method code goes here
   }
   
   /**
    * Example storing user movie favorites in a HashMap
    */
   public void movieFavorites() {
      // Create map of user to favorite movies
      Map<String, List<String>> movieFavorites = 
         new HashMap<>();
      
      // Add user favorites as immutable lists
      movieFavorites.put("Billy", 
         Arrays.asList("Rocky III", "China Town"));
      movieFavorites.put("Kathryn", 
         Arrays.asList("China Town", "Planet of the Apes"));
   }
}
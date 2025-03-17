import java.util.*;

public class Main {
  public static void main(String[] args) {
     // Create a mutable ArrayList directly
     List<Integer> numbers = new ArrayList<>(
        Arrays.asList(1, 2, 3, 4, 5));
     
     // Dynamic operations on the same list
     numbers.add(6);      // Adds to end
     numbers.add(0, 0);   // Adds at beginning
     
     System.out.println(numbers); // [0, 1, 2, 3, 4, 5, 6]
  }
}
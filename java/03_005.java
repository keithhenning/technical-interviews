import java.text.NumberFormat;
import java.util.Arrays;

public class ComplexityDemo {
  public static void demonstrateComplexity() {
     demonstrateComplexity(new int[]{10, 100, 1000});
  }
  
  public static void demonstrateComplexity(int[] sizes) {
     NumberFormat formatter = NumberFormat.getInstance();
     
     for (int n : sizes) {
        // Calculate quadratic complexity operations
        long operations = (long) n * n;
        System.out.println("Size " + n + ": " + 
           formatter.format(operations) + " operations");
     }
  }
  
  public static void main(String[] args) {
     demonstrateComplexity();
  }
}
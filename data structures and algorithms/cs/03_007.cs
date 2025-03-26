public class Fibonacci
{
   public static int Fibonacci(int n)
   {
      if (n <= 1)
      {
         return n;
      }
      return Fibonacci(n - 1) + Fibonacci(n - 2);
   }

   public static void Main(string[] args)
   {
      // Example usage
      int n = 10;
      System.Console.WriteLine(
         "Fibonacci(" + n + ") = " + Fibonacci(n));
   }
}
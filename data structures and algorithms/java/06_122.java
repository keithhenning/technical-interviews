public static int[] solution(int n, int[] a) {
   int[] padded = new int[n + 2];
   for (int i = 0; i < n; i++) {
       padded[i + 1] = a[i];
   }
   
   int[] result = new int[n];
   for (int i = 0; i < n; i++) {
       result[i] = padded[i] + padded[i + 1] + padded[i + 2];
   }
   
   return result;
}
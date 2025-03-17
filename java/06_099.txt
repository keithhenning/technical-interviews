/**
* Compute XOR of all numbers from 0 to n without loop
*/
public static int xorFrom0ToN(int n) {
   int remainder = n % 4;
   if (remainder == 0) {
       return n;
   } else if (remainder == 1) {
       return 1;
   } else if (remainder == 2) {
       return n + 1;
   } else {  // remainder == 3
       return 0;
   }
}
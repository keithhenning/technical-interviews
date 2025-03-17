public class LogarithmicTime {
  public static int binarySearch(int[] arr, int target) {
     int left = 0, right = arr.length - 1;
     while (left <= right) {
        // Calculate middle index safely to prevent overflow
        int mid = left + (right - left) / 2;
        if (arr[mid] == target) {
           return mid;
        } else if (arr[mid] < target) {
           left = mid + 1;
        } else {
           right = mid - 1;
        }
     }
     return -1;
  }

  public static void main(String[] args) {
     int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
     int target = 7;
     int index = binarySearch(numbers, target);
     if (index != -1) {
        System.out.println("Element " + target + 
           " found at index " + index);
     } else {
        System.out.println("Element " + target + 
           " not found in the list");
     }
  }
}
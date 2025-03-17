import java.util.Arrays;

public class MergeSort {
  public static int[] mergeSort(int[] array) {
     if (array.length <= 1) return array;

     int mid = array.length / 2;
     int[] left = mergeSort(
        Arrays.copyOfRange(array, 0, mid));
     int[] right = mergeSort(
        Arrays.copyOfRange(array, mid, array.length));

     return merge(left, right);
  }

  private static int[] merge(int[] left, int[] right) {
     int[] result = new int[left.length + right.length];
     int i = 0, j = 0, k = 0;

     while (i < left.length && j < right.length) 
        result[k++] = (left[i] <= right[j]) ? 
           left[i++] : right[j++];

     while (i < left.length) result[k++] = left[i++];
     while (j < right.length) result[k++] = right[j++];

     return result;
  }

  public static void main(String[] args) {
     int[] array = {23, 16, 6, 59, 3, 11, 37};
     System.out.println(Arrays.toString(mergeSort(array)));
  }
}
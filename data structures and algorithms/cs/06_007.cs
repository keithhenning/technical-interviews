/**
 * Sorts an array using the most appropriate algorithm based on array size.
 */
public int[] SmartSort(int[] arr) {
    // Use insertion sort for small arrays
    if (arr.Length <= 10) {
        return InsertionSort(arr);
    } 
    // Switch to quicksort for larger ones
    else {
        return QuickSort(arr);
    }
}

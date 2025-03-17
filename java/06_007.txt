/**
 * Sorts an array using the most appropriate algorithm based on array size.
 */
public int[] smartSort(int[] arr) {
    // Use insertion sort for small arrays
    if (arr.length <= 10) {
        return insertionSort(arr);
    } 
    // Switch to quicksort for larger ones
    else {
        return quickSort(arr);
    }
}
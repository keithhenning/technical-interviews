/**
 * Updates a sorted list by adding a new item and maintaining the sort order.
 */
public void updateSortedList(ArrayList<Integer> sortedArr, int newItem) {
    // When maintaining an already sorted list
    sortedArr.add(newItem);
    int i = sortedArr.size() - 1;
    
    while (i > 0 && sortedArr.get(i-1) > sortedArr.get(i)) {
        // Swap elements
        int temp = sortedArr.get(i);
        sortedArr.set(i, sortedArr.get(i-1));
        sortedArr.set(i-1, temp);
        i--;
    }
}
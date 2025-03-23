/**
 * Updates a sorted list by adding a new item and maintaining the sort order.
 */
public void UpdateSortedList(List<int> sortedArr, int newItem)
{
   // When maintaining an already sorted list
   sortedArr.Add(newItem);
   int i = sortedArr.Count - 1;

   while (i > 0 && sortedArr[i - 1] > sortedArr[i])
   {
      // Swap elements
      int temp = sortedArr[i];
      sortedArr[i] = sortedArr[i - 1];
      sortedArr[i - 1] = temp;
      i--;
   }
}

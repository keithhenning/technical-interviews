public void bubbleSort(int[] arr) {
    int n = arr.length;
    // Outer loop: n times
    for (int i = 0; i < n; i++) {
        // Inner loop: n times (roughly)
        // Together: n * n = n² operations
        for (int j = 0; j < n - i - 1; j++) {
            if (arr[j] > arr[j + 1]) {
                // Swap elements
                int temp = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = temp;
            }
        }
    }
}
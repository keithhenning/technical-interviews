public static int[] Solution(int n, int[] a) {
    int[] result = new int[n];
    for (int i = 0; i < n; i++) {
        result[i] = (i-1 < 0 ? 0 : a[i-1]) + a[i] + (i+1 >= n ? 0 : a[i+1]);
    }
    return result;
}
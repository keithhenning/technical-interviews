public class Solution {
    public static int MaxDiagonalSum(int[][] matrix) {
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0) {
            return 0;
        }

        int n = matrix.Length;
        int maxSum = int.MinValue;

        for (int col = 0; col < n; col++) {
            int diagonalSum = 0;
            int r = 0, c = col;

            while (r < n && c < n) {
                diagonalSum += matrix[r][c];
                r++;
                c++;
            }

            maxSum = Math.Max(maxSum, diagonalSum);
        }

        for (int row = 1; row < n; row++) {
            int diagonalSum = 0;
            int r = row, c = 0;

            while (r < n && c < n) {
                diagonalSum += matrix[r][c];
                r++;
                c++;
            }

            maxSum = Math.Max(maxSum, diagonalSum);
        }

        return maxSum;
    }
}
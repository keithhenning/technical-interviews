using System.Collections.Generic;

public class XSudokuValidator {
    public static bool IsValidXSudoku(int[][] board) {
        var rows = new HashSet<int>[9];
        var cols = new HashSet<int>[9];
        var boxes = new HashSet<int>[9];
        var mainDiag = new HashSet<int>();
        var antiDiag = new HashSet<int>();

        for (int i = 0; i < 9; i++) {
            rows[i] = new HashSet<int>();
            cols[i] = new HashSet<int>();
            boxes[i] = new HashSet<int>();
        }

        for (int i = 0; i < 9; i++) {
            for (int j = 0; j < 9; j++) {
                int num = board[i][j];
                if (num == 0) continue;

                if (rows[i].Contains(num)) return false;
                rows[i].Add(num);

                if (cols[j].Contains(num)) return false;
                cols[j].Add(num);

                int boxIdx = (i / 3) * 3 + j / 3;
                if (boxes[boxIdx].Contains(num)) return false;
                boxes[boxIdx].Add(num);

                if (i == j) {
                    if (mainDiag.Contains(num)) return false;
                    mainDiag.Add(num);
                }

                if (i + j == 8) {
                    if (antiDiag.Contains(num)) return false;
                    antiDiag.Add(num);
                }
            }
        }

        return true;
    }
}
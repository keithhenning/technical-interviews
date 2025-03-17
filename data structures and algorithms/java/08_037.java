import java.util.HashSet;
import java.util.Set;

public boolean isValidXSudoku(int[][] board) {
    Set<Integer>[] rows = new HashSet[9];
    Set<Integer>[] cols = new HashSet[9];
    Set<Integer>[] boxes = new HashSet[9];
    Set<Integer> mainDiag = new HashSet<>();
    Set<Integer> antiDiag = new HashSet<>();
    
    for (int i = 0; i < 9; i++) {
        rows[i] = new HashSet<>();
        cols[i] = new HashSet<>();
        boxes[i] = new HashSet<>();
    }
    
    for (int i = 0; i < 9; i++) {
        for (int j = 0; j < 9; j++) {
            int num = board[i][j];
            if (num == 0) continue;
            
            // Check row
            if (rows[i].contains(num)) return false;
            rows[i].add(num);
            
            // Check column
            if (cols[j].contains(num)) return false;
            cols[j].add(num);
            
            // Check 3x3 box
            int boxIdx = (i / 3) * 3 + j / 3;
            if (boxes[boxIdx].contains(num)) return false;
            boxes[boxIdx].add(num);
            
            // Check main diagonal
            if (i == j) {
                if (mainDiag.contains(num)) return false;
                mainDiag.add(num);
            }
            
            // Check anti-diagonal
            if (i + j == 8) {
                if (antiDiag.contains(num)) return false;
                antiDiag.add(num);
            }
        }
    }
    
    return true;
}
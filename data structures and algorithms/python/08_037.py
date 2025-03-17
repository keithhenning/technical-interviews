def is_valid_x_sudoku(board):

    rows = [set() for _ in range(9)]
    cols = [set() for _ in range(9)]
    boxes = [set() for _ in range(9)]
    main_diag = set()
    anti_diag = set()
    
    for i in range(9):
        for j in range(9):
            num = board[i][j]
            if num == 0:
                continue
                
            # Check row
            if num in rows[i]:
                return False
            rows[i].add(num)
            
            # Check column
            if num in cols[j]:
                return False
            cols[j].add(num)
            
            # Check 3x3 box
            box_idx = (i // 3) * 3 + j // 3
            if num in boxes[box_idx]:
                return False
            boxes[box_idx].add(num)
            
            # Check main diagonal
            if i == j:
                if num in main_diag:
                    return False
                main_diag.add(num)
                
            # Check anti-diagonal
            if i + j == 8:
                if num in anti_diag:
                    return False
                anti_diag.add(num)
                
    return True
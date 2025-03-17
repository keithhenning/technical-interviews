def solution(n, a):
    padded = [0] + a + [0]  # Add zeros at both ends
    return [padded[i] + padded[i+1] + padded[i+2] for i in range(n)]
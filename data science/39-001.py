import random

def team_draft(rank_a, rank_b):
    merged, team = [], {}
    ia = ib = 0
    while ia < len(rank_a) or ib < len(rank_b):
        a_first = random.random() < 0.5
        for who in ((0, 1) if a_first else (1, 0)):
            src, idx = (rank_a, ia) if who == 0 else (rank_b, ib)
            while idx < len(src) and src[idx] in team:
                idx += 1
            if idx < len(src):
                merged.append(src[idx])
                team[src[idx]] = "A" if who == 0 else "B"
                idx += 1
            if who == 0: ia = idx
            else: ib = idx
    return merged, team

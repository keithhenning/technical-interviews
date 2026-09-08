def decide(p, amount, review_lo, review_hi):
    approve_cost = p * (amount + 20)
    decline_cost = (1 - p) * (0.10 * amount + 5)
    if review_lo <= p <= review_hi:
        return "review"
    return "decline" if decline_cost < approve_cost else "approve"

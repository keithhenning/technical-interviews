# expected cost per transaction at threshold t
def expected_cost(t, p_fraud, amount):
    decline = p_fraud >= t
    fraud_loss = ((~decline) * p_fraud * amount).sum()
    false_decline_loss = (decline * (1 - p_fraud) * amount * margin).sum()
    return fraud_loss + false_decline_loss

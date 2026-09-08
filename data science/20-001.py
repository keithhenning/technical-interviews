import torch, torch.nn.functional as F

def two_tower_loss(user_emb, item_emb, temperature=0.05):
    # user_emb, item_emb: [batch, dim], row i is a positive pair
    logits = user_emb @ item_emb.T / temperature
    labels = torch.arange(logits.size(0), device=logits.device)
    return F.cross_entropy(logits, labels)

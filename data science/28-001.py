JUDGE_PROMPT = """You are grading a support assistant.
Question: {question}
Retrieved context: {context}
Reference answer: {reference}
Assistant answer: {answer}

Return JSON with keys:
  correctness: 1-5 (5 = fully answers the question as the reference does)
  grounded: true/false (false if ANY factual claim about the product or
            account is not supported by the retrieved context)
  unsupported_claim: quote the unsupported sentence, or null
  should_handoff: true/false (true if question is refunds over $500,
            account deletion, legal, or unanswerable from context)
  justification: one sentence
"""

def judge_agreement(judge_labels, human_labels):
    from sklearn.metrics import cohen_kappa_score
    return cohen_kappa_score(judge_labels["correctness"],
                             human_labels["correctness"], weights="quadratic")

import mmh3

def assign(unit_id: str, experiment: dict) -> str | None:
    if not experiment["targeting"](unit_id):
        return None
    bucket = mmh3.hash(f"{experiment['salt']}:{unit_id}", signed=False) % 10000
    cumulative = 0
    for variant in experiment["variants"]:
        cumulative += int(variant["allocation"] * 10000)
        if bucket < cumulative:
            return variant["id"]
    return None

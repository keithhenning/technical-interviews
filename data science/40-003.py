import numpy as np

rng = np.random.default_rng(0)
trials = 200_000
car = rng.integers(3, size=trials)
pick = rng.integers(3, size=trials)
# Host opens a goat door that is neither the car nor your pick.
# If pick == car, there are two choices; sum trick handles both cases.
host = np.where(pick == car,
                (car + 1 + rng.integers(2, size=trials)) % 3,
                3 - pick - car)
switch = 3 - pick - host
print("stay wins:  ", (pick == car).mean())     # ~0.333
print("switch wins:", (switch == car).mean())   # ~0.667

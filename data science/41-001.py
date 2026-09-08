from math import ceil

def per_arm_n(p_base, rel_lift, power_const=16):
    delta = p_base * rel_lift
    return ceil(power_const * p_base * (1 - p_base) / delta**2)

for lift in (0.01, 0.02, 0.05):
    n = per_arm_n(0.03, lift)
    weeks = 2 * n / (50e6 / 4.33)          # two arms, ~4.33 weeks per month
    print(f"{lift:.0%} relative lift: {n:,} per arm, ~{weeks:.1f} weeks")

subs, monthly_cancel, arpu, remaining_life = 20_000_000, 0.04, 12.0, 14
value_per_saved_sub = arpu * remaining_life

def annual_impact(rel_change_in_cancel: float) -> float:
    delta_rate = monthly_cancel * rel_change_in_cancel
    extra_cancels_per_year = subs * delta_rate * 12
    return -extra_cancels_per_year * value_per_saved_sub

starts_lift, starts_to_cancel = 0.015, -0.15
indirect = annual_impact(starts_lift * starts_to_cancel)
direct_point = annual_impact(0.006)
direct_low, direct_high = annual_impact(-0.008), annual_impact(0.020)
print(f"indirect: {indirect/1e6:.1f}M, direct: {direct_point/1e6:.1f}M "
      f"[{direct_high/1e6:.1f}M, {direct_low/1e6:.1f}M]")

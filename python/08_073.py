def optimize_race_day(performance_ratings, race_capacity,
                   ineligibility):
  n_horses = len(performance_ratings)
  n_races = len(race_capacity)
  
  # Convert ineligibility to a more usable format
  ineligible = set((h, r) for h, r in ineligibility)
  
  # Track race assignments and points
  best_assignment = [None] * n_horses
  best_points = 0
  
  # Recursive backtracking function
  def backtrack(horse_idx, assignments, race_counts, 
               total_points):
     nonlocal best_points, best_assignment
     
     # Base case: all horses assigned
     if horse_idx == n_horses:
        # Ensure all races have at least one horse
        if all(count > 0 for count in race_counts):
           if total_points > best_points:
              best_points = total_points
              best_assignment = assignments.copy()
        return
     
     # Try assigning the current horse to each race
     for race in range(n_races):
        # Skip if ineligible or race is at capacity
        if ((horse_idx, race) in ineligible or 
            race_counts[race] >= race_capacity[race]):
           continue
           
        # Try this assignment
        assignments[horse_idx] = race
        race_counts[race] += 1
        
        backtrack(
           horse_idx + 1, 
           assignments, 
           race_counts, 
           total_points + performance_ratings[horse_idx][race]
        )
        
        # Undo the assignment for the next iteration
        race_counts[race] -= 1
        assignments[horse_idx] = None
  
  # Start backtracking with horse 0
  backtrack(0, [None] * n_horses, [0] * n_races, 0)
  
  return best_points, best_assignment
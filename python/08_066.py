import random

def maxWeddingHappiness(relationships, tables, 
                       seats_per_table):
   n = len(relationships)
   if n > tables * seats_per_table:
      return -1  # Not enough seats for all guests
   
   # Calculate relationship score for table arrangement
   def table_score(table_guests):
      score = 0
      for i in range(len(table_guests)):
         for j in range(i+1, len(table_guests)):
            score += relationships[table_guests[i]][table_guests[j]]
      return score
   
   # Calculate total relationship score for all tables
   def total_score(seating):
      score = 0
      for table in seating:
         score += table_score(table)
      return score
   
   # Initialize with random seating
   guests = list(range(n))
   random.shuffle(guests)
   
   # Distribute guests among tables
   seating = []
   for t in range(tables):
      start_idx = t * seats_per_table
      end_idx = min(start_idx + seats_per_table, n)
      if start_idx < n:
         seating.append(guests[start_idx:end_idx])
      else:
         seating.append([])
   
   # Local search optimization
   improved = True
   while improved:
      improved = False
      best_swap_gain = 0
      best_swap = None
      
      # Try all possible guest swaps between tables
      for t1 in range(tables):
         for t2 in range(tables):
            if t1 == t2:
               continue
               
            for i, guest1 in enumerate(seating[t1]):
               for j, guest2 in enumerate(seating[t2]):
                  # Skip if table 1 is already full
                  if len(seating[t2]) >= seats_per_table:
                     continue
                     
                  # Calculate score before swap
                  old_score = (table_score(seating[t1]) + 
                              table_score(seating[t2]))
                  
                  # Perform swap
                  new_t1 = seating[t1].copy()
                  new_t2 = seating[t2].copy()
                  new_t1.remove(guest1)
                  new_t2.remove(guest2)
                  new_t1.append(guest2)
                  new_t2.append(guest1)
                  
                  # Calculate score after swap
                  new_score = table_score(new_t1) +                               
                              table_score(new_t2)
                  gain = new_score - old_score
                  
                  if gain > best_swap_gain:
                     best_swap_gain = gain
                     best_swap = (t1, i, t2, j)
      
      # Apply the best swap if it improves the score
      if best_swap_gain > 0:
         t1, i, t2, j = best_swap
         guest1 = seating[t1][i]
         guest2 = seating[t2][j]
         seating[t1].remove(guest1)
         seating[t2].remove(guest2)
         seating[t1].append(guest2)
         seating[t2].append(guest1)
         improved = True
   
   return total_score(seating)
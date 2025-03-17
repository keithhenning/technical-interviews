from collections import defaultdict
import heapq

def solve_cases(detectives, cases, expertise, 
              communication_overhead):
   n_detectives = detectives
   n_cases = cases
   
   # Calculate all possible solving times
   solving_times = []
   
   # Individual detective times
   for case_id, (case_type, complexity) in enumerate(cases):
      for detective_id in range(n_detectives):
         if case_type in expertise[detective_id]:
            time = complexity / expertise[detective_id][case_type]
            solving_times.append((time, case_id, [detective_id]))
   
   # Collaborative detective times
   for (det1, det2), overhead in communication_overhead.items():
      for case_id, (case_type, complexity) in enumerate(cases):
         if (case_type in expertise[det1] and 
             case_type in expertise[det2]):
            combined_expertise = (expertise[det1][case_type] + 
                                expertise[det2][case_type])
            time = complexity / combined_expertise + overhead
            solving_times.append((time, case_id, [det1, det2]))
   
   # Sort by time (ascending)
   solving_times.sort()
   
   # Greedy assignment with detective availability constraints
   assigned_cases = set()
   busy_detectives = set()
   parallel_time = 0
   sequential_time = 0
   
   while len(assigned_cases) < n_cases:
      for time, case_id, detective_ids in solving_times:
         if case_id in assigned_cases:
            continue
            
         # Check if all detectives are available
         if not any(d in busy_detectives for d in detective_ids):
            assigned_cases.add(case_id)
            busy_detectives.update(detective_ids)
            
            # Update times
            if parallel_time < time:
               sequential_time += time - parallel_time
               parallel_time = time
            break
      else:
         # No more assignments possible, reset busy detectives
         sequential_time += parallel_time
         parallel_time = 0
         busy_detectives.clear()
   
   return sequential_time + parallel_time
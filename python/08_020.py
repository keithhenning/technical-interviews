import heapq

def process_evidence(evidence, hours_per_day):
   processing_order = []
   current_day = 0
   hours_left_today = hours_per_day
   
   # Priority queue as min heap with negative scores
   evidence_queue = []
   
   # Initial queue population
   for item in evidence:
      priority = (-(item["importance"] / 
               item["processing_time"]) * 
               (1 / item["days_until_expiration"]))
      heapq.heappush(evidence_queue, 
               (priority, item["id"], item))
   
   while evidence_queue:
      # Get highest priority evidence
      _, item_id, item = heapq.heappop(evidence_queue)
      
      # Check if it's expired
      if item["days_until_expiration"] <= current_day:
         continue
      
      # Process the evidence
      processing_order.append(item_id)
      
      # Update time tracking
      remaining_time = item["processing_time"]
      while remaining_time > 0:
         if hours_left_today >= remaining_time:
            hours_left_today -= remaining_time
            remaining_time = 0
         else:
            remaining_time -= hours_left_today
            current_day += 1
            hours_left_today = hours_per_day
            
            # Recalculate priorities for remaining evidence
            updated_queue = []
            while evidence_queue:
               _, id, ev = heapq.heappop(evidence_queue)
               if ev["days_until_expiration"] > current_day:
                  new_priority = (-(ev["importance"] / 
                           ev["processing_time"]) * 
                           (1 / (ev["days_until_expiration"] - 
                           current_day)))
                  heapq.heappush(updated_queue, 
                           (new_priority, id, ev))
            evidence_queue = updated_queue
   
   return processing_order
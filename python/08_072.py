import heapq

def restaurant_priority_seating(tables, events):
   # Max heap in Python (implemented as min heap with negatives)
   waitlist = []  # (-priority_score, customer_id, party_size,
                  #  arrival_time, vip_stars, has_reservation)
   results = []
   
   # Process events in chronological order
   for event in events:
      event_type = event[0]
      current_time = event[1]
      
      # Update all customers' priorities based on waiting time
      updated_waitlist = []
      while waitlist:
         neg_priority, customer_id, party_size, arrival_time, \
         vip_stars, has_reservation = heapq.heappop(waitlist)
         waiting_time = current_time - arrival_time
         new_priority = (vip_stars * 10) + \
                        (20 if has_reservation else 0) + waiting_time
         heapq.heappush(updated_waitlist, (
            -new_priority, customer_id, party_size,
            arrival_time, vip_stars, has_reservation
         ))
      waitlist = updated_waitlist
      
      if event_type == "ARRIVE":
         customer_id = event[2]
         party_size = event[3]
         vip_stars = event[4]
         has_reservation = event[5]
         
         # Calculate initial priority
         initial_priority = (vip_stars * 10) + \
                           (20 if has_reservation else 0)
         
         # Add to waitlist
         heapq.heappush(waitlist, (
            -initial_priority, customer_id, party_size,
            current_time, vip_stars, has_reservation
         ))
         
      elif event_type == "TABLE_READY":
         table_size = event[2]
         
         # Find highest priority customer that fits at this table
         temp_waitlist = []
         seated = False
         
         while waitlist and not seated:
            neg_priority, customer_id, party_size, arrival_time, \
            vip_stars, has_reservation = heapq.heappop(waitlist)
            
            if party_size <= table_size:
               # Seat this customer
               results.append([customer_id, current_time])
               seated = True
            else:
               # Put back in temporary waitlist
               heapq.heappush(temp_waitlist, (
                  neg_priority, customer_id, party_size,
                  arrival_time, vip_stars, has_reservation
               ))
         
         # Restore any customers we examined but didn't seat
         while temp_waitlist:
            heapq.heappush(waitlist, heapq.heappop(temp_waitlist))
   
   return results
import java.util.*;

class Customer {
   String id;
   int partySize;
   int vipStars;
   boolean hasReservation;
   int arrivalTime;
   
   public Customer(String id, int partySize, int vipStars, 
         boolean hasReservation, int arrivalTime) {
      this.id = id;
      this.partySize = partySize;
      this.vipStars = vipStars;
      this.hasReservation = hasReservation;
      this.arrivalTime = arrivalTime;
   }
   
   public int getPriority(int currentTime) {
      // Calculate priority based on VIP status, reservation, wait time
      int waitingTime = currentTime - arrivalTime;
      return (vipStars * 10) + (hasReservation ? 20 : 0) + 
            waitingTime;
   }
}

class Result {
   String customerId;
   int seatedTime;
   
   public Result(String customerId, int seatedTime) {
      this.customerId = customerId;
      this.seatedTime = seatedTime;
   }
}

public class RestaurantPrioritySeating {
   public static List<Result> manageSeating(List<Integer> tables, 
         List<Object[]> events) {
      // Sort events chronologically
      events.sort(Comparator.comparing(e -> (Integer)e[1]));
      
      // Priority queue for waitlist (max heap)
      PriorityQueue<Customer> waitlist = new PriorityQueue<>(
            (c1, c2) -> Integer.compare(
                  c2.getPriority(0), c1.getPriority(0)));
      
      List<Result> results = new ArrayList<>();
      
      for (Object[] event : events) {
         String eventType = (String)event[0];
         int currentTime = (Integer)event[1];
         
         // Update waitlist priorities
         PriorityQueue<Customer> updatedWaitlist = 
               new PriorityQueue<>((c1, c2) -> 
                     Integer.compare(
                        c2.getPriority(currentTime), 
                        c1.getPriority(currentTime)));
         updatedWaitlist.addAll(waitlist);
         waitlist = updatedWaitlist;
         
         if (eventType.equals("ARRIVE")) {
            // Process customer arrival
            String customerId = (String)event[2];
            int partySize = (Integer)event[3];
            int vipStars = (Integer)event[4];
            boolean hasReservation = (Boolean)event[5];
            
            Customer newCustomer = new Customer(
                  customerId, partySize, vipStars, 
                  hasReservation, currentTime);
            waitlist.add(newCustomer);
         } else if (eventType.equals("TABLE_READY")) {
            // Seat customers at available table
            int tableSize = (Integer)event[2];
            List<Customer> temp = new ArrayList<>();
            Customer seated = null;
            
            while (!waitlist.isEmpty() && seated == null) {
               Customer customer = waitlist.poll();
               
               if (customer.partySize <= tableSize) {
                  seated = customer;
                  results.add(new Result(customer.id, 
                        currentTime));
               } else {
                  temp.add(customer);
               }
            }
            
            // Restore unseated customers
            waitlist.addAll(temp);
         }
      }
      
      return results;
   }
}
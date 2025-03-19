using System;
using System.Collections.Generic;

class Customer
{
   public string Id { get; }
   public int PartySize { get; }
   public int VipStars { get; }
   public bool HasReservation { get; }
   public int ArrivalTime { get; }

   public Customer(
      string id, 
      int partySize, 
      int vipStars,
      bool hasReservation, 
      int arrivalTime)
   {
      Id = id;
      PartySize = partySize;
      VipStars = vipStars;
      HasReservation = hasReservation;
      ArrivalTime = arrivalTime;
   }

   public int GetPriority(int currentTime)
   {
      int waitingTime = currentTime - ArrivalTime;
      return (VipStars * 10) + 
         (HasReservation ? 20 : 0) +
         waitingTime;
   }
}

class Result
{
   public string CustomerId { get; }
   public int SeatedTime { get; }

   public Result(string customerId, int seatedTime)
   {
      CustomerId = customerId;
      SeatedTime = seatedTime;
   }
}

public class RestaurantPrioritySeating
{
   public static List<Result> ManageSeating(
      List<int> tables,
      List<object[]> events)
   {
      events.Sort((e1, e2) => 
         ((int)e1[1]).CompareTo((int)e2[1]));

      var waitlist = new PriorityQueue<Customer>(
         Comparer<Customer>.Create((c1, c2) =>
            c2.GetPriority(0).CompareTo(c1.GetPriority(0))));

      List<Result> results = new List<Result>();

      foreach (object[] eventObj in events)
      {
         string eventType = (string)eventObj[0];
         int currentTime = (int)eventObj[1];

         var updatedWaitlist = new PriorityQueue<Customer>(
            Comparer<Customer>.Create((c1, c2) => 
               c2.GetPriority(currentTime)
                  .CompareTo(c1.GetPriority(currentTime))));

         foreach (Customer customer in waitlist)
         {
            updatedWaitlist.Enqueue(customer);
         }
         waitlist = updatedWaitlist;

         if (eventType == "ARRIVE")
         {
            string customerId = (string)eventObj[2];
            int partySize = (int)eventObj[3];
            int vipStars = (int)eventObj[4];
            bool hasReservation = (bool)eventObj[5];

            Customer newCustomer = new Customer(
               customerId, 
               partySize, 
               vipStars,
               hasReservation, 
               currentTime);
            waitlist.Enqueue(newCustomer);
         }
         else if (eventType == "TABLE_READY")
         {
            int tableSize = (int)eventObj[2];
            List<Customer> temp = new List<Customer>();
            Customer seated = null;

            while (waitlist.Count > 0 && seated == null)
            {
               Customer customer = waitlist.Dequeue();

               if (customer.PartySize <= tableSize)
               {
                  seated = customer;
                  results.Add(
                     new Result(
                        customer.Id,
                        currentTime));
               }
               else
               {
                  temp.Add(customer);
               }
            }

            foreach (Customer customer in temp)
            {
               waitlist.Enqueue(customer);
            }
         }
      }

      return results;
   }
}

using System;
using System.Collections.Generic;

class DetectiveCaseAssignment
{
   public class Case
   {
      public int Id { get; }
      public string Type { get; }
      public int Complexity { get; }

      public Case(int id, string type, int complexity)
      {
         Id = id;
         Type = type;
         Complexity = complexity;
      }
   }

   public class Assignment : IComparable<Assignment>
   {
      public double Time { get; }
      public int CaseId { get; }
      public List<int> DetectiveIds { get; }

      public Assignment(
         double time,
         int caseId,
         List<int> detectiveIds)
      {
         Time = time;
         CaseId = caseId;
         DetectiveIds = detectiveIds;
      }

      public int CompareTo(Assignment other)
      {
         return Time.CompareTo(other.Time);
      }
   }

   public static double SolveAllCases(
      int numDetectives,
      List<Case> cases,
      Dictionary<int, Dictionary<string, int>> expertise,
      Dictionary<List<int>, int> communicationOverhead)
   {
      List<Assignment> possibleAssignments =
         new List<Assignment>();

      foreach (Case c in cases)
      {
         for (int detective = 0; detective < numDetectives;
            detective++)
         {
            var detectiveExpertise = expertise[detective];
            if (detectiveExpertise.ContainsKey(c.Type))
            {
               double time = (double)c.Complexity /
                  detectiveExpertise[c.Type];
               possibleAssignments.Add(
                  new Assignment(
                     time,
                     c.Id,
                     new List<int> { detective }));
            }
         }
      }

      foreach (var entry in communicationOverhead)
      {
         List<int> pair = entry.Key;
         int overhead = entry.Value;
         int det1 = pair[0];
         int det2 = pair[1];

         foreach (Case c in cases)
         {
            if (expertise[det1].ContainsKey(c.Type) &&
               expertise[det2].ContainsKey(c.Type))
            {
               int combinedExpertise =
                  expertise[det1][c.Type] +
                  expertise[det2][c.Type];
               double time = (double)c.Complexity /
                  combinedExpertise + overhead;
               possibleAssignments.Add(
                  new Assignment(
                     time,
                     c.Id,
                     new List<int> { det1, det2 }));
            }
         }
      }

      possibleAssignments.Sort();

      HashSet<int> assignedCases = new HashSet<int>();
      HashSet<int> busyDetectives = new HashSet<int>();
      double parallelTime = 0;
      double sequentialTime = 0;

      while (assignedCases.Count < cases.Count)
      {
         bool madeAssignment = false;

         foreach (Assignment assignment
            in possibleAssignments)
         {
            if (assignedCases.Contains(assignment.CaseId))
            {
               continue;
            }

            bool detectivesAvailable = true;
            foreach (int detective
               in assignment.DetectiveIds)
            {
               if (busyDetectives.Contains(detective))
               {
                  detectivesAvailable = false;
                  break;
               }
            }

            if (detectivesAvailable)
            {
               assignedCases.Add(assignment.CaseId);
               busyDetectives.AddRange(
                  assignment.DetectiveIds);

               if (parallelTime < assignment.Time)
               {
                  sequentialTime +=
                     assignment.Time - parallelTime;
                  parallelTime = assignment.Time;
               }

               madeAssignment = true;
               break;
            }
         }

         if (!madeAssignment)
         {
            sequentialTime += parallelTime;
            parallelTime = 0;
            busyDetectives.Clear();
         }
      }

      return sequentialTime + parallelTime;
   }
}

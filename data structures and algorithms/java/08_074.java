import java.util.*;

class DetectiveCaseAssignment {
   static class Case {
      int id;
      String type;
      int complexity;
      
      Case(int id, String type, int complexity) {
         this.id = id;
         this.type = type;
         this.complexity = complexity;
      }
   }
   
   static class Assignment implements Comparable<Assignment> {
      double time;
      int caseId;
      List<Integer> detectiveIds;
      
      Assignment(double time, int caseId, 
            List<Integer> detectiveIds) {
         this.time = time;
         this.caseId = caseId;
         this.detectiveIds = detectiveIds;
      }
      
      @Override
      public int compareTo(Assignment other) {
         return Double.compare(this.time, other.time);
      }
   }
   
   public static double solveAllCases(int numDetectives, 
         List<Case> cases,
         Map<Integer, Map<String, Integer>> expertise,
         Map<List<Integer>, Integer> communicationOverhead) {
      // Generate possible assignments
      List<Assignment> possibleAssignments = 
            new ArrayList<>();
      
      // Individual detective assignments
      for (Case c : cases) {
         for (int detective = 0; detective < numDetectives; 
               detective++) {
            Map<String, Integer> detectiveExpertise = 
                  expertise.get(detective);
            if (detectiveExpertise.containsKey(c.type)) {
               double time = (double) c.complexity / 
                     detectiveExpertise.get(c.type);
               possibleAssignments.add(
                     new Assignment(time, c.id, 
                           Arrays.asList(detective)));
            }
         }
      }
      
      // Collaborative assignments
      for (Map.Entry<List<Integer>, Integer> entry : 
            communicationOverhead.entrySet()) {
         List<Integer> pair = entry.getKey();
         int overhead = entry.getValue();
         int det1 = pair.get(0);
         int det2 = pair.get(1);
         
         for (Case c : cases) {
            if (expertise.get(det1).containsKey(c.type) && 
                  expertise.get(det2).containsKey(c.type)) {
               int combinedExpertise = 
                     expertise.get(det1).get(c.type) + 
                     expertise.get(det2).get(c.type);
               double time = (double) c.complexity / 
                     combinedExpertise + overhead;
               possibleAssignments.add(
                     new Assignment(time, c.id, 
                           Arrays.asList(det1, det2)));
            }
         }
      }
      
      // Sort assignments by time
      Collections.sort(possibleAssignments);
      
      // Track case and detective assignments
      Set<Integer> assignedCases = new HashSet<>();
      Set<Integer> busyDetectives = new HashSet<>();
      double parallelTime = 0;
      double sequentialTime = 0;
      
      // Assign cases optimally
      while (assignedCases.size() < cases.size()) {
         boolean madeAssignment = false;
         
         for (Assignment assignment : possibleAssignments) {
            // Skip already assigned cases
            if (assignedCases.contains(assignment.caseId)) {
               continue;
            }
            
            // Check detective availability
            boolean detectivesAvailable = true;
            for (int detective : assignment.detectiveIds) {
               if (busyDetectives.contains(detective)) {
                  detectivesAvailable = false;
                  break;
               }
            }
            
            // Assign case if possible
            if (detectivesAvailable) {
               assignedCases.add(assignment.caseId);
               busyDetectives.addAll(assignment.detectiveIds);
               
               // Update time tracking
               if (parallelTime < assignment.time) {
                  sequentialTime += assignment.time - parallelTime;
                  parallelTime = assignment.time;
               }
               
               madeAssignment = true;
               break;
            }
         }
         
         // Reset if no assignment possible
         if (!madeAssignment) {
            sequentialTime += parallelTime;
            parallelTime = 0;
            busyDetectives.clear();
         }
      }
      
      return sequentialTime + parallelTime;
   }
}
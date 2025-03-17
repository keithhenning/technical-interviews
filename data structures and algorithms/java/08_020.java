import java.util.*;

class Evidence {
    String id;
    int importance;
    int processingTime;
    int daysUntilExpiration;
    
    public Evidence(String id, int importance, int processingTime, 
                   int daysUntilExpiration) {
        this.id = id;
        this.importance = importance;
        this.processingTime = processingTime;
        this.daysUntilExpiration = daysUntilExpiration;
    }
    
    public double getPriority(int currentDay) {
        int daysLeft = daysUntilExpiration - currentDay;
        if (daysLeft <= 0) return Double.NEGATIVE_INFINITY;
        return (importance / (double)processingTime) * 
               (1.0 / daysLeft);
    }
}

public class EvidenceProcessor {
    public static List<String> processEvidence(List<Evidence> evidence, 
                                             int hoursPerDay) {
        List<String> processingOrder = new ArrayList<>();
        int currentDay = 0;
        int hoursLeftToday = hoursPerDay;
        
        // Max heap
        PriorityQueue<Evidence> evidenceQueue = new PriorityQueue<>(
            (e1, e2) -> Double.compare(e2.getPriority(currentDay), 
                                      e1.getPriority(currentDay)));
        
        evidenceQueue.addAll(evidence);
        
        while (!evidenceQueue.isEmpty()) {
            Evidence item = evidenceQueue.poll();
            
            if (item.daysUntilExpiration <= currentDay) {
                continue;
            }
            
            processingOrder.add(item.id);
            
            int remainingTime = item.processingTime;
            while (remainingTime > 0) {
                if (hoursLeftToday >= remainingTime) {
                    hoursLeftToday -= remainingTime;
                    remainingTime = 0;
                } else {
                    remainingTime -= hoursLeftToday;
                    currentDay++;
                    hoursLeftToday = hoursPerDay;
                    
                    // Reorder queue with updated priorities
                    List<Evidence> remaining = new ArrayList<>();
                    while (!evidenceQueue.isEmpty()) {
                        remaining.add(evidenceQueue.poll());
                    }
                    
                    evidenceQueue = new PriorityQueue<>((e1, e2) -> 
                        Double.compare(e2.getPriority(currentDay), 
                                      e1.getPriority(currentDay)));
                    
                    for (Evidence e : remaining) {
                        if (e.daysUntilExpiration > currentDay) {
                            evidenceQueue.add(e);
                        }
                    }
                }
            }
        }
        
        return processingOrder;
    }
}
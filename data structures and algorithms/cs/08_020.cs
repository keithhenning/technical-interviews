using System;
using System.Collections.Generic;

class Evidence {
    public string Id { get; set; }
    public int Importance { get; set; }
    public int ProcessingTime { get; set; }
    public int DaysUntilExpiration { get; set; }

    public Evidence(string id, int importance, int processingTime, int daysUntilExpiration) {
        Id = id;
        Importance = importance;
        ProcessingTime = processingTime;
        DaysUntilExpiration = daysUntilExpiration;
    }

    public double GetPriority(int currentDay) {
        int daysLeft = DaysUntilExpiration - currentDay;
        if (daysLeft <= 0) return double.NegativeInfinity;
        return (Importance / (double)ProcessingTime) * (1.0 / daysLeft);
    }
}

public class EvidenceProcessor {
    public static List<string> ProcessEvidence(List<Evidence> evidence, int hoursPerDay) {
        var processingOrder = new List<string>();
        int currentDay = 0;
        int hoursLeftToday = hoursPerDay;

        var evidenceQueue = new PriorityQueue<Evidence>((e1, e2) => e2.GetPriority(currentDay).CompareTo(e1.GetPriority(currentDay)));
        evidenceQueue.AddRange(evidence);

        while (evidenceQueue.Count > 0) {
            var item = evidenceQueue.Dequeue();

            if (item.DaysUntilExpiration <= currentDay) {
                continue;
            }

            processingOrder.Add(item.Id);

            int remainingTime = item.ProcessingTime;
            while (remainingTime > 0) {
                if (hoursLeftToday >= remainingTime) {
                    hoursLeftToday -= remainingTime;
                    remainingTime = 0;
                } else {
                    remainingTime -= hoursLeftToday;
                    currentDay++;
                    hoursLeftToday = hoursPerDay;

                    var remaining = new List<Evidence>();
                    while (evidenceQueue.Count > 0) {
                        remaining.Add(evidenceQueue.Dequeue());
                    }

                    evidenceQueue = new PriorityQueue<Evidence>((e1, e2) => e2.GetPriority(currentDay).CompareTo(e1.GetPriority(currentDay)));
                    foreach (var e in remaining) {
                        if (e.DaysUntilExpiration > currentDay) {
                            evidenceQueue.Enqueue(e);
                        }
                    }
                }
            }
        }

        return processingOrder;
    }
}
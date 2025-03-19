using System;
using System.Collections.Generic;

class Task {
    public string Id { get; set; }
    public int Priority { get; set; }
    public int ResourceNeeds { get; set; }
    public int Deadline { get; set; }

    public Task(string id, int priority, int resourceNeeds, int deadline) {
        Id = id;
        Priority = priority;
        ResourceNeeds = resourceNeeds;
        Deadline = deadline;
    }
}

public class AdaptiveResourceScheduler {
    public static List<string> ScheduleTasks(List<Task> tasks) {
        tasks.Sort((a, b) => {
            if (a.Priority != b.Priority) {
                return b.Priority - a.Priority;
            }
            return a.Deadline - b.Deadline;
        });

        var result = new List<string>();
        int currentTime = 0;

        foreach (var task in tasks) {
            result.Add(task.Id);
            currentTime += task.ResourceNeeds;
        }

        return result;
    }

    public static void Main(string[] args) {
        var tasks = new List<Task> {
            new Task("T1", 3, 5, 10),
            new Task("T2", 5, 3, 5),
            new Task("T3", 2, 2, 7),
            new Task("T4", 5, 1, 3)
        };

        var schedule = ScheduleTasks(tasks);
        Console.WriteLine("Task execution order: " + string.Join(", ", schedule));
    }
}
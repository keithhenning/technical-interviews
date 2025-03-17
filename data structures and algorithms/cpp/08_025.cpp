#include <iostream>
#include <vector>
#include <string>
#include <algorithm>

struct Task {
    std::string id;
    int priority;
    int resourceNeeds;
    int deadline;
    
    Task(std::string id, int priority, 
         int resourceNeeds, int deadline)
        : id(id), priority(priority), 
          resourceNeeds(resourceNeeds), 
          deadline(deadline) {}
};

std::vector<std::string> scheduleTasks(
        std::vector<Task>& tasks) {
    // Sort by priority (desc) then by deadline (asc)
    std::sort(tasks.begin(), tasks.end(), 
        [](const Task& a, const Task& b) {
            if (a.priority != b.priority) {
                return a.priority > b.priority; // Desc priority
            }
            return a.deadline < b.deadline; // Asc deadline
        });
    
    // Result vector to store tasks in execution order
    std::vector<std::string> result;
    
    // Current time tracker
    int currentTime = 0;
    
    // Schedule each task
    for (const Task& task : tasks) {
        result.push_back(task.id);
        currentTime += task.resourceNeeds;
    }
    
    return result;
}

int main() {
    std::vector<Task> tasks = {
        Task("T1", 3, 5, 10),
        Task("T2", 5, 3, 5),
        Task("T3", 2, 2, 7),
        Task("T4", 5, 1, 3)
    };
    
    std::vector<std::string> schedule = 
        scheduleTasks(tasks);
    
    // Print result
    std::cout << "[";
    for (size_t i = 0; i < schedule.size(); i++) {
        std::cout << schedule[i];
        if (i < schedule.size() - 1) {
            std::cout << ", ";
        }
    }
    std::cout << "]" << std::endl; // Output: [T4, T2, T1, T3]
    
    return 0;
}
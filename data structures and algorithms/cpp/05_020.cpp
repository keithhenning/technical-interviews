#include <queue>
#include <string>

class TaskScheduler {
private:
    std::queue<std::string> task_queue;
        
public:
    void add_task(const std::string& task) {
        task_queue.push(task);
    }
        
    void process_tasks() {
        while (!task_queue.empty()) {
            std::string current_task = task_queue.front();
            task_queue.pop();
            // Process task here
        }
    }
};
from collections import deque

class TaskScheduler:
    def __init__(self):
        self.task_queue = deque()
        
    def add_task(self, task):
        self.task_queue.append(task)
        
    def process_tasks(self):
        while self.task_queue:
            current_task = self.task_queue.popleft()
            # Process task here
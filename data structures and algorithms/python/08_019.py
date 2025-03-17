from collections import defaultdict, deque

class RateLimiter:
  def __init__(self, message_limit, time_window):
     self.message_limit = message_limit
     self.time_window = time_window
     self.user_messages = defaultdict(deque)
  
  def can_send(self, user_id, timestamp):
     message_queue = self.user_messages[user_id]
     while (message_queue and 
           message_queue[0] <= timestamp - self.time_window):
        message_queue.popleft()
     
     if len(message_queue) < self.message_limit:
        message_queue.append(timestamp)
        return True
     
     return False
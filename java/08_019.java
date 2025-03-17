import java.util.*;

public class RateLimiter {
    private final int messageLimit;
    private final int timeWindow;
    private final Map<String, Deque<Integer>> userMessages;
    
    public RateLimiter(int messageLimit, int timeWindow) {
        this.messageLimit = messageLimit;
        this.timeWindow = timeWindow;
        this.userMessages = new HashMap<>();
    }
    
    public boolean canSend(String userId, int timestamp) {
        // Initialize queue for new users
        if (!userMessages.containsKey(userId)) {
            userMessages.put(userId, new LinkedList<>());
        }
        
        Deque<Integer> messageQueue = userMessages.get(userId);
        
        // Remove messages outside the current time window
        while (!messageQueue.isEmpty() && 
               messageQueue.peekFirst() <= timestamp - timeWindow) {
            messageQueue.pollFirst();
        }
        
        // Check if adding a new message would exceed the limit
        if (messageQueue.size() < messageLimit) {
            messageQueue.addLast(timestamp);
            return true;
        }
        
        return false;
    }
}
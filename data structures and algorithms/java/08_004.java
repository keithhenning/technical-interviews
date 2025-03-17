import java.util.*;

public List<String> topKTrendingHashtags(String[] hashtags, 
                                         int k) {
    // Count frequencies
    Map<String, Integer> counter = new HashMap<>();
    for (String tag : hashtags) {
        counter.put(tag, counter.getOrDefault(tag, 0) + 1);
    }
    
    // Use priority queue (min heap)
    PriorityQueue<String> heap = new PriorityQueue<>(
        (a, b) -> counter.get(a) - counter.get(b)
    );
    
    for (String tag : counter.keySet()) {
        heap.add(tag);
        if (heap.size() > k) {
            heap.poll();
        }
    }
    
    // Build result list
    List<String> result = new ArrayList<>();
    while (!heap.isEmpty()) {
        result.add(0, heap.poll());
    }
    
    return result;
}
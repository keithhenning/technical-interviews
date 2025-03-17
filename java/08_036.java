import java.util.HashMap;
import java.util.Map;

public boolean hasFrequencyThreshold(int[] nums, int k) {
    Map<Integer, Integer> counter = new HashMap<>();
    
    for (int num : nums) {
        counter.put(num, counter.getOrDefault(num, 0) + 1);
        if (counter.get(num) >= k) {
            return true;
        }
    }
    
    return false;
}
import java.util.HashSet;

public class RangeDuplicateFinder {
    public static boolean hasNearbyDuplicates(int[] nums, int k) {
        HashSet<Integer> window = new HashSet<>();
        
        for (int i = 0; i < nums.length; i++) {
            if (i >= k) {
                window.remove(nums[i - k]);
            }
            
            if (window.contains(nums[i])) {
                return true;
            }
            
            window.add(nums[i]);
        }
        
        return false;
    }
}
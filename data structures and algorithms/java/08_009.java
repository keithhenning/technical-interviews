import java.util.HashMap;
import java.util.Arrays;
import java.util.Map;

public class TwoSum {
    public static int[] twoSum(int[] nums, int target) {
        Map<Integer, Integer> numMap = new HashMap<>();
        
        for (int i = 0; i < nums.length; i++) {
            int complement = target - nums[i];
            
            if (numMap.containsKey(complement)) {
                return new int[]{numMap.get(complement), i};
            }
            
            numMap.put(nums[i], i);
        }
        
        return null;  // No solution found
    }
    
    public static void main(String[] args) {
        System.out.println(Arrays.toString(
            twoSum(new int[]{2, 7, 11, 15}, 9)));  // [0, 1]
        System.out.println(Arrays.toString(
            twoSum(new int[]{3, 2, 4}, 6)));       // [1, 2]
    }
}
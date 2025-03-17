class Solution {
public:
    int minProcessingPower(vector<int>& tasks, 
                          int maxSeconds) {
        int maxTask = *max_element(tasks.begin(), 
                                  tasks.end());
        
        int left = 1;
        int right = maxTask;
        
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (canComplete(tasks, mid, maxSeconds)) {
                right = mid;
            } else {
                left = mid + 1;
            }
        }
        
        return left;
    }
    
private:
    bool canComplete(const vector<int>& tasks, 
                    int power, int maxSeconds) {
        int totalTime = 0;
        for (int task : tasks) {
            // Ceiling division in C++
            totalTime += (task + power - 1) / power;
        }
        return totalTime <= maxSeconds;
    }
};
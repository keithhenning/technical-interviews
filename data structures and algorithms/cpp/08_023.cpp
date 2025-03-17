#include <iostream>
#include <vector>
#include <algorithm>

int minTeamMembers(std::vector<std::vector<int>>& intervals, 
                  int K) {
    // Sort intervals by start time
    std::sort(intervals.begin(), intervals.end(), 
        [](const std::vector<int>& a, 
           const std::vector<int>& b) {
            return a[0] < b[0];
        });
    
    // Keep track of covered intervals
    std::vector<bool> covered(intervals.size(), false);
    int teamCount = 0;
    
    while (std::find(covered.begin(), covered.end(), 
                    false) != covered.end()) {
        teamCount++;
        
        // Find the earliest uncovered interval
        int earliestUncovered = -1;
        for (int i = 0; i < intervals.size(); i++) {
            if (!covered[i]) {
                earliestUncovered = i;
                break;
            }
        }
        
        if (earliestUncovered == -1) {
            break;
        }
        
        // Start shift at beginning of earliest interval
        int shiftStart = intervals[earliestUncovered][0];
        int shiftEnd = shiftStart + K;
        
        // Cover all intervals that fit within this shift
        for (int i = 0; i < intervals.size(); i++) {
            if (!covered[i] && 
                intervals[i][0] >= shiftStart && 
                intervals[i][1] <= shiftEnd) {
                covered[i] = true;
            }
        }
    }
    
    return teamCount;
}

int main() {
    std::vector<std::vector<int>> intervals = 
        {{1, 3}, {2, 5}, {6, 8}, {8, 10}, {11, 12}};
    int K = 5;
    std::cout << minTeamMembers(intervals, K) << std::endl;
    return 0;
}
#include <vector>
#include <algorithm>

int minProcessingSpeed(std::vector<int>& batches, int h) {
    int left = 1;
    int right = *std::max_element(
        batches.begin(), 
        batches.end()
    );
    
    auto canComplete = [&](int speed) {
        int hours = 0;
        for (int batch : batches) {
            // Ceiling division
            hours += (batch + speed - 1) / speed;
        }
        return hours <= h;
    };
    
    while (left < right) {
        int mid = left + (right - left) / 2;
        if (canComplete(mid)) {
            right = mid;
        } else {
            left = mid + 1;
        }
    }
    
    return left;
}
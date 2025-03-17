#include <vector>
#include <algorithm>

int countConvoys(int target, std::vector<int>& positions, std::vector<int>& speeds) {
    int n = positions.size();
    std::vector<std::pair<int, int>> cars;
    
    // Create pairs of position and speed
    for (int i = 0; i < n; i++) {
        cars.push_back({positions[i], speeds[i]});
    }
    
    // Sort by position in descending order
    std::sort(cars.begin(), cars.end(), [](auto& a, auto& b) {
        return a.first > b.first;
    });
    
    int convoys = 0;
    double prevTime = -1;
    
    for (auto& car : cars) {
        double position = car.first;
        double speed = car.second;
        double time = (target - position) / speed;
        
        if (time > prevTime) {
            convoys++;
            prevTime = time;
        }
    }
    
    return convoys;
}
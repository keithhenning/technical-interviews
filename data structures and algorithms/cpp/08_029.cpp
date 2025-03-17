#include <iostream>
#include <vector>
#include <queue>
#include <deque>
#include <algorithm>
#include <functional>
#include <utility>

struct Point {
    int x, y;
    
    Point(int x, int y) : x(x), y(y) {}
    
    int distanceToOrigin() const {
        return x*x + y*y;
    }
    
    bool operator==(const Point& other) const {
        return x == other.x && y == other.y;
    }
    
    friend std::ostream& operator<<(
            std::ostream& os, 
            const Point& p) {
        os << "(" << p.x << ", " << p.y << ")";
        return os;
    }
};

class KNearestInWindow {
private:
    int windowSize;
    int k;
    std::deque<Point> window;
    
    // Max heap for k-nearest points 
    // (we use greater for a max heap of distances)
    using DistancePointPair = std::pair<int, Point>;
    std::priority_queue<DistancePointPair> heap;
    
public:
    KNearestInWindow(int windowSize, int k) 
        : windowSize(windowSize), k(k) {}
    
    void addPoint(const Point& point) {
        int dist = point.distanceToOrigin();
        
        // Add point to window
        window.push_back(point);
        
        // Remove oldest point if window is too large
        if (window.size() > windowSize) {
            Point oldest = window.front();
            window.pop_front();
            
            // Check if oldest point was in heap
            bool inHeap = false;
            std::priority_queue<DistancePointPair> tempHeap;
            while (!heap.empty()) {
                auto top = heap.top();
                heap.pop();
                
                if (top.second == oldest) {
                    inHeap = true;
                } else {
                    tempHeap.push(top);
                }
            }
            
            heap = std::move(tempHeap);
            
            // If oldest point was in heap, rebuild
            if (inHeap) {
                rebuildHeap();
            }
        }
        
        // Add new point to heap if it's closer than the 
        // farthest point or if heap isn't full yet
        if (heap.size() < k) {
            heap.push({dist, point});
        } else if (dist < heap.top().first) {
            heap.pop();
            heap.push({dist, point});
        }
    }
    
    void rebuildHeap() {
        // Clear heap
        while (!heap.empty()) {
            heap.pop();
        }
        
        // Create a vector of (distance, point) pairs
        std::vector<DistancePointPair> points;
        for (const auto& p : window) {
            points.push_back({p.distanceToOrigin(), p});
        }
        
        // Sort by distance
        std::sort(
            points.begin(), 
            points.end(), 
            [](const DistancePointPair& a, 
               const DistancePointPair& b) {
                return a.first < b.first;
            }
        );
        
        // Add k closest points to heap
        for (int i = 0; 
             i < std::min(k, (int)points.size()); 
             i++) {
            heap.push(points[i]);
        }
    }
    
    std::vector<Point> getKNearest() {
        // Copy heap elements
        auto tempHeap = heap;
        std::vector<DistancePointPair> pairs;
        
        while (!tempHeap.empty()) {
            pairs.push_back(tempHeap.top());
            tempHeap.pop();
        }
        
        // Sort by distance (ascending)
        std::sort(
            pairs.begin(), 
            pairs.end(), 
            [](const DistancePointPair& a, 
               const DistancePointPair& b) {
                return a.first < b.first;
            }
        );
        
        // Extract points
        std::vector<Point> result;
        for (const auto& pair : pairs) {
            result.push_back(pair.second);
        }
        
        return result;
    }
};

int main() {
    std::vector<std::pair<int, int>> points = {
        {1, 2}, {3, 4}, {0, 1}, {5, 2}, 
        {2, 0}, {1, 5}, {3, 1}
    };
    int windowSize = 5;
    int k = 3;
    
    KNearestInWindow knn(windowSize, k);
    for (const auto& p : points) {
        knn.addPoint(Point(p.first, p.second));
    }
    
    auto result = knn.getKNearest();
    
    std::cout << "[";
    for (size_t i = 0; i < result.size(); i++) {
        std::cout << result[i];
        if (i < result.size() - 1) {
            std::cout << ", ";
        }
    }
    std::cout << "]" << std::endl;
    
    return 0;
}
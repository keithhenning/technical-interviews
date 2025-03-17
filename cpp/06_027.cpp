// Define the Node structure for A* algorithm
struct Node {
   // Node position in the grid
   std::vector<int> position;
   // Cost from start to current node
   double gScore;
   // Estimated total cost (g + heuristic)
   double fScore;
   
   // Constructor
   Node(const std::vector<int>& pos, double g, double f)
      : position(pos), gScore(g), fScore(f) {}
   
   // Comparison operator for priority queue (min heap)
   bool operator>(const Node& other) const {
      return fScore > other.fScore;
   }
};

// Use a priority_queue instead of sorting open set
std::priority_queue<Node, std::vector<Node>, 
                  std::greater<Node>> openSet;

// Add nodes with their scores
openSet.push(Node(nodePosition, gScore, fScore));

// Get the node with lowest f-score
Node current = openSet.top();
openSet.pop();
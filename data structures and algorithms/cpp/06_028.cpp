// A* implementation with iteration limit
static std::vector<std::vector<int>> astarWithMaxIterations(
      const std::vector<std::vector<int>>& grid, 
      const std::vector<int>& start, 
      const std::vector<int>& goal, 
      int maxIter) {
   
   // Counter for iterations
   int iterations = 0;
   
   // Priority queue for open set
   std::priority_queue<Node, std::vector<Node>, 
                     std::greater<Node>> openSet;
   // Initialize with start node and heuristic
   openSet.push(Node(start, 0, 
               manhattanDistance(start, goal)));
   
   // Continue while nodes exist and within iteration limit
   while (!openSet.empty() && iterations < maxIter) {
      // ... normal A* code ...
      iterations++;
   }
   
   // Path not found within iteration limit
   return std::vector<std::vector<int>>();
}
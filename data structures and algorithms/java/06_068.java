// Creating a course prerequisite graph
Graph g = new Graph(6);  // 6 courses numbered 0 to 5

// Adding prerequisites (edges)
// Algorithms requires Data Structures
g.addEdge(5, 2);  
// Algorithms requires Programming Basics
g.addEdge(5, 0);  
// Advanced Programming requires Programming Basics
g.addEdge(4, 0);  
// Advanced Programming requires Computer Architecture
g.addEdge(4, 1);  
// Data Structures requires Discrete Math
g.addEdge(2, 3);  
// Discrete Math requires Computer Architecture
g.addEdge(3, 1);  

// Get course order using Kahn's algorithm
List<Integer> courseOrder = g.topologicalSortKahn();
System.out.println("Course order: " + courseOrder);

// Get course order using DFS
courseOrder = g.topologicalSortDFS();
System.out.println("Course order: " + courseOrder);
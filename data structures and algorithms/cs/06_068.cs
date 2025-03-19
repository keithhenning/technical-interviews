using System;
using System.Collections.Generic;

Graph g = new Graph(6);  // 6 courses numbered 0 to 5

// Adding prerequisites (edges)
g.AddEdge(5, 2);  // Algorithms -> Data Structures
g.AddEdge(5, 0);  // Algorithms -> Programming Basics
g.AddEdge(4, 0);  // Advanced Programming -> Basics
g.AddEdge(4, 1);  // Advanced Programming -> Architecture
g.AddEdge(2, 3);  // Data Structures -> Discrete Math
g.AddEdge(3, 1);  // Discrete Math -> Architecture

// Get course order using Kahn's algorithm
var courseOrder = g.TopologicalSortKahn();
Console.WriteLine(
   "Course order: " + string.Join(", ", courseOrder)
);

// Get course order using DFS
courseOrder = g.TopologicalSortDFS();
Console.WriteLine(
   "Course order: " + string.Join(", ", courseOrder)
);
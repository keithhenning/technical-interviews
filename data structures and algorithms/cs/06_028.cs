// Use a PriorityQueue instead of sorting open set
PriorityQueue<Node> openSet = new PriorityQueue<Node>(
   Comparer<Node>.Create((n1, n2) =>
   n1.FScore.CompareTo(n2.FScore))
   );
// Add nodes with their scores
openSet.Enqueue(new Node(nodePosition, gScore, fScore));
// Get the node with lowest f-score
Node current = openSet.Dequeue();
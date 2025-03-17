// Use a PriorityQueue instead of sorting open set
PriorityQueue<Node> openSet = new PriorityQueue<>(Comparator.comparing(n -> n.fScore));
// Add nodes with their scores
openSet.add(new Node(nodePosition, gScore, fScore));
// Get the node with lowest f-score
Node current = openSet.poll();
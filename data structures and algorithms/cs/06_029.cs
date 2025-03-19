/**
 * A* pathfinding with iteration limit
 */
public static List<int[]> AstarWithMaxIterations(int[][] grid, int[] start, int[] goal, int maxIter)
{
    // Track number of algorithm iterations
    int iterations = 0;

    // Initialize priority queue for open nodes
    PriorityQueue<Node> openSet = new PriorityQueue<Node>();
    openSet.Enqueue(new Node(start, 0, ManhattanDistance(start, goal)));

    // Set up other data structures
    Dictionary<string, int[]> cameFrom = new Dictionary<string, int[]>();
    Dictionary<string, int> gScore = new Dictionary<string, int>();
    gScore[JsonConvert.SerializeObject(start)] = 0;
    HashSet<string> closedSet = new HashSet<string>();

    // Process nodes while available and within limit
    while (openSet.Count > 0 && iterations < maxIter)
    {
        // Normal A* algorithm code would go here
        // ...

        // Increment iteration counter
        iterations++;
    }

    // Return null if path not found within iteration limit
    return null;
}

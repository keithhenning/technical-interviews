import java.util.*;

class Request {
    int id;
    int size;
    
    public Request(int id, int size) {
        this.id = id;
        this.size = size;
    }
}

class Server {
    int id;
    int capacity;
    int currentLoad;
    int lastActive;
    
    public Server(int id, int capacity) {
        this.id = id;
        this.capacity = capacity;
        this.currentLoad = 0;
        this.lastActive = 0;
    }
}

class ServerLoad implements Comparable<ServerLoad> {
    int load;
    int lastActive;
    int serverId;
    
    public ServerLoad(int load, int lastActive, int serverId) {
        this.load = load;
        this.lastActive = lastActive;
        this.serverId = serverId;
    }
    
    @Override
    public int compareTo(ServerLoad other) {
        if (this.load != other.load) {
            return Integer.compare(this.load, other.load);
        }
        // If loads are equal, prefer server that has been 
        // idle longer (smaller lastActive)
        return Integer.compare(this.lastActive, other.lastActive);
    }
}

public class LoadBalancer {
    public static List<int[]> assignRequests(List<Request> requests, 
                                           List<Server> servers) {
        // Create a map from server ID to Server object
        Map<Integer, Server> serverMap = new HashMap<>();
        for (Server server : servers) {
            serverMap.put(server.id, server);
        }
        
        // Initialize priority queue for servers
        PriorityQueue<ServerLoad> serverHeap = 
            new PriorityQueue<>();
        for (Server server : servers) {
            serverHeap.add(new ServerLoad(0, 0, server.id));
        }
        
        List<int[]> assignments = new ArrayList<>();
        int currentTime = 0;
        
        for (Request request : requests) {
            currentTime++;
            
            // Get least loaded server
            if (serverHeap.isEmpty()) {
                break; // No available servers
            }
            
            ServerLoad sl = serverHeap.poll();
            Server server = serverMap.get(sl.serverId);
            
            // Check if server has capacity for this request
            if (server.currentLoad + request.size <= 
                server.capacity) {
                // Assign request to server
                server.currentLoad += request.size;
                server.lastActive = currentTime;
                assignments.add(new int[]{server.id, request.id});
                
                // Put server back in heap with updated load
                serverHeap.add(new ServerLoad(server.currentLoad, 
                              -currentTime, server.id));
            }
        }
        
        return assignments;
    }
}
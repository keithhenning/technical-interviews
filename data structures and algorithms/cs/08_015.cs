using System;
using System.Collections.Generic;

class Request {
    public int Id { get; set; }
    public int Size { get; set; }

    public Request(int id, int size) {
        Id = id;
        Size = size;
    }
}

class Server {
    public int Id { get; set; }
    public int Capacity { get; set; }
    public int CurrentLoad { get; set; }
    public int LastActive { get; set; }

    public Server(int id, int capacity) {
        Id = id;
        Capacity = capacity;
        CurrentLoad = 0;
        LastActive = 0;
    }
}

class ServerLoad : IComparable<ServerLoad> {
    public int Load { get; set; }
    public int LastActive { get; set; }
    public int ServerId { get; set; }

    public ServerLoad(int load, int lastActive, int serverId) {
        Load = load;
        LastActive = lastActive;
        ServerId = serverId;
    }

    public int CompareTo(ServerLoad other) {
        if (Load != other.Load) {
            return Load.CompareTo(other.Load);
        }
        // If loads are equal, prefer server that has been 
        // idle longer (smaller lastActive)
        return LastActive.CompareTo(other.LastActive);
    }
}

public class LoadBalancer {
    public static List<int[]> AssignRequests(List<Request> requests, List<Server> servers) {
        // Create a map from server ID to Server object
        var serverMap = new Dictionary<int, Server>();
        foreach (var server in servers) {
            serverMap[server.Id] = server;
        }

        // Initialize priority queue for servers
        var serverHeap = new SortedSet<ServerLoad>();
        foreach (var server in servers) {
            serverHeap.Add(new ServerLoad(0, 0, server.Id));
        }

        var assignments = new List<int[]>();
        int currentTime = 0;

        foreach (var request in requests) {
            currentTime++;

            // Get least loaded server
            if (serverHeap.Count == 0) {
                break; // No available servers
            }

            var sl = serverHeap.Min;
            serverHeap.Remove(sl);
            var server = serverMap[sl.ServerId];

            // Check if server has capacity for this request
            if (server.CurrentLoad + request.Size <= server.Capacity) {
                // Assign request to server
                server.CurrentLoad += request.Size;
                server.LastActive = currentTime;
                assignments.Add(new int[] { server.Id, request.Id });

                // Put server back in heap with updated load
                serverHeap.Add(new ServerLoad(server.CurrentLoad, -currentTime, server.Id));
            }
        }

        return assignments;
    }
}
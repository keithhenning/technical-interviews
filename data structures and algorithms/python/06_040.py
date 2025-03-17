def find_fastest_delivery_route(restaurants, customer, traffic_data):
    graph = Graph()
    
    # Add roads with current traffic conditions
    for road, traffic in traffic_data.items():
        start, end = road
        time = calculate_travel_time(traffic)
        graph.add_edge(start, end, time)
    
    # Find fastest route from restaurant to customer
    distances, path = graph.dijkstra(restaurants)
    return path[customer]
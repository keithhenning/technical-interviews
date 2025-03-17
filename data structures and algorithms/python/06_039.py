def test_dijkstra():
   # Test Case 1: Simple path
   # Verify basic shortest path functionality
   g1 = Graph()
   g1.add_edge('Dallas', 'Chicago', 920)
   g1.add_edge('Dallas', 'Memphis', 410)
   g1.add_edge('Chicago', 'Boston', 850)
   g1.add_edge('Memphis', 'Boston', 1200)
   g1.add_edge('Memphis', 'Chicago', 480)
   
   distances, paths = g1.dijkstra('Dallas')
   assert distances == {
      'Dallas': 0, 
      'Chicago': 890, 
      'Memphis': 410, 
      'Boston': 1740
   }, "Test case 1 distances failed"
   assert paths == {
      'Dallas': ['Dallas'],
      'Chicago': ['Dallas', 'Memphis', 'Chicago'],
      'Memphis': ['Dallas', 'Memphis'],
      'Boston': ['Dallas', 'Memphis', 'Chicago', 'Boston']
   }, "Test case 1 paths failed"
   print("Test case 1 passed!")
   
   # Test Case 2: Disconnected graph
   # Check handling of unreachable nodes
   g2 = Graph()
   g2.add_edge('Dallas', 'Chicago', 920)
   g2.add_edge('Atlanta', 'Miami', 610)
   
   distances, paths = g2.dijkstra('Dallas')
   assert distances['Chicago'] == 920, (
      "Test case 2 reachable distance failed"
   )
   assert distances['Atlanta'] == float('infinity'), (
      "Test case 2 unreachable distance failed"
   )
   assert distances['Miami'] == float('infinity'), (
      "Test case 2 unreachable distance failed"
   )
   assert (
      'Atlanta' not in paths and 
      'Miami' not in paths
   ), "Test case 2 unreachable paths failed"
   print("Test case 2 passed!")
   
   # Test Case 3: Cyclic graph
   # Verify handling of graph with cycles
   g3 = Graph()
   g3.add_edge('Dallas', 'Chicago', 920)
   g3.add_edge('Chicago', 'Atlanta', 590)
   g3.add_edge('Atlanta', 'Dallas', 780)
   g3.add_edge('Chicago', 'Boston', 850)
   
   distances, paths = g3.dijkstra('Dallas')
   assert distances == {
      'Dallas': 0, 
      'Chicago': 920, 
      'Atlanta': 1510, 
      'Boston': 1770
   }, "Test case 3 distances failed"
   assert paths['Boston'] == [
      'Dallas', 'Chicago', 'Boston'
   ], "Test case 3 paths failed"
   print("Test case 3 passed!")
   
   # Test Case 4: Multiple paths to same destination
   # Check shortest path selection
   g4 = Graph()
   g4.add_edge('Dallas', 'Chicago', 920)
   g4.add_edge('Dallas', 'Memphis', 410)
   g4.add_edge('Chicago', 'Boston', 850)
   g4.add_edge('Memphis', 'Boston', 1400)
   g4.add_edge('Dallas', 'Boston', 1800)
   
   distances, paths = g4.dijkstra('Dallas')
   assert distances['Boston'] == 1770, (
      "Test case 4 distance failed"
   )
   assert paths['Boston'] == [
      'Dallas', 'Chicago', 'Boston'
   ], "Test case 4 path failed"
   print("Test case 4 passed!")
   
   # Test Case 5: Large weights
   # Test algorithm with large number values
   g5 = Graph()
   g5.add_edge('Dallas', 'Chicago', 1000000)
   g5.add_edge('Chicago', 'Boston', 2000000)
   
   distances, paths = g5.dijkstra('Dallas')
   assert distances['Boston'] == 3000000, (
      "Test case 5 large weights failed"
   )
   print("Test case 5 passed!")
   
   print("\nAll test cases passed successfully! Your "
         "implementation handles:")
   print("Basic shortest path finding")
   print("Disconnected graphs")
   print("Cyclic graphs")
   print("Multiple paths to same destination")
   print("Large weight values")
   
if __name__ == "__main__":
   test_dijkstra()
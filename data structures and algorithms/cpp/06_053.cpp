void testPerformance() {
    std::vector<int> largeArr(1000000);
    for (int i = 0; i < largeArr.size(); i++) {
        largeArr[i] = i % 100;
    }
    
    int k = 1000;
    
    auto startTime = std::chrono::high_resolution_clock::now();
    int result = maxSumSubarray(largeArr, k);
    auto endTime = std::chrono::high_resolution_clock::now();
    
    std::chrono::duration<double> timeTaken = endTime - startTime;
    
    std::cout << "Time taken: " << timeTaken.count() 
              << " seconds" << std::endl;
}
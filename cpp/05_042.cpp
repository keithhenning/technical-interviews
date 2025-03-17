class BookRecommendationGraph {
private:
    std::unordered_map<std::string, 
        std::unordered_map<std::string, int>> graph;
    
public:
    BookRecommendationGraph() {}
    
    void add_book_relationship(
        const std::string& book1, 
        const std::string& book2, 
        int weight=1) {
        if (graph.find(book1) == graph.end()) {
            graph[book1] = 
                std::unordered_map<std::string, int>();
        }
        if (graph.find(book2) == graph.end()) {
            graph[book2] = 
                std::unordered_map<std::string, int>();
        }
            
        graph[book1][book2] = weight;
        graph[book2][book1] = weight;
    }
    
    std::vector<std::pair<std::string, int>> 
    get_recommendations(
        const std::string& book, 
        int limit=5) {
        if (graph.find(book) == graph.end()) {
            return {};
        }
            
        std::vector<std::pair<std::string, int>> 
            recommendations;
        for (const auto& pair : graph[book]) {
            recommendations.push_back(pair);
        }
        
        // Sort by weight in descending order
        std::sort(recommendations.begin(), 
                  recommendations.end(), 
                  [](const auto& a, const auto& b) { 
                      return a.second > b.second; 
                  });
        
        // Return only the requested number 
        // of recommendations
        if (recommendations.size() > limit) {
            recommendations.resize(limit);
        }
        
        return recommendations;
    }
};
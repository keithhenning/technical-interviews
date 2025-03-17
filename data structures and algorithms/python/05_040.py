class BookRecommendationGraph:
    def __init__(self):
        self.graph = {}
    
    def add_book_relationship(self, book1, book2, weight=1):
        if book1 not in self.graph:
            self.graph[book1] = {}
        if book2 not in self.graph:
            self.graph[book2] = {}
            
        self.graph[book1][book2] = weight
        self.graph[book2][book1] = weight
    
    def get_recommendations(self, book, limit=5):
        if book not in self.graph:
            return []
            
        return sorted(self.graph[book].items(), 
                     key=lambda x: x[1], 
                     reverse=True)[:limit]
class BrowserHistory:
    def __init__(self):
        self.history = []  # Our stack
        
    def visit_page(self, url):
        self.history.push(url)
        
    def go_back(self):
        if not self.history.isEmpty():
            return self.history.pop()
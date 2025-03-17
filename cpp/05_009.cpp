class BrowserHistory {
private:
    std::vector<std::string> history; // Our stack
    
public:
    void visit_page(const std::string& url) {
        history.push_back(url);
    }
    
    std::string go_back() {
        if (!history.empty()) {
            std::string page = history.back();
            history.pop_back();
            return page;
        }
        return "";
    }
};
std::vector<int> getComponent(int x) {
    int root = find(x);
    std::vector<int> component;
    
    for (int i = 0; i < parent.size(); i++) {
        if (find(i) == root) {
            component.push_back(i);
        }
    }
    
    return component;
}
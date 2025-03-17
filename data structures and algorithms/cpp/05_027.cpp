class TextEditorHistory {
private:
    LinkedList changes;
    Node* current;
    
public:
    TextEditorHistory() : current(nullptr) {}
    
    void add_change(const std::string& text_state) {
        Node* new_node = new Node(text_state);
        if (!current) {
            changes.head = new_node;
        } else {
            new_node->next = current->next;
            current->next = new_node;
        }
        current = new_node;
    }
};
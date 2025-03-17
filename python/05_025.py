class TextEditorHistory:
    def __init__(self):
        self.changes = LinkedList()
        self.current = None
    
    def add_change(self, text_state):
        new_node = Node(text_state)
        if not self.current:
            self.changes.head = new_node
        else:
            new_node.next = self.current.next
            self.current.next = new_node
        self.current = new_node
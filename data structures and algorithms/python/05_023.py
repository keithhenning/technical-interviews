def remove(self, target):
    current = head
    prev = None
    while current:
        if current.data == target:
            prev.next = current.next
            break
        prev = current
        current = current.next
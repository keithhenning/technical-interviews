std::string dequeue() {
    if (!isEmpty()) {
        std::string front = queue.front();
        queue.erase(queue.begin());
        return front;
    }
    return "";
}
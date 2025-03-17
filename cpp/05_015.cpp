std::string peek() {
    if (!isEmpty()) {
        return queue.front();
    }
    return "";
}
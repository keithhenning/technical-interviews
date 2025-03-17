std::queue<std::string> queue;

// pop() doesn't return value like other languages
// So you need to get front() first, then pop()
std::string next = queue.front();
queue.pop();

// Check if queue is empty before front()/pop()
if (!queue.empty()) {
    // Access front and pop
}
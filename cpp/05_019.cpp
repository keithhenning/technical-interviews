// Using STL queue
#include <queue>
std::queue<std::string> queue;
queue.push("first");         // Enqueue
queue.push("second");        
std::string first_item = queue.front(); // View front element
queue.pop();                 // Dequeue
bool is_empty = queue.empty();

// Using deque for more flexibility
#include <deque>
std::deque<std::string> dq;
dq.push_back("first");       // Enqueue at back
dq.push_back("second");
std::string first = dq.front(); // View front
dq.pop_front();              // Dequeue from front
bool empty = dq.empty();
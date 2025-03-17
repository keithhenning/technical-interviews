class Stack {
private:
    // Initialize our stack with an empty vector
    std::vector<std::string> stack;
    
public:
    // Get the length of the stack
    size_t length() {
        return stack.size();
    }
    
    // Add item to the top of our stack
    std::string push(const std::string& item) {
        stack.push_back(item);
        return item; 
    }
    
    // Remove and return the top item
    std::string pop() {
        if (!isEmpty()) {
            std::string top = stack.back();
            stack.pop_back();
            return top;
        }
        return "";  // Always handle empty stack case!
    }
    
    // Look at the top item without removing it
    std::string peek() {
        if (!isEmpty()) {
            return stack.back();
        }
        return "";
    }
    
    // Check if stack is empty
    bool isEmpty() {
        return length() == 0;
    }
};

// Let's test it out with the music library example
int main() {
    Stack album;
    album.push("album 1");  
    album.push("album 2"); 
    album.push("album 3");
    
    std::cout << "Top album is: " << album.peek() << std::endl;
    album.pop();  // Remove the top album
    std::cout << "Now the top album is: " << album.peek() 
             << std::endl;
    std::cout << "Total albums in stack: " << album.length() 
             << std::endl;
    
    return 0;
}
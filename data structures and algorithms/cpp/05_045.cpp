#include <iostream>
#include <string>
#include <vector>

class FileSystemNode {
private:
    std::string name;
    bool is_directory;
    std::vector<FileSystemNode*> children;
    
public:
    FileSystemNode(
        const std::string& name, 
        bool is_directory = false) 
        : name(name), 
          is_directory(is_directory) {}
        
    void add_child(FileSystemNode* child) {
        if (is_directory) {
            children.push_back(child);
        }
    }
            
    void print_structure(int level = 0) {
        std::string indent(level * 2, ' ');
        std::cout << indent << name << "/" 
                  << std::endl;
        
        if (is_directory) {
            for (auto child : children) {
                child->print_structure(level + 1);
            }
        }
    }
    
    ~FileSystemNode() {
        if (is_directory) {
            for (auto child : children) {
                delete child;
            }
        }
    }
};
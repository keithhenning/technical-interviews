#include <iostream>
#include <string>
#include <filesystem>

namespace fs = std::filesystem;

void explore_directory(const fs::path& path, int depth = 0) {
    if (!fs::is_directory(path)) {
        return;
    }
    
    // Process current directory
    for (int i = 0; i < depth; i++) {
        std::cout << "  ";
    }
    std::cout << path.filename().string() << std::endl;
    
    // Explore subdirectories (DFS!)
    for (const auto& entry : fs::directory_iterator(path)) {
        explore_directory(entry.path(), depth + 1);
    }
}
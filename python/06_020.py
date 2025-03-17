def explore_directory(path, depth=0):
    if not os.path.isdir(path):
        return
        
    # Process current directory
    print('  ' * depth + os.path.basename(path))
    
    # Explore subdirectories (DFS!)
    for item in os.listdir(path):
        full_path = os.path.join(path, item)
        explore_directory(full_path, depth + 1)
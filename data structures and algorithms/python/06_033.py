class DynamicAstar:
    def __init__(self, grid):
        self.grid = grid
        self.cached_paths = {}
        
    def update_grid(self, changes):
        self.grid.update(changes)
        # Invalidate affected cached paths
        self.invalidate_cached_paths(changes)
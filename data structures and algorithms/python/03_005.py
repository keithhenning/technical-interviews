def demonstrate_complexity(sizes=[10, 100, 1000]):
    for n in sizes:
        operations = n * n
        print(f"Size {n}: {operations:,} operations")
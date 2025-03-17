def quickselect(arr, k):
    def partition(left, right, pivot_index):
        pivot_value = arr[pivot_index]
        # Move pivot to the end
        arr[pivot_index], arr[right] = arr[right], arr[pivot_index]
        
        store_index = left
        for i in range(left, right):
            if arr[i] < pivot_value:
                arr[store_index], arr[i] = arr[i], arr[store_index]
                store_index += 1
        
        # Move pivot to its final place
        arr[right], arr[store_index] = arr[store_index], arr[right]
        return store_index
    
    def select(left, right, k):
        if left == right:
            return arr[left]
        
        # Choose pivot (using middle element for simplicity)
        pivot_index = (left + right) // 2
        pivot_index = partition(left, right, pivot_index)
        
        if k == pivot_index:
            return arr[k]
        elif k < pivot_index:
            return select(left, pivot_index - 1, k)
        else:
            return select(pivot_index + 1, right, k)
    
    return select(0, len(arr) - 1, k)

# Example usage with detailed steps
def demo_quickselect():
    arr = [3, 2, 1, 5, 6, 4]
    k = 2  # Find 3rd smallest element (0-based index)
    
    print("Original array:", arr)
    result = quickselect(arr, k)
    print(f"The {k+1}th smallest element is: {result}")
    print("Note: Array may be partially sorted after running quickselect:", arr)

if __name__ == "__main__":
    demo_quickselect()
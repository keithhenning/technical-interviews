def smart_sort(arr):
    if len(arr) <= 10:
        return insertion_sort(arr)  
    else:
        return quick_sort(arr)
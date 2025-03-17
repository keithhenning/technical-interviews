# Median-of-three pivot selection
def choose_pivot(arr, low, high):
    mid = (low + high) // 2
    pivot = median([arr[low], arr[mid], arr[high]])
    return pivot
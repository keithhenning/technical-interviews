def findKthElement(nums1, nums2, k):

    # Ensure nums1 is the smaller array for simpler binary search
    if len(nums1) > len(nums2):
        return findKthElement(nums2, nums1, k)
    
    m, n = len(nums1), len(nums2)
    left, right = max(0, k - n), min(k, m)
    
    while left <= right:
        mid1 = (left + right) // 2
        mid2 = k - mid1
        
        l1 = float('-inf') if mid1 == 0 else nums1[mid1 - 1]
        r1 = float('inf') if mid1 == m else nums1[mid1]
        l2 = float('-inf') if mid2 == 0 else nums2[mid2 - 1]
        r2 = float('inf') if mid2 == n else nums2[mid2]
        
        if l1 <= r2 and l2 <= r1:
            return max(l1, l2)
        elif l1 > r2:
            right = mid1 - 1
        else:
            left = mid1 + 1
    
    return -1  # Should not reach here if arrays are sorted
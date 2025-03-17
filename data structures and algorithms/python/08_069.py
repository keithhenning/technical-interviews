def canCreateBlend(acidity, targetAcidity):

    left, right = 0, len(acidity) - 1
    
    while left < right:
        blend_acidity = (acidity[left] + acidity[right]) / 2
        
        # Account for floating-point precision
        if abs(blend_acidity - targetAcidity) < 0.001:
            return True
        elif blend_acidity < targetAcidity:
            left += 1
        else:
            right -= 1
    
    return False
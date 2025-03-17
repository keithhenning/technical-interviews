def optimal_document_segment(document, tokens):

    if not document or not tokens:
        return ""
    
    # Count frequencies of tokens
    token_count = {}
    for char in tokens:
        token_count[char] = token_count.get(char, 0) + 1
    
    # Initialize variables
    window_count = {}
    required_tokens = len(token_count)
    formed = 0
    
    # Result tracking
    min_len = float('inf')
    result_start = 0
    
    # Window pointers
    left, right = 0, 0
    
    # Expand window
    while right < len(document):
        # Add right character to window
        char = document[right]
        window_count[char] = window_count.get(char, 0) + 1
        
        # Check if this character satisfies a token requirement
        if (char in token_count and 
            window_count[char] == token_count[char]):
            formed += 1
        
        # Try to contract window from left
        while left <= right and formed == required_tokens:
            char = document[left]
            
            # Update result if current window is smaller
            if right - left + 1 < min_len:
                min_len = right - left + 1
                result_start = left
            
            # Remove left character from window
            window_count[char] -= 1
            
            # Check if removing this character breaks a token
            # requirement
            if (char in token_count and 
                window_count[char] < token_count[char]):
                formed -= 1
            
            left += 1
        
        right += 1
    
    return ("" if min_len == float('inf') else 
            document[result_start:result_start + min_len])
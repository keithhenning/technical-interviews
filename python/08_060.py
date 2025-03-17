def groupAnagramsByFrequency(strs):

    groups = {}
    result = []
    
    for s in strs:
        # Create frequency counter for each string
        freq = [0] * 26
        for char in s:
            freq[ord(char) - ord('a')] += 1
        
        # Convert frequency array to tuple to use as dictionary key
        freq_tuple = tuple(freq)
        
        if freq_tuple in groups:
            groups[freq_tuple].append(s)
        else:
            groups[freq_tuple] = [s]
            # Track order of appearance
            result.append(groups[freq_tuple])  
    
    return result
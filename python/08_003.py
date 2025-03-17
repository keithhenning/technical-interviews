def group_word_patterns(words):

    groups = {}
    
    for word in words:
        # Generate key by sorting characters
        key = ''.join(sorted(word))
        
        # Add word to its group
        if key not in groups:
            groups[key] = []
        groups[key].append(word)
    
    # Return lists of grouped words
    return list(groups.values())
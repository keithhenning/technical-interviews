def count_convoys(target, positions, speeds):

    # Pair positions with speeds and sort by position
    # in descending order
    cars = sorted(zip(positions, speeds), reverse=True)
    
    convoys = 0
    prev_time = -1
    
    for position, speed in cars:
        # Calculate time to reach target
        time = (target - position) / speed
        
        # If this vehicle takes longer to reach target,
        # it forms a new convoy
        if time > prev_time:
            convoys += 1
            prev_time = time
            
    return convoys
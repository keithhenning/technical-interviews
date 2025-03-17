def daily_temperatures(temperatures):
    n = len(temperatures)
    result = [0] * n
    stack = []
    
    for i in range(n):
        while stack and temperatures[i] > temperatures[stack[-1]]:
            prev_day = stack.pop()
            result[prev_day] = i - prev_day
        stack.append(i)
        
    return result

# Example
temps = [73, 74, 75, 71, 69, 72, 76, 73]
print(daily_temperatures(temps)) # Output: [1, 1, 4, 2, 1, 1, 0, 0]
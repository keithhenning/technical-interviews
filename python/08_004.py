import heapq

from collections import Counter

def top_k_trending_hashtags(hashtags, k):
    # Count frequencies
    counter = Counter(hashtags)
    
    # Use heap to find top k frequent hashtags
    return heapq.nlargest(k, counter.keys(), 
                          key=counter.get)
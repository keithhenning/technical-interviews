using System;
using System.Collections.Generic;

public class IntelligentCache<K, V> {
    private readonly int capacity;
    private readonly Dictionary<K, CacheItem> cache;

    public IntelligentCache(int capacity) {
        this.capacity = capacity;
        this.cache = new Dictionary<K, CacheItem>();
    }

    public V Get(K key) {
        if (!cache.ContainsKey(key)) {
            return default(V);
        }

        var item = cache[key];
        item.Access();
        return item.Value;
    }

    public void Put(K key, V value) {
        if (cache.ContainsKey(key)) {
            var item = cache[key];
            item.Value = value;
            item.Access();
            return;
        }

        if (cache.Count >= capacity) {
            Evict();
        }

        cache[key] = new CacheItem(key, value);
    }

    private void Evict() {
        if (cache.Count == 0) {
            return;
        }

        double minScore = double.PositiveInfinity;
        K minKey = default(K);
        long currentTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        foreach (var entry in cache) {
            var item = entry.Value;
            double score = item.GetScore(currentTime);
            if (score < minScore) {
                minScore = score;
                minKey = entry.Key;
            }
        }

        if (!EqualityComparer<K>.Default.Equals(minKey, default(K))) {
            cache.Remove(minKey);
        }
    }

    private class CacheItem {
        public K Key { get; }
        public V Value { get; set; }
        public int Frequency { get; private set; }
        public long LastAccess { get; private set; }

        public CacheItem(K key, V value) {
            Key = key;
            Value = value;
            Frequency = 1;
            LastAccess = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }

        public void Access() {
            Frequency++;
            LastAccess = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }

        public double GetScore(long currentTime) {
            double recencyScore = 1.0 / (1.0 + (currentTime - LastAccess) / 1000.0);
            return Frequency * recencyScore;
        }
    }
}
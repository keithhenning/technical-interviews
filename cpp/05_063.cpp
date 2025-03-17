void handle_collision(const K& key, const V& value,
  std::vector<std::pair<K, V>>& bucket) {
    for (auto& item : bucket) {
        if (item.first == key) {
            item.second = value;
            return;
        }
    }
    bucket.push_back({key, value});
}
size_t good_hash(const auto& key) {
    // Use standard hash for strings
    if constexpr(std::is_same_v<decltype(key), 
                 std::string>) {
        return std::hash<std::string>{}(key);
    }
    // Custom hash for tuples
    if constexpr(std::is_same_v<decltype(key), 
                 std::tuple>) {
        size_t hash_val = 0;
        std::apply([&hash_val](auto&&... args) {
            ((hash_val += 
                std::hash<std::decay_t<
                    decltype(args)>>{}(args)), 
             ...);
        }, key);
        return hash_val;
    }
    return std::hash<decltype(key)>{}(key);
}
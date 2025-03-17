// Pet-Owner relationships
std::unordered_map<std::string, std::vector<std::string>> relationships = {
    {"Wednesday", {"Keith"}, // Wednesday is Keith's cat
    {"Keith", {"Wednesday"}}, // Keith is Wednesday's human
    {"Whiskers", {"Tom"}},// Whiskers is Tom's cat
    {"Tom", {"Whiskers"}} // Tom is Whiskers' human
};
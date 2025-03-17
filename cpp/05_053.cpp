class Codec {
public:
    // Encodes a tree to a single string
    string serialize(Node* root) {
        if (!root) {
            return "null";
        }
        return std::to_string(root->value) + "," + 
               serialize(root->left) + "," + 
               serialize(root->right);
    }
    
    // Decodes your encoded data to tree
    Node* deserialize(string data) {
        std::istringstream stream(data);
        std::function<Node*()> dfs = [&]() -> Node* {
            std::string val;
            std::getline(stream, val, ',');
            
            if (val == "null") {
                return nullptr;
            }
            
            Node* node = new Node(std::stoi(val));
            node->left = dfs();
            node->right = dfs();
            return node;
        };
            
        return dfs();
    }
};
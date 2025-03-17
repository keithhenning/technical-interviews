#include <iostream>
#include <string>
#include <queue>
#include <map>
#include <unordered_map>
#include <vector>

// Huffman Tree Node structure
struct HuffmanNode {
   char character;
   int frequency;
   HuffmanNode* left;
   HuffmanNode* right;
   
   // Constructor initializes node
   HuffmanNode(char c, int freq) : 
      character(c), 
      frequency(freq), 
      left(nullptr), 
      right(nullptr) {}
};

// Custom comparator for priority queue
struct Compare {
   bool operator()(HuffmanNode* a, HuffmanNode* b) {
      return a->frequency > b->frequency;
   }
};

// Recursive Huffman code generation
void generateCodes(HuffmanNode* root, std::string code,
                   std::map<char, std::string>& codes) {
   // Base case: empty node
   if (!root)
      return;
   
   // Store code for leaf nodes
   if (root->character != '-' && 
       std::isalpha(root->character)) {
      codes[root->character] = code;
   }
   
   // Recurse left and right
   generateCodes(root->left, code + "0", codes);
   generateCodes(root->right, code + "1", codes);
}

// Recursive tree deletion to prevent memory leaks
void deleteTree(HuffmanNode* node) {
   if (!node) return;
   
   deleteTree(node->left);
   deleteTree(node->right);
   delete node;
}

int main() {
   // Input text for encoding
   std::string text = "huffman encoding example";
   
   // Calculate character frequencies
   std::unordered_map<char, int> frequency;
   for (char c : text) {
      frequency[c]++;
   }
   
   // Priority queue for Huffman tree construction
   std::priority_queue<HuffmanNode*, 
      std::vector<HuffmanNode*>, Compare> pq;
   
   // Create leaf nodes
   for (auto& pair : frequency) {
      pq.push(new HuffmanNode(pair.first, 
                               pair.second));
   }
   
   // Build Huffman Tree
   HuffmanNode* root = nullptr;
   while (pq.size() > 1) {
      // Extract two lowest frequency nodes
      HuffmanNode* x = pq.top();
      pq.pop();
      
      HuffmanNode* y = pq.top();
      pq.pop();
      
      // Create parent node
      HuffmanNode* sum = new HuffmanNode(
         '-', 
         x->frequency + y->frequency
      );
      sum->left = x;
      sum->right = y;
      
      root = sum;
      pq.push(sum);
   }
   
   // Generate Huffman codes
   std::map<char, std::string> codes;
   generateCodes(root, "", codes);
   
   // Print character codes
   std::cout << "Huffman Codes:" << std::endl;
   for (auto& pair : codes) {
      std::cout << pair.first << ": " 
                << pair.second << std::endl;
   }
   
   // Encode text
   std::string encoded;
   for (char c : text) {
      encoded += codes[c];
   }
   
   // Output results
   std::cout << "\nEncoded text: " << encoded 
             << std::endl;
   
   // Calculate compression ratio
   double originalSize = text.length() * 8;
   double compressedSize = encoded.length();
   std::cout << "Compression ratio: " 
             << compressedSize / originalSize 
             << std::endl;
   
   // Properly clean up memory
   deleteTree(root);
   
   return 0;
}
#include <iostream>
#include <vector>

// Definition for singly-linked list
struct ListNode {
    int val;
    ListNode *next;
    ListNode(int x) : val(x), next(nullptr) {}
};

ListNode* reverseList(ListNode* head) {
    ListNode* prev = nullptr;
    ListNode* current = head;
    
    while (current != nullptr) {
        // Save the next node
        ListNode* next = current->next;
        
        // Reverse the pointer
        current->next = prev;
        
        // Move pointers forward
        prev = current;
        current = next;
    }
    
    // prev is the new head
    return prev;
}

// Helper function to create a linked list from a vector
ListNode* createLinkedList(const std::vector<int>& arr) {
    if (arr.empty()) {
        return nullptr;
    }
    
    ListNode* head = new ListNode(arr[0]);
    ListNode* current = head;
    
    for (size_t i = 1; i < arr.size(); i++) {
        current->next = new ListNode(arr[i]);
        current = current->next;
    }
    
    return head;
}

// Helper function to convert linked list to vector for display
std::vector<int> linkedListToVector(ListNode* head) {
    std::vector<int> result;
    ListNode* current = head;
    
    while (current != nullptr) {
        result.push_back(current->val);
        current = current->next;
    }
    
    return result;
}

// Helper to print vector
void printVector(const std::vector<int>& vec) {
    std::cout << "[";
    for (size_t i = 0; i < vec.size(); i++) {
        std::cout << vec[i];
        if (i < vec.size() - 1) {
            std::cout << ", ";
        }
    }
    std::cout << "]" << std::endl;
}

int main() {
    ListNode* list = createLinkedList({1, 2, 3, 4, 5});
    ListNode* reversedList = reverseList(list);
    printVector(linkedListToVector(reversedList));  
    // Prints [5, 4, 3, 2, 1]
    
    return 0;
}
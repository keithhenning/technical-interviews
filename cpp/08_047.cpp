#include <cstddef> // for nullptr

struct ListNode {
    int val;
    ListNode* next;
    ListNode(int x) : val(x), next(nullptr) {}
};

class Solution {
public:
    ListNode* partitionList(ListNode* head, int pivot) {
        if (!head) {
            return nullptr;
        }
        
        // Create dummy heads for both partitions
        ListNode lessHead(0);
        ListNode greaterHead(0);
        
        ListNode* less = &lessHead;
        ListNode* greater = &greaterHead;
        
        // Traverse the original list
        ListNode* current = head;
        while (current) {
            if (current->val < pivot) {
                less->next = current;
                less = less->next;
            } else {
                greater->next = current;
                greater = greater->next;
            }
            
            current = current->next;
        }
        
        // Connect the two lists
        greater->next = nullptr;
        less->next = greaterHead.next;
        
        return lessHead.next;
    }
};
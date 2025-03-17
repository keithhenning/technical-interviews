#include <vector>
#include <queue>
#include <cstddef> // for nullptr

struct ListNode {
    int val;
    ListNode* next;
    ListNode(int x) : val(x), next(nullptr) {}
};

class Solution {
public:
    ListNode* interleaveLists(
            std::vector<ListNode*>& lists) {
        if (lists.empty()) {
            return nullptr;
        }
        
        // Create a queue to store non-empty lists
        std::queue<ListNode*> queue;
        for (ListNode* list : lists) {
            if (list != nullptr) {
                queue.push(list);
            }
        }
        
        if (queue.empty()) {
            return nullptr;
        }
        
        ListNode dummy(0);
        ListNode* tail = &dummy;
        
        while (!queue.empty()) {
            // Get current list
            ListNode* current = queue.front();
            queue.pop();
            
            // Append current node to result
            tail->next = current;
            tail = tail->next;
            
            // Move to next node in current list
            if (current->next != nullptr) {
                queue.push(current->next);
            }
        }
        
        return dummy.next;
    }
};
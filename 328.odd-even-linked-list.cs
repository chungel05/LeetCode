/*
 * @lc app=leetcode id=328 lang=csharp
 *
 * [328] Odd Even Linked List
 *
 * https://leetcode.com/problems/odd-even-linked-list/description/
 *
 * algorithms
 * Medium (61.66%)
 * Likes:    10281
 * Dislikes: 546
 * Total Accepted:    1.1M
 * Total Submissions: 1.7M
 * Testcase Example:  '[1,2,3,4,5]'
 *
 * Given the head of a singly linked list, group all the nodes with odd indices
 * together followed by the nodes with even indices, and return the reordered
 * list.
 * 
 * The first node is considered odd, and the second node is even, and so on.
 * 
 * Note that the relative order inside both the even and odd groups should
 * remain as it was in the input.
 * 
 * You must solve the problem in O(1) extra space complexity and O(n) time
 * complexity.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: head = [1,2,3,4,5]
 * Output: [1,3,5,2,4]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: head = [2,1,3,5,6,4,7]
 * Output: [2,3,6,7,1,5,4]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * The number of nodes in the linked list is in the range [0, 10^4].
 * -10^6 <= Node.val <= 10^6
 * 
 * 
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public partial class Solution
{
    public ListNode OddEvenList(ListNode head)
    {
        if (head == null)
            return null;

        // Separate into 2 list
        // odd which start from head
        // even which start from head.next
        ListNode odd = head;
        ListNode even = head.next;
        ListNode evenHead = even;
        // if even is null, it means that it is total odd Nodes
        // if even.next is null, it means that it is total even Nodes
        while (even != null && even.next != null)
        {
            // odd jump 2 nodes into next odd node
            odd.next = even.next;
            odd = odd.next;

            // even jump 2 nodes into next even node
            even.next = odd.next;
            even = even.next;
        }

        // After reordering, combine the end of odd List with head of even list
        odd.next = evenHead;

        return head;
    }
}
// @lc code=end


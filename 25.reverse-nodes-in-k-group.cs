/*
 * @lc app=leetcode id=25 lang=csharp
 *
 * [25] Reverse Nodes in k-Group
 *
 * https://leetcode.com/problems/reverse-nodes-in-k-group/description/
 *
 * algorithms
 * Hard (60.64%)
 * Likes:    13971
 * Dislikes: 726
 * Total Accepted:    1.1M
 * Total Submissions: 1.7M
 * Testcase Example:  '[1,2,3,4,5]\n2'
 *
 * Given the head of a linked list, reverse the nodes of the list k at a time,
 * and return the modified list.
 * 
 * k is a positive integer and is less than or equal to the length of the
 * linked list. If the number of nodes is not a multiple of k then left-out
 * nodes, in the end, should remain as it is.
 * 
 * You may not alter the values in the list's nodes, only nodes themselves may
 * be changed.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: head = [1,2,3,4,5], k = 2
 * Output: [2,1,4,3,5]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: head = [1,2,3,4,5], k = 3
 * Output: [3,2,1,4,5]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * The number of nodes in the list is n.
 * 1 <= k <= n <= 5000
 * 0 <= Node.val <= 1000
 * 
 * 
 * 
 * Follow-up: Can you solve the problem in O(1) extra memory space?
 * 
 */

// @lc code=start

using System.Diagnostics.CodeAnalysis;

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
    public ListNode ReverseListInGroup(ListNode left, ListNode right)
    {
        ListNode prev = null;
        ListNode curr = left;
        while (curr != right)
        {
            ListNode next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }
        return prev;
    }

    public ListNode ReverseKGroup(ListNode head, int k)
    {
        ListNode left = head, right = head, prev = null;
        while (right != null)
        {
            for (int i = 0; i < k; i++)
            {
                if (right == null)
                    return head;

                right = right.next;
            }
            ListNode newHead = ReverseListInGroup(left, right);
            if (prev == null)
                head = newHead;
            else
                prev.next = newHead;
            prev = left;
            left.next = right;
            left = right;
        }
        return head;
    }
}
// @lc code=end


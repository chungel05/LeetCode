/*
 * @lc app=leetcode id=234 lang=csharp
 *
 * [234] Palindrome Linked List
 *
 * https://leetcode.com/problems/palindrome-linked-list/description/
 *
 * algorithms
 * Easy (54.27%)
 * Likes:    16815
 * Dislikes: 899
 * Total Accepted:    2.2M
 * Total Submissions: 4M
 * Testcase Example:  '[1,2,2,1]'
 *
 * Given the head of a singly linked list, return true if it is a palindrome or
 * false otherwise.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: head = [1,2,2,1]
 * Output: true
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: head = [1,2]
 * Output: false
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * The number of nodes in the list is in the range [1, 10^5].
 * 0 <= Node.val <= 9
 * 
 * 
 * 
 * Follow up: Could you do it in O(n) time and O(1) space?
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
    public bool IsPalindrome(ListNode head)
    {
        if (head == null || head.next == null)
            return true;

        ListNode slow = head.next, fast = head.next.next;
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        ListNode prev = null;
        ListNode curr = slow;
        while (curr != null)
        {
            ListNode next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }

        ListNode left = head;
        ListNode right = prev;
        while (left != null && right != null)
        {
            if (left.val != right.val)
                return false;
            left = left.next;
            right = right.next;
        }
        return true;
    }
}
// @lc code=end


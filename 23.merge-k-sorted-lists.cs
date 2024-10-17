/*
 * @lc app=leetcode id=23 lang=csharp
 *
 * [23] Merge k Sorted Lists
 *
 * https://leetcode.com/problems/merge-k-sorted-lists/description/
 *
 * algorithms
 * Hard (54.33%)
 * Likes:    19708
 * Dislikes: 729
 * Total Accepted:    2.2M
 * Total Submissions: 4M
 * Testcase Example:  '[[1,4,5],[1,3,4],[2,6]]'
 *
 * You are given an array of k linked-lists lists, each linked-list is sorted
 * in ascending order.
 * 
 * Merge all the linked-lists into one sorted linked-list and return it.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: lists = [[1,4,5],[1,3,4],[2,6]]
 * Output: [1,1,2,3,4,4,5,6]
 * Explanation: The linked-lists are:
 * [
 * ⁠ 1->4->5,
 * ⁠ 1->3->4,
 * ⁠ 2->6
 * ]
 * merging them into one sorted list:
 * 1->1->2->3->4->4->5->6
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: lists = []
 * Output: []
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: lists = [[]]
 * Output: []
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * k == lists.length
 * 0 <= k <= 10^4
 * 0 <= lists[i].length <= 500
 * -10^4 <= lists[i][j] <= 10^4
 * lists[i] is sorted in ascending order.
 * The sum of lists[i].length will not exceed 10^4.
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
    // merge 2 sorted linked lists
    public ListNode MergeLists(ListNode list1, ListNode list2)
    {
        ListNode dummy = new ListNode(-1);
        ListNode curr = dummy;
        while (list1 != null && list2 != null)
        {
            if (list1.val < list2.val)
            {
                curr.next = list1;
                list1 = list1.next;
            }
            else
            {
                curr.next = list2;
                list2 = list2.next;
            }
            curr = curr.next;
        }

        if (list1 != null)
            curr.next = list1;
        else if (list2 != null)
            curr.next = list2;

        return dummy.next;
    }

    public ListNode MergeKLists(ListNode[] lists)
    {
        if (lists == null || lists.Length == 0) return null;

        Queue<ListNode> queue = new Queue<ListNode>();
        foreach (var list in lists)
        {
            if (list != null)
                queue.Enqueue(list);
        }

        while (queue.Count > 1)
        {
            var l1 = queue.Dequeue();
            var l2 = queue.Dequeue();
            var merged = MergeLists(l1, l2);
            queue.Enqueue(merged);
        }
        return queue.Count == 1 ? queue.Dequeue() : null;
    }
}
// @lc code=end


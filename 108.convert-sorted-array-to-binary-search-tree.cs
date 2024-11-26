/*
 * @lc app=leetcode id=108 lang=csharp
 *
 * [108] Convert Sorted Array to Binary Search Tree
 *
 * https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/description/
 *
 * algorithms
 * Easy (72.75%)
 * Likes:    11176
 * Dislikes: 581
 * Total Accepted:    1.3M
 * Total Submissions: 1.8M
 * Testcase Example:  '[-10,-3,0,5,9]'
 *
 * Given an integer array nums where the elements are sorted in ascending
 * order, convert it to a height-balanced binary search tree.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [-10,-3,0,5,9]
 * Output: [0,-3,9,-10,null,5]
 * Explanation: [0,-10,5,null,-3,null,9] is also accepted:
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [1,3]
 * Output: [3,1]
 * Explanation: [1,null,3] and [3,1] are both height-balanced BSTs.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 10^4
 * -10^4 <= nums[i] <= 10^4
 * nums is sorted in a strictly increasing order.
 * 
 * 
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
/*
 * Space Optimal solution, no need to split nums array
 * Time: O(n) where n = nums.Length, Space: O(log n)
 */
public partial class Solution
{
    private TreeNode BuildSortedArrayToBST(int[] nums, int left, int right)
    {
        // left > right means range <= 0, so we return null
        if (left > right)
            return null;

        // calc the mid point, which is the root
        int mid = (left + right) / 2;
        // create new Tree node with mid point and left half and right half
        return new TreeNode(nums[mid], BuildSortedArrayToBST(nums, left, mid - 1), BuildSortedArrayToBST(nums, mid + 1, right));
    }

    public TreeNode SortedArrayToBST(int[] nums)
    {
        return BuildSortedArrayToBST(nums, 0, nums.Length - 1);
    }
}
// @lc code=end


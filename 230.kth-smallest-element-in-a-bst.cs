/*
 * @lc app=leetcode id=230 lang=csharp
 *
 * [230] Kth Smallest Element in a BST
 *
 * https://leetcode.com/problems/kth-smallest-element-in-a-bst/description/
 *
 * algorithms
 * Medium (73.81%)
 * Likes:    11667
 * Dislikes: 235
 * Total Accepted:    1.6M
 * Total Submissions: 2.2M
 * Testcase Example:  '[3,1,4,null,2]\n1'
 *
 * Given the root of a binary search tree, and an integer k, return the k^th
 * smallest value (1-indexed) of all the values of the nodes in the tree.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: root = [3,1,4,null,2], k = 1
 * Output: 1
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: root = [5,3,6,2,4,null,null,1], k = 3
 * Output: 3
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * The number of nodes in the tree is n.
 * 1 <= k <= n <= 10^4
 * 0 <= Node.val <= 10^4
 * 
 * 
 * 
 * Follow up: If the BST is modified often (i.e., we can do insert and delete
 * operations) and you need to find the kth smallest frequently, how would you
 * optimize?
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
public partial class Solution
{
    public void DFSKthSmallest(TreeNode node, int k, List<TreeNode> list)
    {
        if (list.Count >= k)
            return;

        if (node == null)
            return;
        DFSKthSmallest(node.left, k, list);
        list.Add(node);
        DFSKthSmallest(node.right, k, list);
    }

    public int KthSmallest(TreeNode root, int k)
    {
        List<TreeNode> res = new List<TreeNode>();
        DFSKthSmallest(root, k, res);
        return res[k - 1].val;
    }
}
// @lc code=end


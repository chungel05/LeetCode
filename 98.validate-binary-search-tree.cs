/*
 * @lc app=leetcode id=98 lang=csharp
 *
 * [98] Validate Binary Search Tree
 *
 * https://leetcode.com/problems/validate-binary-search-tree/description/
 *
 * algorithms
 * Medium (33.50%)
 * Likes:    17049
 * Dislikes: 1388
 * Total Accepted:    2.6M
 * Total Submissions: 7.6M
 * Testcase Example:  '[2,1,3]'
 *
 * Given the root of a binary tree, determine if it is a valid binary search
 * tree (BST).
 * 
 * A valid BST is defined as follows:
 * 
 * 
 * The left subtree of a node contains only nodes with keys less than the
 * node's key.
 * The right subtree of a node contains only nodes with keys greater than the
 * node's key.
 * Both the left and right subtrees must also be binary search trees.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: root = [2,1,3]
 * Output: true
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: root = [5,1,4,null,null,3,6]
 * Output: false
 * Explanation: The root node's value is 5 but its right child's value is
 * 4.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * The number of nodes in the tree is in the range [1, 10^4].
 * -2^31 <= Node.val <= 2^31 - 1
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
public partial class Solution
{
    public bool DFSIsValidBST(TreeNode root, double min, double max)
    {
        if (root == null)
            return true;

        if (!(root.val > min && root.val < max))
            return false;

        return DFSIsValidBST(root.left, min, root.val) && DFSIsValidBST(root.right, root.val, max);
    }
    public bool IsValidBST(TreeNode root)
    {
        return DFSIsValidBST(root, double.NegativeInfinity, double.PositiveInfinity);
    }
}
// @lc code=end


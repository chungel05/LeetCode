/*
 * @lc app=leetcode id=572 lang=csharp
 *
 * [572] Subtree of Another Tree
 *
 * https://leetcode.com/problems/subtree-of-another-tree/description/
 *
 * algorithms
 * Easy (48.78%)
 * Likes:    8312
 * Dislikes: 535
 * Total Accepted:    939.8K
 * Total Submissions: 1.9M
 * Testcase Example:  '[3,4,5,1,2]\n[4,1,2]'
 *
 * Given the roots of two binary trees root and subRoot, return true if there
 * is a subtree of root with the same structure and node values of subRoot and
 * false otherwise.
 * 
 * A subtree of a binary tree tree is a tree that consists of a node in tree
 * and all of this node's descendants. The tree tree could also be considered
 * as a subtree of itself.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: root = [3,4,5,1,2], subRoot = [4,1,2]
 * Output: true
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: root = [3,4,5,1,2,null,null,null,null,0], subRoot = [4,1,2]
 * Output: false
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * The number of nodes in the root tree is in the range [1, 2000].
 * The number of nodes in the subRoot tree is in the range [1, 1000].
 * -10^4 <= root.val <= 10^4
 * -10^4 <= subRoot.val <= 10^4
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
    public bool DepthSubTree(TreeNode node, TreeNode subRoot)
    {
        if (node != null && subRoot != null)
        {
            bool left = DepthSubTree(node.left, subRoot.left);
            bool right = DepthSubTree(node.right, subRoot.right);
            return left && right && node.val == subRoot.val;
        }
        else if (node == null && subRoot == null)
            return true;
        else
            return false;
    }

    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        if (root == null)
            return false;

        if (DepthSubTree(root, subRoot))
            return true;
        else
            return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
    }
}
// @lc code=end


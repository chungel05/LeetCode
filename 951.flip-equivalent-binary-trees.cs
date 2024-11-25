/*
 * @lc app=leetcode id=951 lang=csharp
 *
 * [951] Flip Equivalent Binary Trees
 *
 * https://leetcode.com/problems/flip-equivalent-binary-trees/description/
 *
 * algorithms
 * Medium (67.11%)
 * Likes:    2822
 * Dislikes: 116
 * Total Accepted:    247.3K
 * Total Submissions: 353.9K
 * Testcase Example:  '[1,2,3,4,5,6,null,null,null,7,8]\n[1,3,2,null,6,4,5,null,null,null,null,8,7]'
 *
 * For a binary tree T, we can define a flip operation as follows: choose any
 * node, and swap the left and right child subtrees.
 * 
 * A binary tree X is flip equivalent to a binary tree Y if and only if we can
 * make X equal to Y after some number of flip operations.
 * 
 * Given the roots of two binary trees root1 and root2, return true if the two
 * trees are flip equivalent or false otherwise.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: root1 = [1,2,3,4,5,6,null,null,null,7,8], root2 =
 * [1,3,2,null,6,4,5,null,null,null,null,8,7]
 * Output: true
 * Explanation: We flipped at nodes with values 1, 3, and 5.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: root1 = [], root2 = []
 * Output: true
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: root1 = [], root2 = [1]
 * Output: false
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * The number of nodes in each tree is in the range [0, 100].
 * Each tree will have unique node values in the range [0, 99].
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
    private bool DFSFlipEquiv(TreeNode node1, TreeNode node2)
    {
        if (node1 == null && node2 == null)
            return true;

        if (node1 == null || node2 == null || node1.val != node2.val)
            return false;

        // if they are not fliped
        return (DFSFlipEquiv(node1.left, node2.left) && DFSFlipEquiv(node1.right, node2.right)) ||
        // if they are fliped
        (DFSFlipEquiv(node1.left, node2.right) && DFSFlipEquiv(node1.right, node2.left));
    }

    public bool FlipEquiv(TreeNode root1, TreeNode root2)
    {
        return DFSFlipEquiv(root1, root2);
    }
}
// @lc code=end


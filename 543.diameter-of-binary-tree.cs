/*
 * @lc app=leetcode id=543 lang=csharp
 *
 * [543] Diameter of Binary Tree
 *
 * https://leetcode.com/problems/diameter-of-binary-tree/description/
 *
 * algorithms
 * Easy (61.62%)
 * Likes:    14110
 * Dislikes: 1071
 * Total Accepted:    1.7M
 * Total Submissions: 2.8M
 * Testcase Example:  '[1,2,3,4,5]'
 *
 * Given the root of a binary tree, return the length of the diameter of the
 * tree.
 * 
 * The diameter of a binary tree is the length of the longest path between any
 * two nodes in a tree. This path may or may not pass through the root.
 * 
 * The length of a path between two nodes is represented by the number of edges
 * between them.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: root = [1,2,3,4,5]
 * Output: 3
 * Explanation: 3 is the length of the path [4,2,1,3] or [5,2,1,3].
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: root = [1,2]
 * Output: 1
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * The number of nodes in the tree is in the range [1, 10^4].
 * -100 <= Node.val <= 100
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
    public int Depth(TreeNode node, ref int maxDiameter)
    {
        if (node == null)
            return 0;

        int leftDepth = Depth(node.left, ref maxDiameter);
        int rightDepth = Depth(node.right, ref maxDiameter);
        maxDiameter = Math.Max(maxDiameter, leftDepth + rightDepth);

        return Math.Max(leftDepth, rightDepth) + 1;
    }
    public int DiameterOfBinaryTree(TreeNode root)
    {
        int maxDiameter = 0;
        Depth(root, ref maxDiameter);
        return maxDiameter;
    }
}
// @lc code=end


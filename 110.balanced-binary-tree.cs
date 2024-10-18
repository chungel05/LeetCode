/*
 * @lc app=leetcode id=110 lang=csharp
 *
 * [110] Balanced Binary Tree
 *
 * https://leetcode.com/problems/balanced-binary-tree/description/
 *
 * algorithms
 * Easy (53.56%)
 * Likes:    10933
 * Dislikes: 719
 * Total Accepted:    1.7M
 * Total Submissions: 3.1M
 * Testcase Example:  '[3,9,20,null,null,15,7]'
 *
 * Given a binary tree, determine if it is height-balanced.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: root = [3,9,20,null,null,15,7]
 * Output: true
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: root = [1,2,2,3,3,null,null,4,4]
 * Output: false
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: root = []
 * Output: true
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * The number of nodes in the tree is in the range [0, 5000].
 * -10^4 <= Node.val <= 10^4
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
    public int DepthBalance(TreeNode node, ref bool isBalance)
    {
        if (node == null)
            return 0;

        int left = DepthBalance(node.left, ref isBalance);
        int right = DepthBalance(node.right, ref isBalance);

        if (Math.Abs(left - right) > 1)
            isBalance = false;

        return Math.Max(left, right) + 1;

    }

    public bool IsBalanced(TreeNode root)
    {
        bool isBalance = true;
        DepthBalance(root, ref isBalance);
        return isBalance;
    }
}
// @lc code=end


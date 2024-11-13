/*
 * @lc app=leetcode id=107 lang=csharp
 *
 * [107] Binary Tree Level Order Traversal II
 *
 * https://leetcode.com/problems/binary-tree-level-order-traversal-ii/description/
 *
 * algorithms
 * Medium (64.45%)
 * Likes:    4927
 * Dislikes: 326
 * Total Accepted:    688.3K
 * Total Submissions: 1.1M
 * Testcase Example:  '[3,9,20,null,null,15,7]'
 *
 * Given the root of a binary tree, return the bottom-up level order traversal
 * of its nodes' values. (i.e., from left to right, level by level from leaf to
 * root).
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: root = [3,9,20,null,null,15,7]
 * Output: [[15,7],[9,20],[3]]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: root = [1]
 * Output: [[1]]
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: root = []
 * Output: []
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * The number of nodes in the tree is in the range [0, 2000].
 * -1000 <= Node.val <= 1000
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
    public IList<IList<int>> LevelOrderBottom(TreeNode root)
    {
        List<IList<int>> res = new List<IList<int>>();
        Queue<TreeNode> q = new Queue<TreeNode>();

        if (root != null)
            q.Enqueue(root);

        while (q.Count > 0)
        {
            int len = q.Count;
            List<int> currSet = new List<int>();
            for (int i = 0; i < len; i++)
            {
                TreeNode tmp = q.Dequeue();
                currSet.Add(tmp.val);
                if (tmp.left != null)
                    q.Enqueue(tmp.left);
                if (tmp.right != null)
                    q.Enqueue(tmp.right);
            }
            res.Insert(0, currSet);
        }

        return res;
    }
}
// @lc code=end


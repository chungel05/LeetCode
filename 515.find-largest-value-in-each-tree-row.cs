/*
 * @lc app=leetcode id=515 lang=csharp
 *
 * [515] Find Largest Value in Each Tree Row
 *
 * https://leetcode.com/problems/find-largest-value-in-each-tree-row/description/
 *
 * algorithms
 * Medium (65.72%)
 * Likes:    3974
 * Dislikes: 125
 * Total Accepted:    444.7K
 * Total Submissions: 669.8K
 * Testcase Example:  '[1,3,2,5,3,null,9]'
 *
 * Given the root of a binary tree, return an array of the largest value in
 * each row of the tree (0-indexed).
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: root = [1,3,2,5,3,null,9]
 * Output: [1,3,9]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: root = [1,2,3]
 * Output: [1,3]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * The number of nodes in the tree will be in the range [0, 10^4].
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
    public IList<int> LargestValues(TreeNode root)
    {
        List<int> res = new List<int>();
        if (root == null)
            return res;

        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);

        while (q.Count > 0)
        {
            int max = int.MinValue;
            for (int i = q.Count; i > 0; i--)
            {
                TreeNode tmp = q.Dequeue();
                max = Math.Max(max, tmp.val);

                if (tmp.left != null)
                    q.Enqueue(tmp.left);

                if (tmp.right != null)
                    q.Enqueue(tmp.right);
            }
            res.Add(max);
        }
        return res;
    }
}
// @lc code=end


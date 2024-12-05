/*
 * @lc app=leetcode id=103 lang=csharp
 *
 * [103] Binary Tree Zigzag Level Order Traversal
 *
 * https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/description/
 *
 * algorithms
 * Medium (60.13%)
 * Likes:    11081
 * Dislikes: 317
 * Total Accepted:    1.3M
 * Total Submissions: 2.2M
 * Testcase Example:  '[3,9,20,null,null,15,7]'
 *
 * Given the root of a binary tree, return the zigzag level order traversal of
 * its nodes' values. (i.e., from left to right, then right to left for the
 * next level and alternate between).
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: root = [3,9,20,null,null,15,7]
 * Output: [[3],[20,9],[15,7]]
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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
    {
        List<IList<int>> res = new List<IList<int>>();
        if (root == null)
            return res;

        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);

        bool isLeftToRight = true;
        while (q.Count > 0)
        {
            List<int> nums = new List<int>();
            for (int i = q.Count; i > 0; i--)
            {
                TreeNode tmp = q.Dequeue();
                // if left to right, we add val at the end
                if (isLeftToRight)
                    nums.Add(tmp.val);
                // if right to left, we insert val at the beginning
                else
                    nums.Insert(0, tmp.val);

                if (tmp.left != null)
                    q.Enqueue(tmp.left);
                if (tmp.right != null)
                    q.Enqueue(tmp.right);
            }
            res.Add(nums);
            isLeftToRight = !isLeftToRight;
        }

        return res;
    }
}
// @lc code=end


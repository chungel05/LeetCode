/*
 * @lc app=leetcode id=257 lang=csharp
 *
 * [257] Binary Tree Paths
 *
 * https://leetcode.com/problems/binary-tree-paths/description/
 *
 * algorithms
 * Easy (64.85%)
 * Likes:    6699
 * Dislikes: 308
 * Total Accepted:    793K
 * Total Submissions: 1.2M
 * Testcase Example:  '[1,2,3,null,5]'
 *
 * Given the root of a binary tree, return all root-to-leaf paths in any
 * order.
 * 
 * A leaf is a node with no children.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: root = [1,2,3,null,5]
 * Output: ["1->2->5","1->3"]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: root = [1]
 * Output: ["1"]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * The number of nodes in the tree is in the range [1, 100].
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
    public void DFSBinaryTreePaths(TreeNode node, List<string> currS, List<string> res)
    {
        if (node == null)
            return;

        currS.Add(node.val.ToString());
        if (node.left == null && node.right == null)
            res.Add(string.Join("->", currS));

        DFSBinaryTreePaths(node.left, currS, res);
        DFSBinaryTreePaths(node.right, currS, res);
        currS.RemoveAt(currS.Count - 1);
    }

    public IList<string> BinaryTreePaths(TreeNode root)
    {
        List<string> res = new List<string>();
        DFSBinaryTreePaths(root, new List<string>(), res);
        return res;
    }
}
// @lc code=end


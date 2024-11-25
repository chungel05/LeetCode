/*
 * @lc app=leetcode id=1110 lang=csharp
 *
 * [1110] Delete Nodes And Return Forest
 *
 * https://leetcode.com/problems/delete-nodes-and-return-forest/description/
 *
 * algorithms
 * Medium (72.42%)
 * Likes:    4611
 * Dislikes: 142
 * Total Accepted:    353.2K
 * Total Submissions: 487.6K
 * Testcase Example:  '[1,2,3,4,5,6,7]\n[3,5]'
 *
 * Given the root of a binary tree, each node in the tree has a distinct
 * value.
 * 
 * After deleting all nodes with a value in to_delete, we are left with a
 * forest (a disjoint union of trees).
 * 
 * Return the roots of the trees in the remaining forest. You may return the
 * result in any order.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: root = [1,2,3,4,5,6,7], to_delete = [3,5]
 * Output: [[1,2,null,4],[6],[7]]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: root = [1,2,4,null,3], to_delete = [3]
 * Output: [[1,2,4]]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * The number of nodes in the given tree is at most 1000.
 * Each node has a distinct value between 1 and 1000.
 * to_delete.length <= 1000
 * to_delete contains distinct values between 1 and 1000.
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
    private bool DFSDelNodes(TreeNode node, HashSet<int> delete, List<TreeNode> res)
    {
        if (node == null)
            return false;

        // if left need to delete, we set the left to null
        if (DFSDelNodes(node.left, delete, res))
            node.left = null;

        // if right need to delete, we set the right to null
        if (DFSDelNodes(node.right, delete, res))
            node.right = null;

        // if current node need to delete, we add left and right to res
        // and return true
        if (delete.Contains(node.val))
        {
            if (node.left != null)
                res.Add(node.left);
            if (node.right != null)
                res.Add(node.right);
            return true;
        }

        // return false if no need to delete
        return false;
    }

    public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
    {
        List<TreeNode> res = new List<TreeNode>();

        // convert array to HashSet for easy lookup
        HashSet<int> delete = to_delete.ToHashSet();

        // if root do not need to delete, we add to the res regardless the order
        if (!DFSDelNodes(root, delete, res))
            res.Add(root);

        return res;
    }
}
// @lc code=end


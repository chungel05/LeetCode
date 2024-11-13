/*
 * @lc app=leetcode id=113 lang=csharp
 *
 * [113] Path Sum II
 *
 * https://leetcode.com/problems/path-sum-ii/description/
 *
 * algorithms
 * Medium (59.29%)
 * Likes:    8090
 * Dislikes: 157
 * Total Accepted:    934.5K
 * Total Submissions: 1.6M
 * Testcase Example:  '[5,4,8,11,null,13,4,7,2,null,null,5,1]\n22'
 *
 * Given the root of a binary tree and an integer targetSum, return all
 * root-to-leaf paths where the sum of the node values in the path equals
 * targetSum. Each path should be returned as a list of the node values, not
 * node references.
 * 
 * A root-to-leaf path is a path starting from the root and ending at any leaf
 * node. A leaf is a node with no children.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: root = [5,4,8,11,null,13,4,7,2,null,null,5,1], targetSum = 22
 * Output: [[5,4,11,2],[5,8,4,5]]
 * Explanation: There are two paths whose sum equals targetSum:
 * 5 + 4 + 11 + 2 = 22
 * 5 + 8 + 4 + 5 = 22
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: root = [1,2,3], targetSum = 5
 * Output: []
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: root = [1,2], targetSum = 0
 * Output: []
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * The number of nodes in the tree is in the range [0, 5000].
 * -1000 <= Node.val <= 1000
 * -1000 <= targetSum <= 1000
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
    public void DFSPathSum(TreeNode node, int targetSum, int currSum, List<int> currSet, List<IList<int>> res)
    {
        if (node == null)
            return;

        currSet.Add(node.val);
        currSum += node.val;
        if (currSum == targetSum && node.left == null && node.right == null)
            res.Add(new List<int>(currSet));

        DFSPathSum(node.left, targetSum, currSum, currSet, res);
        DFSPathSum(node.right, targetSum, currSum, currSet, res);
        currSet.RemoveAt(currSet.Count - 1);
    }

    public IList<IList<int>> PathSum(TreeNode root, int targetSum)
    {
        List<IList<int>> res = new List<IList<int>>();
        DFSPathSum(root, targetSum, 0, new List<int>(), res);
        return res;
    }
}
// @lc code=end


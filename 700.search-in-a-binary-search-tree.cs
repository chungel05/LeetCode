/*
 * @lc app=leetcode id=700 lang=csharp
 *
 * [700] Search in a Binary Search Tree
 *
 * https://leetcode.com/problems/search-in-a-binary-search-tree/description/
 *
 * algorithms
 * Easy (80.72%)
 * Likes:    6064
 * Dislikes: 195
 * Total Accepted:    1M
 * Total Submissions: 1.3M
 * Testcase Example:  '[4,2,7,1,3]\n2'
 *
 * You are given the root of a binary search tree (BST) and an integer val.
 * 
 * Find the node in the BST that the node's value equals val and return the
 * subtree rooted with that node. If such a node does not exist, return
 * null.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: root = [4,2,7,1,3], val = 2
 * Output: [2,1,3]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: root = [4,2,7,1,3], val = 5
 * Output: []
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * The number of nodes in the tree is in the range [1, 5000].
 * 1 <= Node.val <= 10^7
 * root is a binary search tree.
 * 1 <= val <= 10^7
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
    public TreeNode SearchBST(TreeNode root, int val)
    {
        // base case, root == null, we cannot find target val
        if (root == null)
            return null;

        // if root.val == val, this is the target node
        if (root.val == val)
            return root;

        // Since it is BST
        // if root.val > val, we just need to find left side
        if (root.val > val)
            return SearchBST(root.left, val);

        // else we find the right side
        return SearchBST(root.right, val);
    }
}
// @lc code=end


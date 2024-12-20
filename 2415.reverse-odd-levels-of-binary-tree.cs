/*
 * @lc app=leetcode id=2415 lang=csharp
 *
 * [2415] Reverse Odd Levels of Binary Tree
 *
 * https://leetcode.com/problems/reverse-odd-levels-of-binary-tree/description/
 *
 * algorithms
 * Medium (78.44%)
 * Likes:    1234
 * Dislikes: 48
 * Total Accepted:    71.4K
 * Total Submissions: 88.6K
 * Testcase Example:  '[2,3,5,8,13,21,34]'
 *
 * Given the root of a perfect binary tree, reverse the node values at each odd
 * level of the tree.
 * 
 * 
 * For example, suppose the node values at level 3 are [2,1,3,4,7,11,29,18],
 * then it should become [18,29,11,7,4,3,1,2].
 * 
 * 
 * Return the root of the reversed tree.
 * 
 * A binary tree is perfect if all parent nodes have two children and all
 * leaves are on the same level.
 * 
 * The level of a node is the number of edges along the path between it and the
 * root node.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: root = [2,3,5,8,13,21,34]
 * Output: [2,5,3,8,13,21,34]
 * Explanation: 
 * The tree has only one odd level.
 * The nodes at level 1 are 3, 5 respectively, which are reversed and become 5,
 * 3.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: root = [7,13,11]
 * Output: [7,11,13]
 * Explanation: 
 * The nodes at level 1 are 13, 11, which are reversed and become 11, 13.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: root = [0,1,2,0,0,0,0,1,1,1,1,2,2,2,2]
 * Output: [0,2,1,0,0,0,0,2,2,2,2,1,1,1,1]
 * Explanation: 
 * The odd levels have non-zero values.
 * The nodes at level 1 were 1, 2, and are 2, 1 after the reversal.
 * The nodes at level 3 were 1, 1, 1, 1, 2, 2, 2, 2, and are 2, 2, 2, 2, 1, 1,
 * 1, 1 after the reversal.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * The number of nodes in the tree is in the range [1, 2^14].
 * 0 <= Node.val <= 10^5
 * root is a perfect binary tree.
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
/*
 * Time: O(n) traversal nodes + O(n) swap val = O(n), Space: O(n) where n is no. of nodes
 */

public partial class Solution
{
    public TreeNode ReverseOddLevels(TreeNode root)
    {
        Queue<TreeNode> q = new Queue<TreeNode>();
        // since it is perfect tree, no need to take care of root is null edge case
        q.Enqueue(root);

        bool isOdd = false;
        while (q.Count > 0)
        {
            TreeNode[] nums = new TreeNode[q.Count];
            for (int i = q.Count; i > 0; i--)
            {
                TreeNode tmp = q.Dequeue();

                // store the nodes in current level to array, seq does not matter
                nums[i - 1] = tmp;

                // queue the next level normally
                if (tmp.left != null)
                    q.Enqueue(tmp.left);
                if (tmp.right != null)
                    q.Enqueue(tmp.right);
            }

            // if odd level
            if (isOdd)
            {
                // we swap val of left most node with right most node
                // boundary to middle two pointer operation
                int left = 0, right = nums.Length - 1;
                while (left < right)
                {
                    int value = nums[left].val;
                    nums[left].val = nums[right].val;
                    nums[right].val = value;
                    left++;
                    right--;
                }
            }
            isOdd = !isOdd;
        }
        return root;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=1448 lang=csharp
 *
 * [1448] Count Good Nodes in Binary Tree
 *
 * https://leetcode.com/problems/count-good-nodes-in-binary-tree/description/
 *
 * algorithms
 * Medium (73.09%)
 * Likes:    5919
 * Dislikes: 181
 * Total Accepted:    584.4K
 * Total Submissions: 799.4K
 * Testcase Example:  '[3,1,4,3,null,1,5]'
 *
 * Given a binary tree root, a node X in the tree is named good if in the path
 * from root to X there are no nodes with a value greater than X.
 * 
 * Return the number of good nodes in the binary tree.
 * 
 * 
 * Example 1:
 * 
 * 
 * 
 * 
 * Input: root = [3,1,4,3,null,1,5]
 * Output: 4
 * Explanation: Nodes in blue are good.
 * Root Node (3) is always a good node.
 * Node 4 -> (3,4) is the maximum value in the path starting from the root.
 * Node 5 -> (3,4,5) is the maximum value in the path
 * Node 3 -> (3,1,3) is the maximum value in the path.
 * 
 * Example 2:
 * 
 * 
 * 
 * 
 * Input: root = [3,3,null,4,2]
 * Output: 3
 * Explanation: Node 2 -> (3, 3, 2) is not good, because "3" is higher than
 * it.
 * 
 * Example 3:
 * 
 * 
 * Input: root = [1]
 * Output: 1
 * Explanation: Root is considered as good.
 * 
 * 
 * Constraints:
 * 
 * 
 * The number of nodes in the binary tree is in the range [1, 10^5].
 * Each node's value is between [-10^4, 10^4].
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
    public int GoodNodes(TreeNode root)
    {
        // BFS implementation
        int count = 1;
        Queue<(TreeNode, int)> q = new Queue<(TreeNode, int)>();

        if (root != null)
            q.Enqueue((root, root.val));

        while (q.Count > 0)
        {
            int currLen = q.Count;
            for (int i = 0; i < currLen; i++)
            {
                (TreeNode node, int max) = q.Dequeue();
                if (node.left != null)
                {
                    if (node.left.val >= max)
                        count++;
                    q.Enqueue((node.left, Math.Max(node.left.val, max)));
                }
                if (node.right != null)
                {
                    if (node.right.val >= max)
                        count++;
                    q.Enqueue((node.right, Math.Max(node.right.val, max)));
                }
            }
        }
        return count;
    }
}
// @lc code=end


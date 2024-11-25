/*
 * @lc app=leetcode id=987 lang=csharp
 *
 * [987] Vertical Order Traversal of a Binary Tree
 *
 * https://leetcode.com/problems/vertical-order-traversal-of-a-binary-tree/description/
 *
 * algorithms
 * Hard (49.03%)
 * Likes:    7810
 * Dislikes: 4354
 * Total Accepted:    504.4K
 * Total Submissions: 1M
 * Testcase Example:  '[3,9,20,null,null,15,7]'
 *
 * Given the root of a binary tree, calculate the vertical order traversal of
 * the binary tree.
 * 
 * For each node at position (row, col), its left and right children will be at
 * positions (row + 1, col - 1) and (row + 1, col + 1) respectively. The root
 * of the tree is at (0, 0).
 * 
 * The vertical order traversal of a binary tree is a list of top-to-bottom
 * orderings for each column index starting from the leftmost column and ending
 * on the rightmost column. There may be multiple nodes in the same row and
 * same column. In such a case, sort these nodes by their values.
 * 
 * Return the vertical order traversal of the binary tree.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: root = [3,9,20,null,null,15,7]
 * Output: [[9],[3,15],[20],[7]]
 * Explanation:
 * Column -1: Only node 9 is in this column.
 * Column 0: Nodes 3 and 15 are in this column in that order from top to
 * bottom.
 * Column 1: Only node 20 is in this column.
 * Column 2: Only node 7 is in this column.
 * 
 * Example 2:
 * 
 * 
 * Input: root = [1,2,3,4,5,6,7]
 * Output: [[4],[2],[1,5,6],[3],[7]]
 * Explanation:
 * Column -2: Only node 4 is in this column.
 * Column -1: Only node 2 is in this column.
 * Column 0: Nodes 1, 5, and 6 are in this column.
 * ⁠         1 is at the top, so it comes first.
 * ⁠         5 and 6 are at the same position (2, 0), so we order them by their
 * value, 5 before 6.
 * Column 1: Only node 3 is in this column.
 * Column 2: Only node 7 is in this column.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: root = [1,2,3,4,6,5,7]
 * Output: [[4],[2],[1,5,6],[3],[7]]
 * Explanation:
 * This case is the exact same as example 2, but with nodes 5 and 6 swapped.
 * Note that the solution remains the same since 5 and 6 are in the same
 * location and should be ordered by their values.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * The number of nodes in the tree is in the range [1, 1000].
 * 0 <= Node.val <= 1000
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
    private void DFSVerticalTraversal(TreeNode node, int row, int col, List<int[]> nodes)
    {
        // DFS traversal of all nodes not caring any order
        if (node == null)
            return;

        nodes.Add(new int[] { col, row, node.val });
        DFSVerticalTraversal(node.left, row + 1, col - 1, nodes);
        DFSVerticalTraversal(node.right, row + 1, col + 1, nodes);
    }

    public IList<IList<int>> VerticalTraversal(TreeNode root)
    {
        List<int[]> nodes = new List<int[]>();
        DFSVerticalTraversal(root, 0, 0, nodes);

        // Custom sorting method, to sort col -> row -> val
        nodes.Sort((x, y) =>
        {
            if (x[0] != y[0])
                return x[0].CompareTo(y[0]);
            if (x[1] != y[1])
                return x[1].CompareTo(y[1]);
            return x[2].CompareTo(y[2]);
        });

        // Combine the result according to the column
        List<IList<int>> res = new List<IList<int>>();
        int prevCol = Int32.MinValue;
        foreach (int[] tmp in nodes)
        {
            if (prevCol != tmp[0])
                res.Add(new List<int>());
            res[res.Count - 1].Add(tmp[2]);
            prevCol = tmp[0];
        }
        return res;
    }
}
// @lc code=end


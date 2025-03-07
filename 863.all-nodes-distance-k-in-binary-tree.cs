/*
 * @lc app=leetcode id=863 lang=csharp
 *
 * [863] All Nodes Distance K in Binary Tree
 *
 * https://leetcode.com/problems/all-nodes-distance-k-in-binary-tree/description/
 *
 * algorithms
 * Medium (65.10%)
 * Likes:    11214
 * Dislikes: 241
 * Total Accepted:    497.2K
 * Total Submissions: 761.3K
 * Testcase Example:  '[3,5,1,6,2,0,8,null,null,7,4]\n5\n2'
 *
 * Given the root of a binary tree, the value of a target node target, and an
 * integer k, return an array of the values of all nodes that have a distance k
 * from the target node.
 * 
 * You can return the answer in any order.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: root = [3,5,1,6,2,0,8,null,null,7,4], target = 5, k = 2
 * Output: [7,4,1]
 * Explanation: The nodes that are a distance 2 from the target node (with
 * value 5) have values 7, 4, and 1.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: root = [1], target = 1, k = 3
 * Output: []
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * The number of nodes in the tree is in the range [1, 500].
 * 0 <= Node.val <= 500
 * All the values Node.val are unique.
 * target is the value of one of the nodes in the tree.
 * 0 <= k <= 1000
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
 *     public TreeNode(int x) { val = x; }
 * }
 */
public partial class Solution
{
    private void DFSMapDistanceKParent(TreeNode node, TreeNode parent, Dictionary<TreeNode, TreeNode> map)
    {
        if (node == null)
            return;

        map[node] = parent;
        DFSMapDistanceKParent(node.left, node, map);
        DFSMapDistanceKParent(node.right, node, map);
    }

    private void DFSTraversalDistanceK(TreeNode node, int k, Dictionary<TreeNode, TreeNode> map, HashSet<int> visited, List<int> res)
    {
        // create visited to prevent parent go back to same child again
        if (node == null || visited.Contains(node.val))
            return;

        visited.Add(node.val);

        // if distance is 0, means that we need to add to result and no need to continue
        if (k == 0)
        {
            res.Add(node.val);
            return;
        }

        // if distance > 0, we continue to traversal left, right and parent
        DFSTraversalDistanceK(node.left, k - 1, map, visited, res);
        DFSTraversalDistanceK(node.right, k - 1, map, visited, res);
        DFSTraversalDistanceK(map[node], k - 1, map, visited, res);
    }

    public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
    {
        Dictionary<TreeNode, TreeNode> map = new Dictionary<TreeNode, TreeNode>();
        HashSet<int> visited = new HashSet<int>();
        List<int> res = new List<int>();

        // Create a dictionary to map each node with parent
        DFSMapDistanceKParent(root, null, map);

        // Traversal the target with k distance child and parent
        DFSTraversalDistanceK(target, k, map, visited, res);

        return res;
    }
}
// @lc code=end


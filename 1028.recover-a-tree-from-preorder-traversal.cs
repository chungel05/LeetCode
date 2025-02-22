/*
 * @lc app=leetcode id=1028 lang=csharp
 *
 * [1028] Recover a Tree From Preorder Traversal
 *
 * https://leetcode.com/problems/recover-a-tree-from-preorder-traversal/description/
 *
 * algorithms
 * Hard (75.17%)
 * Likes:    1673
 * Dislikes: 47
 * Total Accepted:    58K
 * Total Submissions: 76.9K
 * Testcase Example:  '"1-2--3--4-5--6--7"'
 *
 * We run a preorder depth-first search (DFS) on the root of a binary tree.
 * 
 * At each node in this traversal, we output D dashes (where D is the depth of
 * this node), then we output the value of this node.  If the depth of a node
 * is D, the depth of its immediate child is D + 1.  The depth of the root node
 * is 0.
 * 
 * If a node has only one child, that child is guaranteed to be the left
 * child.
 * 
 * Given the output traversal of this traversal, recover the tree and return
 * its root.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: traversal = "1-2--3--4-5--6--7"
 * Output: [1,2,5,3,4,6,7]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: traversal = "1-2--3---4-5--6---7"
 * Output: [1,2,5,3,null,6,null,4,null,7]
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: traversal = "1-401--349---90--88"
 * Output: [1,401,null,349,88,90]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * The number of nodes in the original tree is in the range [1, 1000].
 * 1 <= Node.val <= 10^9
 * 
 * 
 */
/*
 * Stack Approach
 * Time: O(l) where l = Length of traversal, Space: O(n) where n is no. nodes
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
    // Dictionary Approach
    // Time: O(l) where l = Length of traversal, Space: O(n) where n is no. nodes
    /* public TreeNode RecoverFromPreorder(string traversal)
    {
        Dictionary<int, List<TreeNode>> map = new Dictionary<int, List<TreeNode>>();
        int depth = 0;
        for (int i = 0; i < traversal.Length; i++)
        {
            if (traversal[i] == '-')
            {
                depth++;
                continue;
            }

            int tmp = 0;
            while (i < traversal.Length && traversal[i] != '-')
            {
                tmp = tmp * 10 + (traversal[i] - '0');
                i++;
            }

            if (!map.ContainsKey(depth))
                map[depth] = new List<TreeNode>();

            TreeNode newNode = new TreeNode(tmp);
            map[depth].Add(newNode);
            if (depth != 0)
            {
                TreeNode lastParent = map[depth - 1][^1];
                if (lastParent.left == null)
                    lastParent.left = newNode;
                else
                    lastParent.right = newNode;
            }
            depth = 0;
            i--;
        }
        return map[0][0];
    } */

    // Stack Approach
    // Time: O(l) where l = Length of traversal, Space: O(n) where n is no. nodes
    // Preorder traversal is recurrsive call to visit all the node by root-left-right
    // so it is able to use stack/recurrsive to simulate the situation
    public TreeNode RecoverFromPreorder(string traversal)
    {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        int i = 0;
        // loop all the chars in traversal
        while (i < traversal.Length)
        {
            // count the '-' which is depth
            // root level must be 0
            int depth = 0;
            while (traversal[i] == '-')
            {
                depth++;
                i++;
            }

            // calc the value, which maybe more than 1 digit
            int val = 0;
            while (i < traversal.Length && traversal[i] != '-')
            {
                val = val * 10 + (traversal[i] - '0');
                i++;
            }

            // case 1: depth >= current stack counts, which is similar to recurrsive until the end of child
            // case 2: depth < current stack counts, which some recurrsive are completed, go back to target level
            // so based on the assumption, pop out the completed recurrsive call (nodes)
            while (stack.Count > depth)
                stack.Pop();

            // create new node and assign to left or right of last node (parent)
            TreeNode child = new TreeNode(val);
            if (stack.Count > 0)
            {
                if (stack.Peek().left == null)
                    stack.Peek().left = child;
                else
                    stack.Peek().right = child;
            }
            // push new node to stack as continue to recurrsively visit the childs
            stack.Push(child);
        }

        // after tree recovered, the root will be the last element of stack
        while (stack.Count > 1)
            stack.Pop();

        return stack.Peek();
    }
}
// @lc code=end


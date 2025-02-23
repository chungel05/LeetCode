/*
 * @lc app=leetcode id=889 lang=csharp
 *
 * [889] Construct Binary Tree from Preorder and Postorder Traversal
 *
 * https://leetcode.com/problems/construct-binary-tree-from-preorder-and-postorder-traversal/description/
 *
 * algorithms
 * Medium (71.74%)
 * Likes:    2792
 * Dislikes: 120
 * Total Accepted:    112.1K
 * Total Submissions: 155.3K
 * Testcase Example:  '[1,2,4,5,3,6,7]\n[4,5,2,6,7,3,1]'
 *
 * Given two integer arrays, preorder and postorder where preorder is the
 * preorder traversal of a binary tree of distinct values and postorder is the
 * postorder traversal of the same tree, reconstruct and return the binary
 * tree.
 * 
 * If there exist multiple answers, you can return any of them.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: preorder = [1,2,4,5,3,6,7], postorder = [4,5,2,6,7,3,1]
 * Output: [1,2,3,4,5,6,7]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: preorder = [1], postorder = [1]
 * Output: [1]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= preorder.length <= 30
 * 1 <= preorder[i] <= preorder.length
 * All the values of preorder are unique.
 * postorder.length == preorder.length
 * 1 <= postorder[i] <= postorder.length
 * All the values of postorder are unique.
 * It is guaranteed that preorder and postorder are the preorder traversal and
 * postorder traversal of the same binary tree.
 * 
 * 
 */
/*
 * Dictionary Approach
 * Time: O(n), Space: O(n)
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
    // By obervation, the curr node preorder[i]:
    // its left is preorder[i + 1], its right is postorder[j - 1] where j is index of preorder[i] in postorder
    public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder)
    {
        int n = preorder.Length;
        int[] postIdx = new int[n + 1];
        TreeNode[] tree = new TreeNode[n + 1];

        // use array instead of dictionary because val in nodes are seq.
        for (int i = 0; i < n; i++)
            postIdx[postorder[i]] = i;

        tree[preorder[0]] = new TreeNode(preorder[0]);
        for (int i = 0; i < n; i++)
        {
            int val = preorder[i];
            // current node
            TreeNode curr = tree[val];
            // check its left
            if (i + 1 < n && tree[preorder[i + 1]] == null)
            {
                tree[preorder[i + 1]] = new TreeNode(preorder[i + 1]);
                curr.left = tree[preorder[i + 1]];
            }
            // check its right
            if (postIdx[val] - 1 >= 0 && tree[postorder[postIdx[val] - 1]] == null)
            {
                tree[postorder[postIdx[val] - 1]] = new TreeNode(postorder[postIdx[val] - 1]);
                curr.right = tree[postorder[postIdx[val] - 1]];
            }
        }

        // return first node in preorder which is root
        return tree[preorder[0]];
    }

    // Recurrsive Approach
    // Time: O(n), Space: O(n) because the recurrsive stack use up to n
    /* private TreeNode RecoverConstructFromPrePost(int[] preorder, int[] postorder, ref int preIdx, ref int postIdx)
    {
        TreeNode curr = new TreeNode(preorder[preIdx++]);

        if (curr.val != postorder[postIdx])
            curr.left = RecoverConstructFromPrePost(preorder, postorder, ref preIdx, ref postIdx);

        if (curr.val != postorder[postIdx])
            curr.right = RecoverConstructFromPrePost(preorder, postorder, ref preIdx, ref postIdx);

        postIdx++;
        return curr;
    }

    public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder)
    {
        int i = 0, j = 0;
        return RecoverConstructFromPrePost(preorder, postorder, ref i, ref j);
    } */
}
// @lc code=end


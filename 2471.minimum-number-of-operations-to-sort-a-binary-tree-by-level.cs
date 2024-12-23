/*
 * @lc app=leetcode id=2471 lang=csharp
 *
 * [2471] Minimum Number of Operations to Sort a Binary Tree by Level
 *
 * https://leetcode.com/problems/minimum-number-of-operations-to-sort-a-binary-tree-by-level/description/
 *
 * algorithms
 * Medium (62.19%)
 * Likes:    1106
 * Dislikes: 39
 * Total Accepted:    94.4K
 * Total Submissions: 126.9K
 * Testcase Example:  '[1,4,3,7,6,8,5,null,null,null,null,9,null,10]'
 *
 * You are given the root of a binary tree with unique values.
 * 
 * In one operation, you can choose any two nodes at the same level and swap
 * their values.
 * 
 * Return the minimum number of operations needed to make the values at each
 * level sorted in a strictly increasing order.
 * 
 * The level of a node is the number of edges along the path between it and the
 * root node.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: root = [1,4,3,7,6,8,5,null,null,null,null,9,null,10]
 * Output: 3
 * Explanation:
 * - Swap 4 and 3. The 2^nd level becomes [3,4].
 * - Swap 7 and 5. The 3^rd level becomes [5,6,8,7].
 * - Swap 8 and 7. The 3^rd level becomes [5,6,7,8].
 * We used 3 operations so return 3.
 * It can be proven that 3 is the minimum number of operations needed.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: root = [1,3,2,7,6,5,4]
 * Output: 3
 * Explanation:
 * - Swap 3 and 2. The 2^nd level becomes [2,3].
 * - Swap 7 and 4. The 3^rd level becomes [4,6,5,7].
 * - Swap 6 and 5. The 3^rd level becomes [4,5,6,7].
 * We used 3 operations so return 3.
 * It can be proven that 3 is the minimum number of operations needed.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: root = [1,2,3,4,5,6]
 * Output: 0
 * Explanation: Each level is already sorted in increasing order so return
 * 0.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * The number of nodes in the tree is in the range [1, 10^5].
 * 1 <= Node.val <= 10^5
 * All the values of the tree are unique.
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
    private int CycleSortMinimumOperations(int[][] nums)
    {
        // in order to get the minimum swap operation
        // we need to check the path of cycles in every element

        // created visited to record the element we already proceed
        bool[] visited = new bool[nums.Length];
        int res = 0;

        // sort the nums by its value
        Array.Sort(nums, (x, y) => x[0].CompareTo(y[0]));

        for (int i = 0; i < nums.Length; i++)
        {
            // if the num's position is corrected or visited, we move the other element
            if (nums[i][1] == i || visited[i])
                continue;

            // start from current element, trace the path of cycle
            // i.e. index 0 => index 2 => index 3 => index 0
            // for this cycle, we have 3 nums, and swap 2 times
            int j = i;
            int cycle = 0;
            while (!visited[j])
            {
                visited[j] = true;
                j = nums[j][1];
                cycle++;
            }
            // because we have 3 paths in the example, so our swap operation is 2
            res += cycle - 1;
        }
        return res;
    }

    public int MinimumOperations(TreeNode root)
    {
        int res = 0;
        // create queue to traversal the tree level by level
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);

        while (q.Count > 0)
        {
            int n = q.Count;
            // create nums array to record all the element in the current level
            int[][] nums = new int[n][];
            for (int i = 0; i < n; i++)
            {
                TreeNode tmp = q.Dequeue();
                // record the val and position
                nums[i] = new int[] { tmp.val, i };

                // Enqueue normally from left to right
                if (tmp.left != null)
                    q.Enqueue(tmp.left);
                if (tmp.right != null)
                    q.Enqueue(tmp.right);
            }
            // use the cycle sort to count the minimum swap operation
            res += CycleSortMinimumOperations(nums);
        }
        return res;
    }
}
// @lc code=end


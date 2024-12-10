/*
 * @lc app=leetcode id=64 lang=csharp
 *
 * [64] Minimum Path Sum
 *
 * https://leetcode.com/problems/minimum-path-sum/description/
 *
 * algorithms
 * Medium (65.09%)
 * Likes:    12718
 * Dislikes: 177
 * Total Accepted:    1.4M
 * Total Submissions: 2.1M
 * Testcase Example:  '[[1,3,1],[1,5,1],[4,2,1]]'
 *
 * Given a m x n grid filled with non-negative numbers, find a path from top
 * left to bottom right, which minimizes the sum of all numbers along its
 * path.
 * 
 * Note: You can only move either down or right at any point in time.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: grid = [[1,3,1],[1,5,1],[4,2,1]]
 * Output: 7
 * Explanation: Because the path 1 → 3 → 1 → 1 → 1 minimizes the sum.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: grid = [[1,2,3],[4,5,6]]
 * Output: 12
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * m == grid.length
 * n == grid[i].length
 * 1 <= m, n <= 200
 * 0 <= grid[i][j] <= 200
 * 
 * 
 */
/*
 * Time: O(m*n), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    public int MinPathSum(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                // if grid[0][0], sum = val itself
                if (i == 0 && j == 0)
                    continue;

                // since only two direction can come to the cell, top / left
                // sum = min(top, left) + val itself
                int top = i - 1 < 0 ? int.MaxValue : grid[i - 1][j];
                int left = j - 1 < 0 ? int.MaxValue : grid[i][j - 1];
                grid[i][j] = grid[i][j] + Math.Min(top, left);
            }
        }
        return grid[m - 1][n - 1];
    }
}
// @lc code=end


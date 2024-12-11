/*
 * @lc app=leetcode id=221 lang=csharp
 *
 * [221] Maximal Square
 *
 * https://leetcode.com/problems/maximal-square/description/
 *
 * algorithms
 * Medium (47.43%)
 * Likes:    10371
 * Dislikes: 235
 * Total Accepted:    753.3K
 * Total Submissions: 1.6M
 * Testcase Example:  '[["1","0","1","0","0"],["1","0","1","1","1"],["1","1","1","1","1"],["1","0","0","1","0"]]'
 *
 * Given an m x n binary matrix filled with 0's and 1's, find the largest
 * square containing only 1's and return its area.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: matrix =
 * [["1","0","1","0","0"],["1","0","1","1","1"],["1","1","1","1","1"],["1","0","0","1","0"]]
 * Output: 4
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: matrix = [["0","1"],["1","0"]]
 * Output: 1
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: matrix = [["0"]]
 * Output: 0
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * m == matrix.length
 * n == matrix[i].length
 * 1 <= m, n <= 300
 * matrix[i][j] is '0' or '1'.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int MaximalSquare(char[][] matrix)
    {
        int m = matrix.Length, n = matrix[0].Length;
        // create 2D DP [m + 1][n + 1] to store the max square size of that cell
        int[][] dp = new int[m + 1][];

        // initialized base case, all 0
        for (int i = 0; i <= m; i++)
        {
            dp[i] = new int[n + 1];
        }

        // create int to trace the max size
        int maxSizeSquare = 0;
        // loop from bottom right to top left
        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                // if matrix == '1', we check the min size of adj. cell
                // bottom(i + 1, j), right(i, j + 1), bottom-right(i + 1, j + 1)
                // the size of current cell = 1 + min size of adj. cells
                if (matrix[i][j] == '1')
                    dp[i][j] = 1 + Math.Min(Math.Min(dp[i + 1][j], dp[i][j + 1]), dp[i + 1][j + 1]);
                maxSizeSquare = Math.Max(maxSizeSquare, dp[i][j]);
            }
        }
        // return the area of max size
        return maxSizeSquare * maxSizeSquare;
    }
}
// @lc code=end


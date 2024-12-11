/*
 * @lc app=leetcode id=1277 lang=csharp
 *
 * [1277] Count Square Submatrices with All Ones
 *
 * https://leetcode.com/problems/count-square-submatrices-with-all-ones/description/
 *
 * algorithms
 * Medium (75.59%)
 * Likes:    5380
 * Dislikes: 98
 * Total Accepted:    327.7K
 * Total Submissions: 417.9K
 * Testcase Example:  '[[0,1,1,1],[1,1,1,1],[0,1,1,1]]'
 *
 * Given a m * n matrix of ones and zeros, return how many square submatrices
 * have all ones.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: matrix =
 * [
 * [0,1,1,1],
 * [1,1,1,1],
 * [0,1,1,1]
 * ]
 * Output: 15
 * Explanation: 
 * There are 10 squares of side 1.
 * There are 4 squares of side 2.
 * There is  1 square of side 3.
 * Total number of squares = 10 + 4 + 1 = 15.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: matrix = 
 * [
 * ⁠ [1,0,1],
 * ⁠ [1,1,0],
 * ⁠ [1,1,0]
 * ]
 * Output: 7
 * Explanation: 
 * There are 6 squares of side 1.  
 * There is 1 square of side 2. 
 * Total number of squares = 6 + 1 = 7.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= arr.length <= 300
 * 1 <= arr[0].length <= 300
 * 0 <= arr[i][j] <= 1
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int CountSquares(int[][] matrix)
    {
        int m = matrix.Length, n = matrix[0].Length;
        // create 2D DP with [m + 1][n + 1] to store the max square formed in that cell
        int[][] dp = new int[m + 1][];

        // base case, all 0
        for (int i = 0; i <= m; i++)
        {
            dp[i] = new int[n + 1];
        }

        // create int to trace the sum of square
        int sumOfSquare = 0;
        // loop from bottom right to top left
        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                // if matrix = 1, check min square formed in the adj. cell
                // bottom(i + 1, j), right(i, j + 1), bottom-right(i + 1, j + 1)
                // the square formed in current cell = 1 + min(square formed in adj. cell)
                if (matrix[i][j] == 1)
                    dp[i][j] = 1 + Math.Min(Math.Min(dp[i + 1][j], dp[i][j + 1]), dp[i + 1][j + 1]);

                // sum all the square formed
                sumOfSquare += dp[i][j];
            }
        }
        return sumOfSquare;
    }
}
// @lc code=end


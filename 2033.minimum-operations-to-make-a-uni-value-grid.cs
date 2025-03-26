/*
 * @lc app=leetcode id=2033 lang=csharp
 *
 * [2033] Minimum Operations to Make a Uni-Value Grid
 *
 * https://leetcode.com/problems/minimum-operations-to-make-a-uni-value-grid/description/
 *
 * algorithms
 * Medium (53.51%)
 * Likes:    606
 * Dislikes: 44
 * Total Accepted:    33.6K
 * Total Submissions: 59.1K
 * Testcase Example:  '[[2,4],[6,8]]\n2'
 *
 * You are given a 2D integer grid of size m x n and an integer x. In one
 * operation, you can add x to or subtract x from any element in the grid.
 * 
 * A uni-value grid is a grid where all the elements of it are equal.
 * 
 * Return the minimum number of operations to make the grid uni-value. If it is
 * not possible, return -1.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: grid = [[2,4],[6,8]], x = 2
 * Output: 4
 * Explanation: We can make every element equal to 4 by doing the following: 
 * - Add x to 2 once.
 * - Subtract x from 6 once.
 * - Subtract x from 8 twice.
 * A total of 4 operations were used.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: grid = [[1,5],[2,3]], x = 1
 * Output: 5
 * Explanation: We can make every element equal to 3.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: grid = [[1,2],[3,4]], x = 2
 * Output: -1
 * Explanation: It is impossible to make every element equal.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * m == grid.length
 * n == grid[i].length
 * 1 <= m, n <= 10^5
 * 1 <= m * n <= 10^5
 * 1 <= x, grid[i][j] <= 10^4
 * 
 * 
 */
/*
 * Math and Sorting Approach
 * Time: O(mn * log (mn)), Space: O(mn)
 */

// @lc code=start
public partial class Solution
{
    public int MinOperations(int[][] grid, int x)
    {
        int m = grid.Length, n = grid[0].Length;
        // Flatten 2D array into 1D array
        int[] nums = new int[m * n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                // assume add/subtract ?x to grid[0][0], and make it equal to grid[i][j]
                // then ? should be integer, and difference ?x should be divisible by x
                // if it is not divisible, return -1
                if ((grid[i][j] - grid[0][0]) % x != 0)
                    return -1;

                nums[i * n + j] = grid[i][j];
            }
        }

        // sort the nums, and make all nums equal to median
        Array.Sort(nums, (a, b) => a - b);
        int operation = 0, median = nums[m * n / 2];
        for (int i = 0; i < m * n; i++)
        {
            // calc the operations that needed to make nums[i] equal to median
            operation += Math.Abs(median - nums[i]) / x;
        }
        return operation;
    }
}
// @lc code=end


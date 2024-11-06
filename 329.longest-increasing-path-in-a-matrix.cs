/*
 * @lc app=leetcode id=329 lang=csharp
 *
 * [329] Longest Increasing Path in a Matrix
 *
 * https://leetcode.com/problems/longest-increasing-path-in-a-matrix/description/
 *
 * algorithms
 * Hard (54.20%)
 * Likes:    9047
 * Dislikes: 137
 * Total Accepted:    568.9K
 * Total Submissions: 1M
 * Testcase Example:  '[[9,9,4],[6,6,8],[2,1,1]]'
 *
 * Given an m x n integers matrix, return the length of the longest increasing
 * path in matrix.
 * 
 * From each cell, you can either move in four directions: left, right, up, or
 * down. You may not move diagonally or move outside the boundary (i.e.,
 * wrap-around is not allowed).
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: matrix = [[9,9,4],[6,6,8],[2,1,1]]
 * Output: 4
 * Explanation: The longest increasing path is [1, 2, 6, 9].
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: matrix = [[3,4,5],[3,2,6],[2,2,1]]
 * Output: 4
 * Explanation: The longest increasing path is [3, 4, 5, 6]. Moving diagonally
 * is not allowed.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: matrix = [[1]]
 * Output: 1
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * m == matrix.length
 * n == matrix[i].length
 * 1 <= m, n <= 200
 * 0 <= matrix[i][j] <= 2^31 - 1
 * 
 * 
 */
/*
 * Top-down approach with caching
 * No need to have visited dictionary to record the current path
 * because the visited field must small then the caller field
 * (i.e. 4 -> 6 -> 4) caller = 6, visited = 4, it will return 0
 */

// @lc code=start
public partial class Solution
{
    public int DFSLongestIncreasingPath(int[][] matrix, int i, int j, int prev, Dictionary<(int, int), int> dp)
    {
        if (i < 0 || j < 0 || i >= matrix.Length || j >= matrix[0].Length || prev >= matrix[i][j])
            return 0;

        var key = (i, j);
        if (dp.ContainsKey(key))
            return dp[key];

        int updown = Math.Max(DFSLongestIncreasingPath(matrix, i - 1, j, matrix[i][j], dp), DFSLongestIncreasingPath(matrix, i + 1, j, matrix[i][j], dp));
        int leftright = Math.Max(DFSLongestIncreasingPath(matrix, i, j - 1, matrix[i][j], dp), DFSLongestIncreasingPath(matrix, i, j + 1, matrix[i][j], dp));
        int res = 1 + Math.Max(updown, leftright);

        dp[key] = res;
        return res;
    }

    public int LongestIncreasingPath(int[][] matrix)
    {
        Dictionary<(int, int), int> dp = new Dictionary<(int, int), int>();

        int res = 0;
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                res = Math.Max(res, DFSLongestIncreasingPath(matrix, i, j, -1, dp));
            }
        }
        return res;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=54 lang=csharp
 *
 * [54] Spiral Matrix
 *
 * https://leetcode.com/problems/spiral-matrix/description/
 *
 * algorithms
 * Medium (51.53%)
 * Likes:    15270
 * Dislikes: 1371
 * Total Accepted:    1.7M
 * Total Submissions: 3.2M
 * Testcase Example:  '[[1,2,3],[4,5,6],[7,8,9]]'
 *
 * Given an m x n matrix, return all elements of the matrix in spiral order.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
 * Output: [1,2,3,6,9,8,7,4,5]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]
 * Output: [1,2,3,4,8,12,11,10,9,5,6,7]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * m == matrix.length
 * n == matrix[i].length
 * 1 <= m, n <= 10
 * -100 <= matrix[i][j] <= 100
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        int l = 0, r = matrix[0].Length, top = 0, bottom = matrix.Length;
        List<int> res = new List<int>();

        while (l < r && top < bottom)
        {
            for (int i = l; i < r; i++)
            {
                res.Add(matrix[top][i]);
            }
            top++;

            for (int i = top; i < bottom; i++)
            {
                res.Add(matrix[i][r - 1]);
            }
            r--;

            if (!(l < r && top < bottom))
                break;

            for (int i = r - 1; i >= l; i--)
            {
                res.Add(matrix[bottom - 1][i]);
            }
            bottom--;

            for (int i = bottom - 1; i >= top; i--)
            {
                res.Add(matrix[i][l]);
            }
            l++;
        }
        return res;
    }
}
// @lc code=end


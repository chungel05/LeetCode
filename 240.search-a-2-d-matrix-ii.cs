/*
 * @lc app=leetcode id=240 lang=csharp
 *
 * [240] Search a 2D Matrix II
 *
 * https://leetcode.com/problems/search-a-2d-matrix-ii/description/
 *
 * algorithms
 * Medium (53.63%)
 * Likes:    12111
 * Dislikes: 210
 * Total Accepted:    1M
 * Total Submissions: 1.9M
 * Testcase Example:  '[[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]]\n' +
  '5'
 *
 * Write an efficient algorithm that searches for a value target in an m x n
 * integer matrix matrix. This matrix has the following properties:
 * 
 * 
 * Integers in each row are sorted in ascending from left to right.
 * Integers in each column are sorted in ascending from top to bottom.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: matrix =
 * [[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]],
 * target = 5
 * Output: true
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: matrix =
 * [[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]],
 * target = 20
 * Output: false
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * m == matrix.length
 * n == matrix[i].length
 * 1 <= n, m <= 300
 * -10^9 <= matrix[i][j] <= 10^9
 * All the integers in each row are sorted in ascending order.
 * All the integers in each column are sorted in ascending order.
 * -10^9 <= target <= 10^9
 * 
 * 
 */
/*
 * Binary search approach
 * Time: O(m * log n), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            if (target >= matrix[i][0] && target <= matrix[i][matrix[0].Length - 1])
            {
                int l = 0, r = matrix[0].Length - 1;
                while (l <= r)
                {
                    int mid = (l + r) / 2;
                    if (matrix[i][mid] == target)
                        return true;
                    else if (matrix[i][mid] > target)
                        r = mid - 1;
                    else
                        l = mid + 1;
                }
            }
        }
        return false;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=73 lang=csharp
 *
 * [73] Set Matrix Zeroes
 *
 * https://leetcode.com/problems/set-matrix-zeroes/description/
 *
 * algorithms
 * Medium (57.64%)
 * Likes:    14924
 * Dislikes: 761
 * Total Accepted:    1.7M
 * Total Submissions: 2.9M
 * Testcase Example:  '[[1,1,1],[1,0,1],[1,1,1]]'
 *
 * Given an m x n integer matrix matrix, if an element is 0, set its entire row
 * and column to 0's.
 * 
 * You must do it in place.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: matrix = [[1,1,1],[1,0,1],[1,1,1]]
 * Output: [[1,0,1],[0,0,0],[1,0,1]]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: matrix = [[0,1,2,0],[3,4,5,2],[1,3,1,5]]
 * Output: [[0,0,0,0],[0,4,5,0],[0,3,1,0]]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * m == matrix.length
 * n == matrix[0].length
 * 1 <= m, n <= 200
 * -2^31 <= matrix[i][j] <= 2^31 - 1
 * 
 * 
 * 
 * Follow up:
 * 
 * 
 * A straightforward solution using O(mn) space is probably a bad idea.
 * A simple improvement uses O(m + n) space, but still not the best
 * solution.
 * Could you devise a constant space solution?
 * 
 * 
 */
/*
 * Array Space Optimal Approach
 * Time: O(mn), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    public void SetZeroes(int[][] matrix)
    {
        // since matrix[0][0] will affected by other cells in col j = 0
        // first row will be affected incorrectly
        // so, instead of changing matrix[0][0], use boolean to record
        bool col0 = false;
        for (int i = 0; i < matrix.Length; i++)
        {
            if (matrix[i][0] == 0)
                col0 = true;

            for (int j = 1; j < matrix[0].Length; j++)
            {
                // mark 0 in first row and first col
                if (matrix[i][j] == 0)
                {
                    matrix[i][0] = 0;
                    matrix[0][j] = 0;
                }
            }
        }

        // from [m - 1, n - 1] to [0, 0]
        // to prevent changing of indicator: first row and first col
        for (int i = matrix.Length - 1; i >= 0; i--)
        {
            for (int j = matrix[0].Length - 1; j >= 1; j--)
            {
                if (matrix[i][0] == 0 || matrix[0][j] == 0)
                    matrix[i][j] = 0;
            }
            if (col0)
                matrix[i][0] = 0;
        }
    }

    // Hash Approach
    // Time: O(mn), Space: O(m + n)
    /* public void SetZeroes(int[][] matrix)
    {
        HashSet<int> row = new HashSet<int>();
        HashSet<int> col = new HashSet<int>();

        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                if (matrix[i][j] == 0)
                {
                    if (!row.Contains(i))
                        row.Add(i);

                    if (!col.Contains(j))
                        col.Add(j);
                }
            }
        }

        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                if (row.Contains(i) || col.Contains(j))
                    matrix[i][j] = 0;
            }
        }

    } */
}
// @lc code=end


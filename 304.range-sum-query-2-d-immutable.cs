/*
 * @lc app=leetcode id=304 lang=csharp
 *
 * [304] Range Sum Query 2D - Immutable
 *
 * https://leetcode.com/problems/range-sum-query-2d-immutable/description/
 *
 * algorithms
 * Medium (55.35%)
 * Likes:    5028
 * Dislikes: 348
 * Total Accepted:    389.3K
 * Total Submissions: 701.7K
 * Testcase Example:  '["NumMatrix","sumRegion","sumRegion","sumRegion"]\n' +
  '[[[[3,0,1,4,2],[5,6,3,2,1],[1,2,0,1,5],[4,1,0,1,7],[1,0,3,0,5]]],[2,1,4,3],[1,1,2,2],[1,2,2,4]]'
 *
 * Given a 2D matrix matrix, handle multiple queries of the following
 * type:
 * 
 * 
 * Calculate the sum of the elements of matrix inside the rectangle defined by
 * its upper left corner (row1, col1) and lower right corner (row2, col2).
 * 
 * 
 * Implement the NumMatrix class:
 * 
 * 
 * NumMatrix(int[][] matrix) Initializes the object with the integer matrix
 * matrix.
 * int sumRegion(int row1, int col1, int row2, int col2) Returns the sum of the
 * elements of matrix inside the rectangle defined by its upper left corner
 * (row1, col1) and lower right corner (row2, col2).
 * 
 * 
 * You must design an algorithm where sumRegion works on O(1) time
 * complexity.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input
 * ["NumMatrix", "sumRegion", "sumRegion", "sumRegion"]
 * [[[[3, 0, 1, 4, 2], [5, 6, 3, 2, 1], [1, 2, 0, 1, 5], [4, 1, 0, 1, 7], [1,
 * 0, 3, 0, 5]]], [2, 1, 4, 3], [1, 1, 2, 2], [1, 2, 2, 4]]
 * Output
 * [null, 8, 11, 12]
 * 
 * Explanation
 * NumMatrix numMatrix = new NumMatrix([[3, 0, 1, 4, 2], [5, 6, 3, 2, 1], [1,
 * 2, 0, 1, 5], [4, 1, 0, 1, 7], [1, 0, 3, 0, 5]]);
 * numMatrix.sumRegion(2, 1, 4, 3); // return 8 (i.e sum of the red rectangle)
 * numMatrix.sumRegion(1, 1, 2, 2); // return 11 (i.e sum of the green
 * rectangle)
 * numMatrix.sumRegion(1, 2, 2, 4); // return 12 (i.e sum of the blue
 * rectangle)
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * m == matrix.length
 * n == matrix[i].length
 * 1 <= m, n <= 200
 * -10^4 <= matrix[i][j] <= 10^4
 * 0 <= row1 <= row2 < m
 * 0 <= col1 <= col2 < n
 * At most 10^4 calls will be made to sumRegion.
 * 
 * 
 */

// @lc code=start
public class NumMatrix
{
    private int[][] prefixSumMatrix;

    public NumMatrix(int[][] matrix)
    {
        if (matrix.Length == 0 || matrix[0].Length == 0)
            return;

        int m = matrix.Length;
        int n = matrix[0].Length;
        prefixSumMatrix = new int[m + 1][];
        prefixSumMatrix[0] = new int[n + 1];

        for (int i = 1; i < m + 1; i++)
        {
            prefixSumMatrix[i] = new int[n + 1];
            for (int j = 1; j < n + 1; j++)
            {
                // since row[0] and col[0] are additional zero, so we need to reduce 1 in matrix
                // only [i - 1][j - 1] part is duplicated, so reduce it
                prefixSumMatrix[i][j] = prefixSumMatrix[i - 1][j] + prefixSumMatrix[i][j - 1]
                                        + matrix[i - 1][j - 1] - prefixSumMatrix[i - 1][j - 1];
            }
        }
    }

    public int SumRegion(int row1, int col1, int row2, int col2)
    {
        // since the row and col are corresponding to matrix, so we need to add 1
        return prefixSumMatrix[row2 + 1][col2 + 1] - prefixSumMatrix[row1][col2 + 1]
                - prefixSumMatrix[row2 + 1][col1] + prefixSumMatrix[row1][col1];
    }
}

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * int param_1 = obj.SumRegion(row1,col1,row2,col2);
 */
// @lc code=end


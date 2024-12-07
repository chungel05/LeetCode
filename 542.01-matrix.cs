/*
 * @lc app=leetcode id=542 lang=csharp
 *
 * [542] 01 Matrix
 *
 * https://leetcode.com/problems/01-matrix/description/
 *
 * algorithms
 * Medium (49.63%)
 * Likes:    9751
 * Dislikes: 426
 * Total Accepted:    649K
 * Total Submissions: 1.3M
 * Testcase Example:  '[[0,0,0],[0,1,0],[0,0,0]]'
 *
 * Given an m x n binary matrix mat, return the distance of the nearest 0 for
 * each cell.
 * 
 * The distance between two adjacent cells is 1.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: mat = [[0,0,0],[0,1,0],[0,0,0]]
 * Output: [[0,0,0],[0,1,0],[0,0,0]]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: mat = [[0,0,0],[0,1,0],[1,1,1]]
 * Output: [[0,0,0],[0,1,0],[1,2,1]]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * m == mat.length
 * n == mat[i].length
 * 1 <= m, n <= 10^4
 * 1 <= m * n <= 10^4
 * mat[i][j] is either 0 or 1.
 * There is at least one 0 in mat.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int[][] UpdateMatrix(int[][] mat)
    {
        int m = mat.Length, n = mat[0].Length;
        // create array for holding the result and record as visited
        int[][] res = new int[m][];
        Queue<(int, int)> q = new Queue<(int, int)>();
        // create array for 4 direction cases
        int[] direction = new int[] { -1, 0, 1, 0, -1 };

        // initialized result array
        for (int i = 0; i < m; i++)
        {
            res[i] = new int[n];
            for (int j = 0; j < n; j++)
            {
                // if it is 0, we enqueue it and mark as 0 distance
                if (mat[i][j] == 0)
                {
                    q.Enqueue((i, j));
                    res[i][j] = 0;
                }
                // otherwise, we mark as -1 which is not computed
                else
                    res[i][j] = -1;
            }
        }

        while (q.Count > 0)
        {
            for (int i = q.Count; i > 0; i--)
            {
                (int row, int col) = q.Dequeue();

                // for 4 direction cases
                for (int j = 0; j < 4; j++)
                {
                    int newRow = row + direction[j];
                    int newCol = col + direction[j + 1];

                    // if out of range, continue to next direction
                    if (newRow >= m || newCol >= n || newRow < 0 || newCol < 0)
                        continue;

                    // if next direction is not computed
                    if (res[newRow][newCol] == -1)
                    {
                        // we mark it as current distance + 1, and enqueue it for next level
                        res[newRow][newCol] = res[row][col] + 1;
                        q.Enqueue((newRow, newCol));
                    }
                }
            }
        }

        return res;
    }
}
// @lc code=end


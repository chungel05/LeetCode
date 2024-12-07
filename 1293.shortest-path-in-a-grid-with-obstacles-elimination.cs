/*
 * @lc app=leetcode id=1293 lang=csharp
 *
 * [1293] Shortest Path in a Grid with Obstacles Elimination
 *
 * https://leetcode.com/problems/shortest-path-in-a-grid-with-obstacles-elimination/description/
 *
 * algorithms
 * Hard (45.33%)
 * Likes:    4597
 * Dislikes: 84
 * Total Accepted:    225.5K
 * Total Submissions: 496.7K
 * Testcase Example:  '[[0,0,0],[1,1,0],[0,0,0],[0,1,1],[0,0,0]]\n1'
 *
 * You are given an m x n integer matrix grid where each cell is either 0
 * (empty) or 1 (obstacle). You can move up, down, left, or right from and to
 * an empty cell in one step.
 * 
 * Return the minimum number of steps to walk from the upper left corner (0, 0)
 * to the lower right corner (m - 1, n - 1) given that you can eliminate at
 * most k obstacles. If it is not possible to find such walk return -1.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: grid = [[0,0,0],[1,1,0],[0,0,0],[0,1,1],[0,0,0]], k = 1
 * Output: 6
 * Explanation: 
 * The shortest path without eliminating any obstacle is 10.
 * The shortest path with one obstacle elimination at position (3,2) is 6. Such
 * path is (0,0) -> (0,1) -> (0,2) -> (1,2) -> (2,2) -> (3,2) -> (4,2).
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: grid = [[0,1,1],[1,1,1],[1,0,0]], k = 1
 * Output: -1
 * Explanation: We need to eliminate at least two obstacles to find such a
 * walk.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * m == grid.length
 * n == grid[i].length
 * 1 <= m, n <= 40
 * 1 <= k <= m * n
 * grid[i][j] is either 0 or 1.
 * grid[0][0] == grid[m - 1][n - 1] == 0
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int ShortestPath(int[][] grid, int k)
    {
        int m = grid.Length, n = grid[0].Length;
        // create 3-D array for mark as visited, for each (row, col) it may have different route according to obs
        bool[][][] visited = new bool[m][][];
        // create array for 4 direction cases
        int[] direction = new int[] { -1, 0, 1, 0, -1 };
        // queue for BFS, (int row, int col, int obs)
        Queue<(int, int, int)> q = new Queue<(int, int, int)>();

        for (int i = 0; i < m; i++)
        {
            visited[i] = new bool[n][];
            for (int j = 0; j < n; j++)
            {
                visited[i][j] = new bool[k + 1];
                Array.Fill(visited[i][j], false);
            }
        }

        // start from (0,0) which must be 0
        q.Enqueue((0, 0, 0));
        visited[0][0][0] = true;

        int count = 0;
        while (q.Count > 0)
        {
            for (int i = q.Count; i > 0; i--)
            {
                (int row, int col, int obs) = q.Dequeue();

                // if we reach (m - 1, n - 1), return current level
                if (row == m - 1 && col == n - 1)
                    return count;

                for (int j = 0; j < 4; j++)
                {
                    int newRow = row + direction[j];
                    int newCol = col + direction[j + 1];

                    // check the new row and col are out of range or not
                    if (newRow >= m || newCol >= n || newRow < 0 || newCol < 0)
                        continue;

                    // get the new obs
                    // if it is obstacle (1), we +1
                    // if it is not obstacle (0), we +0
                    int newObs = obs + grid[newRow][newCol];

                    // check the current obs exceeds k or not
                    // if it is visited, we also skip
                    if (newObs > k || visited[newRow][newCol][newObs])
                        continue;

                    visited[newRow][newCol][newObs] = true;
                    q.Enqueue((newRow, newCol, newObs));
                }
            }
            count++;
        }
        return -1;
    }
}
// @lc code=end


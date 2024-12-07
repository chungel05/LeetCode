/*
 * @lc app=leetcode id=1091 lang=csharp
 *
 * [1091] Shortest Path in Binary Matrix
 *
 * https://leetcode.com/problems/shortest-path-in-binary-matrix/description/
 *
 * algorithms
 * Medium (48.24%)
 * Likes:    6722
 * Dislikes: 252
 * Total Accepted:    572.6K
 * Total Submissions: 1.2M
 * Testcase Example:  '[[0,1],[1,0]]'
 *
 * Given an n x n binary matrix grid, return the length of the shortest clear
 * path in the matrix. If there is no clear path, return -1.
 * 
 * A clear path in a binary matrix is a path from the top-left cell (i.e., (0,
 * 0)) to the bottom-right cell (i.e., (n - 1, n - 1)) such that:
 * 
 * 
 * All the visited cells of the path are 0.
 * All the adjacent cells of the path are 8-directionally connected (i.e., they
 * are different and they share an edge or a corner).
 * 
 * 
 * The length of a clear path is the number of visited cells of this path.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: grid = [[0,1],[1,0]]
 * Output: 2
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: grid = [[0,0,0],[1,1,0],[1,1,0]]
 * Output: 4
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: grid = [[1,0,0],[1,1,0],[1,1,0]]
 * Output: -1
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * n == grid.length
 * n == grid[i].length
 * 1 <= n <= 100
 * grid[i][j] is 0 or 1
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int ShortestPathBinaryMatrix(int[][] grid)
    {
        int n = grid.Length;
        // create array to mark it as visited
        bool[][] visited = new bool[n][];
        Queue<(int, int)> q = new Queue<(int, int)>();
        // create array for 8 direction cases
        int[] direction = new int[] { 0, -1, 1, -1, -1, 0, 1, 1, 0 };

        for (int i = 0; i < n; i++)
        {
            visited[i] = new bool[n];
        }

        int len = 0;
        // if grid[0][0] == 1, there is no clear path
        if (grid[0][0] == 0)
        {
            q.Enqueue((0, 0));
            visited[0][0] = true;
        }

        while (q.Count > 0)
        {
            len++;
            for (int i = q.Count; i > 0; i--)
            {
                (int row, int col) = q.Dequeue();
                // if we meet the target, return current level
                if (row == n - 1 && col == n - 1)
                    return len;

                for (int j = 1; j < direction.Length; j++)
                {
                    int newRow = row + direction[j - 1];
                    int newCol = col + direction[j];

                    // if out of range, continue to next direction
                    if (newRow >= n || newCol >= n || newRow < 0 || newCol < 0)
                        continue;

                    // not visited and cell val = 0
                    if (grid[newRow][newCol] == 0 && !visited[newRow][newCol])
                    {
                        q.Enqueue((newRow, newCol));
                        visited[newRow][newCol] = true;
                    }
                }
            }
        }

        return -1;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=994 lang=csharp
 *
 * [994] Rotting Oranges
 *
 * https://leetcode.com/problems/rotting-oranges/description/
 *
 * algorithms
 * Medium (55.12%)
 * Likes:    13198
 * Dislikes: 417
 * Total Accepted:    1M
 * Total Submissions: 1.8M
 * Testcase Example:  '[[2,1,1],[1,1,0],[0,1,1]]'
 *
 * You are given an m x n grid where each cell can have one of three
 * values:
 * 
 * 
 * 0 representing an empty cell,
 * 1 representing a fresh orange, or
 * 2 representing a rotten orange.
 * 
 * 
 * Every minute, any fresh orange that is 4-directionally adjacent to a rotten
 * orange becomes rotten.
 * 
 * Return the minimum number of minutes that must elapse until no cell has a
 * fresh orange. If this is impossible, return -1.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: grid = [[2,1,1],[1,1,0],[0,1,1]]
 * Output: 4
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: grid = [[2,1,1],[0,1,1],[1,0,1]]
 * Output: -1
 * Explanation: The orange in the bottom left corner (row 2, column 0) is never
 * rotten, because rotting only happens 4-directionally.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: grid = [[0,2]]
 * Output: 0
 * Explanation: Since there are already no fresh oranges at minute 0, the
 * answer is just 0.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * m == grid.length
 * n == grid[i].length
 * 1 <= m, n <= 10
 * grid[i][j] is 0, 1, or 2.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int OrangesRotting(int[][] grid)
    {
        int time = 0;
        int fresh = 0;
        Queue<int[]> q = new Queue<int[]>();
        int[][] direction = new int[][]
        {
            new int[] { 1, 0},
            new int[] { -1, 0},
            new int[] { 0, 1},
            new int[] { 0, -1}
        };

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 1)
                    fresh++;
                else if (grid[i][j] == 2)
                    q.Enqueue(new int[] { i, j });
            }
        }

        while (q.Count > 0 && fresh > 0)
        {
            int len = q.Count;
            for (int i = 0; i < len; i++)
            {
                int[] tmp = q.Dequeue();
                foreach (var d in direction)
                {
                    int row = d[0] + tmp[0];
                    int col = d[1] + tmp[1];
                    if (row < 0 || col < 0 || row >= grid.Length || col >= grid[0].Length || grid[row][col] != 1)
                        continue;

                    grid[row][col] = 2;
                    fresh--;
                    q.Enqueue(new int[] { row, col });
                }
            }
            time++;
        }

        return fresh == 0 ? time : -1;
    }
}
// @lc code=end


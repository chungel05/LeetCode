/*
 * @lc app=leetcode id=778 lang=csharp
 *
 * [778] Swim in Rising Water
 *
 * https://leetcode.com/problems/swim-in-rising-water/description/
 *
 * algorithms
 * Hard (61.64%)
 * Likes:    3782
 * Dislikes: 259
 * Total Accepted:    187.4K
 * Total Submissions: 303.7K
 * Testcase Example:  '[[0,2],[1,3]]'
 *
 * You are given an n x n integer matrix grid where each value grid[i][j]
 * represents the elevation at that point (i, j).
 * 
 * The rain starts to fall. At time t, the depth of the water everywhere is t.
 * You can swim from a square to another 4-directionally adjacent square if and
 * only if the elevation of both squares individually are at most t. You can
 * swim infinite distances in zero time. Of course, you must stay within the
 * boundaries of the grid during your swim.
 * 
 * Return the least time until you can reach the bottom right square (n - 1, n
 * - 1) if you start at the top left square (0, 0).
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: grid = [[0,2],[1,3]]
 * Output: 3
 * Explanation:
 * At time 0, you are in grid location (0, 0).
 * You cannot go anywhere else because 4-directionally adjacent neighbors have
 * a higher elevation than t = 0.
 * You cannot reach point (1, 1) until time 3.
 * When the depth of water is 3, we can swim anywhere inside the grid.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: grid =
 * [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
 * Output: 16
 * Explanation: The final route is shown.
 * We need to wait until time 16 so that (0, 0) and (4, 4) are connected.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * n == grid.length
 * n == grid[i].length
 * 1 <= n <= 50
 * 0 <= grid[i][j] < n^2
 * Each value grid[i][j] is unique.
 * 
 * 
 */
/*
 * Dijkstra's Algorithm Implementation
 */

// @lc code=start
public partial class Solution
{
    public int SwimInWater(int[][] grid)
    {
        HashSet<(int, int)> visited = new HashSet<(int, int)>();
        var minHeap = new PriorityQueue<(int t, int r, int c), int>();
        int[] direction = new int[] { 0, -1, 0, 1, 0 };

        minHeap.Enqueue((grid[0][0], 0, 0), grid[0][0]);
        visited.Add((0, 0));

        while (minHeap.Count > 0)
        {
            var tmp = minHeap.Dequeue();
            if (tmp.r == grid.Length - 1 && tmp.c == grid.Length - 1)
                return tmp.t;

            for (int i = 0; i < direction.Length - 1; i++)
            {
                int r = tmp.r + direction[i];
                int c = tmp.c + direction[i + 1];
                if (r < 0 || c < 0 || r >= grid.Length || c >= grid.Length || visited.Contains((r, c)))
                    continue;

                visited.Add((r, c));
                minHeap.Enqueue((Math.Max(grid[r][c], tmp.t), r, c), Math.Max(grid[r][c], tmp.t));
            }

        }
        return 0;
    }
}
// @lc code=end


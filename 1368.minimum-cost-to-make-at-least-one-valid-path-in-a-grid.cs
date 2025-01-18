/*
 * @lc app=leetcode id=1368 lang=csharp
 *
 * [1368] Minimum Cost to Make at Least One Valid Path in a Grid
 *
 * https://leetcode.com/problems/minimum-cost-to-make-at-least-one-valid-path-in-a-grid/description/
 *
 * algorithms
 * Hard (62.50%)
 * Likes:    1958
 * Dislikes: 21
 * Total Accepted:    67.2K
 * Total Submissions: 103.1K
 * Testcase Example:  '[[1,1,1,1],[2,2,2,2],[1,1,1,1],[2,2,2,2]]'
 *
 * Given an m x n grid. Each cell of the grid has a sign pointing to the next
 * cell you should visit if you are currently in this cell. The sign of
 * grid[i][j] can be:
 * 
 * 
 * 1 which means go to the cell to the right. (i.e go from grid[i][j] to
 * grid[i][j + 1])
 * 2 which means go to the cell to the left. (i.e go from grid[i][j] to
 * grid[i][j - 1])
 * 3 which means go to the lower cell. (i.e go from grid[i][j] to grid[i +
 * 1][j])
 * 4 which means go to the upper cell. (i.e go from grid[i][j] to grid[i -
 * 1][j])
 * 
 * 
 * Notice that there could be some signs on the cells of the grid that point
 * outside the grid.
 * 
 * You will initially start at the upper left cell (0, 0). A valid path in the
 * grid is a path that starts from the upper left cell (0, 0) and ends at the
 * bottom-right cell (m - 1, n - 1) following the signs on the grid. The valid
 * path does not have to be the shortest.
 * 
 * You can modify the sign on a cell with cost = 1. You can modify the sign on
 * a cell one time only.
 * 
 * Return the minimum cost to make the grid have at least one valid path.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: grid = [[1,1,1,1],[2,2,2,2],[1,1,1,1],[2,2,2,2]]
 * Output: 3
 * Explanation: You will start at point (0, 0).
 * The path to (3, 3) is as follows. (0, 0) --> (0, 1) --> (0, 2) --> (0, 3)
 * change the arrow to down with cost = 1 --> (1, 3) --> (1, 2) --> (1, 1) -->
 * (1, 0) change the arrow to down with cost = 1 --> (2, 0) --> (2, 1) --> (2,
 * 2) --> (2, 3) change the arrow to down with cost = 1 --> (3, 3)
 * The total cost = 3.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: grid = [[1,1,3],[3,2,2],[1,1,4]]
 * Output: 0
 * Explanation: You can follow the path from (0, 0) to (2, 2).
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: grid = [[1,2],[4,3]]
 * Output: 1
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * m == grid.length
 * n == grid[i].length
 * 1 <= m, n <= 100
 * 1 <= grid[i][j] <= 4
 * 
 * 
 */
/*
 * Dijkstra's Algorithm
 * Time: O((m * n) * log (m * n)), Space: O(m * n)
 */

// @lc code=start
public partial class Solution
{
    public int MinCost(int[][] grid)
    {
        PriorityQueue<(int, int, int), int> minHeap = new PriorityQueue<(int, int, int), int>();
        int[][] dist = new int[grid.Length][];
        // create direction array to store the 4 direction
        int[][] direction = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };

        for (int i = 0; i < grid.Length; i++)
        {
            dist[i] = new int[grid[0].Length];
            Array.Fill(dist[i], int.MaxValue);
        }

        // start from (0, 0), which distance is 0
        minHeap.Enqueue((0, 0, 0), 0);
        dist[0][0] = 0;
        // find the shortest path from (0, 0) to (m - 1, n - 1)
        // while direction edge weight = 0, and non-direction edge = 1
        while (minHeap.Count > 0)
        {
            (int x, int y, int cost) = minHeap.Dequeue();
            // return ans if arrived (m - 1, n - 1)
            if (x == grid.Length - 1 && y == grid[0].Length - 1)
                return cost;

            // go through each edge
            for (int i = 0; i < 4; i++)
            {
                int nextX = direction[i][0] + x;
                int nextY = direction[i][1] + y;
                int nextCost = cost + (grid[x][y] - 1 == i ? 0 : 1);
                // out of range
                if (nextX < 0 || nextX >= grid.Length || nextY < 0 || nextY >= grid[0].Length)
                    continue;

                // if dist is smaller than before
                if (nextCost < dist[nextX][nextY])
                {
                    // update cost
                    // and add to minHeap
                    dist[nextX][nextY] = nextCost;
                    minHeap.Enqueue((nextX, nextY, nextCost), nextCost);
                }
            }
        }
        return -1;
    }
}
// @lc code=end


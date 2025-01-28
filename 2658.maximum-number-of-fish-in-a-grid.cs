/*
 * @lc app=leetcode id=2658 lang=csharp
 *
 * [2658] Maximum Number of Fish in a Grid
 *
 * https://leetcode.com/problems/maximum-number-of-fish-in-a-grid/description/
 *
 * algorithms
 * Medium (60.96%)
 * Likes:    460
 * Dislikes: 25
 * Total Accepted:    31.8K
 * Total Submissions: 53.1K
 * Testcase Example:  '[[0,2,1,0],[4,0,0,3],[1,0,0,4],[0,3,2,0]]'
 *
 * You are given a 0-indexed 2D matrix grid of size m x n, where (r, c)
 * represents:
 * 
 * 
 * A land cell if grid[r][c] = 0, or
 * A water cell containing grid[r][c] fish, if grid[r][c] > 0.
 * 
 * 
 * A fisher can start at any water cell (r, c) and can do the following
 * operations any number of times:
 * 
 * 
 * Catch all the fish at cell (r, c), or
 * Move to any adjacent water cell.
 * 
 * 
 * Return the maximum number of fish the fisher can catch if he chooses his
 * starting cell optimally, or 0 if no water cell exists.
 * 
 * An adjacent cell of the cell (r, c), is one of the cells (r, c + 1), (r, c -
 * 1), (r + 1, c) or (r - 1, c) if it exists.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: grid = [[0,2,1,0],[4,0,0,3],[1,0,0,4],[0,3,2,0]]
 * Output: 7
 * Explanation: The fisher can start at cell (1,3) and collect 3 fish, then
 * move to cell (2,3) and collect 4 fish.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: grid = [[1,0,0,0],[0,0,0,0],[0,0,0,0],[0,0,0,1]]
 * Output: 1
 * Explanation: The fisher can start at cells (0,0) or (3,3) and collect a
 * single fish. 
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * m == grid.length
 * n == grid[i].length
 * 1 <= m, n <= 10
 * 0 <= grid[i][j] <= 10
 * 
 * 
 */
/*
 * Union Find Approach
 * Time: O(m * n), Space: O(m * n)
 */

// @lc code=start
public partial class Solution
{
    private int[] parent;
    private int[] size;

    private int Find(int node)
    {
        if (parent[node] != node)
            parent[node] = Find(parent[node]);
        return parent[node];
    }

    private bool Union(int x, int y)
    {
        int px = Find(x);
        int py = Find(y);
        if (px == py)
            return false;

        if (size[py] > size[px])
        {
            int tmp = px;
            px = py;
            py = tmp;
        }

        size[px] += size[py];
        parent[py] = px;
        return true;
    }

    public int FindMaxFish(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        // initialized Union Find parent and size array
        // Flatten to 1D, where key = i * n + j
        parent = new int[m * n];
        size = new int[m * n];
        // initialized 4 direction
        int[][] direction = new int[][] { new int[] { 0, -1 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 1, 0 } };

        // initialized parent and size value
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                // parent = element key itself
                parent[i * n + j] = i * n + j;
                // size = grid value
                size[i * n + j] = grid[i][j];
            }
        }

        int maxFish = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                // if grid is water
                if (grid[i][j] > 0)
                {
                    // loop for 4 directions
                    foreach (int[] d in direction)
                    {
                        int nextX = d[0] + i;
                        int nextY = d[1] + j;

                        // if out of range, continue to next direction
                        if (nextX < 0 || nextX >= m || nextY < 0 || nextY >= n || grid[nextX][nextY] == 0)
                            continue;

                        // group current cell [i, j] with next cell
                        Union(i * n + j, nextX * n + nextY);
                    }
                    // compare the max value (size) stored in parent
                    maxFish = Math.Max(maxFish, size[Find(i * n + j)]);
                }
            }
        }
        return maxFish;
    }
}
// @lc code=end


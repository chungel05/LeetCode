/*
 * @lc app=leetcode id=407 lang=csharp
 *
 * [407] Trapping Rain Water II
 *
 * https://leetcode.com/problems/trapping-rain-water-ii/description/
 *
 * algorithms
 * Hard (48.37%)
 * Likes:    3847
 * Dislikes: 103
 * Total Accepted:    99.4K
 * Total Submissions: 201.8K
 * Testcase Example:  '[[1,4,3,1,3,2],[3,2,1,3,2,4],[2,3,3,2,3,1]]'
 *
 * Given an m x n integer matrix heightMap representing the height of each unit
 * cell in a 2D elevation map, return the volume of water it can trap after
 * raining.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: heightMap = [[1,4,3,1,3,2],[3,2,1,3,2,4],[2,3,3,2,3,1]]
 * Output: 4
 * Explanation: After the rain, water is trapped between the blocks.
 * We have two small ponds 1 and 3 units trapped.
 * The total volume of water trapped is 4.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: heightMap =
 * [[3,3,3,3,3],[3,2,2,2,3],[3,2,1,2,3],[3,2,2,2,3],[3,3,3,3,3]]
 * Output: 10
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * m == heightMap.length
 * n == heightMap[i].length
 * 1 <= m, n <= 200
 * 0 <= heightMap[i][j] <= 2 * 10^4
 * 
 * 
 */
/*
 * BFS Approach
 * Time: O(mn * log(mn)), Space: O(mn)
 */

// @lc code=start
public partial class Solution
{
    // initial from the boundary, push toward the center
    // if height of adj. cell < height of current cell, we can trap the water and calc the volume
    // push the adj. cell as new boundary with height = max(adj. cell, current cell)
    // until visited all the cells, which is m * n
    public int TrapRainWater(int[][] heightMap)
    {
        int m = heightMap.Length, n = heightMap[0].Length;
        // Using the heap to store the boundary, each time process the min height and look around the 4 adjacent cells
        PriorityQueue<(int, int, int), int> minHeap = new PriorityQueue<(int, int, int), int>();
        // visited array
        bool[][] visited = new bool[m][];
        // direction array
        int[][] direction = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };

        // Initialization
        for (int i = 0; i < m; i++)
        {
            visited[i] = new bool[n];
            for (int j = 0; j < n; j++)
            {
                // add the initial boundary to heap and mark as visited
                // because the boundary cannot trap any water
                if (i == 0 || i == m - 1 || j == 0 || j == n - 1)
                {
                    minHeap.Enqueue((i, j, heightMap[i][j]), heightMap[i][j]);
                    visited[i][j] = true;
                }
            }
        }

        int totalVolume = 0;
        while (minHeap.Count > 0)
        {
            // Dequeue the min height of the boundary
            (int x, int y, int h) = minHeap.Dequeue();
            // look for the adj. cells
            for (int i = 0; i < 4; i++)
            {
                // Row and Col of next cell
                int nextX = x + direction[i][0];
                int nextY = y + direction[i][1];
                // out of range checking
                if (nextX < 0 || nextX >= m || nextY < 0 || nextY >= n)
                    continue;

                // if not visited, check the water trapped and set as new boundary
                if (!visited[nextX][nextY])
                {
                    // mark as visited
                    visited[nextX][nextY] = true;
                    // if height of adj. cell < height of current cell, it can trap water
                    if (heightMap[nextX][nextY] < h)
                    {
                        // vol = height of current cell - height of adj. cell
                        totalVolume += h - heightMap[nextX][nextY];
                        // set as new boundary with height = max(adj. cell, current cell) which is h
                        minHeap.Enqueue((nextX, nextY, h), h);
                    }
                    else
                    {
                        // because height of adj. cell >= height of current cell, it cannot trap water
                        // set as new boundary with height = max(adj. cell, current cell) which is height of adj. cell
                        minHeap.Enqueue((nextX, nextY, heightMap[nextX][nextY]), heightMap[nextX][nextY]);
                    }
                }
            }
        }
        return totalVolume;
    }
}
// @lc code=end


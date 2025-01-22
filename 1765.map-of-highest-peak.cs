/*
 * @lc app=leetcode id=1765 lang=csharp
 *
 * [1765] Map of Highest Peak
 *
 * https://leetcode.com/problems/map-of-highest-peak/description/
 *
 * algorithms
 * Medium (62.97%)
 * Likes:    879
 * Dislikes: 52
 * Total Accepted:    32.8K
 * Total Submissions: 51.2K
 * Testcase Example:  '[[0,1],[0,0]]'
 *
 * You are given an integer matrix isWater of size m x n that represents a map
 * of land and water cells.
 * 
 * 
 * If isWater[i][j] == 0, cell (i, j) is a land cell.
 * If isWater[i][j] == 1, cell (i, j) is a water cell.
 * 
 * 
 * You must assign each cell a height in a way that follows these rules:
 * 
 * 
 * The height of each cell must be non-negative.
 * If the cell is a water cell, its height must be 0.
 * Any two adjacent cells must have an absolute height difference of at most 1.
 * A cell is adjacent to another cell if the former is directly north, east,
 * south, or west of the latter (i.e., their sides are touching).
 * 
 * 
 * Find an assignment of heights such that the maximum height in the matrix is
 * maximized.
 * 
 * Return an integer matrix height of size m x n where height[i][j] is cell (i,
 * j)'s height. If there are multiple solutions, return any of them.
 * 
 * 
 * Example 1:
 * 
 * 
 * 
 * 
 * Input: isWater = [[0,1],[0,0]]
 * Output: [[1,0],[2,1]]
 * Explanation: The image shows the assigned heights of each cell.
 * The blue cell is the water cell, and the green cells are the land cells.
 * 
 * 
 * Example 2:
 * 
 * 
 * 
 * 
 * Input: isWater = [[0,0,1],[1,0,0],[0,0,0]]
 * Output: [[1,1,0],[0,1,1],[1,2,2]]
 * Explanation: A height of 2 is the maximum possible height of any assignment.
 * Any height assignment that has a maximum height of 2 while still meeting the
 * rules will also be accepted.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * m == isWater.length
 * n == isWater[i].length
 * 1 <= m, n <= 1000
 * isWater[i][j] is 0 or 1.
 * There is at least one water cell.
 * 
 * 
 * 
 * Note: This question is the same as 542:
 * https://leetcode.com/problems/01-matrix/
 * 
 */
/*
 * BFS Approach
 * Time: O(mn), Space: O(mn)
 */

// @lc code=start
public partial class Solution
{
    public int[][] HighestPeak(int[][] isWater)
    {
        int m = isWater.Length, n = isWater[0].Length;
        // initize Queue for BFS
        Queue<(int, int)> q = new Queue<(int, int)>();
        // initize 4 direction Top, Bottom, Left, Right
        int[][] direction = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };

        // Loop for the isWater m * n
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                // if it is water, we set its height as 0
                // and add it to Queue for level 0
                if (isWater[i][j] == 1)
                {
                    q.Enqueue((i, j));
                    isWater[i][j] = 0;
                }
                // if it is land, we set its height as -1, indicate that it is not visited
                else
                    isWater[i][j] = -1;
            }
        }

        // initial level is 0
        int level = 0;
        while (q.Count > 0)
        {
            // increment level by 1 as next level
            level++;
            // Loop for current level
            for (int i = q.Count; i > 0; i--)
            {
                // Dequeue the cell
                (int row, int col) = q.Dequeue();
                // Find all 4 adj. cell
                for (int j = 0; j < 4; j++)
                {
                    int nextRow = row + direction[j][0];
                    int nextCol = col + direction[j][1];

                    // if it is out of range, continue to move to next cell
                    if (nextRow < 0 || nextRow >= m || nextCol < 0 || nextCol >= n)
                        continue;

                    // if it is visited, continue to move to next cell
                    if (isWater[nextRow][nextCol] != -1)
                        continue;

                    // set the height as next level
                    isWater[nextRow][nextCol] = level;
                    // and add to the Queue for next level
                    q.Enqueue((nextRow, nextCol));
                }
            }
        }
        return isWater;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=827 lang=csharp
 *
 * [827] Making A Large Island
 *
 * https://leetcode.com/problems/making-a-large-island/description/
 *
 * algorithms
 * Hard (48.79%)
 * Likes:    4088
 * Dislikes: 84
 * Total Accepted:    226.8K
 * Total Submissions: 454.9K
 * Testcase Example:  '[[1,0],[0,1]]'
 *
 * You are given an n x n binary matrix grid. You are allowed to change at most
 * one 0 to be 1.
 * 
 * Return the size of the largest island in grid after applying this
 * operation.
 * 
 * An island is a 4-directionally connected group of 1s.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: grid = [[1,0],[0,1]]
 * Output: 3
 * Explanation: Change one 0 to 1 and connect two 1s, then we get an island
 * with area = 3.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: grid = [[1,1],[1,0]]
 * Output: 4
 * Explanation: Change the 0 to 1 and make the island bigger, only one island
 * with area = 4.
 * 
 * Example 3:
 * 
 * 
 * Input: grid = [[1,1],[1,1]]
 * Output: 4
 * Explanation: Can't change any 0 to 1, only one island with area = 4.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * n == grid.length
 * n == grid[i].length
 * 1 <= n <= 500
 * grid[i][j] is either 0 or 1.
 * 
 * 
 */
/*
 * Union Find Approach
 * Time: O(n^2), Space: O(n^2)
 */

// @lc code=start
public partial class Solution
{
    private int[] parent;
    private int[] size;

    // Parent Find Method
    private int Find(int n)
    {
        if (parent[n] != n)
            parent[n] = Find(parent[n]);
        return parent[n];
    }

    // Union Method
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

    public int LargestIsland(int[][] grid)
    {
        // Initialized parent size and 4 directions
        int n = grid.Length;
        parent = new int[n * n];
        size = new int[n * n];
        int[][] direction = new int[][] { new int[] { 0, -1 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 1, 0 } };

        // Initialized parent of each node and its corresponding area
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int curr = i * n + j;
                parent[curr] = curr;
                size[curr] = grid[i][j];
            }
        }

        // Using Union Find to join the adj. cells together
        // So we know the area of different groups
        // which is store at size[parent]
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int curr = i * n + j;

                // if grid[i][j] = 1, try to union 4 adj. cells
                if (grid[i][j] == 1)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        int newX = direction[k][0] + i;
                        int newY = direction[k][1] + j;

                        // out of range, continue to next cell
                        if (newX < 0 || newX >= n || newY < 0 || newY >= n || grid[newX][newY] == 0)
                            continue;

                        Union(curr, newX * n + newY);
                    }
                }
            }
        }

        // loop again for the whole grid
        // find the grid[i][j] = 0, try to flip it to 1 and join the 4 adj. cells together
        // i.e. area = 1 + top + bottom + left + right
        // p.s. they may belongs to same parent, so we need to use HashSet to prevent duplicated
        int maxIsland = -1;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                // if grid[i][j] = 0, flip it to 1
                if (grid[i][j] == 0)
                {
                    int area = 1;
                    HashSet<int> p = new HashSet<int>();
                    for (int k = 0; k < 4; k++)
                    {
                        int newX = direction[k][0] + i;
                        int newY = direction[k][1] + j;

                        // out of range, continue to next cell
                        if (newX < 0 || newX >= n || newY < 0 || newY >= n || grid[newX][newY] == 0)
                            continue;

                        // check the parent
                        // if not contains, we add the area together
                        int par = Find(newX * n + newY);
                        if (!p.Contains(par))
                        {
                            area += size[par];
                            p.Add(par);
                        }

                    }
                    // record the max island area
                    maxIsland = Math.Max(maxIsland, area);
                }
            }
        }

        // if maxIsland still = -1, it means that no 0 to flip
        // so return max area in size
        // otherwise return maxIsland
        return maxIsland == -1 ? size.Max() : maxIsland;
    }
}
// @lc code=end


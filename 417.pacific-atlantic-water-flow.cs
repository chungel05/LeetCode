/*
 * @lc app=leetcode id=417 lang=csharp
 *
 * [417] Pacific Atlantic Water Flow
 *
 * https://leetcode.com/problems/pacific-atlantic-water-flow/description/
 *
 * algorithms
 * Medium (56.12%)
 * Likes:    7542
 * Dislikes: 1520
 * Total Accepted:    523.4K
 * Total Submissions: 931.5K
 * Testcase Example:  '[[1,2,2,3,5],[3,2,3,4,4],[2,4,5,3,1],[6,7,1,4,5],[5,1,1,2,4]]'
 *
 * There is an m x n rectangular island that borders both the Pacific Ocean and
 * Atlantic Ocean. The Pacific Ocean touches the island's left and top edges,
 * and the Atlantic Ocean touches the island's right and bottom edges.
 * 
 * The island is partitioned into a grid of square cells. You are given an m x
 * n integer matrix heights where heights[r][c] represents the height above sea
 * level of the cell at coordinate (r, c).
 * 
 * The island receives a lot of rain, and the rain water can flow to
 * neighboring cells directly north, south, east, and west if the neighboring
 * cell's height is less than or equal to the current cell's height. Water can
 * flow from any cell adjacent to an ocean into the ocean.
 * 
 * Return a 2D list of grid coordinates result where result[i] = [ri, ci]
 * denotes that rain water can flow from cell (ri, ci) to both the Pacific and
 * Atlantic oceans.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: heights =
 * [[1,2,2,3,5],[3,2,3,4,4],[2,4,5,3,1],[6,7,1,4,5],[5,1,1,2,4]]
 * Output: [[0,4],[1,3],[1,4],[2,2],[3,0],[3,1],[4,0]]
 * Explanation: The following cells can flow to the Pacific and Atlantic
 * oceans, as shown below:
 * [0,4]: [0,4] -> Pacific Ocean 
 * [0,4] -> Atlantic Ocean
 * [1,3]: [1,3] -> [0,3] -> Pacific Ocean 
 * [1,3] -> [1,4] -> Atlantic Ocean
 * [1,4]: [1,4] -> [1,3] -> [0,3] -> Pacific Ocean 
 * [1,4] -> Atlantic Ocean
 * [2,2]: [2,2] -> [1,2] -> [0,2] -> Pacific Ocean 
 * [2,2] -> [2,3] -> [2,4] -> Atlantic Ocean
 * [3,0]: [3,0] -> Pacific Ocean 
 * [3,0] -> [4,0] -> Atlantic Ocean
 * [3,1]: [3,1] -> [3,0] -> Pacific Ocean 
 * [3,1] -> [4,1] -> Atlantic Ocean
 * [4,0]: [4,0] -> Pacific Ocean 
 * ⁠      [4,0] -> Atlantic Ocean
 * Note that there are other possible paths for these cells to flow to the
 * Pacific and Atlantic oceans.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: heights = [[1]]
 * Output: [[0,0]]
 * Explanation: The water can flow from the only cell to the Pacific and
 * Atlantic oceans.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * m == heights.length
 * n == heights[r].length
 * 1 <= m, n <= 200
 * 0 <= heights[r][c] <= 10^5
 * 
 * 
 */

// @lc code=start
using System.Data;
using System.Runtime.InteropServices;

public partial class Solution
{
    public void DFSPacificAtlantic(int[][] heights, int row, int col, int prevHeight, HashSet<string> visited)
    {
        // since it is reverse from ocean to the point, so the preHeight <= curr height
        if (row < 0 || col < 0 || row >= heights.Length || col >= heights[0].Length || prevHeight > heights[row][col] || visited.Contains(row + "," + col))
            return;

        visited.Add(row + "," + col);
        DFSPacificAtlantic(heights, row + 1, col, heights[row][col], visited);
        DFSPacificAtlantic(heights, row - 1, col, heights[row][col], visited);
        DFSPacificAtlantic(heights, row, col + 1, heights[row][col], visited);
        DFSPacificAtlantic(heights, row, col - 1, heights[row][col], visited);
    }

    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        List<IList<int>> res = new List<IList<int>>();
        HashSet<string> pacific = new HashSet<string>();
        HashSet<string> atlantic = new HashSet<string>();

        for (int i = 0; i < heights.Length; i++)
        {
            // flow from first row, check which point can reach pacific through first row
            DFSPacificAtlantic(heights, i, 0, heights[i][0], pacific);
            // flow from last row, check which point can reach atlantic through last row
            DFSPacificAtlantic(heights, i, heights[0].Length - 1, heights[i][heights[0].Length - 1], atlantic);
        }

        for (int j = 0; j < heights[0].Length; j++)
        {
            // flow from first col, check which point can reach pacific through first col
            DFSPacificAtlantic(heights, 0, j, heights[0][j], pacific);
            // flow from last col, check which point can reach atlantic through last col
            DFSPacificAtlantic(heights, heights.Length - 1, j, heights[heights.Length - 1][j], atlantic);
        }

        for (int i = 0; i < heights.Length; i++)
        {
            for (int j = 0; j < heights[0].Length; j++)
            {
                if (pacific.Contains(i + "," + j) && atlantic.Contains(i + "," + j))
                    res.Add(new List<int>() { i, j });
            }
        }
        return res;
    }
}
// @lc code=end


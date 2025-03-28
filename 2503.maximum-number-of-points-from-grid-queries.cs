/*
 * @lc app=leetcode id=2503 lang=csharp
 *
 * [2503] Maximum Number of Points From Grid Queries
 *
 * https://leetcode.com/problems/maximum-number-of-points-from-grid-queries/description/
 *
 * algorithms
 * Hard (38.13%)
 * Likes:    499
 * Dislikes: 26
 * Total Accepted:    12.5K
 * Total Submissions: 30.9K
 * Testcase Example:  '[[1,2,3],[2,5,7],[3,5,1]]\n[5,6,2]'
 *
 * You are given an m x n integer matrix grid and an array queries of size k.
 * 
 * Find an array answer of size k such that for each integer queries[i] you
 * start in the top left cell of the matrix and repeat the following
 * process:
 * 
 * 
 * If queries[i] is strictly greater than the value of the current cell that
 * you are in, then you get one point if it is your first time visiting this
 * cell, and you can move to any adjacent cell in all 4 directions: up, down,
 * left, and right.
 * Otherwise, you do not get any points, and you end this process.
 * 
 * 
 * After the process, answer[i] is the maximum number of points you can get.
 * Note that for each query you are allowed to visit the same cell multiple
 * times.
 * 
 * Return the resulting array answer.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: grid = [[1,2,3],[2,5,7],[3,5,1]], queries = [5,6,2]
 * Output: [5,8,1]
 * Explanation: The diagrams above show which cells we visit to get points for
 * each query.
 * 
 * Example 2:
 * 
 * 
 * Input: grid = [[5,2,1],[1,1,2]], queries = [3]
 * Output: [0]
 * Explanation: We can not get any points because the value of the top left
 * cell is already greater than or equal to 3.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * m == grid.length
 * n == grid[i].length
 * 2 <= m, n <= 1000
 * 4 <= m * n <= 10^5
 * k == queries.length
 * 1 <= k <= 10^4
 * 1 <= grid[i][j], queries[i] <= 10^6
 * 
 * 
 */
/*
 * Heap with Binary Search Approach
 * Time: O(mn * log mn + q * log mn), Space: O(mn)
 */

// @lc code=start
public partial class Solution
{
    private int BSMaxPoints(int[] threshold, int num)
    {
        int left = 0, right = threshold.Length;
        while (left < right)
        {
            int mid = (left + right) / 2;
            if (threshold[mid] < num)
                left = mid + 1;
            else
                right = mid;
        }
        return left - 1;
    }

    public int[] MaxPoints(int[][] grid, int[] queries)
    {
        int m = grid.Length, n = grid[0].Length;
        // direction array
        int[] direction = new int[] { -1, 0, 1, 0, -1 };
        // the value(threshold[i]) needed to get the max points (i)
        int[] threshold = new int[m * n + 1];
        int pointer = 1;

        // minHeap to precess
        PriorityQueue<(int, int), int> minHeap = new PriorityQueue<(int, int), int>();
        bool[] visited = new bool[m * n];
        minHeap.Enqueue((0, 0), grid[0][0]);
        visited[0] = true;

        // Time: O(mn * log mn)
        while (minHeap.Count > 0)
        {
            // for each points [i], need to have value > then minHeap.Dequeue() or prev. threshold[i - 1]
            (int row, int col) = minHeap.Dequeue();
            threshold[pointer] = Math.Max(threshold[pointer - 1], grid[row][col]);
            pointer++;

            // process 4 directions
            for (int i = 0; i < 4; i++)
            {
                int newRow = row + direction[i];
                int newCol = col + direction[i + 1];
                // out of range
                if (newRow < 0 || newRow >= grid.Length || newCol < 0 || newCol >= grid[0].Length)
                    continue;

                // visited before
                if (visited[newRow * grid[0].Length + newCol])
                    continue;

                // mark as visited
                visited[newRow * grid[0].Length + newCol] = true;
                // add to heap
                minHeap.Enqueue((newRow, newCol), grid[newRow][newCol]);
            }
        }

        // for each query, find the max points can get
        // Time: O(q * log mn)
        int[] ans = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
            ans[i] = BSMaxPoints(threshold, queries[i]);

        return ans;
    }

    // BFS Approach
    /* private int BFSMaxPoints(int[][] grid, int num)
    {
        int ans = 0;
        int[] direction = new int[] { -1, 0, 1, 0, -1 };
        bool[] visited = new bool[grid.Length * grid[0].Length];
        Queue<(int, int)> q = new Queue<(int, int)>();
        q.Enqueue((0, 0));
        visited[0] = true;

        while (q.Count > 0)
        {
            (int row, int col) = q.Dequeue();
            if (num <= grid[row][col])
                continue;

            ans++;
            for (int i = 0; i < 4; i++)
            {
                int newRow = row + direction[i];
                int newCol = col + direction[i + 1];
                if (newRow < 0 || newRow >= grid.Length || newCol < 0 || newCol >= grid[0].Length)
                    continue;

                if (visited[newRow * grid[0].Length + newCol])
                    continue;

                visited[newRow * grid[0].Length + newCol] = true;
                q.Enqueue((newRow, newCol));
            }
        }
        return ans;
    }

    public int[] MaxPoints(int[][] grid, int[] queries)
    {
        int[] ans = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            ans[i] = BFSMaxPoints(grid, queries[i]);
        }
        return ans;
    } */
}
// @lc code=end


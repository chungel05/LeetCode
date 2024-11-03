/*
 * @lc app=leetcode id=1584 lang=csharp
 *
 * [1584] Min Cost to Connect All Points
 *
 * https://leetcode.com/problems/min-cost-to-connect-all-points/description/
 *
 * algorithms
 * Medium (67.63%)
 * Likes:    5153
 * Dislikes: 131
 * Total Accepted:    326.4K
 * Total Submissions: 481.9K
 * Testcase Example:  '[[0,0],[2,2],[3,10],[5,2],[7,0]]'
 *
 * You are given an array points representing integer coordinates of some
 * points on a 2D-plane, where points[i] = [xi, yi].
 * 
 * The cost of connecting two points [xi, yi] and [xj, yj] is the manhattan
 * distance between them: |xi - xj| + |yi - yj|, where |val| denotes the
 * absolute value of val.
 * 
 * Return the minimum cost to make all points connected. All points are
 * connected if there is exactly one simple path between any two points.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: points = [[0,0],[2,2],[3,10],[5,2],[7,0]]
 * Output: 20
 * Explanation: 
 * 
 * We can connect the points as shown above to get the minimum cost of 20.
 * Notice that there is a unique path between every pair of points.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: points = [[3,12],[-2,5],[-4,1]]
 * Output: 18
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= points.length <= 1000
 * -10^6 <= xi, yi <= 10^6
 * All pairs (xi, yi) are distinct.
 * 
 * 
 */
/*
 * Prim's Algorithm Implementation
 */

// @lc code=start
public partial class Solution
{
    public int MinCostConnectPoints(int[][] points)
    {
        HashSet<int> visited = new HashSet<int>();
        var minHeap = new PriorityQueue<int, int>();

        int cost = 0;
        minHeap.Enqueue(0, 0);
        while (minHeap.Count > 0 && visited.Count < points.Length)
        {
            if (minHeap.TryPeek(out int i, out int c))
            {
                minHeap.Dequeue();

                if (visited.Contains(i))
                    continue;

                cost += c;
                visited.Add(i);

                for (int j = 0; j < points.Length; j++)
                {
                    if (j != i)
                    {
                        if (!visited.Contains(j))
                            minHeap.Enqueue(j, Math.Abs(points[i][0] - points[j][0]) + Math.Abs(points[i][1] - points[j][1]));
                    }
                }
            }
        }
        return cost;
    }
}
// @lc code=end


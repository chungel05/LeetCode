/*
 * @lc app=leetcode id=1976 lang=csharp
 *
 * [1976] Number of Ways to Arrive at Destination
 *
 * https://leetcode.com/problems/number-of-ways-to-arrive-at-destination/description/
 *
 * algorithms
 * Medium (27.76%)
 * Likes:    3044
 * Dislikes: 155
 * Total Accepted:    99.8K
 * Total Submissions: 352.1K
 * Testcase Example:  '7\n' +
  '[[0,6,7],[0,1,2],[1,2,3],[1,3,3],[6,3,3],[3,5,1],[6,5,1],[2,5,1],[0,4,5],[4,6,2]]'
 *
 * You are in a city that consists of n intersections numbered from 0 to n - 1
 * with bi-directional roads between some intersections. The inputs are
 * generated such that you can reach any intersection from any other
 * intersection and that there is at most one road between any two
 * intersections.
 * 
 * You are given an integer n and a 2D integer array roads where roads[i] =
 * [ui, vi, timei] means that there is a road between intersections ui and vi
 * that takes timei minutes to travel. You want to know in how many ways you
 * can travel from intersection 0 to intersection n - 1 in the shortest amount
 * of time.
 * 
 * Return the number of ways you can arrive at your destination in the shortest
 * amount of time. Since the answer may be large, return it modulo 10^9 + 7.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: n = 7, roads =
 * [[0,6,7],[0,1,2],[1,2,3],[1,3,3],[6,3,3],[3,5,1],[6,5,1],[2,5,1],[0,4,5],[4,6,2]]
 * Output: 4
 * Explanation: The shortest amount of time it takes to go from intersection 0
 * to intersection 6 is 7 minutes.
 * The four ways to get there in 7 minutes are:
 * - 0 ➝ 6
 * - 0 ➝ 4 ➝ 6
 * - 0 ➝ 1 ➝ 2 ➝ 5 ➝ 6
 * - 0 ➝ 1 ➝ 3 ➝ 5 ➝ 6
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: n = 2, roads = [[1,0,10]]
 * Output: 1
 * Explanation: There is only one way to go from intersection 0 to intersection
 * 1, and it takes 10 minutes.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= n <= 200
 * n - 1 <= roads.length <= n * (n - 1) / 2
 * roads[i].length == 3
 * 0 <= ui, vi <= n - 1
 * 1 <= timei <= 10^9
 * ui != vi
 * There is at most one road connecting any two intersections.
 * You can reach any intersection from any other intersection.
 * 
 * 
 */
/*
 * BFS - Dijkstra Algorithm
 * Time: O((V + E) * log V), Space: O(E + V)
 */

// @lc code=start
public partial class Solution
{
    public int CountPaths(int n, int[][] roads)
    {
        // store the paths to node i
        int[] paths = new int[n];
        // store the shortest distance to node i
        long[] dist = new long[n];
        // adj. nodes list
        List<int[]>[] adj = new List<int[]>[n];

        // Initialization
        for (int i = 0; i < n; i++)
        {
            adj[i] = new List<int[]>();
            dist[i] = long.MaxValue;
        }

        // create the adj. list
        for (int i = 0; i < roads.Length; i++)
        {
            int u = roads[i][0];
            int v = roads[i][1];
            int t = roads[i][2];
            adj[u].Add(new int[] { v, t });
            adj[v].Add(new int[] { u, t });
        }

        // start from source - 0
        dist[0] = 0;
        // no. of paths to 0 = 1
        paths[0] = 1;
        PriorityQueue<(int, long), long> minHeap = new PriorityQueue<(int, long), long>();
        minHeap.Enqueue((0, 0), 0);
        while (minHeap.Count > 0)
        {
            (int u, long d) = minHeap.Dequeue();

            // if accumunlated dist d > shortest dist of node u
            // no need to process, because already go through shortest paths
            if (d > dist[u])
                continue;

            // check all adj. nodes
            foreach (int[] next in adj[u])
            {
                int v = next[0];
                int time = next[1];

                // if accumunlated dist d + edge time < shortest dist[v]
                // reset and update
                if (dist[v] > d + time)
                {
                    // update dist[v]
                    dist[v] = d + time;
                    // reset paths[v] to predecessor paths[u]
                    // because new shortest dist from 0 to v is going through u
                    // the paths 0 to v = the paths 0 to u
                    paths[v] = paths[u];
                    // enqueue for next movement
                    minHeap.Enqueue((v, dist[v]), dist[v]);
                }
                // if accumunlated dist d + edge time == shortest dist[v]
                // it is another paths from 0 to v
                // so add the paths together
                else if (dist[v] == d + time)
                {
                    paths[v] = (paths[u] + paths[v]) % (1000000007);
                }
            }
        }
        // ans = no. of paths from 0 to n - 1
        return paths[n - 1];

    }
}
// @lc code=end


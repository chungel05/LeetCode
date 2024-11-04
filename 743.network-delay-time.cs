/*
 * @lc app=leetcode id=743 lang=csharp
 *
 * [743] Network Delay Time
 *
 * https://leetcode.com/problems/network-delay-time/description/
 *
 * algorithms
 * Medium (55.27%)
 * Likes:    7584
 * Dislikes: 372
 * Total Accepted:    567.9K
 * Total Submissions: 1M
 * Testcase Example:  '[[2,1,1],[2,3,1],[3,4,1]]\n4\n2'
 *
 * You are given a network of n nodes, labeled from 1 to n. You are also given
 * times, a list of travel times as directed edges times[i] = (ui, vi, wi),
 * where ui is the source node, vi is the target node, and wi is the time it
 * takes for a signal to travel from source to target.
 * 
 * We will send a signal from a given node k. Return the minimum time it takes
 * for all the n nodes to receive the signal. If it is impossible for all the n
 * nodes to receive the signal, return -1.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: times = [[2,1,1],[2,3,1],[3,4,1]], n = 4, k = 2
 * Output: 2
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: times = [[1,2,1]], n = 2, k = 1
 * Output: 1
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: times = [[1,2,1]], n = 2, k = 2
 * Output: -1
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= k <= n <= 100
 * 1 <= times.length <= 6000
 * times[i].length == 3
 * 1 <= ui, vi <= n
 * ui != vi
 * 0 <= wi <= 100
 * All the pairs (ui, vi) are unique. (i.e., no multiple edges.)
 * 
 * 
 */
/*
 * Dijkstra's Algorithm Implementation
 */

// @lc code=start
public partial class Solution
{
    public int NetworkDelayTime(int[][] times, int n, int k)
    {
        Dictionary<int, List<int[]>> edges = new Dictionary<int, List<int[]>>();
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
        Dictionary<int, int> timeMap = new Dictionary<int, int>();

        for (int i = 0; i < times.Length; i++)
        {
            if (!edges.ContainsKey(times[i][0]))
                edges[times[i][0]] = new List<int[]>();
            edges[times[i][0]].Add(new int[] { times[i][1], times[i][2] });
        }

        minHeap.Enqueue(k, 0);
        for (int i = 1; i <= n; i++)
        {
            timeMap[i] = int.MaxValue;
        }
        timeMap[k] = 0;

        while (minHeap.Count > 0)
        {
            if (minHeap.TryDequeue(out int index, out int time))
            {
                if (time > timeMap[index])
                    continue;

                if (edges.ContainsKey(index))
                {
                    foreach (int[] adj in edges[index])
                    {
                        if (adj[1] + time < timeMap[adj[0]])
                        {
                            timeMap[adj[0]] = adj[1] + time;
                            minHeap.Enqueue(adj[0], adj[1] + time);
                        }
                    }
                }
            }
        }

        int res = 0;
        for (int i = 1; i <= n; i++)
        {
            if (timeMap[i] == int.MaxValue)
                return -1;
            else
                res = Math.Max(res, timeMap[i]);
        }
        return res;
    }
}
// @lc code=end


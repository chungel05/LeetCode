/*
 * @lc app=leetcode id=787 lang=csharp
 *
 * [787] Cheapest Flights Within K Stops
 *
 * https://leetcode.com/problems/cheapest-flights-within-k-stops/description/
 *
 * algorithms
 * Medium (39.68%)
 * Likes:    10132
 * Dislikes: 425
 * Total Accepted:    634.2K
 * Total Submissions: 1.6M
 * Testcase Example:  '4\n[[0,1,100],[1,2,100],[2,0,100],[1,3,600],[2,3,200]]\n0\n3\n1'
 *
 * There are n cities connected by some number of flights. You are given an
 * array flights where flights[i] = [fromi, toi, pricei] indicates that there
 * is a flight from city fromi to city toi with cost pricei.
 * 
 * You are also given three integers src, dst, and k, return the cheapest price
 * from src to dst with at most k stops. If there is no such route, return
 * -1.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: n = 4, flights = [[0,1,100],[1,2,100],[2,0,100],[1,3,600],[2,3,200]],
 * src = 0, dst = 3, k = 1
 * Output: 700
 * Explanation:
 * The graph is shown above.
 * The optimal path with at most 1 stop from city 0 to 3 is marked in red and
 * has cost 100 + 600 = 700.
 * Note that the path through cities [0,1,2,3] is cheaper but is invalid
 * because it uses 2 stops.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: n = 3, flights = [[0,1,100],[1,2,100],[0,2,500]], src = 0, dst = 2, k
 * = 1
 * Output: 200
 * Explanation:
 * The graph is shown above.
 * The optimal path with at most 1 stop from city 0 to 2 is marked in red and
 * has cost 100 + 100 = 200.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: n = 3, flights = [[0,1,100],[1,2,100],[0,2,500]], src = 0, dst = 2, k
 * = 0
 * Output: 500
 * Explanation:
 * The graph is shown above.
 * The optimal path with no stops from city 0 to 2 is marked in red and has
 * cost 500.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= n <= 100
 * 0 <= flights.length <= (n * (n - 1) / 2)
 * flights[i].length == 3
 * 0 <= fromi, toi < n
 * fromi != toi
 * 1 <= pricei <= 10^4
 * There will not be any multiple flights between two cities.
 * 0 <= src, dst, k < n
 * src != dst
 * 
 * 
 */

// @lc code=start

public partial class Solution
{
    // Shortest path Implementation
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
    {
        Dictionary<int, List<int[]>> edges = new Dictionary<int, List<int[]>>();

        foreach (var flight in flights)
        {
            if (!edges.ContainsKey(flight[0]))
                edges[flight[0]] = new List<int[]>();
            edges[flight[0]].Add(new int[] { flight[1], flight[2] });
        }

        Queue<(int node, int stop, int price)> q = new Queue<(int node, int stop, int price)>();
        q.Enqueue((src, 0, 0));

        int[] costMap = new int[n];
        for (int i = 0; i < n; i++)
        {
            costMap[i] = int.MaxValue;
        }
        costMap[src] = 0;

        while (q.Count > 0)
        {
            if (q.TryDequeue(out (int node, int stop, int price) ele))
            {
                if (ele.stop > k)
                    continue;

                if (edges.ContainsKey(ele.node))
                {
                    foreach (var e in edges[ele.node])
                    {
                        int nextNode = e[0];
                        int newCost = e[1] + ele.price;
                        int nextStop = ele.stop + 1;
                        if (newCost < costMap[nextNode])
                        {
                            costMap[nextNode] = newCost;
                            q.Enqueue((nextNode, nextStop, newCost));
                        }
                    }
                }
            }
        }
        return costMap[dst] == int.MaxValue ? -1 : costMap[dst];
    }

    // Bellman Ford Algorithm Implementation
    /* public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
    {
        int[] costMap = new int[n];
        Array.Fill(costMap, int.MaxValue);
        costMap[src] = 0;

        for (int i = 0; i <= k; i++)
        {
            int[] tmp = new int[n];
            Array.Copy(costMap, tmp, n);

            foreach (int[] e in flights)
            {
                int s = e[0];
                int d = e[1];
                int p = e[2];
                if (costMap[s] == int.MaxValue)
                    continue;

                if (tmp[d] > costMap[s] + p)
                    tmp[d] = costMap[s] + p;
            }
            costMap = tmp;
        }
        return costMap[dst] == int.MaxValue ? -1 : costMap[dst];
    } */
}
// @lc code=end


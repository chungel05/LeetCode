/*
 * @lc app=leetcode id=2872 lang=csharp
 *
 * [2872] Maximum Number of K-Divisible Components
 *
 * https://leetcode.com/problems/maximum-number-of-k-divisible-components/description/
 *
 * algorithms
 * Hard (57.37%)
 * Likes:    618
 * Dislikes: 24
 * Total Accepted:    71.2K
 * Total Submissions: 101.4K
 * Testcase Example:  '5\n[[0,2],[1,2],[1,3],[2,4]]\n[1,8,1,4,4]\n6'
 *
 * There is an undirected tree with n nodes labeled from 0 to n - 1. You are
 * given the integer n and a 2D integer array edges of length n - 1, where
 * edges[i] = [ai, bi] indicates that there is an edge between nodes ai and bi
 * in the tree.
 * 
 * You are also given a 0-indexed integer array values of length n, where
 * values[i] is the value associated with the i^th node, and an integer k.
 * 
 * A valid split of the tree is obtained by removing any set of edges, possibly
 * empty, from the tree such that the resulting components all have values that
 * are divisible by k, where the value of a connected component is the sum of
 * the values of its nodes.
 * 
 * Return the maximum number of components in any valid split.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: n = 5, edges = [[0,2],[1,2],[1,3],[2,4]], values = [1,8,1,4,4], k = 6
 * Output: 2
 * Explanation: We remove the edge connecting node 1 with 2. The resulting
 * split is valid because:
 * - The value of the component containing nodes 1 and 3 is values[1] +
 * values[3] = 12.
 * - The value of the component containing nodes 0, 2, and 4 is values[0] +
 * values[2] + values[4] = 6.
 * It can be shown that no other valid split has more than 2 connected
 * components.
 * 
 * Example 2:
 * 
 * 
 * Input: n = 7, edges = [[0,1],[0,2],[1,3],[1,4],[2,5],[2,6]], values =
 * [3,0,6,1,5,2,1], k = 3
 * Output: 3
 * Explanation: We remove the edge connecting node 0 with 2, and the edge
 * connecting node 0 with 1. The resulting split is valid because:
 * - The value of the component containing node 0 is values[0] = 3.
 * - The value of the component containing nodes 2, 5, and 6 is values[2] +
 * values[5] + values[6] = 9.
 * - The value of the component containing nodes 1, 3, and 4 is values[1] +
 * values[3] + values[4] = 6.
 * It can be shown that no other valid split has more than 3 connected
 * components.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= n <= 3 * 10^4
 * edges.length == n - 1
 * edges[i].length == 2
 * 0 <= ai, bi < n
 * values.length == n
 * 0 <= values[i] <= 10^9
 * 1 <= k <= 10^9
 * Sum of values is divisible by k.
 * The input is generated such that edges represents a valid tree.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int MaxKDivisibleComponents(int n, int[][] edges, int[] values, int k)
    {
        Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();
        int[] in_degree = new int[n];
        for (int i = 0; i < edges.Length; i++)
        {
            // create dictionary of the adj. list for easy lookup
            if (!adj.ContainsKey(edges[i][0]))
                adj[edges[i][0]] = new List<int>();
            adj[edges[i][0]].Add(edges[i][1]);

            if (!adj.ContainsKey(edges[i][1]))
                adj[edges[i][1]] = new List<int>();
            adj[edges[i][1]].Add(edges[i][0]);

            // count the edge connected to the node
            in_degree[edges[i][0]]++;
            in_degree[edges[i][1]]++;
        }

        Queue<int> q = new Queue<int>();
        for (int i = 0; i < n; i++)
        {
            // if it has only 1 edge, then it is the leaf, we add to queue
            if (in_degree[i] == 1)
                q.Enqueue(i);
        }

        // base case, whole tree = 1
        int res = 1;
        while (q.Count > 0)
        {
            int node = q.Dequeue();
            in_degree[node]--;

            // check all the adj. node
            foreach (int parent in adj[node])
            {
                // check the edges remained, if it is 0, we will not go back to leaf
                // since we add the node which has only 1 edge to the queue, so parent should be 1 only
                if (in_degree[parent] == 0)
                    continue;

                // calc the condition
                // if it can be divided by k, then it can be a valid split, so we add the count to res
                if (values[node] % k == 0)
                    res++;
                // otherwise, we add the value of current node to its parent
                // to prevent overflow, we only add the remainder
                else
                    values[parent] += values[node] % k;

                // reduce edge to indicate we already process
                in_degree[parent]--;

                // if parent only remain 1 edge, we add to queue
                if (in_degree[parent] == 1)
                    q.Enqueue(parent);
            }
        }
        return res;
    }
}
// @lc code=end


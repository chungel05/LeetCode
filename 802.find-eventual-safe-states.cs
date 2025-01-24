/*
 * @lc app=leetcode id=802 lang=csharp
 *
 * [802] Find Eventual Safe States
 *
 * https://leetcode.com/problems/find-eventual-safe-states/description/
 *
 * algorithms
 * Medium (64.33%)
 * Likes:    5996
 * Dislikes: 472
 * Total Accepted:    312K
 * Total Submissions: 479.5K
 * Testcase Example:  '[[1,2],[2,3],[5],[0],[5],[],[]]'
 *
 * There is a directed graph of n nodes with each node labeled from 0 to n - 1.
 * The graph is represented by a 0-indexed 2D integer array graph where
 * graph[i] is an integer array of nodes adjacent to node i, meaning there is
 * an edge from node i to each node in graph[i].
 * 
 * A node is a terminal node if there are no outgoing edges. A node is a safe
 * node if every possible path starting from that node leads to a terminal node
 * (or another safe node).
 * 
 * Return an array containing all the safe nodes of the graph. The answer
 * should be sorted in ascending order.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: graph = [[1,2],[2,3],[5],[0],[5],[],[]]
 * Output: [2,4,5,6]
 * Explanation: The given graph is shown above.
 * Nodes 5 and 6 are terminal nodes as there are no outgoing edges from either
 * of them.
 * Every path starting at nodes 2, 4, 5, and 6 all lead to either node 5 or 6.
 * 
 * Example 2:
 * 
 * 
 * Input: graph = [[1,2,3,4],[1,2],[3,4],[0,4],[]]
 * Output: [4]
 * Explanation:
 * Only node 4 is a terminal node, and every path starting at node 4 leads to
 * node 4.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * n == graph.length
 * 1 <= n <= 10^4
 * 0 <= graph[i].length <= n
 * 0 <= graph[i][j] <= n - 1
 * graph[i] is sorted in a strictly increasing order.
 * The graph may contain self-loops.
 * The number of edges in the graph will be in the range [1, 4 * 10^4].
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    // DFS Approach
    // Time: O(V + E), Space: O(V)
    /* private bool DFSEventualSafeNodes(int[][] graph, int node, int[] dp)
    {
        if (dp[node] != -1)
            return dp[node] == 1;

        dp[node] = 0;
        for (int i = 0; i < graph[node].Length; i++)
        {
            if (!DFSEventualSafeNodes(graph, graph[node][i], dp))
            {
                return false;
            }
        }
        dp[node] = 1;
        return true;
    }

    public IList<int> EventualSafeNodes(int[][] graph)
    {
        int n = graph.Length;
        List<int> ans = new List<int>();
        int[] dp = new int[n];
        Array.Fill(dp, -1);
        for (int i = 0; i < n; i++)
        {
            if (DFSEventualSafeNodes(graph, i, dp))
                ans.Add(i);
        }
        return ans;
    } */

    // Topological Sorting
    // Time: O(V + E), Space: O(V)
    public IList<int> EventualSafeNodes(int[][] graph)
    {
        int n = graph.Length;
        List<int>[] incomingNode = new List<int>[n];
        int[] outgoingDegree = new int[n];
        Queue<int> q = new Queue<int>();
        List<int> ans = new List<int>();

        // initialize the incoming list for each node
        for (int i = 0; i < n; i++)
        {
            incomingNode[i] = new List<int>();
        }

        // loop all the edges and added to incomingNode,
        // which each element have a list of nodes point to it
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < graph[i].Length; j++)
            {
                incomingNode[graph[i][j]].Add(i);
                // count the outgoing edges
                outgoingDegree[i]++;
            }
        }

        for (int i = 0; i < n; i++)
        {
            // if outgoing edges = 0, it is Terminal node, add to queue
            if (outgoingDegree[i] == 0)
                q.Enqueue(i);
        }

        // check from the terminal node, if prev node are also no other edge, it will be safe node
        while (q.Count > 0)
        {
            for (int i = q.Count; i > 0; i--)
            {
                // whatever added to queue are safe node or terminal node, add to result
                int node = q.Dequeue();
                ans.Add(node);

                // for all incoming edge
                foreach (int prev in incomingNode[node])
                {
                    // remove the edges, until there is no other outgoing edge
                    // then it will be safe node
                    // add to queue
                    outgoingDegree[prev]--;
                    if (outgoingDegree[prev] == 0)
                        q.Enqueue(prev);
                }
            }
        }

        // because the node added to result are not sorted, so sort it before return
        return ans.OrderBy(x => x).ToList();
    }
}
// @lc code=end


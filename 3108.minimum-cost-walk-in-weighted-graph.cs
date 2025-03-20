/*
 * @lc app=leetcode id=3108 lang=csharp
 *
 * [3108] Minimum Cost Walk in Weighted Graph
 *
 * https://leetcode.com/problems/minimum-cost-walk-in-weighted-graph/description/
 *
 * algorithms
 * Hard (46.21%)
 * Likes:    211
 * Dislikes: 17
 * Total Accepted:    14.6K
 * Total Submissions: 31.2K
 * Testcase Example:  '5\n[[0,1,7],[1,3,7],[1,2,1]]\n[[0,3],[3,4]]'
 *
 * There is an undirected weighted graph with n vertices labeled from 0 to n -
 * 1.
 * 
 * You are given the integer n and an array edges, where edges[i] = [ui, vi,
 * wi] indicates that there is an edge between vertices ui and vi with a weight
 * of wi.
 * 
 * A walk on a graph is a sequence of vertices and edges. The walk starts and
 * ends with a vertex, and each edge connects the vertex that comes before it
 * and the vertex that comes after it. It's important to note that a walk may
 * visit the same edge or vertex more than once.
 * 
 * The cost of a walk starting at node u and ending at node v is defined as the
 * bitwise AND of the weights of the edges traversed during the walk. In other
 * words, if the sequence of edge weights encountered during the walk is w0,
 * w1, w2, ..., wk, then the cost is calculated as w0 & w1 & w2 & ... & wk,
 * where & denotes the bitwise AND operator.
 * 
 * You are also given a 2D array query, where query[i] = [si, ti]. For each
 * query, you need to find the minimum cost of the walk starting at vertex si
 * and ending at vertex ti. If there exists no such walk, the answer is -1.
 * 
 * Return the array answer, where answer[i] denotes the minimum cost of a walk
 * for query i.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: n = 5, edges = [[0,1,7],[1,3,7],[1,2,1]], query = [[0,3],[3,4]]
 * 
 * Output: [1,-1]
 * 
 * Explanation:
 * 
 * To achieve the cost of 1 in the first query, we need to move on the
 * following edges: 0->1 (weight 7), 1->2 (weight 1), 2->1 (weight 1), 1->3
 * (weight 7).
 * 
 * In the second query, there is no walk between nodes 3 and 4, so the answer
 * is -1.
 * 
 * Example 2:
 * 
 * 
 * 
 * Input: n = 3, edges = [[0,2,7],[0,1,15],[1,2,6],[1,2,1]], query = [[1,2]]
 * 
 * Output: [0]
 * 
 * Explanation:
 * 
 * To achieve the cost of 0 in the first query, we need to move on the
 * following edges: 1->2 (weight 1), 2->1 (weight 6), 1->2 (weight 1).
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 2 <= n <= 10^5
 * 0 <= edges.length <= 10^5
 * edges[i].length == 3
 * 0 <= ui, vi <= n - 1
 * ui != vi
 * 0 <= wi <= 10^5
 * 1 <= query.length <= 10^5
 * query[i].length == 2
 * 0 <= si, ti <= n - 1
 * si != ti
 * 
 * 
 */
/*
 * Union Find Approach
 * Time: O(Q + V + E * a(V)), Space: O(V)
 */

// @lc code=start
public class MinimumCostDSU
{
    public int[] parent;
    public int[] cost;

    // Initialization
    // Time: O(V)
    public MinimumCostDSU(int n)
    {
        parent = new int[n];
        cost = new int[n];
        for (int i = 0; i < n; i++)
        {
            // parent of i = i itself
            parent[i] = i;
            // -1 to indicate no result cost
            cost[i] = -1;
        }
    }

    // Find parent
    // Time: O(a(V))
    public int Find(int x)
    {
        if (parent[x] != x)
            parent[x] = Find(parent[x]);
        return parent[x];
    }

    // Union 2 Vertices with weight
    // Time: O(a(V))
    public void Union(int x, int y, int weight)
    {
        // find corresponding parent
        int px = Find(x);
        int py = Find(y);

        // vertice with small cost will be the parent
        if (cost[px] > cost[py])
        {
            int tmp = px;
            px = py;
            py = tmp;
        }

        // update parent
        parent[py] = px;
        // if py have cost, propagate it with w1 & w
        int newWeight = cost[py] != -1 ? (cost[py] & weight) : weight;
        // if px have cost, need to apply formula w0 & (w1 & w)
        // otherwise just = newWeight
        cost[px] = cost[px] != -1 ? (cost[px] & newWeight) : newWeight;
    }

    // Get the result cost
    // Time: O(a(V))
    public int ResultCost(int x, int y)
    {
        int px = Find(x);
        int py = Find(y);
        if (px == py)
            return cost[px];
        return -1;
    }
}

public partial class Solution
{
    public int[] MinimumCost(int n, int[][] edges, int[][] query)
    {
        // initialize dsu
        MinimumCostDSU dsu = new MinimumCostDSU(n);

        // loop all the edges
        for (int i = 0; i < edges.Length; i++)
        {
            int u = edges[i][0];
            int v = edges[i][1];
            int w = edges[i][2];
            // union u and v with w
            dsu.Union(u, v, w);
        }

        int[] ans = new int[query.Length];
        for (int i = 0; i < query.Length; i++)
        {
            // get cost
            ans[i] = dsu.ResultCost(query[i][0], query[i][1]);
        }
        return ans;
    }
}
// @lc code=end


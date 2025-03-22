/*
 * @lc app=leetcode id=2685 lang=csharp
 *
 * [2685] Count the Number of Complete Components
 *
 * https://leetcode.com/problems/count-the-number-of-complete-components/description/
 *
 * algorithms
 * Medium (66.33%)
 * Likes:    765
 * Dislikes: 18
 * Total Accepted:    42.1K
 * Total Submissions: 62.4K
 * Testcase Example:  '6\n[[0,1],[0,2],[1,2],[3,4]]'
 *
 * You are given an integer n. There is an undirected graph with n vertices,
 * numbered from 0 to n - 1. You are given a 2D integer array edges where
 * edges[i] = [ai, bi] denotes that there exists an undirected edge connecting
 * vertices ai and bi.
 * 
 * Return the number of complete connected components of the graph.
 * 
 * A connected component is a subgraph of a graph in which there exists a path
 * between any two vertices, and no vertex of the subgraph shares an edge with
 * a vertex outside of the subgraph.
 * 
 * A connected component is said to be complete if there exists an edge between
 * every pair of its vertices.
 * 
 * 
 * Example 1:
 * 
 * 
 * 
 * 
 * Input: n = 6, edges = [[0,1],[0,2],[1,2],[3,4]]
 * Output: 3
 * Explanation: From the picture above, one can see that all of the components
 * of this graph are complete.
 * 
 * 
 * Example 2:
 * 
 * 
 * 
 * 
 * Input: n = 6, edges = [[0,1],[0,2],[1,2],[3,4],[3,5]]
 * Output: 1
 * Explanation: The component containing vertices 0, 1, and 2 is complete since
 * there is an edge between every pair of two vertices. On the other hand, the
 * component containing vertices 3, 4, and 5 is not complete since there is no
 * edge between vertices 4 and 5. Thus, the number of complete components in
 * this graph is 1.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= n <= 50
 * 0 <= edges.length <= n * (n - 1) / 2
 * edges[i].length == 2
 * 0 <= ai, bi <= n - 1
 * ai != bi
 * There are no repeated edges.
 * 
 * 
 */
/*
 * Union Find Approach
 * Time: O(V + E * a(V)), Space: O(V)
 */

// @lc code=start
public class CountCompleteComponentsDSU
{
    // store parent of each node
    private int[] parent;
    // store no. of nodes connected
    private int[] nodes;
    // store no. edges connected
    private int[] edges;

    // Initialization
    // Time: O(V)
    public CountCompleteComponentsDSU(int n)
    {
        parent = new int[n];
        nodes = new int[n];
        edges = new int[n];
        for (int i = 0; i < n; i++)
        {
            // parent[i] = i itself
            parent[i] = i;
            // no. of nodes = 1 (node itself)
            nodes[i] = 1;
            // no. of edges = 0 (no edge connected)
            edges[i] = 0;
        }
    }

    // Find Function
    // Time: O(a(V))
    public int Find(int x)
    {
        if (parent[x] != x)
            parent[x] = Find(parent[x]);
        return parent[x];
    }

    // Union Function
    // Time: O(a(V))
    public void Union(int x, int y)
    {
        int px = Find(x);
        int py = Find(y);

        // if nodes are connected, only increment the edge (new edge)
        if (px == py)
        {
            edges[px]++;
            return;
        }

        // if not connected
        if (nodes[px] < nodes[py])
        {
            int tmp = px;
            px = py;
            py = tmp;
        }

        // connect the nodes
        parent[py] = px;
        // increment the no. of nodes connected
        nodes[px] += nodes[py];
        // increment the no. of edges connected + 1 (new edge)
        edges[px] += edges[py] + 1;
    }

    // Check Function
    // Time: O(a(V))
    public bool IsCompleteComponents(int x)
    {
        int px = Find(x);

        // if x is the parent of the group
        // check the condition: m * (m - 1) / 2 == edges
        if (px == x && (nodes[px] * (nodes[px] - 1) >> 1) == edges[px])
            return true;

        // not complete connected components / not parent of the group
        return false;
    }
}

public partial class Solution
{
    // Union Find Approach
    public int CountCompleteComponents(int n, int[][] edges)
    {
        CountCompleteComponentsDSU dsu = new CountCompleteComponentsDSU(n);
        int ans = 0;

        for (int i = 0; i < edges.Length; i++)
        {
            dsu.Union(edges[i][0], edges[i][1]);
        }

        for (int i = 0; i < n; i++)
        {
            if (dsu.IsCompleteComponents(i))
                ans++;
        }
        return ans;
    }

    // BFS Approach
    /* public int CountCompleteComponents(int n, int[][] edges)
    {
        List<int>[] adj = new List<int>[n];
        bool[] visited = new bool[n];
        Queue<int> q = new Queue<int>();
        int ans = 0;

        for (int i = 0; i < n; i++)
            adj[i] = new List<int>();

        for (int i = 0; i < edges.Length; i++)
        {
            int u = edges[i][0];
            int v = edges[i][1];
            adj[u].Add(v);
            adj[v].Add(u);
        }

        for (int i = 0; i < n; i++)
        {
            if (visited[i])
                continue;

            int countOfNodes = 0;
            int countOfEdges = 0;
            q.Enqueue(i);
            while (q.Count > 0)
            {
                int node = q.Dequeue();
                if (visited[node])
                    continue;

                countOfNodes++;
                visited[node] = true;
                foreach (int next in adj[node])
                {
                    countOfEdges++;
                    q.Enqueue(next);
                    adj[next].Remove(node);
                }
            }

            if (countOfNodes * (countOfNodes - 1) / 2 == countOfEdges)
                ans++;
        }
        return ans;
    } */
}
// @lc code=end


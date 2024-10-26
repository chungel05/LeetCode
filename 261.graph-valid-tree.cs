/*
 * @lc app=leetcode id=261 lang=csharp
 *
 * [261] Graph Valid Tree
 *
 */

// @lc code=start
public partial class Solution
{
    public bool DFSGraphValidTree(HashSet<int>[] adj, int currNode, bool[] visited)
    {
        if (visited[currNode])
            return false;

        visited[currNode] = true;
        foreach (int node in adj[currNode])
        {
            adj[node].Remove(currNode);
            if (!DFSGraphValidTree(adj, node, visited))
                return false;
        }

        return true;
    }

    public bool GraphValidTree(int n, int[][] edges)
    {
        HashSet<int>[] adj = new HashSet<int>[n];
        bool[] visited = new bool[n];

        for (int i = 0; i < n; i++)
        {
            adj[i] = new HashSet<int>();
        }

        foreach (int[] edge in edges)
        {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }

        if (!DFSGraphValidTree(adj, 0, visited))
            return false;
        return visited.Any(x => !x) ? false : true;
    }
}
// @lc code=end
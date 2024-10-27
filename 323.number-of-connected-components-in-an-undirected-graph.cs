/*
 * @lc app=leetcode id=323 lang=csharp
 *
 * [323] Number of Connected Components In An Undirected Graph
 *
 */
/*
 * DFS Implementation
 * O(E+V)
 */
// @lc code=start
public partial class Solution
{
    public void DFSCountComponents(HashSet<int>[] map, int currNode, bool[] visited)
    {
        if (visited[currNode])
            return;

        visited[currNode] = true;
        foreach (int node in map[currNode])
        {
            map[node].Remove(currNode);
            DFSCountComponents(map, node, visited);
        }
    }

    public int CountComponents(int n, int[][] edges)
    {
        HashSet<int>[] map = new HashSet<int>[n];
        bool[] visited = new bool[n];
        int count = 0;

        for (int i = 0; i < n; i++)
        {
            map[i] = new HashSet<int>();
        }

        foreach (int[] edge in edges)
        {
            map[edge[0]].Add(edge[1]);
            map[edge[1]].Add(edge[0]);
        }

        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                DFSCountComponents(map, i, visited);
                count++;
            }
        }
        return count;
    }
}
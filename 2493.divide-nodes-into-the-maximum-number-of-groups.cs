/*
 * @lc app=leetcode id=2493 lang=csharp
 *
 * [2493] Divide Nodes Into the Maximum Number of Groups
 *
 * https://leetcode.com/problems/divide-nodes-into-the-maximum-number-of-groups/description/
 *
 * algorithms
 * Hard (39.97%)
 * Likes:    843
 * Dislikes: 65
 * Total Accepted:    69.9K
 * Total Submissions: 103K
 * Testcase Example:  '6\n[[1,2],[1,4],[1,5],[2,6],[2,3],[4,6]]'
 *
 * You are given a positive integer n representing the number of nodes in an
 * undirected graph. The nodes are labeled from 1 to n.
 * 
 * You are also given a 2D integer array edges, where edges[i] = [ai, bi]
 * indicates that there is a bidirectional edge between nodes ai and bi. Notice
 * that the given graph may be disconnected.
 * 
 * Divide the nodes of the graph into m groups (1-indexed) such that:
 * 
 * 
 * Each node in the graph belongs to exactly one group.
 * For every pair of nodes in the graph that are connected by an edge [ai, bi],
 * if ai belongs to the group with index x, and bi belongs to the group with
 * index y, then |y - x| = 1.
 * 
 * 
 * Return the maximum number of groups (i.e., maximum m) into which you can
 * divide the nodes. Return -1 if it is impossible to group the nodes with the
 * given conditions.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: n = 6, edges = [[1,2],[1,4],[1,5],[2,6],[2,3],[4,6]]
 * Output: 4
 * Explanation: As shown in the image we:
 * - Add node 5 to the first group.
 * - Add node 1 to the second group.
 * - Add nodes 2 and 4 to the third group.
 * - Add nodes 3 and 6 to the fourth group.
 * We can see that every edge is satisfied.
 * It can be shown that that if we create a fifth group and move any node from
 * the third or fourth group to it, at least on of the edges will not be
 * satisfied.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: n = 3, edges = [[1,2],[2,3],[3,1]]
 * Output: -1
 * Explanation: If we add node 1 to the first group, node 2 to the second
 * group, and node 3 to the third group to satisfy the first two edges, we can
 * see that the third edge will not be satisfied.
 * It can be shown that no grouping is possible.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= n <= 500
 * 1 <= edges.length <= 10^4
 * edges[i].length == 2
 * 1 <= ai, bi <= n
 * ai != bi
 * There is at most one edge between any pair of vertices.
 * 
 * 
 */
/*
 * Combined Union Find + BFS Approach
 * Time: O(V * (V + E)), Space: O(V)
 */

// @lc code=start
public partial class Solution
{
    // Method to check whether it is Bipartite
    // Time: O(V + E), Space: O(V)
    /* private bool IsBipartite(List<int>[] adj, int[] color, int src)
    {
        Queue<int> q = new Queue<int>();
        q.Enqueue(src);
        color[src] = 1;

        while (q.Count > 0)
        {
            int node = q.Dequeue();

            foreach (int next in adj[node])
            {
                if (color[next] == 0)
                {
                    color[next] = color[node] + 1;
                    q.Enqueue(next);
                }
                else if (Math.Abs(color[next] - color[node]) != 1)
                    return false;
            }
        }
        return true;
    } */

    // Method to find the max groups(level) from src node
    // Time: O(V + E), Space: O(V)
    /* private int BFSMaxGroup(List<int>[] adj, int[] dist, int src)
    {
        Queue<int> q = new Queue<int>();
        q.Enqueue(src);
        dist[src] = 1;
        int maxGroup = 1;

        while (q.Count > 0)
        {
            int node = q.Dequeue();

            foreach(int next in adj[node])
            {
                if (dist[next] == 0)
                {
                    dist[next] = dist[node] + 1;
                    q.Enqueue(next);
                    maxGroup = Math.Max(maxGroup, dist[next]);
                }
            }
        }
        return maxGroup;
    } */

    // Combined IsBipartite and MaxGroup into one Method
    public int MagnificentSets(int n, int[][] edges)
    {
        // create adj list for each node, store the information of edges
        List<int>[] adj = new List<int>[n];
        // create groups to store the max groups of each parent node
        // i.e. some nodes are 0 because only record in the parent node
        int[] groups = new int[n];

        // initialization of adj list
        for (int i = 0; i < n; i++)
        {
            adj[i] = new List<int>();
        }

        // convert the edges to adj list
        for (int i = 0; i < edges.Length; i++)
        {
            // since the information in edges are [1, n], so need to convert to [0, n - 1]
            int a = edges[i][0] - 1;
            int b = edges[i][1] - 1;
            adj[a].Add(b);
            adj[b].Add(a);
        }

        // start from each node, do the BFS to find the max groups
        // if it is not bipartite, return -1
        // otherwise, record the max groups in the corresponding groups[parent]
        // Time: O(V * (V + E)) because do BFS [V] times which BFS is O(V + E), 
        for (int i = 0; i < n; i++)
        {
            // start from i, assume parent is i
            Queue<int> q = new Queue<int>();
            int parent = i;
            q.Enqueue(i);

            // dist array to record it is visited and the corresponding group
            int[] dist = new int[n];
            // to track the max group
            int maxGroup = 1;
            // dist[src] is the first group
            dist[i] = 1;

            // BFS from src node i
            while (q.Count > 0)
            {
                int node = q.Dequeue();
                // in order to group the connected nodes into one single group, use smallest node to be the parent
                // this is Union Find Method
                parent = Math.Min(parent, node);

                // loop the adj. nodes
                foreach (int next in adj[node])
                {
                    // if dist[next] = 0, it is not visited, we update its group
                    if (dist[next] == 0)
                    {
                        dist[next] = dist[node] + 1;
                        q.Enqueue(next);
                        // track the max groups
                        maxGroup = Math.Max(maxGroup, dist[next]);
                    }
                    // if it is visited, check its group difference
                    // if not equal to 1, it is not bipartite, return -1
                    else if (Math.Abs(dist[next] - dist[node]) != 1)
                        return -1;
                }
            }
            // after BFS, store the max groups in corresponding parent
            groups[parent] = Math.Max(groups[parent], maxGroup);
        }

        // sum the max groups of each parent
        int res = 0;
        for (int i = 0; i < n; i++)
            res += groups[i];

        return res;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=684 lang=csharp
 *
 * [684] Redundant Connection
 *
 * https://leetcode.com/problems/redundant-connection/description/
 *
 * algorithms
 * Medium (63.53%)
 * Likes:    6287
 * Dislikes: 407
 * Total Accepted:    401.1K
 * Total Submissions: 630.7K
 * Testcase Example:  '[[1,2],[1,3],[2,3]]'
 *
 * In this problem, a tree is an undirected graph that is connected and has no
 * cycles.
 * 
 * You are given a graph that started as a tree with n nodes labeled from 1 to
 * n, with one additional edge added. The added edge has two different vertices
 * chosen from 1 to n, and was not an edge that already existed. The graph is
 * represented as an array edges of length n where edges[i] = [ai, bi]
 * indicates that there is an edge between nodes ai and bi in the graph.
 * 
 * Return an edge that can be removed so that the resulting graph is a tree of
 * n nodes. If there are multiple answers, return the answer that occurs last
 * in the input.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: edges = [[1,2],[1,3],[2,3]]
 * Output: [2,3]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: edges = [[1,2],[2,3],[3,4],[1,4],[1,5]]
 * Output: [1,4]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * n == edges.length
 * 3 <= n <= 1000
 * edges[i].length == 2
 * 1 <= ai < bi <= edges.length
 * ai != bi
 * There are no repeated edges.
 * The given graph is connected.
 * 
 * 
 */
/*
 * Union Find Implementation
 * for each edge, connect the node to the parent
 * if the node is already connected, then return 0
 * and return the redundant edge
 */

// @lc code=start
public partial class Solution
{
    private int[] parent;
    private int[] rank;

    private int UnionFindRedundantConnection(int n)
    {
        int res = n;

        while (parent[res] != res)
        {
            parent[res] = parent[parent[res]];
            res = parent[res];
        }
        return res;
    }

    private int UnionRedundantConnection(int n1, int n2)
    {
        int p1 = UnionFindRedundantConnection(n1);
        int p2 = UnionFindRedundantConnection(n2);
        if (p1 == p2)
            return 0;

        if (rank[p2] > rank[p1])
        {
            parent[p1] = p2;
            rank[p2] += rank[p1];
        }
        else
        {
            parent[p2] = p1;
            rank[p1] += rank[p2];
        }
        return 1;
    }

    public int[] FindRedundantConnection(int[][] edges)
    {
        parent = new int[edges.Length + 1];
        rank = new int[edges.Length + 1];

        for (int i = 1; i < edges.Length + 1; i++)
        {
            parent[i] = i;
            rank[i] = 1;
        }

        foreach (int[] edge in edges)
        {
            if (UnionRedundantConnection(edge[0], edge[1]) == 0)
                return edge;
        }
        return new int[] { };
    }
}
// @lc code=end


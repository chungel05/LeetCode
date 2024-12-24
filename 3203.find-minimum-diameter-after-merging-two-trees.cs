/*
 * @lc app=leetcode id=3203 lang=csharp
 *
 * [3203] Find Minimum Diameter After Merging Two Trees
 *
 * https://leetcode.com/problems/find-minimum-diameter-after-merging-two-trees/description/
 *
 * algorithms
 * Hard (35.96%)
 * Likes:    179
 * Dislikes: 11
 * Total Accepted:    14K
 * Total Submissions: 34.8K
 * Testcase Example:  '[[0,1],[0,2],[0,3]]\n[[0,1]]'
 *
 * There exist two undirected trees with n and m nodes, numbered from 0 to n -
 * 1 and from 0 to m - 1, respectively. You are given two 2D integer arrays
 * edges1 and edges2 of lengths n - 1 and m - 1, respectively, where edges1[i]
 * = [ai, bi] indicates that there is an edge between nodes ai and bi in the
 * first tree and edges2[i] = [ui, vi] indicates that there is an edge between
 * nodes ui and vi in the second tree.
 * 
 * You must connect one node from the first tree with another node from the
 * second tree with an edge.
 * 
 * Return the minimum possible diameter of the resulting tree.
 * 
 * The diameter of a tree is the length of the longest path between any two
 * nodes in the tree.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: edges1 = [[0,1],[0,2],[0,3]], edges2 = [[0,1]]
 * 
 * Output: 3
 * 
 * Explanation:
 * 
 * We can obtain a tree of diameter 3 by connecting node 0 from the first tree
 * with any node from the second tree.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: edges1 = [[0,1],[0,2],[0,3],[2,4],[2,5],[3,6],[2,7]], edges2 =
 * [[0,1],[0,2],[0,3],[2,4],[2,5],[3,6],[2,7]]
 * 
 * Output: 5
 * 
 * Explanation:
 * 
 * We can obtain a tree of diameter 5 by connecting node 0 from the first tree
 * with node 0 from the second tree.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= n, m <= 10^5
 * edges1.length == n - 1
 * edges2.length == m - 1
 * edges1[i].length == edges2[i].length == 2
 * edges1[i] = [ai, bi]
 * 0 <= ai, bi < n
 * edges2[i] = [ui, vi]
 * 0 <= ui, vi < m
 * The input is generated such that edges1 and edges2 represent valid trees.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    private int DiameterOfMHT(int[][] edges)
    {
        int n = edges.Length + 1;

        // edge case, if we do not have any edge and only have 1 node
        // we return diameter = 0
        if (n == 1)
            return 0;

        int[] degree = new int[n];
        List<int>[] graph = new List<int>[n];

        for (int i = 0; i < n; i++)
        {
            graph[i] = new List<int>();
        }

        for (int i = 0; i < n - 1; i++)
        {
            graph[edges[i][0]].Add(edges[i][1]);
            graph[edges[i][1]].Add(edges[i][0]);

            degree[edges[i][0]]++;
            degree[edges[i][1]]++;
        }

        Queue<int> q = new Queue<int>();
        for (int i = 0; i < n; i++)
        {
            // Add the node which only has 1 edge, it is leaf
            if (degree[i] == 1)
                q.Enqueue(i);
        }

        int level = 0;
        int remaining = n;
        while (remaining > 2)
        {
            remaining -= q.Count;
            for (int i = q.Count; i > 0; i--)
            {
                int node = q.Dequeue();
                degree[node]--;

                foreach (int parent in graph[node])
                {
                    if (degree[parent] == 0)
                        continue;

                    degree[parent]--;

                    // Add the node which only has 1 edge, it is leaf
                    if (degree[parent] == 1)
                        q.Enqueue(parent);
                }
            }
            level++;
        }

        // if remain 2 node, each one can be the root of MHT, and the diameter is 2 * level + 1 (remaining edge of 2 root)
        // else remain 1 node, it is the only root of MHT, and the diameter is 2 * level
        return remaining == 2 ? 2 * level + 1 : 2 * level;
    }

    public int MinimumDiameterAfterMerge(int[][] edges1, int[][] edges2)
    {
        // find the diameter of each tree
        int d1 = DiameterOfMHT(edges1);
        int d2 = DiameterOfMHT(edges2);

        // case 1: max diameter = original tree
        int res = Math.Max(d1, d2);

        // case 2: max diameter = from tree 1 to tree 2 = radius of tree 1 + radius of tree 2 + 1
        // we use ceiling because we need to get Minimum height of the MHT
        // i.e. diameter = 7, min height = 4
        return Math.Max((int)Math.Ceiling(d1 / 2.0) + (int)Math.Ceiling(d2 / 2.0) + 1, res);
    }
}
// @lc code=end


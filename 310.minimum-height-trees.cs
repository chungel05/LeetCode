/*
 * @lc app=leetcode id=310 lang=csharp
 *
 * [310] Minimum Height Trees
 *
 * https://leetcode.com/problems/minimum-height-trees/description/
 *
 * algorithms
 * Medium (41.89%)
 * Likes:    8391
 * Dislikes: 391
 * Total Accepted:    402.4K
 * Total Submissions: 960.6K
 * Testcase Example:  '4\n[[1,0],[1,2],[1,3]]'
 *
 * A tree is an undirected graph in which any two vertices are connected by
 * exactly one path. In other words, any connected graph without simple cycles
 * is a tree.
 * 
 * Given a tree of n nodes labelled from 0 to n - 1, and an array of n - 1
 * edges where edges[i] = [ai, bi] indicates that there is an undirected edge
 * between the two nodes ai and bi in the tree, you can choose any node of the
 * tree as the root. When you select a node x as the root, the result tree has
 * height h. Among all possible rooted trees, those with minimum height (i.e.
 * min(h))  are called minimum height trees (MHTs).
 * 
 * Return a list of all MHTs' root labels. You can return the answer in any
 * order.
 * 
 * The height of a rooted tree is the number of edges on the longest downward
 * path between the root and a leaf.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: n = 4, edges = [[1,0],[1,2],[1,3]]
 * Output: [1]
 * Explanation: As shown, the height of the tree is 1 when the root is the node
 * with label 1 which is the only MHT.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: n = 6, edges = [[3,0],[3,1],[3,2],[3,4],[5,4]]
 * Output: [3,4]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= n <= 2 * 10^4
 * edges.length == n - 1
 * 0 <= ai, bi < n
 * ai != bi
 * All the pairs (ai, bi) are distinct.
 * The given input is guaranteed to be a tree and there will be no repeated
 * edges.
 * 
 * 
 */
/*
 * Topological Sorting Approach
 * Time: O(V+E):
 * In the queue, we loop for each node and its corresponding edge
 * Because each edge have 2 end, so we will look to the edge twice which is O(2E)
 * so overall time complexity is O(V+E)
 * Space: O(V+E):
 * Adj list hold O(E) space
 * queue hold O(V) space
 */

// @lc code=start
public partial class Solution
{
    public IList<int> FindMinHeightTrees(int n, int[][] edges)
    {
        if (n == 1)
            return new List<int>() { 0 };

        List<int>[] adj = new List<int>[n];
        int[] degrees = new int[n];

        for (int i = 0; i < n; i++)
            adj[i] = new List<int>();

        foreach (int[] e in edges)
        {
            // construct adj list
            adj[e[0]].Add(e[1]);
            adj[e[1]].Add(e[0]);

            // increase degree if it have edge
            degrees[e[0]]++;
            degrees[e[1]]++;
        }

        Queue<int> q = new Queue<int>();
        for (int i = 0; i < n; i++)
        {
            // push all node with only 1 degree, which is the leaf
            if (degrees[i] == 1)
                q.Enqueue(i);
        }

        List<int> leaves = new List<int>();
        while (q.Count > 0)
        {
            // reset leaves set because we have another level
            leaves.Clear();

            for (int i = q.Count; i > 0; i--)
            {
                int node = q.Dequeue();
                leaves.Add(node);

                // look for all adj nodes
                foreach (int next in adj[node])
                {
                    // we remove the edge by decreasing the degree
                    degrees[next]--;

                    // if the next node have only 1 degree, it is a leaf
                    if (degrees[next] == 1)
                        q.Enqueue(next);
                }
            }
        }

        // continue util we have 1 or 2 nodes remain
        return leaves;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=547 lang=csharp
 *
 * [547] Number of Provinces
 *
 * https://leetcode.com/problems/number-of-provinces/description/
 *
 * algorithms
 * Medium (67.28%)
 * Likes:    9944
 * Dislikes: 375
 * Total Accepted:    1M
 * Total Submissions: 1.5M
 * Testcase Example:  '[[1,1,0],[1,1,0],[0,0,1]]'
 *
 * There are n cities. Some of them are connected, while some are not. If city
 * a is connected directly with city b, and city b is connected directly with
 * city c, then city a is connected indirectly with city c.
 * 
 * A province is a group of directly or indirectly connected cities and no
 * other cities outside of the group.
 * 
 * You are given an n x n matrix isConnected where isConnected[i][j] = 1 if the
 * i^th city and the j^th city are directly connected, and isConnected[i][j] =
 * 0 otherwise.
 * 
 * Return the total number of provinces.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: isConnected = [[1,1,0],[1,1,0],[0,0,1]]
 * Output: 2
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: isConnected = [[1,0,0],[0,1,0],[0,0,1]]
 * Output: 3
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= n <= 200
 * n == isConnected.length
 * n == isConnected[i].length
 * isConnected[i][j] is 1 or 0.
 * isConnected[i][i] == 1
 * isConnected[i][j] == isConnected[j][i]
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    private int UnionFindCircleNum(int n, int[] parent)
    {
        int res = parent[n];
        while (parent[res] != res)
        {
            parent[res] = parent[parent[res]];
            res = parent[res];
        }
        return res;
    }

    private bool UnionCircleNum(int n1, int n2, int[] parent, int[] rank)
    {
        int p1 = UnionFindCircleNum(n1, parent);
        int p2 = UnionFindCircleNum(n2, parent);

        if (p1 == p2)
            return false;

        if (rank[p2] > p1)
        {
            parent[p1] = p2;
            rank[p2] += rank[p1];
        }
        else
        {
            parent[p2] = p1;
            rank[p1] += rank[p2];
        }
        return true;
    }

    public int FindCircleNum(int[][] isConnected)
    {
        int[] parent = new int[isConnected.Length];
        int[] rank = new int[isConnected.Length];
        HashSet<int[]> edges = new HashSet<int[]>();

        for (int i = 0; i < isConnected.Length; i++)
        {
            parent[i] = i;
            rank[i] = 1;
        }

        for (int i = 0; i < isConnected.Length; i++)
        {
            for (int j = i + 1; j < isConnected.Length; j++)
            {
                if (isConnected[i][j] == 1)
                {
                    edges.Add(new int[] { i, j });
                }
            }
        }

        int res = isConnected.Length;
        foreach (int[] edge in edges)
        {
            if (UnionCircleNum(edge[0], edge[1], parent, rank))
                res--;
        }
        return res;
    }
}
// @lc code=end


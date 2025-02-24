/*
 * @lc app=leetcode id=2467 lang=csharp
 *
 * [2467] Most Profitable Path in a Tree
 *
 * https://leetcode.com/problems/most-profitable-path-in-a-tree/description/
 *
 * algorithms
 * Medium (49.36%)
 * Likes:    770
 * Dislikes: 85
 * Total Accepted:    19.2K
 * Total Submissions: 36.2K
 * Testcase Example:  '[[0,1],[1,2],[1,3],[3,4]]\n3\n[-2,4,2,-4,6]'
 *
 * There is an undirected tree with n nodes labeled from 0 to n - 1, rooted at
 * node 0. You are given a 2D integer array edges of length n - 1 where
 * edges[i] = [ai, bi] indicates that there is an edge between nodes ai and bi
 * in the tree.
 * 
 * At every node i, there is a gate. You are also given an array of even
 * integers amount, where amount[i] represents:
 * 
 * 
 * the price needed to open the gate at node i, if amount[i] is negative,
 * or,
 * the cash reward obtained on opening the gate at node i, otherwise.
 * 
 * 
 * The game goes on as follows:
 * 
 * 
 * Initially, Alice is at node 0 and Bob is at node bob.
 * At every second, Alice and Bob each move to an adjacent node. Alice moves
 * towards some leaf node, while Bob moves towards node 0.
 * For every node along their path, Alice and Bob either spend money to open
 * the gate at that node, or accept the reward. Note that:
 * 
 * If the gate is already open, no price will be required, nor will there be
 * any cash reward.
 * If Alice and Bob reach the node simultaneously, they share the price/reward
 * for opening the gate there. In other words, if the price to open the gate is
 * c, then both Alice and Bob pay c / 2 each. Similarly, if the reward at the
 * gate is c, both of them receive c / 2 each.
 * 
 * 
 * If Alice reaches a leaf node, she stops moving. Similarly, if Bob reaches
 * node 0, he stops moving. Note that these events are independent of each
 * other.
 * 
 * 
 * Return the maximum net income Alice can have if she travels towards the
 * optimal leaf node.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: edges = [[0,1],[1,2],[1,3],[3,4]], bob = 3, amount = [-2,4,2,-4,6]
 * Output: 6
 * Explanation: 
 * The above diagram represents the given tree. The game goes as follows:
 * - Alice is initially on node 0, Bob on node 3. They open the gates of their
 * respective nodes.
 * ⁠ Alice's net income is now -2.
 * - Both Alice and Bob move to node 1. 
 * Since they reach here simultaneously, they open the gate together and share
 * the reward.
 * Alice's net income becomes -2 + (4 / 2) = 0.
 * - Alice moves on to node 3. Since Bob already opened its gate, Alice's
 * income remains unchanged.
 * Bob moves on to node 0, and stops moving.
 * - Alice moves on to node 4 and opens the gate there. Her net income becomes
 * 0 + 6 = 6.
 * Now, neither Alice nor Bob can make any further moves, and the game ends.
 * It is not possible for Alice to get a higher net income.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: edges = [[0,1]], bob = 1, amount = [-7280,2350]
 * Output: -7280
 * Explanation: 
 * Alice follows the path 0->1 whereas Bob follows the path 1->0.
 * Thus, Alice opens the gate at node 0 only. Hence, her net income is
 * -7280. 
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 2 <= n <= 10^5
 * edges.length == n - 1
 * edges[i].length == 2
 * 0 <= ai, bi < n
 * ai != bi
 * edges represents a valid tree.
 * 1 <= bob < n
 * amount.length == n
 * amount[i] is an even integer in the range [-10^4, 10^4].
 * 
 * 
 */
/*
 * DFS Approach
 * Time: O(n), Space: O(n) where n is no. of nodes
 */

// @lc code=start
public partial class Solution
{
    // Combined DFS Approach
    // Time: O(n), Space: O(n)
    private int CombinedBobAndAlice(List<int>[] adj, int[] amount, int parent, int node, int time, int n, int bob, int[] distFromBob)
    {
        int maxIncome = 0, maxChild = Int32.MinValue;
        // if current node is source of Bob, then its distance (level) will be 0
        if (node == bob)
            distFromBob[node] = 0;
        // otherwise, initialized as n
        else
            distFromBob[node] = n;

        // go through the childs
        foreach (int child in adj[node])
        {
            // use parent to indicate where come from, prevent go back for the path
            if (child == parent)
                continue;

            // calc the max profit alice can get from the child's path
            maxChild = Math.Max(maxChild, CombinedBobAndAlice(adj, amount, node, child, time + 1, n, bob, distFromBob));
            // update distance (level) of current node from bob
            // if the child node is not path of Bob, its distance will be n
            // otherwise, it will be level
            distFromBob[node] = Math.Min(distFromBob[node], distFromBob[child] + 1);
        }

        // if distFromBob[node] > time, there are 2 cases
        // case 1: the node is not the path of Bob = distFromBob[node] = n
        // case 2: the node is path of Bob and Bob arrived later than Alice = [0, n - 1]
        // no matter which cases, Alice need to open the gate which current max profit is amount[node]
        if (distFromBob[node] > time)
            maxIncome = amount[node];
        // if distFromBob[node] == time, which Bob and Alice will meet each other at the same time
        // current max profit is amount[node] / 2
        else if (distFromBob[node] == time)
            maxIncome = amount[node] / 2;

        // if max profit from child is min value, then it is leaf, return the maxIncome
        // otherwise, return maxIncome + maxChild
        return maxChild == Int32.MinValue ? maxIncome : maxIncome + maxChild;
    }

    // 2 DFS Approach
    // Time: O(n), Space: O(n) where n is no. of nodes
    // Find the path of Bob and its corresponding distance from source (level)
    // since it is valid tree, so there must be one and only one path from Bob to 0
    /* private bool DFSBob(List<int>[] adj, int parent, int node, int time, int[] distFromBob)
    {
        // if arrived node 0, return true and update its time (level)
        if (node == 0)
        {
            distFromBob[node] = time;
            return true;
        }

        // otherwise, move to child nodes
        foreach (int child in adj[node])
        {
            // use parent to indicate where come from, prevent go back for the path
            if (child == parent)
                continue;

            // move to child node
            // if found the destination node 0, update its time (level)
            if (DFSBob(adj, node, child, time + 1, distFromBob))
            {
                distFromBob[node] = time;
                return true;
            }
        }
        return false;
    } */

    // DFS Alice's path and calc the corresponding profit
    /* private int DFSAlice(List<int>[] adj, int[] amount, int parent, int node, int time, int[] distFromBob)
    {
        int maxIncome = 0, maxChild = Int32.MinValue;
        // Go through the child first, calc the returned profit
        foreach (int child in adj[node])
        {
            // use parent to indicate where come from, prevent go back for the path
            if (child == parent)
                continue;

            // update the max profit from each child
            maxChild = Math.Max(maxChild, DFSAlice(adj, amount, node, child, time + 1, distFromBob));
        }

        // if distFromBob[node] > time, there are 2 cases
        // case 1: the node is not the path of Bob = distFromBob[node] = n
        // case 2: the node is path of Bob and Bob arrived later than Alice = [0, n - 1]
        // no matter which cases, Alice need to open the gate which current max profit is amount[node]
        if (distFromBob[node] > time)
            maxIncome = amount[node];
        // if distFromBob[node] == time, which Bob and Alice will meet each other at the same time
        // current max profit is amount[node] / 2
        else if (distFromBob[node] == time)
            maxIncome = amount[node] / 2;

        // if max profit from child is min value, then it is leaf, return the maxIncome
        // otherwise, return maxIncome + maxChild
        return maxChild == Int32.MinValue ? maxIncome : maxIncome + maxChild;
    } */

    public int MostProfitablePath(int[][] edges, int bob, int[] amount)
    {
        int n = edges.Length + 1;
        int[] distFromBob = new int[n];
        List<int>[] adj = new List<int>[n];
        for (int i = 0; i < n; i++)
            adj[i] = new List<int>();

        // create the tree by using edges
        for (int i = 0; i < n - 1; i++)
        {
            adj[edges[i][0]].Add(edges[i][1]);
            adj[edges[i][1]].Add(edges[i][0]);
        }

        return CombinedBobAndAlice(adj, amount, 0, 0, 0, n, bob, distFromBob);
    }
}
// @lc code=end


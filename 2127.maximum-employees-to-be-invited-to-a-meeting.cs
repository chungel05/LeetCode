/*
 * @lc app=leetcode id=2127 lang=csharp
 *
 * [2127] Maximum Employees to Be Invited to a Meeting
 *
 * https://leetcode.com/problems/maximum-employees-to-be-invited-to-a-meeting/description/
 *
 * algorithms
 * Hard (37.46%)
 * Likes:    1513
 * Dislikes: 63
 * Total Accepted:    73.8K
 * Total Submissions: 118.3K
 * Testcase Example:  '[2,2,1,2]'
 *
 * A company is organizing a meeting and has a list of n employees, waiting to
 * be invited. They have arranged for a large circular table, capable of
 * seating any number of employees.
 * 
 * The employees are numbered from 0 to n - 1. Each employee has a favorite
 * person and they will attend the meeting only if they can sit next to their
 * favorite person at the table. The favorite person of an employee is not
 * themself.
 * 
 * Given a 0-indexed integer array favorite, where favorite[i] denotes the
 * favorite person of the i^th employee, return the maximum number of employees
 * that can be invited to the meeting.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: favorite = [2,2,1,2]
 * Output: 3
 * Explanation:
 * The above figure shows how the company can invite employees 0, 1, and 2, and
 * seat them at the round table.
 * All employees cannot be invited because employee 2 cannot sit beside
 * employees 0, 1, and 3, simultaneously.
 * Note that the company can also invite employees 1, 2, and 3, and give them
 * their desired seats.
 * The maximum number of employees that can be invited to the meeting is 3. 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: favorite = [1,2,0]
 * Output: 3
 * Explanation: 
 * Each employee is the favorite person of at least one other employee, and the
 * only way the company can invite them is if they invite every employee.
 * The seating arrangement will be the same as that in the figure given in
 * example 1:
 * - Employee 0 will sit between employees 2 and 1.
 * - Employee 1 will sit between employees 0 and 2.
 * - Employee 2 will sit between employees 1 and 0.
 * The maximum number of employees that can be invited to the meeting is 3.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: favorite = [3,0,1,4,1]
 * Output: 4
 * Explanation:
 * The above figure shows how the company will invite employees 0, 1, 3, and 4,
 * and seat them at the round table.
 * Employee 2 cannot be invited because the two spots next to their favorite
 * employee 1 are taken.
 * So the company leaves them out of the meeting.
 * The maximum number of employees that can be invited to the meeting is 4.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * n == favorite.length
 * 2 <= n <= 10^5
 * 0 <= favorite[i] <= n - 1
 * favorite[i] != i
 * 
 * 
 */
/*
 * Topological Sorting Approach
 * Time: O(V + E) = O(2n) = O(n), because V = [0, n - 1] = n, E = favorite.Length = n
 * Space: O(n)
 */

// @lc code=start
public partial class Solution
{
    public int MaximumInvitations(int[] favorite)
    {
        int n = favorite.Length;
        // chainLen to store the no. of nodes propagate to i
        int[] chainLen = new int[n];
        // marked as visited
        bool[] visited = new bool[n];
        // count the incoming edges, which is fav counts
        int[] in_degree = new int[n];
        // Handle the node not in cycle, propagation part
        Queue<int> q = new Queue<int>();

        // fav counts
        for (int i = 0; i < n; i++)
        {
            in_degree[favorite[i]]++;
        }

        for (int i = 0; i < n; i++)
        {
            // if fav count is 0, it is the chain end
            // Add to Queue
            if (in_degree[i] == 0)
                q.Enqueue(i);
        }

        // Handling node in cycle, propagate the chainLen to fav node
        while (q.Count > 0)
        {
            int node = q.Dequeue();
            visited[node] = true;

            int fav = favorite[node];
            // propagate the chainLen, and compare with other route
            chainLen[fav] = Math.Max(chainLen[fav], chainLen[node] + 1);

            // if in_degree is 0, can propagate again
            in_degree[fav]--;
            if (in_degree[fav] == 0)
                q.Enqueue(fav);
        }

        // cycle detection and calc possible chain len
        int maxCycle = 0, pairChain = 0;
        for (int i = 0; i < n; i++)
        {
            // if visited, it already handle in Queue
            if (visited[i])
                continue;

            // check the cycle len start from current node = i
            int cycleLen = 0, curr = i;
            while (!visited[curr])
            {
                visited[curr] = true;
                curr = favorite[curr];
                cycleLen++;
            }

            // if cycleLen == 2, it is special case
            // can form a part of table, also can merge with other group with same properties
            // i.e. [A -> B <-> C <- D] merge with [E -> F -> G -> H <-> I]
            // A, D, E, I can sit together without problem
            if (cycleLen == 2)
                pairChain += 2 + chainLen[i] + chainLen[favorite[i]];

            // if it is cycleLen more then 2
            // it only can form individually
            // i.e. [A -> B -> C -> D -> A], other cycle cannot merge together
            else
                maxCycle = Math.Max(maxCycle, cycleLen);
        }

        return Math.Max(maxCycle, pairChain);
    }
}
// @lc code=end


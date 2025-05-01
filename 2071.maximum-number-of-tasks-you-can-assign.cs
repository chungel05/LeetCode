/*
 * @lc app=leetcode id=2071 lang=csharp
 *
 * [2071] Maximum Number of Tasks You Can Assign
 *
 * https://leetcode.com/problems/maximum-number-of-tasks-you-can-assign/description/
 *
 * algorithms
 * Hard (33.61%)
 * Likes:    581
 * Dislikes: 26
 * Total Accepted:    12.6K
 * Total Submissions: 35.2K
 * Testcase Example:  '[3,2,1]\n[0,3,3]\n1\n1'
 *
 * You have n tasks and m workers. Each task has a strength requirement stored
 * in a 0-indexed integer array tasks, with the i^th task requiring tasks[i]
 * strength to complete. The strength of each worker is stored in a 0-indexed
 * integer array workers, with the j^th worker having workers[j] strength. Each
 * worker can only be assigned to a single task and must have a strength
 * greater than or equal to the task's strength requirement (i.e., workers[j]
 * >= tasks[i]).
 * 
 * Additionally, you have pills magical pills that will increase a worker's
 * strength by strength. You can decide which workers receive the magical
 * pills, however, you may only give each worker at most one magical pill.
 * 
 * Given the 0-indexed integer arrays tasks and workers and the integers pills
 * and strength, return the maximum number of tasks that can be completed.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: tasks = [3,2,1], workers = [0,3,3], pills = 1, strength = 1
 * Output: 3
 * Explanation:
 * We can assign the magical pill and tasks as follows:
 * - Give the magical pill to worker 0.
 * - Assign worker 0 to task 2 (0 + 1 >= 1)
 * - Assign worker 1 to task 1 (3 >= 2)
 * - Assign worker 2 to task 0 (3 >= 3)
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: tasks = [5,4], workers = [0,0,0], pills = 1, strength = 5
 * Output: 1
 * Explanation:
 * We can assign the magical pill and tasks as follows:
 * - Give the magical pill to worker 0.
 * - Assign worker 0 to task 0 (0 + 5 >= 5)
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: tasks = [10,15,30], workers = [0,10,10,10,10], pills = 3, strength =
 * 10
 * Output: 2
 * Explanation:
 * We can assign the magical pills and tasks as follows:
 * - Give the magical pill to worker 0 and worker 1.
 * - Assign worker 0 to task 0 (0 + 10 >= 10)
 * - Assign worker 1 to task 1 (10 + 10 >= 15)
 * The last pill is not given because it will not make any worker strong enough
 * for the last task.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * n == tasks.length
 * m == workers.length
 * 1 <= n, m <= 5 * 10^4
 * 0 <= pills <= m
 * 0 <= tasks[i], workers[j], strength <= 10^9
 * 
 * 
 */
/*
 * Binary Search Approach (with Greedy assignment)
 * Time: O(n log n + m log m + min(m,n) * log^2 min(m, n))
 * Space: O(m + n + min(m, n))
 */

// @lc code=start
public partial class Solution
{
    private static bool CheckMaxTaskAssign(int k, int[] tasks, int[] workers, int pills, int strength)
    {
        // take k easiest tasks and assign to k strongest workers
        // if strongest worker cannot take task without pills,
        // then assign weakest worker that can take it with pills

        // use LinkedList to hold the workers
        var ws = new LinkedList<int>();
        // worker select from strongest to weakest
        int currWorker = workers.Length - 1;

        // assign tasks from hardest to easiest
        for (var i = k - 1; i >= 0; i--)
        {
            // add the worker that can take the task[i] with pills
            // suppose we need k strongest worker, then currWorker should be >= m - k
            while (currWorker >= workers.Length - k && workers[currWorker] + strength >= tasks[i])
            {
                // add to front, so it is sorting accending
                ws.AddFirst(workers[currWorker]);
                // move worker pointer
                currWorker--;
            }

            // if no worker can take the task (even with pills), then return false
            if (ws.Count == 0)
                return false;
            // if strongest worker can take the task without pills, then directly assign it
            else if (ws.Last != null && ws.Last.Value >= tasks[i])
                ws.RemoveLast();
            // otherwise, assign weakest worker that can take task with pills
            else
            {
                // if no more pills, then return false
                if (pills == 0)
                    return false;

                // assign work and use pills
                pills--;
                ws.RemoveFirst();
            }
        }

        // if k tasks assigned to k strongest workers, then return true
        return true;
    }

    public int MaxTaskAssign(int[] tasks, int[] workers, int pills, int strength)
    {
        // sort tasks and workers
        Array.Sort(tasks);
        Array.Sort(workers);

        // Binary Search, find the max k that can achieve
        int l = 0;
        int r = Math.Min(tasks.Length, workers.Length);

        while (l < r)
        {
            int mid = (l + r + 1) / 2;

            if (CheckMaxTaskAssign(mid, tasks, workers, pills, strength))
                l = mid;
            else
                r = mid - 1;
        }

        return l;
    }
}
// @lc code=end


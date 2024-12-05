/*
 * @lc app=leetcode id=1335 lang=csharp
 *
 * [1335] Minimum Difficulty of a Job Schedule
 *
 * https://leetcode.com/problems/minimum-difficulty-of-a-job-schedule/description/
 *
 * algorithms
 * Hard (59.60%)
 * Likes:    3448
 * Dislikes: 322
 * Total Accepted:    204.5K
 * Total Submissions: 342.9K
 * Testcase Example:  '[6,5,4,3,2,1]\n2'
 *
 * You want to schedule a list of jobs in d days. Jobs are dependent (i.e To
 * work on the i^th job, you have to finish all the jobs j where 0 <= j < i).
 * 
 * You have to finish at least one task every day. The difficulty of a job
 * schedule is the sum of difficulties of each day of the d days. The
 * difficulty of a day is the maximum difficulty of a job done on that day.
 * 
 * You are given an integer array jobDifficulty and an integer d. The
 * difficulty of the i^th job is jobDifficulty[i].
 * 
 * Return the minimum difficulty of a job schedule. If you cannot find a
 * schedule for the jobs return -1.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: jobDifficulty = [6,5,4,3,2,1], d = 2
 * Output: 7
 * Explanation: First day you can finish the first 5 jobs, total difficulty =
 * 6.
 * Second day you can finish the last job, total difficulty = 1.
 * The difficulty of the schedule = 6 + 1 = 7 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: jobDifficulty = [9,9,9], d = 4
 * Output: -1
 * Explanation: If you finish a job per day you will still have a free day. you
 * cannot find a schedule for the given jobs.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: jobDifficulty = [1,1,1], d = 3
 * Output: 3
 * Explanation: The schedule is one job per day. total difficulty will be
 * 3.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= jobDifficulty.length <= 300
 * 0 <= jobDifficulty[i] <= 1000
 * 1 <= d <= 10
 * 
 * 
 */
/*
 * DFS top-down approach with caching
 * Time: O(n * n * d), Space: O(n * n * d)
 * for the same day, we will have n DFS calls
 * for different day, we will have at most d * n DFS calls
 * so we total have n * n * d
 */

// @lc code=start
public partial class Solution
{
    private int DFSMinDifficulty(int[] jobDifficulty, int d, int i, int currMax, int[,,] dp)
    {
        // base valid case: d == 0 and i == job.Length
        if (d == 0 && i == jobDifficulty.Length)
            return 0;

        // invalid case: d == 0 but i != job.Length OR
        // i == job.Length but d != 0
        // return maxValue / 2 because maxValue + currMax will overflow which is negative
        if (d == 0 || i == jobDifficulty.Length)
            return int.MaxValue / 2;

        // return cache if possible
        if (dp[d, i, currMax] != -1)
            return dp[d, i, currMax];

        // max job difficulty in curr day
        currMax = Math.Max(currMax, jobDifficulty[i]);
        int res = Math.Min(
            // Case 1: continue in the same day
            DFSMinDifficulty(jobDifficulty, d, i + 1, currMax, dp),
            // Case 2: continue but not in the same day, so we need to add currMax
            DFSMinDifficulty(jobDifficulty, d - 1, i + 1, 0, dp) + currMax
        );

        dp[d, i, currMax] = res;

        return res;
    }

    public int MinDifficulty(int[] jobDifficulty, int d)
    {
        if (jobDifficulty.Length < d)
            return -1;

        // initized dp array using d, i and curr max difficulty
        int[,,] dp = new int[d + 1, jobDifficulty.Length, 1001];

        for (int i = 0; i <= d; i++)
        {
            for (int j = 0; j < jobDifficulty.Length; j++)
            {
                for (int k = 0; k < 1001; k++)
                    dp[i, j, k] = -1;
            }
        }

        return DFSMinDifficulty(jobDifficulty, d, 0, 0, dp);
    }
}
// @lc code=end


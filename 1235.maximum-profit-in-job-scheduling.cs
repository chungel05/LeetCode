/*
 * @lc app=leetcode id=1235 lang=csharp
 *
 * [1235] Maximum Profit in Job Scheduling
 *
 * https://leetcode.com/problems/maximum-profit-in-job-scheduling/description/
 *
 * algorithms
 * Hard (54.32%)
 * Likes:    6912
 * Dislikes: 110
 * Total Accepted:    334.2K
 * Total Submissions: 615.5K
 * Testcase Example:  '[1,2,3,3]\n[3,4,5,6]\n[50,10,40,70]'
 *
 * We have n jobs, where every job is scheduled to be done from startTime[i] to
 * endTime[i], obtaining a profit of profit[i].
 * 
 * You're given the startTime, endTime and profit arrays, return the maximum
 * profit you can take such that there are no two jobs in the subset with
 * overlapping time range.
 * 
 * If you choose a job that ends at time X you will be able to start another
 * job that starts at time X.
 * 
 * 
 * Example 1:
 * 
 * 
 * 
 * 
 * Input: startTime = [1,2,3,3], endTime = [3,4,5,6], profit = [50,10,40,70]
 * Output: 120
 * Explanation: The subset chosen is the first and fourth job. 
 * Time range [1-3]+[3-6] , we get profit of 120 = 50 + 70.
 * 
 * 
 * Example 2:
 * 
 * ⁠
 * 
 * 
 * Input: startTime = [1,2,3,4,6], endTime = [3,5,10,6,9], profit =
 * [20,20,100,70,60]
 * Output: 150
 * Explanation: The subset chosen is the first, fourth and fifth job. 
 * Profit obtained 150 = 20 + 70 + 60.
 * 
 * 
 * Example 3:
 * 
 * 
 * 
 * 
 * Input: startTime = [1,1,1], endTime = [2,3,4], profit = [5,6,4]
 * Output: 6
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= startTime.length == endTime.length == profit.length <= 5 * 10^4
 * 1 <= startTime[i] < endTime[i] <= 10^9
 * 1 <= profit[i] <= 10^4
 * 
 * 
 */
/*
 * DFS top-down with caching approach
 * Time: O(n log n), Space: O(n)
 * we need to compute n-th jobs and for each job we need to perform binary search
 */

// @lc code=start
public partial class Solution
{
    private int BSJobScheduling(int[][] jobs, int endtime, int l)
    {
        // Binary Search to find the smallest index such that its start time >= endtime
        // Since the mid point round to left, so we always push left to right, until left == right
        // there is case that we cannot find any valid job, so we need to include jobs.Length as edge and return it
        int left = l, right = jobs.Length;
        while (left < right)
        {
            int mid = (left + right) / 2;
            if (jobs[mid][0] >= endtime)
                right = mid;
            else
                left = mid + 1;
        }
        return left;
    }

    private int DFSJobScheduling(int[][] jobs, int i, int[] dp)
    {
        // if i >= jobs.Length, we are out of range, return 0
        if (i >= jobs.Length)
            return 0;

        // if i-th job are computed, we return the cache
        if (dp[i] != 0)
            return dp[i];

        // find the smallest index such that its start time >= i-th job endtime
        int j = BSJobScheduling(jobs, jobs[i][1], i + 1);
        // Case 1: we dont do the job, so we will have DFS(i + 1) profit
        // Case 2: we do the i-th job, so we will have profit[i] + DFS(j) profit
        dp[i] = Math.Max(DFSJobScheduling(jobs, i + 1, dp), jobs[i][2] + DFSJobScheduling(jobs, j, dp));
        return dp[i];
    }

    public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
    {
        // assign to new int[][] and sort it, in order to perform binary search
        int[][] jobs = new int[profit.Length][];
        for (int i = 0; i < profit.Length; i++)
        {
            jobs[i] = new int[3] { startTime[i], endTime[i], profit[i] };
        }

        Array.Sort(jobs, (x, y) => x[0].CompareTo(y[0]));
        int[] dp = new int[jobs.Length];

        // DFS(0), return max profit with/without 0-th job 
        return DFSJobScheduling(jobs, 0, dp);
    }
}
// @lc code=end


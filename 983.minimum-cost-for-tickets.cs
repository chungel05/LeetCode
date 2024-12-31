/*
 * @lc app=leetcode id=983 lang=csharp
 *
 * [983] Minimum Cost For Tickets
 *
 * https://leetcode.com/problems/minimum-cost-for-tickets/description/
 *
 * algorithms
 * Medium (65.24%)
 * Likes:    8237
 * Dislikes: 162
 * Total Accepted:    357.9K
 * Total Submissions: 540.4K
 * Testcase Example:  '[1,4,6,7,8,20]\n[2,7,15]'
 *
 * You have planned some train traveling one year in advance. The days of the
 * year in which you will travel are given as an integer array days. Each day
 * is an integer from 1 to 365.
 * 
 * Train tickets are sold in three different ways:
 * 
 * 
 * a 1-day pass is sold for costs[0] dollars,
 * a 7-day pass is sold for costs[1] dollars, and
 * a 30-day pass is sold for costs[2] dollars.
 * 
 * 
 * The passes allow that many days of consecutive travel.
 * 
 * 
 * For example, if we get a 7-day pass on day 2, then we can travel for 7 days:
 * 2, 3, 4, 5, 6, 7, and 8.
 * 
 * 
 * Return the minimum number of dollars you need to travel every day in the
 * given list of days.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: days = [1,4,6,7,8,20], costs = [2,7,15]
 * Output: 11
 * Explanation: For example, here is one way to buy passes that lets you travel
 * your travel plan:
 * On day 1, you bought a 1-day pass for costs[0] = $2, which covered day 1.
 * On day 3, you bought a 7-day pass for costs[1] = $7, which covered days 3,
 * 4, ..., 9.
 * On day 20, you bought a 1-day pass for costs[0] = $2, which covered day 20.
 * In total, you spent $11 and covered all the days of your travel.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: days = [1,2,3,4,5,6,7,8,9,10,30,31], costs = [2,7,15]
 * Output: 17
 * Explanation: For example, here is one way to buy passes that lets you travel
 * your travel plan:
 * On day 1, you bought a 30-day pass for costs[2] = $15 which covered days 1,
 * 2, ..., 30.
 * On day 31, you bought a 1-day pass for costs[0] = $2 which covered day 31.
 * In total, you spent $17 and covered all the days of your travel.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= days.length <= 365
 * 1 <= days[i] <= 365
 * days is in strictly increasing order.
 * costs.length == 3
 * 1 <= costs[i] <= 1000
 * 
 * 
 */
/*
 * DFS Top-down Approach
 * Time: O(n), Space: O(n)
 */

// @lc code=start
public partial class Solution
{
    /* private int BSMincostTickets(int[] days, int left, int day)
    {
        int right = days.Length;
        while (left < right)
        {
            int mid = (left + right) / 2;
            if (days[mid] > day)
                right = mid;
            else
            {
                left = mid + 1;
            }
        }
        return left;
    } */

    private int DFSMincostTickets(int[] days, int[] costs, int i, int[] dp)
    {
        if (i >= days.Length)
            return 0;

        if (dp[i] != -1)
            return dp[i];

        // 1 day
        int one = costs[0] + DFSMincostTickets(days, costs, i + 1, dp);
        // 7 days
        int j = i + 1;
        while (j < days.Length && days[j] <= days[i] + 6)
            j++;
        int seven = costs[1] + DFSMincostTickets(days, costs, j, dp);
        // 30 days
        while (j < days.Length && days[j] <= days[i] + 29)
            j++;
        int thirty = costs[2] + DFSMincostTickets(days, costs, j, dp);

        dp[i] = Math.Min(Math.Min(one, seven), thirty);
        return dp[i];
    }

    public int MincostTickets(int[] days, int[] costs)
    {
        int[] dp = new int[days.Length];
        Array.Fill(dp, -1);
        return DFSMincostTickets(days, costs, 0, dp);
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=3169 lang=csharp
 *
 * [3169] Count Days Without Meetings
 *
 * https://leetcode.com/problems/count-days-without-meetings/description/
 *
 * algorithms
 * Medium (33.99%)
 * Likes:    259
 * Dislikes: 7
 * Total Accepted:    50.1K
 * Total Submissions: 136.3K
 * Testcase Example:  '10\n[[5,7],[1,3],[9,10]]'
 *
 * You are given a positive integer days representing the total number of days
 * an employee is available for work (starting from day 1). You are also given
 * a 2D array meetings of size n where, meetings[i] = [start_i, end_i]
 * represents the starting and ending days of meeting i (inclusive).
 * 
 * Return the count of days when the employee is available for work but no
 * meetings are scheduled.
 * 
 * Note: The meetings may overlap.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: days = 10, meetings = [[5,7],[1,3],[9,10]]
 * 
 * Output: 2
 * 
 * Explanation:
 * 
 * There is no meeting scheduled on the 4^th and 8^th days.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: days = 5, meetings = [[2,4],[1,3]]
 * 
 * Output: 1
 * 
 * Explanation:
 * 
 * There is no meeting scheduled on the 5^th day.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: days = 6, meetings = [[1,6]]
 * 
 * Output: 0
 * 
 * Explanation:
 * 
 * Meetings are scheduled for all working days.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= days <= 10^9
 * 1 <= meetings.length <= 10^5
 * meetings[i].length == 2
 * 1 <= meetings[i][0] <= meetings[i][1] <= days
 * 
 * 
 */
/*
 * Sorting Approach
 * Time: O(n log n), Space: O(n)
 */

// @lc code=start
public partial class Solution
{
    public int CountDays(int days, int[][] meetings)
    {
        // running number from [1, days]
        int day = 1;
        // available days
        int ans = 0;
        // Sorting according to start day of meeting
        Array.Sort(meetings, (a, b) =>
        {
            return a[0].CompareTo(b[0]);
        });

        // loop through all meeting
        for (int i = 0; i < meetings.Length; i++)
        {
            int start = meetings[i][0];
            int end = meetings[i][1];
            // start > day means available slot between day and start
            if (start > day)
                ans += start - day;

            // take the max because current meeting may within prev meeting [p_start, c_start, ..., c_end, p_end]
            day = Math.Max(day, end + 1);
        }

        // remaining available slot
        ans += days - day + 1;
        return ans;
    }
}
// @lc code=end


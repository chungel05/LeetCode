/*
 * @lc app=leetcode id=435 lang=csharp
 *
 * [435] Non-overlapping Intervals
 *
 * https://leetcode.com/problems/non-overlapping-intervals/description/
 *
 * algorithms
 * Medium (54.18%)
 * Likes:    8312
 * Dislikes: 226
 * Total Accepted:    661.3K
 * Total Submissions: 1.2M
 * Testcase Example:  '[[1,2],[2,3],[3,4],[1,3]]'
 *
 * Given an array of intervals intervals where intervals[i] = [starti, endi],
 * return the minimum number of intervals you need to remove to make the rest
 * of the intervals non-overlapping.
 * 
 * Note that intervals which only touch at a point are non-overlapping. For
 * example, [1, 2] and [2, 3] are non-overlapping.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: intervals = [[1,2],[2,3],[3,4],[1,3]]
 * Output: 1
 * Explanation: [1,3] can be removed and the rest of the intervals are
 * non-overlapping.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: intervals = [[1,2],[1,2],[1,2]]
 * Output: 2
 * Explanation: You need to remove two [1,2] to make the rest of the intervals
 * non-overlapping.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: intervals = [[1,2],[2,3]]
 * Output: 0
 * Explanation: You don't need to remove any of the intervals since they're
 * already non-overlapping.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= intervals.length <= 10^5
 * intervals[i].length == 2
 * -5 * 10^4 <= starti < endi <= 5 * 10^4
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int EraseOverlapIntervals(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
        int prevEnd = intervals[0][1];
        int res = 0;

        for (int i = 1; i < intervals.Length; i++)
        {
            if (prevEnd > intervals[i][0])
            {
                res++;
                prevEnd = Math.Min(prevEnd, intervals[i][1]);
            }
            else
                prevEnd = intervals[i][1];
        }
        return res;
    }
}
// @lc code=end


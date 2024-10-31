/*
 * @lc app=leetcode id=57 lang=csharp
 *
 * [57] Insert Interval
 *
 * https://leetcode.com/problems/insert-interval/description/
 *
 * algorithms
 * Medium (42.27%)
 * Likes:    10621
 * Dislikes: 835
 * Total Accepted:    1.3M
 * Total Submissions: 3M
 * Testcase Example:  '[[1,3],[6,9]]\n[2,5]'
 *
 * You are given an array of non-overlapping intervals intervals where
 * intervals[i] = [starti, endi] represent the start and the end of the i^th
 * interval and intervals is sorted in ascending order by starti. You are also
 * given an interval newInterval = [start, end] that represents the start and
 * end of another interval.
 * 
 * Insert newInterval into intervals such that intervals is still sorted in
 * ascending order by starti and intervals still does not have any overlapping
 * intervals (merge overlapping intervals if necessary).
 * 
 * Return intervals after the insertion.
 * 
 * Note that you don't need to modify intervals in-place. You can make a new
 * array and return it.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: intervals = [[1,3],[6,9]], newInterval = [2,5]
 * Output: [[1,5],[6,9]]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
 * Output: [[1,2],[3,10],[12,16]]
 * Explanation: Because the new interval [4,8] overlaps with
 * [3,5],[6,7],[8,10].
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 0 <= intervals.length <= 10^4
 * intervals[i].length == 2
 * 0 <= starti <= endi <= 10^5
 * intervals is sorted by starti in ascending order.
 * newInterval.length == 2
 * 0 <= start <= end <= 10^5
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        List<int[]> res = new List<int[]>();
        for (int i = 0; i < intervals.Length; i++)
        {
            // no overlap and newInterval before all intervals, add remaining intervals to the list
            if (newInterval[1] < intervals[i][0])
            {
                res.Add(newInterval);
                res.AddRange(intervals.Skip(i).ToArray());
                return res.ToArray();
            }
            // no overlap but newInterval after interval i, add interval i to list
            else if (newInterval[0] > intervals[i][1])
                res.Add(intervals[i]);
            // merge interval i and newInterval
            else
            {
                newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
                newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
            }
        }
        res.Add(newInterval);
        return res.ToArray();
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=56 lang=csharp
 *
 * [56] Merge Intervals
 *
 * https://leetcode.com/problems/merge-intervals/description/
 *
 * algorithms
 * Medium (48.05%)
 * Likes:    22567
 * Dislikes: 809
 * Total Accepted:    2.7M
 * Total Submissions: 5.7M
 * Testcase Example:  '[[1,3],[2,6],[8,10],[15,18]]'
 *
 * Given an array of intervals where intervals[i] = [starti, endi], merge all
 * overlapping intervals, and return an array of the non-overlapping intervals
 * that cover all the intervals in the input.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
 * Output: [[1,6],[8,10],[15,18]]
 * Explanation: Since intervals [1,3] and [2,6] overlap, merge them into
 * [1,6].
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: intervals = [[1,4],[4,5]]
 * Output: [[1,5]]
 * Explanation: Intervals [1,4] and [4,5] are considered overlapping.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= intervals.length <= 10^4
 * intervals[i].length == 2
 * 0 <= starti <= endi <= 10^4
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int[][] Merge(int[][] intervals)
    {
        List<int[]> res = new List<int[]>();
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
        res.Add(intervals[0]);

        for (int i = 1; i < intervals.Length; i++)
        {
            int lastEnd = res[res.Count - 1][1];
            if (lastEnd >= intervals[i][0])
                res[res.Count - 1][1] = Math.Max(res[res.Count - 1][1], intervals[i][1]);
            else
                res.Add(intervals[i]);
        }
        return res.ToArray();
    }
}
// @lc code=end


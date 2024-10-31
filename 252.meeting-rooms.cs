/*
 * @lc app=leetcode id=252 lang=csharp
 *
 * [252] Meeting Rooms
 */

// @lc code=start
public partial class Solution
{
    public bool MeetingRooms(List<Interval> intervals)
    {
        intervals.Sort((a, b) => a.start.CompareTo(b.start));

        for (int i = 1; i < intervals.Count; i++)
        {
            Interval first = intervals[i - 1];
            Interval second = intervals[i];
            if (second.start < first.end)
                return false;
        }
        return true;
    }
}
// @lc code=end

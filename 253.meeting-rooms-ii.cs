/*
 * @lc app=leetcode id=253 lang=csharp
 *
 * [253] Meeting Rooms II
 */

// @lc code=start
public partial class Solution
{
    public int MinMeetingRooms(List<Interval> intervals)
    {
        if (intervals.Count == 0 || intervals == null)
            return 0;

        int res = 0;
        int[] start = new int[intervals.Count], end = new int[intervals.Count];

        for (int i = 0; i < intervals.Count; i++)
        {
            start[i] = intervals[i].start;
            end[i] = intervals[i].end;
        }

        Array.Sort(start);
        Array.Sort(end);

        // take the first end time (smallest), and loop the start time
        // if the start time is not larger than end time, than every time slot is overlap
        // if we found the end time is smaller than start time, then means that one of the time slot is done
        // then we get the new end time by moving e pointer and compare the next start time (* not current start time)
        for (int s = 0, e = 0; s < start.Length; s++)
        {
            if (start[s] < end[e])
                res++;
            else
                e++;
        }
        return res;
    }
}
// @lc code=end

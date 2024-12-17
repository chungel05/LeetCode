/*
 * @lc app=leetcode id=729 lang=csharp
 *
 * [729] My Calendar I
 *
 * https://leetcode.com/problems/my-calendar-i/description/
 *
 * algorithms
 * Medium (58.38%)
 * Likes:    4670
 * Dislikes: 128
 * Total Accepted:    407.1K
 * Total Submissions: 697.6K
 * Testcase Example:  '["MyCalendar","book","book","book"]\n[[],[10,20],[15,25],[20,30]]'
 *
 * You are implementing a program to use as your calendar. We can add a new
 * event if adding the event will not cause a double booking.
 * 
 * A double booking happens when two events have some non-empty intersection
 * (i.e., some moment is common to both events.).
 * 
 * The event can be represented as a pair of integers startTime and endTime
 * that represents a booking on the half-open interval [startTime, endTime),
 * the range of real numbers x such that startTime <= x < endTime.
 * 
 * Implement the MyCalendar class:
 * 
 * 
 * MyCalendar() Initializes the calendar object.
 * boolean book(int startTime, int endTime) Returns true if the event can be
 * added to the calendar successfully without causing a double booking.
 * Otherwise, return false and do not add the event to the calendar.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input
 * ["MyCalendar", "book", "book", "book"]
 * [[], [10, 20], [15, 25], [20, 30]]
 * Output
 * [null, true, false, true]
 * 
 * Explanation
 * MyCalendar myCalendar = new MyCalendar();
 * myCalendar.book(10, 20); // return True
 * myCalendar.book(15, 25); // return False, It can not be booked because time
 * 15 is already booked by another event.
 * myCalendar.book(20, 30); // return True, The event can be booked, as the
 * first event takes every time less than 20, but not including 20.
 * 
 * 
 * Constraints:
 * 
 * 
 * 0 <= start < end <= 10^9
 * At most 1000 calls will be made to book.
 * 
 * 
 */

// @lc code=start
public class MyCalendarTree
{
    private MyCalendarTree left;
    private MyCalendarTree right;
    private int start;
    private int end;

    public MyCalendarTree(int startTime, int endTime)
    {
        this.left = null;
        this.right = null;
        this.start = startTime;
        this.end = endTime;
    }

    public bool Insert(int startTime, int endTime)
    {
        MyCalendarTree curr = this;

        while (true)
        {
            if (startTime >= curr.end)
            {
                if (curr.right == null)
                {
                    curr.right = new MyCalendarTree(startTime, endTime);
                    return true;
                }
                curr = curr.right;
            }
            else if (endTime <= curr.start)
            {
                if (curr.left == null)
                {
                    curr.left = new MyCalendarTree(startTime, endTime);
                    return true;
                }
                curr = curr.left;
            }
            else
                return false;
        }
    }
}

public class MyCalendar
{
    private MyCalendarTree root;
    public MyCalendar()
    {
        root = null;
    }

    public bool Book(int startTime, int endTime)
    {
        if (root == null)
        {
            root = new MyCalendarTree(startTime, endTime);
            return true;
        }

        return root.Insert(startTime, endTime);
    }
}

/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * bool param_1 = obj.Book(startTime,endTime);
 */
// @lc code=end


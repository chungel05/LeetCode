/*
 * @lc app=leetcode id=295 lang=csharp
 *
 * [295] Find Median from Data Stream
 *
 * https://leetcode.com/problems/find-median-from-data-stream/description/
 *
 * algorithms
 * Hard (52.41%)
 * Likes:    12115
 * Dislikes: 252
 * Total Accepted:    872.8K
 * Total Submissions: 1.7M
 * Testcase Example:  '["MedianFinder","addNum","addNum","findMedian","addNum","findMedian"]\n' +
  '[[],[1],[2],[],[3],[]]'
 *
 * The median is the middle value in an ordered integer list. If the size of
 * the list is even, there is no middle value, and the median is the mean of
 * the two middle values.
 * 
 * 
 * For example, for arr = [2,3,4], the median is 3.
 * For example, for arr = [2,3], the median is (2 + 3) / 2 = 2.5.
 * 
 * 
 * Implement the MedianFinder class:
 * 
 * 
 * MedianFinder() initializes the MedianFinder object.
 * void addNum(int num) adds the integer num from the data stream to the data
 * structure.
 * double findMedian() returns the median of all elements so far. Answers
 * within 10^-5 of the actual answer will be accepted.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input
 * ["MedianFinder", "addNum", "addNum", "findMedian", "addNum", "findMedian"]
 * [[], [1], [2], [], [3], []]
 * Output
 * [null, null, null, 1.5, null, 2.0]
 * 
 * Explanation
 * MedianFinder medianFinder = new MedianFinder();
 * medianFinder.addNum(1);    // arr = [1]
 * medianFinder.addNum(2);    // arr = [1, 2]
 * medianFinder.findMedian(); // return 1.5 (i.e., (1 + 2) / 2)
 * medianFinder.addNum(3);    // arr[1, 2, 3]
 * medianFinder.findMedian(); // return 2.0
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * -10^5 <= num <= 10^5
 * There will be at least one element in the data structure before calling
 * findMedian.
 * At most 5 * 10^4 calls will be made to addNum and findMedian.
 * 
 * 
 * 
 * Follow up:
 * 
 * 
 * If all integer numbers from the stream are in the range [0, 100], how would
 * you optimize your solution?
 * If 99% of all integer numbers from the stream are in the range [0, 100], how
 * would you optimize your solution?
 * 
 * 
 */

// @lc code=start
public class MedianFinder
{
    private double median;
    private PriorityQueue<int, int> max; // contains nums > median
    private PriorityQueue<int, int> min; // contains nums <= median

    public MedianFinder()
    {
        median = 0.0;
        max = new PriorityQueue<int, int>();
        min = new PriorityQueue<int, int>();
    }

    public void AddNum(int num)
    {
        if (num > median)
            max.Enqueue(num, num);
        else
            min.Enqueue(num, -num);

        if (max.Count == min.Count)
            median = ((double)(max.Peek() + min.Peek()) / 2);
        else if (min.Count - max.Count == 1)
            median = min.Peek();
        else if (max.Count > min.Count)
        {
            int n = max.Dequeue();
            median = n;
            min.Enqueue(n, -n);
        }
        else
        {
            int n = min.Dequeue();
            median = ((double)(n + min.Peek()) / 2);
            max.Enqueue(n, n);
        }

    }

    public double FindMedian()
    {
        return median;
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */
// @lc code=end


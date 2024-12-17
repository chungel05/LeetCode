/*
 * @lc app=leetcode id=480 lang=csharp
 *
 * [480] Sliding Window Median
 *
 * https://leetcode.com/problems/sliding-window-median/description/
 *
 * algorithms
 * Hard (38.82%)
 * Likes:    3291
 * Dislikes: 211
 * Total Accepted:    165.8K
 * Total Submissions: 427.8K
 * Testcase Example:  '[1,3,-1,-3,5,3,6,7]\n3'
 *
 * The median is the middle value in an ordered integer list. If the size of
 * the list is even, there is no middle value. So the median is the mean of the
 * two middle values.
 * 
 * 
 * For examples, if arr = [2,3,4], the median is 3.
 * For examples, if arr = [1,2,3,4], the median is (2 + 3) / 2 = 2.5.
 * 
 * 
 * You are given an integer array nums and an integer k. There is a sliding
 * window of size k which is moving from the very left of the array to the very
 * right. You can only see the k numbers in the window. Each time the sliding
 * window moves right by one position.
 * 
 * Return the median array for each window in the original array. Answers
 * within 10^-5 of the actual value will be accepted.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [1,3,-1,-3,5,3,6,7], k = 3
 * Output: [1.00000,-1.00000,-1.00000,3.00000,5.00000,6.00000]
 * Explanation: 
 * Window position                Median
 * ---------------                -----
 * [1  3  -1] -3  5  3  6  7        1
 * ⁠1 [3  -1  -3] 5  3  6  7       -1
 * ⁠1  3 [-1  -3  5] 3  6  7       -1
 * ⁠1  3  -1 [-3  5  3] 6  7        3
 * ⁠1  3  -1  -3 [5  3  6] 7        5
 * ⁠1  3  -1  -3  5 [3  6  7]       6
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [1,2,3,4,2,3,1,4,2], k = 3
 * Output: [2.00000,3.00000,3.00000,3.00000,2.00000,3.00000,2.00000]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= k <= nums.length <= 10^5
 * -2^31 <= nums[i] <= 2^31 - 1
 * 
 * 
 */

// @lc code=start
using Microsoft.VisualBasic;

public class MedianSlidingWindow
{
    // create minHeap to store the num > median
    private PriorityQueue<int, int> minHeap;
    // create maxHeap to store the num <= median
    private PriorityQueue<int, int> maxHeap;
    // create dict to store the num needed to remove
    private Dictionary<int, int> removalCount;
    // some element will be mark as delayed remove, because it is not the top of maxHeap/minHeap and it is not within the sliding window
    // so maxHeapCount/minHeapCount will show the actual num in maxHeap/minHeap for the rebalancing
    private int maxHeapCount;
    private int minHeapCount;
    private int windowSize;

    public MedianSlidingWindow(int size)
    {
        this.minHeap = new PriorityQueue<int, int>();
        this.maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
        this.removalCount = new Dictionary<int, int>();
        this.windowSize = size;
        this.maxHeapCount = 0;
        this.minHeapCount = 0;
    }

    public double Median()
    {
        // if window size is even, we return maxHeap + minHeap / 2
        // else return the median in maxHeap
        return (this.windowSize & 1) == 0 ? ((double)maxHeap.Peek() + minHeap.Peek()) / 2.0 : maxHeap.Peek();
    }

    public void AddNum(int n)
    {
        // we add maxHeap first
        // if n <= maxHeap, then it is smaller half side
        if (maxHeap.Count == 0 || n <= maxHeap.Peek())
        {
            maxHeap.Enqueue(n, n);
            maxHeapCount++;
        }
        else
        {
            minHeap.Enqueue(n, n);
            minHeapCount++;
        }
        Rebalance();
    }

    public void RemoveNum(int n)
    {
        // Mark as needed to remove
        if (!removalCount.ContainsKey(n))
            removalCount[n] = 0;
        removalCount[n]++;

        if (n <= maxHeap.Peek())
        {
            // mark the count for rebalancing
            maxHeapCount--;
            // Remove if it is the top of maxHeap
            if (n == maxHeap.Peek())
                Prune(maxHeap);
        }
        else
        {
            // mark the count for rebalancing
            minHeapCount--;
            // Remove if it is the top of minHeap
            if (n == minHeap.Peek())
                Prune(minHeap);
        }
        Rebalance();
    }

    private void Prune(PriorityQueue<int, int> heap)
    {
        // Remove until the dict does not contain the top of heap
        while (heap.Count > 0 && removalCount.ContainsKey(heap.Peek()))
        {
            int n = heap.Peek();
            removalCount[n]--;

            // if all duplicates are removed, we can remove in dict as well
            if (removalCount[n] == 0)
                removalCount.Remove(n);

            heap.Dequeue();
        }
    }

    private void Rebalance()
    {
        // Valid case:
        // 1. maxHeapCount == minHeapCount
        // 2. maxHeapCount == minHeapCount + 1
        // so we need to rebalance for other cases
        if (maxHeapCount > minHeapCount + 1)
        {
            int n = maxHeap.Dequeue();
            minHeap.Enqueue(n, n);
            maxHeapCount--;
            minHeapCount++;
            Prune(maxHeap);
        }
        else if (minHeapCount > maxHeapCount)
        {
            int n = minHeap.Dequeue();
            maxHeap.Enqueue(n, n);
            maxHeapCount++;
            minHeapCount--;
            Prune(minHeap);
        }
    }
}

public partial class Solution
{
    public double[] MedianSlidingWindow(int[] nums, int k)
    {
        MedianSlidingWindow MSW = new MedianSlidingWindow(k);
        double[] median = new double[nums.Length - k + 1];

        for (int i = 0; i < k; i++)
        {
            MSW.AddNum(nums[i]);
        }
        median[0] = MSW.Median();

        for (int i = k; i < nums.Length; i++)
        {
            MSW.AddNum(nums[i]);
            MSW.RemoveNum(nums[i - k]);
            median[i - k + 1] = MSW.Median();
        }
        return median;
    }
}
// @lc code=end


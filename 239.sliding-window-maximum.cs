/*
 * @lc app=leetcode id=239 lang=csharp
 *
 * [239] Sliding Window Maximum
 *
 * https://leetcode.com/problems/sliding-window-maximum/description/
 *
 * algorithms
 * Hard (46.88%)
 * Likes:    18513
 * Dislikes: 706
 * Total Accepted:    1.1M
 * Total Submissions: 2.4M
 * Testcase Example:  '[1,3,-1,-3,5,3,6,7]\n3'
 *
 * You are given an array of integers nums, there is a sliding window of size k
 * which is moving from the very left of the array to the very right. You can
 * only see the k numbers in the window. Each time the sliding window moves
 * right by one position.
 * 
 * Return the max sliding window.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [1,3,-1,-3,5,3,6,7], k = 3
 * Output: [3,3,5,5,6,7]
 * Explanation: 
 * Window position                Max
 * ---------------               -----
 * [1  3  -1] -3  5  3  6  7       3
 * ⁠1 [3  -1  -3] 5  3  6  7       3
 * ⁠1  3 [-1  -3  5] 3  6  7       5
 * ⁠1  3  -1 [-3  5  3] 6  7       5
 * ⁠1  3  -1  -3 [5  3  6] 7       6
 * ⁠1  3  -1  -3  5 [3  6  7]      7
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [1], k = 1
 * Output: [1]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 10^5
 * -10^4 <= nums[i] <= 10^4
 * 1 <= k <= nums.length
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        int left = 0;
        int[] maxInt = new int[nums.Length - k + 1];
        PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>();

        for (int right = 0; right < nums.Length; right++)
        {
            while (maxHeap.Count > 0 && maxHeap.Peek() < right - k + 1)
                maxHeap.Dequeue();

            maxHeap.Enqueue(right, -nums[right]);
            if (right - left + 1 == k)
            {
                maxInt[left] = nums[maxHeap.Peek()];
                left++;
            }
        }
        return maxInt;
    }
}
// @lc code=end


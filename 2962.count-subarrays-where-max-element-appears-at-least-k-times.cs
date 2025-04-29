/*
 * @lc app=leetcode id=2962 lang=csharp
 *
 * [2962] Count Subarrays Where Max Element Appears at Least K Times
 *
 * https://leetcode.com/problems/count-subarrays-where-max-element-appears-at-least-k-times/description/
 *
 * algorithms
 * Medium (58.92%)
 * Likes:    1293
 * Dislikes: 64
 * Total Accepted:    143.3K
 * Total Submissions: 244.6K
 * Testcase Example:  '[1,3,2,3,3]\n2'
 *
 * You are given an integer array nums and a positive integer k.
 * 
 * Return the number of subarrays where the maximum element of nums appears at
 * least k times in that subarray.
 * 
 * A subarray is a contiguous sequence of elements within an array.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [1,3,2,3,3], k = 2
 * Output: 6
 * Explanation: The subarrays that contain the element 3 at least 2 times are:
 * [1,3,2,3], [1,3,2,3,3], [3,2,3], [3,2,3,3], [2,3,3] and [3,3].
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [1,4,2,1], k = 3
 * Output: 0
 * Explanation: No subarray contains the element 4 at least 3 times.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 10^5
 * 1 <= nums[i] <= 10^6
 * 1 <= k <= 10^5
 * 
 * 
 */
/*
 * Two Pointer Approach - Sliding Window
 * Time: O(n), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    public long CountSubarrays(int[] nums, int k)
    {
        int max = 0;
        int count = 0;
        long ans = 0;
        int l = 0;

        // find the max element
        for (int i = 0; i < nums.Length; i++)
            max = Math.Max(max, nums[i]);

        // Find the valid window
        for (int r = 0; r < nums.Length; r++)
        {
            // count the occurrences of max element
            if (nums[r] == max)
                count++;

            // shrink the window until it is invalid, to find the min size of window
            // l is the possible no. of subarrays
            // i.e. [1,3,2,3], k = 2
            // l at index 2, the window will be invalid, which means possible no. of subarrays = 2
            while (count == k)
            {
                if (nums[l] == max)
                    count--;
                l++;
            }

            // For any valid window, the possible subarray end at r is l
            ans += l;
        }
        return ans;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=2401 lang=csharp
 *
 * [2401] Longest Nice Subarray
 *
 * https://leetcode.com/problems/longest-nice-subarray/description/
 *
 * algorithms
 * Medium (51.80%)
 * Likes:    1466
 * Dislikes: 37
 * Total Accepted:    54.3K
 * Total Submissions: 96.1K
 * Testcase Example:  '[1,3,8,48,10]'
 *
 * You are given an array nums consisting of positive integers.
 * 
 * We call a subarray of nums nice if the bitwise AND of every pair of elements
 * that are in different positions in the subarray is equal to 0.
 * 
 * Return the length of the longest nice subarray.
 * 
 * A subarray is a contiguous part of an array.
 * 
 * Note that subarrays of length 1 are always considered nice.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [1,3,8,48,10]
 * Output: 3
 * Explanation: The longest nice subarray is [3,8,48]. This subarray satisfies
 * the conditions:
 * - 3 AND 8 = 0.
 * - 3 AND 48 = 0.
 * - 8 AND 48 = 0.
 * It can be proven that no longer nice subarray can be obtained, so we return
 * 3.
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [3,1,5,11,13]
 * Output: 1
 * Explanation: The length of the longest nice subarray is 1. Any subarray of
 * length 1 can be chosen.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 10^5
 * 1 <= nums[i] <= 10^9
 * 
 * 
 */
/*
 * Two Pointer - Sliding Window with Bit Manipulation
 * Time: O(n), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    public int LongestNiceSubarray(int[] nums)
    {
        int ans = 0;
        int curr = 0;
        int left = 0;
        // loop from [0, n - 1]
        for (int right = 0; right < nums.Length; right++)
        {
            // if running num & nums[right] == 0, it means that it is nice no matter which combination
            // because their bit are set in different position
            if ((curr & nums[right]) == 0)
                // update ans
                ans = Math.Max(ans, right - left + 1);
            else
            {
                // if nums[right] cannot form nice seq, shrink the window
                // until it can form nice seq (maybe it needs to unset all the bits and restart at nums[right])
                // since the window is smaller, so no need to update ans
                while ((curr & nums[right]) != 0)
                    // unset the bits of nums[left]
                    curr ^= nums[left++];
            }
            // update running num
            curr |= nums[right];
        }
        return ans;
    }
}
// @lc code=end


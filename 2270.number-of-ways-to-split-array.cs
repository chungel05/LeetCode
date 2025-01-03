/*
 * @lc app=leetcode id=2270 lang=csharp
 *
 * [2270] Number of Ways to Split Array
 *
 * https://leetcode.com/problems/number-of-ways-to-split-array/description/
 *
 * algorithms
 * Medium (48.31%)
 * Likes:    681
 * Dislikes: 65
 * Total Accepted:    71.2K
 * Total Submissions: 136.9K
 * Testcase Example:  '[10,4,-8,7]'
 *
 * You are given a 0-indexed integer array nums of length n.
 * 
 * nums contains a valid split at index i if the following are true:
 * 
 * 
 * The sum of the first i + 1 elements is greater than or equal to the sum of
 * the last n - i - 1 elements.
 * There is at least one element to the right of i. That is, 0 <= i < n - 1.
 * 
 * 
 * Return the number of valid splits in nums.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [10,4,-8,7]
 * Output: 2
 * Explanation: 
 * There are three ways of splitting nums into two non-empty parts:
 * - Split nums at index 0. Then, the first part is [10], and its sum is 10.
 * The second part is [4,-8,7], and its sum is 3. Since 10 >= 3, i = 0 is a
 * valid split.
 * - Split nums at index 1. Then, the first part is [10,4], and its sum is 14.
 * The second part is [-8,7], and its sum is -1. Since 14 >= -1, i = 1 is a
 * valid split.
 * - Split nums at index 2. Then, the first part is [10,4,-8], and its sum is
 * 6. The second part is [7], and its sum is 7. Since 6 < 7, i = 2 is not a
 * valid split.
 * Thus, the number of valid splits in nums is 2.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [2,3,1,0]
 * Output: 2
 * Explanation: 
 * There are two valid splits in nums:
 * - Split nums at index 1. Then, the first part is [2,3], and its sum is 5.
 * The second part is [1,0], and its sum is 1. Since 5 >= 1, i = 1 is a valid
 * split. 
 * - Split nums at index 2. Then, the first part is [2,3,1], and its sum is 6.
 * The second part is [0], and its sum is 0. Since 6 >= 0, i = 2 is a valid
 * split.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 2 <= nums.length <= 10^5
 * -10^5 <= nums[i] <= 10^5
 * 
 * 
 */
/*
 * Time: O(n), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    // Prefix sum approach with O(n) Space
    /* public int WaysToSplitArray(int[] nums)
    {
        // since each num is [-10^5, 10^5], so it may overflow of int
        // we use long instead
        long[] prefixSum = new long[nums.Length + 1];
        for (int i = 0; i < nums.Length; i++)
        {
            // pre-calc the prefix sum of each num
            prefixSum[i + 1] = prefixSum[i] + nums[i];
        }

        int ans = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            // sum of [0, i] = prefixSum[i + 1] - prefixSum[0] = prefixSum[i + 1]
            long left = prefixSum[i + 1];
            // sum of [i + 1, n] = prefixSum[n] - prefixSum[i + 1]
            long right = prefixSum[nums.Length] - prefixSum[i + 1];
            if (left >= right)
                ans++;
        }
        return ans;
    } */

    // Prefix sum approach with O(1) Space optimized
    public int WaysToSplitArray(int[] nums)
    {
        long totalSum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            totalSum += nums[i];
        }

        int ans = 0;
        long runningSum = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            // left = [0, i] = prefixSum[i + 1] = running sum
            runningSum += nums[i];
            // right = [i + 1, n] = prefixSum[n] - prefixSum[i + 1] = total sum - running sum
            if (runningSum >= totalSum - runningSum)
                ans++;
        }
        return ans;
    }
}
// @lc code=end


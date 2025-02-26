/*
 * @lc app=leetcode id=1749 lang=csharp
 *
 * [1749] Maximum Absolute Sum of Any Subarray
 *
 * https://leetcode.com/problems/maximum-absolute-sum-of-any-subarray/description/
 *
 * algorithms
 * Medium (60.48%)
 * Likes:    1317
 * Dislikes: 22
 * Total Accepted:    46.4K
 * Total Submissions: 75.8K
 * Testcase Example:  '[1,-3,2,3,-4]'
 *
 * You are given an integer array nums. The absolute sum of a subarray [numsl,
 * numsl+1, ..., numsr-1, numsr] is abs(numsl + numsl+1 + ... + numsr-1 +
 * numsr).
 * 
 * Return the maximum absolute sum of any (possibly empty) subarray of nums.
 * 
 * Note that abs(x) is defined as follows:
 * 
 * 
 * If x is a negative integer, then abs(x) = -x.
 * If x is a non-negative integer, then abs(x) = x.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [1,-3,2,3,-4]
 * Output: 5
 * Explanation: The subarray [2,3] has absolute sum = abs(2+3) = abs(5) = 5.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [2,-5,1,-4,3,-2]
 * Output: 8
 * Explanation: The subarray [-5,1,-4] has absolute sum = abs(-5+1-4) = abs(-8)
 * = 8.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 10^5
 * -10^4 <= nums[i] <= 10^4
 * 
 * 
 */
/*
 * Prefix Sum Approach
 * Time: O(n), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    // Prefix Sum Approach
    // Time: O(n), Space: O(1)
    /* public int MaxAbsoluteSum(int[] nums)
    {
        int max = 0, min = 0, sum = 0, ans = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            // calc the prefix sum
            sum += nums[i];
            // if prefix sum >= 0, which is positive value
            if (sum >= 0)
            {
                // the possible max absolute sum will be (+)sum - (-)(min negative prefix sum)
                ans = Math.Max(ans, sum - min);
                // update max positive prefix sum
                max = Math.Max(max, sum);
            }
            // if prefix sum < 0, which is negative value
            else
            {
                // the possible max absolute sum will be (+)(max positive prefix sum) - (-)sum
                ans = Math.Max(ans, max - sum);
                // update min negative prefix sum
                min = Math.Min(min, sum);
            }
        }
        return ans;
    } */

    // Simplified Prefix Sum Approach
    // Time: O(n), Space: O(1)
    public int MaxAbsoluteSum(int[] nums)
    {
        int max = 0;
        int min = 0;
        int ans = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            // to maintain a max positive subarray, if prefix sum is < 0, reset to 0
            max = Math.Max(0, nums[i] + max);
            // to maintain a min negative subarray, if prefix sum is > 0, reset to 0
            min = Math.Min(0, nums[i] + min);
            // at current index i, find out the max absolute value
            ans = Math.Max(ans, Math.Max(max, -min));
        }
        return ans;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=53 lang=csharp
 *
 * [53] Maximum Subarray
 *
 * https://leetcode.com/problems/maximum-subarray/description/
 *
 * algorithms
 * Medium (51.27%)
 * Likes:    34611
 * Dislikes: 1468
 * Total Accepted:    4.4M
 * Total Submissions: 8.5M
 * Testcase Example:  '[-2,1,-3,4,-1,2,1,-5,4]'
 *
 * Given an integer array nums, find the subarray with the largest sum, and
 * return its sum.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
 * Output: 6
 * Explanation: The subarray [4,-1,2,1] has the largest sum 6.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [1]
 * Output: 1
 * Explanation: The subarray [1] has the largest sum 1.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: nums = [5,4,-1,7,8]
 * Output: 23
 * Explanation: The subarray [5,4,-1,7,8] has the largest sum 23.
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
 * 
 * Follow up: If you have figured out the O(n) solution, try coding another
 * solution using the divide and conquer approach, which is more subtle.
 * 
 */

// @lc code=start
public partial class Solution
{
    public int MaxSubArray(int[] nums)
    {
        int maxVal = nums[0];
        int sum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (sum < 0)
                sum = 0;

            sum += nums[i];
            maxVal = Math.Max(maxVal, sum);

        }
        return maxVal;
    }
}
// @lc code=end


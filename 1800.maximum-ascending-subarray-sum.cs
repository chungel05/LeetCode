/*
 * @lc app=leetcode id=1800 lang=csharp
 *
 * [1800] Maximum Ascending Subarray Sum
 *
 * https://leetcode.com/problems/maximum-ascending-subarray-sum/description/
 *
 * algorithms
 * Easy (61.99%)
 * Likes:    807
 * Dislikes: 28
 * Total Accepted:    80.1K
 * Total Submissions: 125.7K
 * Testcase Example:  '[10,20,30,5,10,50]'
 *
 * Given an array of positive integers nums, return the maximum possible sum of
 * an ascending subarray in nums.
 * 
 * A subarray is defined as a contiguous sequence of numbers in an array.
 * 
 * A subarray [numsl, numsl+1, ..., numsr-1, numsr] is ascending if for all i
 * where l <= i < r, numsi  < numsi+1. Note that a subarray of size 1 is
 * ascending.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [10,20,30,5,10,50]
 * Output: 65
 * Explanation: [5,10,50] is the ascending subarray with the maximum sum of
 * 65.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [10,20,30,40,50]
 * Output: 150
 * Explanation: [10,20,30,40,50] is the ascending subarray with the maximum sum
 * of 150.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: nums = [12,17,15,13,10,11,12]
 * Output: 33
 * Explanation: [10,11,12] is the ascending subarray with the maximum sum of
 * 33.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 100
 * 1 <= nums[i] <= 100
 * 
 * 
 */
/*
 * Array Checking Approach
 * Time: O(n), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    public int MaxAscendingSum(int[] nums)
    {
        // since nums must have 1 element, so the edge case n = 1, sum = nums[0]
        int sum = nums[0], currSum = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            // if seq is not strictly increasing, reset the currSum
            if (nums[i] <= nums[i - 1])
                currSum = 0;
            // sum of Prev Sum and current nums[i]
            currSum += nums[i];
            // update the max sum
            sum = Math.Max(sum, currSum);
        }
        return sum;
    }
}
// @lc code=end


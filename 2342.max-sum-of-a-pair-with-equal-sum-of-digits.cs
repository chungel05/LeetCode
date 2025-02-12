/*
 * @lc app=leetcode id=2342 lang=csharp
 *
 * [2342] Max Sum of a Pair With Equal Sum of Digits
 *
 * https://leetcode.com/problems/max-sum-of-a-pair-with-equal-sum-of-digits/description/
 *
 * algorithms
 * Medium (55.42%)
 * Likes:    739
 * Dislikes: 23
 * Total Accepted:    56.7K
 * Total Submissions: 100.8K
 * Testcase Example:  '[18,43,36,13,7]'
 *
 * You are given a 0-indexed array nums consisting of positive integers. You
 * can choose two indices i and j, such that i != j, and the sum of digits of
 * the number nums[i] is equal to that of nums[j].
 * 
 * Return the maximum value of nums[i] + nums[j] that you can obtain over all
 * possible indices i and j that satisfy the conditions.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [18,43,36,13,7]
 * Output: 54
 * Explanation: The pairs (i, j) that satisfy the conditions are:
 * - (0, 2), both numbers have a sum of digits equal to 9, and their sum is 18
 * + 36 = 54.
 * - (1, 4), both numbers have a sum of digits equal to 7, and their sum is 43
 * + 7 = 50.
 * So the maximum sum that we can obtain is 54.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [10,12,19,14]
 * Output: -1
 * Explanation: There are no two numbers that satisfy the conditions, so we
 * return -1.
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
 * Hash Approach
 * Time: O(n), Space: O(82) 
 */

// @lc code=start
public partial class Solution
{
    // calc the sum of digits
    private int SumOfDigit(int x)
    {
        int sum = 0;
        while (x != 0)
        {
            sum += x % 10;
            x /= 10;
        }
        return sum;
    }

    public int MaximumSum(int[] nums)
    {
        // since the max value of nums[i] is 10^9, so the possible max sum of digits = SumOfDigit(10^9 - 1) = 81
        int sizeOfArray = SumOfDigit((int)Math.Pow(10, 9) - 1) + 1;
        // range of maxNum array will be [0, SumOfDigit(10^9 - 1) + 1], 0 will not use
        int[] maxNum = new int[sizeOfArray];
        int ans = -1;

        for (int i = 0; i < nums.Length; i++)
        {
            // calc the sum of digits
            int sum = SumOfDigit(nums[i]);

            // if maxNum[sum] has num
            if (maxNum[sum] != 0)
            {
                // get the possible max (nums[i] + nums[j]) to ans
                ans = Math.Max(ans, maxNum[sum] + nums[i]);
                // update the maxNum[sum], because only need to record the max nums[i]
                maxNum[sum] = Math.Max(maxNum[sum], nums[i]);
            }
            // if maxNum[sum] does not have num, update maxNum[sum] to nums[i]
            else
                maxNum[sum] = nums[i];
        }
        return ans;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=312 lang=csharp
 *
 * [312] Burst Balloons
 *
 * https://leetcode.com/problems/burst-balloons/description/
 *
 * algorithms
 * Hard (59.96%)
 * Likes:    9131
 * Dislikes: 261
 * Total Accepted:    319.1K
 * Total Submissions: 530.9K
 * Testcase Example:  '[3,1,5,8]'
 *
 * You are given n balloons, indexed from 0 to n - 1. Each balloon is painted
 * with a number on it represented by an array nums. You are asked to burst all
 * the balloons.
 * 
 * If you burst the i^th balloon, you will get nums[i - 1] * nums[i] * nums[i +
 * 1] coins. If i - 1 or i + 1 goes out of bounds of the array, then treat it
 * as if there is a balloon with a 1 painted on it.
 * 
 * Return the maximum coins you can collect by bursting the balloons wisely.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [3,1,5,8]
 * Output: 167
 * Explanation:
 * nums = [3,1,5,8] --> [3,5,8] --> [3,8] --> [8] --> []
 * coins =  3*1*5    +   3*5*8   +  1*3*8  + 1*8*1 = 167
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [1,5]
 * Output: 10
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * n == nums.length
 * 1 <= n <= 300
 * 0 <= nums[i] <= 100
 * 
 * 
 */
/*
 * Top-down approach with caching
 * Pop the left and right nums subset first
 * remaining nums[i] will calc with left and right boundarys 
 */

// @lc code=start
public partial class Solution
{
    public int DFSMaxCoins(int[] nums, int l, int r, int[,] dp)
    {
        if (l > r)
            return 0;

        if (dp[l, r] != -1)
            return dp[l, r];

        dp[l, r] = 0;
        for (int i = l; i <= r; i++)
        {
            int res = nums[l - 1] * nums[i] * nums[r + 1];
            res += DFSMaxCoins(nums, l, i - 1, dp) + DFSMaxCoins(nums, i + 1, r, dp);
            dp[l, r] = Math.Max(dp[l, r], res);
        }
        return dp[l, r];
    }

    public int MaxCoins(int[] nums)
    {
        int n = nums.Length;
        int[,] dp = new int[n + 2, n + 2];
        int[] newNums = new int[n + 2];
        newNums[0] = newNums[n + 1] = 1;
        for (int i = 0; i < n; i++)
        {
            newNums[i + 1] = nums[i];
        }

        for (int i = 0; i < n + 2; i++)
        {
            for (int j = 0; j < n + 2; j++)
                dp[i, j] = -1;
        }

        return DFSMaxCoins(newNums, 1, n, dp);
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=213 lang=csharp
 *
 * [213] House Robber II
 *
 * https://leetcode.com/problems/house-robber-ii/description/
 *
 * algorithms
 * Medium (42.62%)
 * Likes:    10050
 * Dislikes: 162
 * Total Accepted:    865.3K
 * Total Submissions: 2M
 * Testcase Example:  '[2,3,2]'
 *
 * You are a professional robber planning to rob houses along a street. Each
 * house has a certain amount of money stashed. All houses at this place are
 * arranged in a circle. That means the first house is the neighbor of the last
 * one. Meanwhile, adjacent houses have a security system connected, and it
 * will automatically contact the police if two adjacent houses were broken
 * into on the same night.
 * 
 * Given an integer array nums representing the amount of money of each house,
 * return the maximum amount of money you can rob tonight without alerting the
 * police.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [2,3,2]
 * Output: 3
 * Explanation: You cannot rob house 1 (money = 2) and then rob house 3 (money
 * = 2), because they are adjacent houses.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [1,2,3,1]
 * Output: 4
 * Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
 * Total amount you can rob = 1 + 3 = 4.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: nums = [1,2,3]
 * Output: 3
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 100
 * 0 <= nums[i] <= 1000
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int Rob2Helper(int[] nums)
    {
        int rob1 = 0, rob2 = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            int temp = Math.Max(rob1 + nums[i], rob2);
            rob1 = rob2;
            rob2 = temp;
        }
        return rob2;
    }

    public int Rob(int[] nums)
    {
        int temp = Math.Max(Rob2Helper(nums.Skip(1).ToArray()), Rob2Helper(nums.Take(nums.Length - 1).ToArray()));
        return Math.Max(temp, nums[0]);
    }
}
// @lc code=end


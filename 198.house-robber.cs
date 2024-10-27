/*
 * @lc app=leetcode id=198 lang=csharp
 *
 * [198] House Robber
 *
 * https://leetcode.com/problems/house-robber/description/
 *
 * algorithms
 * Medium (51.56%)
 * Likes:    21451
 * Dislikes: 443
 * Total Accepted:    2.5M
 * Total Submissions: 4.9M
 * Testcase Example:  '[1,2,3,1]'
 *
 * You are a professional robber planning to rob houses along a street. Each
 * house has a certain amount of money stashed, the only constraint stopping
 * you from robbing each of them is that adjacent houses have security systems
 * connected and it will automatically contact the police if two adjacent
 * houses were broken into on the same night.
 * 
 * Given an integer array nums representing the amount of money of each house,
 * return the maximum amount of money you can rob tonight without alerting the
 * police.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [1,2,3,1]
 * Output: 4
 * Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
 * Total amount you can rob = 1 + 3 = 4.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [2,7,9,3,1]
 * Output: 12
 * Explanation: Rob house 1 (money = 2), rob house 3 (money = 9) and rob house
 * 5 (money = 1).
 * Total amount you can rob = 2 + 9 + 1 = 12.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 100
 * 0 <= nums[i] <= 400
 * 
 * 
 */
/*
 * Rob1 is the max amount of prev house not adjacent to current house
 * Rob2 is the max amount of prev house adjacent to current house
 * For example: [3] is current house, [2] is adjacent house, [1] is prev not adjacent house
 * For current house, we have 2 choices:
 * 1: Rob1 [1] + current house [3]
 * 2: Rob2 [2] only becase it is adjacent house
 */

// @lc code=start
public partial class Solution
{
    public int Rob(int[] nums)
    {
        int rob1 = 0, rob2 = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            int temp = rob2;
            rob2 = Math.Max(rob2, rob1 + nums[i]);
            rob1 = temp;
        }
        return rob2;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=494 lang=csharp
 *
 * [494] Target Sum
 *
 * https://leetcode.com/problems/target-sum/description/
 *
 * algorithms
 * Medium (47.62%)
 * Likes:    11091
 * Dislikes: 370
 * Total Accepted:    682.9K
 * Total Submissions: 1.4M
 * Testcase Example:  '[1,1,1,1,1]\n3'
 *
 * You are given an integer array nums and an integer target.
 * 
 * You want to build an expression out of nums by adding one of the symbols '+'
 * and '-' before each integer in nums and then concatenate all the
 * integers.
 * 
 * 
 * For example, if nums = [2, 1], you can add a '+' before 2 and a '-' before 1
 * and concatenate them to build the expression "+2-1".
 * 
 * 
 * Return the number of different expressions that you can build, which
 * evaluates to target.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [1,1,1,1,1], target = 3
 * Output: 5
 * Explanation: There are 5 ways to assign symbols to make the sum of nums be
 * target 3.
 * -1 + 1 + 1 + 1 + 1 = 3
 * +1 - 1 + 1 + 1 + 1 = 3
 * +1 + 1 - 1 + 1 + 1 = 3
 * +1 + 1 + 1 - 1 + 1 = 3
 * +1 + 1 + 1 + 1 - 1 = 3
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [1], target = 1
 * Output: 1
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 20
 * 0 <= nums[i] <= 1000
 * 0 <= sum(nums[i]) <= 1000
 * -1000 <= target <= 1000
 * 
 * 
 */
/*
 * Top-down approach with caching
 */

// @lc code=start
public partial class Solution
{
    private int DFSFindTargetSumWays(int[] nums, int i, int currSum, int target, int[][] dp, int totalSum)
    {
        if (i == nums.Length)
            return currSum == target ? 1 : 0;

        if (dp[i][currSum + totalSum] != int.MinValue)
            return dp[i][currSum + totalSum];

        dp[i][currSum + totalSum] = DFSFindTargetSumWays(nums, i + 1, currSum + nums[i], target, dp, totalSum)
                                    + DFSFindTargetSumWays(nums, i + 1, currSum - nums[i], target, dp, totalSum);
        return dp[i][currSum + totalSum];
    }

    public int FindTargetSumWays(int[] nums, int target)
    {
        int[][] dp = new int[nums.Length][];
        int totalSum = nums.Sum();
        for (int i = 0; i < nums.Length; i++)
        {
            dp[i] = new int[2 * totalSum + 1];
            for (int j = 0; j < 2 * totalSum + 1; j++)
                dp[i][j] = int.MinValue;
        }

        return DFSFindTargetSumWays(nums, 0, 0, target, dp, totalSum);
    }
}
// @lc code=end


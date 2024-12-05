/*
 * @lc app=leetcode id=377 lang=csharp
 *
 * [377] Combination Sum IV
 *
 * https://leetcode.com/problems/combination-sum-iv/description/
 *
 * algorithms
 * Medium (54.32%)
 * Likes:    7471
 * Dislikes: 672
 * Total Accepted:    518.2K
 * Total Submissions: 952.4K
 * Testcase Example:  '[1,2,3]\n4'
 *
 * Given an array of distinct integers nums and a target integer target, return
 * the number of possible combinations that add up to target.
 * 
 * The test cases are generated so that the answer can fit in a 32-bit
 * integer.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [1,2,3], target = 4
 * Output: 7
 * Explanation:
 * The possible combination ways are:
 * (1, 1, 1, 1)
 * (1, 1, 2)
 * (1, 2, 1)
 * (1, 3)
 * (2, 1, 1)
 * (2, 2)
 * (3, 1)
 * Note that different sequences are counted as different combinations.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [9], target = 3
 * Output: 0
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 200
 * 1 <= nums[i] <= 1000
 * All the elements of nums are unique.
 * 1 <= target <= 1000
 * 
 * 
 * 
 * Follow up: What if negative numbers are allowed in the given array? How does
 * it change the problem? What limitation we need to add to the question to
 * allow negative numbers?
 * 
 */
/*
 * DFS with Caching approach
 * Time: O(n * t), Space: O(n * t)
 * we need to compute and store results for each value from 1 to target
 */

// @lc code=start
public partial class Solution
{
    private int DFSCombinationSum4(int[] nums, int target, int currSum, int[] dp)
    {
        if (currSum > target)
            return 0;

        if (currSum == target)
            return 1;

        if (dp[currSum] != -1)
            return dp[currSum];

        int count = 0;
        for (int j = 0; j < nums.Length; j++)
        {
            count += DFSCombinationSum4(nums, target, currSum + nums[j], dp);
        }
        dp[currSum] = count;
        return dp[currSum];
    }

    public int CombinationSum4(int[] nums, int target)
    {
        int[] dp = new int[target];
        Array.Fill(dp, -1);
        return DFSCombinationSum4(nums, target, 0, dp);
    }
}
// @lc code=end


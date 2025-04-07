/*
 * @lc app=leetcode id=416 lang=csharp
 *
 * [416] Partition Equal Subset Sum
 *
 * https://leetcode.com/problems/partition-equal-subset-sum/description/
 *
 * algorithms
 * Medium (46.79%)
 * Likes:    12491
 * Dislikes: 255
 * Total Accepted:    958.4K
 * Total Submissions: 2M
 * Testcase Example:  '[1,5,11,5]'
 *
 * Given an integer array nums, return true if you can partition the array into
 * two subsets such that the sum of the elements in both subsets is equal or
 * false otherwise.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [1,5,11,5]
 * Output: true
 * Explanation: The array can be partitioned as [1, 5, 5] and [11].
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [1,2,3,5]
 * Output: false
 * Explanation: The array cannot be partitioned into equal sum subsets.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 200
 * 1 <= nums[i] <= 100
 * 
 * 
 */
/*
 * DP Approach
 * Time: O(n * sum), Space: O(n * sum)
 * Start from right hand side, create all the possible sum that can sum to target (total sum / 2)
 */

// @lc code=start
public partial class Solution
{
    // Top-down Approach
    /* private bool DFSCanPartition(int[] nums, int i, int sum, int[][] dp)
    {
        if (sum == 0)
            return true;

        if (i >= nums.Length || i < 0 || sum < 0)
            return false;

        if (dp[i][sum] != -1)
            return dp[i][sum] == 1 ? true : false;

        if (DFSCanPartition(nums, i + 1, sum - nums[i], dp) || DFSCanPartition(nums, i + 1, sum, dp))
        {
            dp[i][sum] = 1;
            return true;
        }
        else
        {
            dp[i][sum] = 0;
            return false;
        }
    }

    public bool CanPartition(int[] nums)
    {
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
            sum += nums[i];

        if (sum % 2 != 0)
            return false;

        sum = sum / 2;
        int[][] dp = new int[nums.Length][];
        for (int i = 0; i < nums.Length; i++)
        {
            dp[i] = new int[sum + 1];
            Array.Fill(dp[i], -1);
        }
        return DFSCanPartition(nums, 0, sum, dp);
    } */

    // Bottom-up Approach
    /* public bool CanPartition(int[] nums)
    {
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
            sum += nums[i];

        // if sum is not divisible by 2 => cannot partition into 2 parts
        if (sum % 2 != 0)
            return false;

        sum = sum / 2;
        bool[][] dp = new bool[nums.Length + 1][];
        for (int i = 0; i <= nums.Length; i++)
            dp[i] = new bool[sum + 1];

        // Bottom-up
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            for (int j = sum; j >= 0; j--)
            {
                // if sum == num[i], then it is possible to get sum
                if (j - nums[i] == 0)
                    dp[i][j] = true;
                // if nums[i] > j, inherit from dp[i + 1][sum]
                else if (j - nums[i] < 0)
                    dp[i][j] = dp[i + 1][j];
                // else, check dp[i + 1][sum - num] || dp[i + 1][sum]
                else
                    dp[i][j] = dp[i + 1][j - nums[i]] || dp[i + 1][j];
            }
        }
        return dp[0][sum];
    } */

    // Space Optimized Bottom-up Approach
    public bool CanPartition(int[] nums)
    {
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
            sum += nums[i];

        // if sum is not divisible by 2 => cannot partition into 2 parts
        if (sum % 2 != 0)
            return false;

        sum = sum / 2;
        bool[] dp = new bool[sum + 1];
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = sum; j >= nums[i]; j--)
            {
                dp[j] = dp[j - nums[i]] || dp[j];
                if (j == nums[i])
                    dp[j] = true;
            }
        }
        return dp[sum];
    }
}
// @lc code=end


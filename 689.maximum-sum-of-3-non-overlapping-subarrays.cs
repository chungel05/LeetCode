/*
 * @lc app=leetcode id=689 lang=csharp
 *
 * [689] Maximum Sum of 3 Non-Overlapping Subarrays
 *
 * https://leetcode.com/problems/maximum-sum-of-3-non-overlapping-subarrays/description/
 *
 * algorithms
 * Hard (50.39%)
 * Likes:    2011
 * Dislikes: 121
 * Total Accepted:    82.8K
 * Total Submissions: 162.2K
 * Testcase Example:  '[1,2,1,2,6,7,5,1]\n2'
 *
 * Given an integer array nums and an integer k, find three non-overlapping
 * subarrays of length k with maximum sum and return them.
 * 
 * Return the result as a list of indices representing the starting position of
 * each interval (0-indexed). If there are multiple answers, return the
 * lexicographically smallest one.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [1,2,1,2,6,7,5,1], k = 2
 * Output: [0,3,5]
 * Explanation: Subarrays [1, 2], [2, 6], [7, 5] correspond to the starting
 * indices [0, 3, 5].
 * We could have also taken [2, 1], but an answer of [1, 3, 5] would be
 * lexicographically larger.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [1,2,1,2,1,2,1,2,1], k = 2
 * Output: [0,2,4]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 2 * 10^4
 * 1 <= nums[i] < 2^16
 * 1 <= k <= floor(nums.length / 3)
 * 
 * 
 */
/*
 * Bottom up approach
 * Time: O(n * l), where l = Length of nums, n = no. of non-overlapping subarrays
 * Space: O(n * l)
 */

// @lc code=start
public partial class Solution
{
    public int[] MaxSumOfThreeSubarrays(int[] nums, int k)
    {
        int n = 3;
        int[][] dp = new int[n + 1][];
        int[][] index = new int[n + 1][];

        for (int i = 0; i <= n; i++)
        {
            dp[i] = new int[nums.Length + 1];
            index[i] = new int[nums.Length + 1];
        }

        // prefix sum
        int[] prefixSum = new int[nums.Length + 1];
        for (int i = 0; i < nums.Length; i++)
        {
            prefixSum[i + 1] = prefixSum[i] + nums[i];
        }

        for (int i = 1; i <= n; i++)
        {
            for (int j = k - 1; j < nums.Length; j++)
            {
                // first col is base case = 0, so we shift 1 col, which is j + 1
                // include case, sum[i...i + k] = sum[j - k + 1...j + 1]
                // prefixSum[i + k] - prefixSum[i] = prefixSum[j + 1] - prefixSum[j - k + 1]
                int tmpMax = prefixSum[j + 1] - prefixSum[j - k + 1] + dp[i - 1][j - k + 1];
                if (tmpMax > dp[i][j])
                {
                    // include case, max value = tmpMax
                    // index = i = j - k + 1
                    dp[i][j + 1] = tmpMax;
                    index[i][j + 1] = j - k + 1;
                }
                else
                {
                    // exclude case, max value = last dp[i][j]
                    // index = last index[i][j]
                    dp[i][j + 1] = dp[i][j];
                    index[i][j + 1] = index[i][j];
                }
            }
        }

        int[] res = new int[n];
        int prev = nums.Length;
        for (int i = n; i > 0; i--)
        {
            res[i - 1] = index[i][prev];
            prev = res[i - 1];
        }

        return res;
    }
}
// @lc code=end


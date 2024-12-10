/*
 * @lc app=leetcode id=368 lang=csharp
 *
 * [368] Largest Divisible Subset
 *
 * https://leetcode.com/problems/largest-divisible-subset/description/
 *
 * algorithms
 * Medium (45.67%)
 * Likes:    6049
 * Dislikes: 285
 * Total Accepted:    323.7K
 * Total Submissions: 707.8K
 * Testcase Example:  '[1,2,3]'
 *
 * Given a set of distinct positive integers nums, return the largest subset
 * answer such that every pair (answer[i], answer[j]) of elements in this
 * subset satisfies:
 * 
 * 
 * answer[i] % answer[j] == 0, or
 * answer[j] % answer[i] == 0
 * 
 * 
 * If there are multiple solutions, return any of them.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [1,2,3]
 * Output: [1,2]
 * Explanation: [1,3] is also accepted.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [1,2,4,8]
 * Output: [1,2,4,8]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 1000
 * 1 <= nums[i] <= 2 * 10^9
 * All the integers in nums are unique.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public IList<int> LargestDivisibleSubset(int[] nums)
    {
        // dp holds the max nums of subset that nums[i] can divisble
        int[] dp = new int[nums.Length];
        // prev holds the prev index that nums[i] can divisible by it
        int[] prev = new int[nums.Length];
        int index = 0;

        Array.Fill(dp, 1);
        Array.Fill(prev, -1);

        // sort the nums to accending order, we only need to check nums[i] % nums[j] which nums[i] > nums[j]
        Array.Sort(nums);
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                // if it is divisible, and the subset is larger than before, update it
                if (nums[i] % nums[j] == 0 && dp[i] < dp[j] + 1)
                {
                    // update count
                    dp[i] = dp[j] + 1;
                    // update prev index
                    prev[i] = j;
                }
            }

            // if dp[i]: count of subset i is larger than dp[index]: max dp, update the max index
            if (dp[index] < dp[i])
                index = i;
        }

        // construct the result list
        List<int> res = new List<int>();
        while (index != -1)
        {
            res.Add(nums[index]);
            index = prev[index];
        }
        return res;
    }
}
// @lc code=end


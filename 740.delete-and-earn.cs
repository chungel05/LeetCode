/*
 * @lc app=leetcode id=740 lang=csharp
 *
 * [740] Delete and Earn
 *
 * https://leetcode.com/problems/delete-and-earn/description/
 *
 * algorithms
 * Medium (56.53%)
 * Likes:    7643
 * Dislikes: 388
 * Total Accepted:    373.1K
 * Total Submissions: 659.8K
 * Testcase Example:  '[3,4,2]'
 *
 * You are given an integer array nums. You want to maximize the number of
 * points you get by performing the following operation any number of
 * times:
 * 
 * 
 * Pick any nums[i] and delete it to earn nums[i] points. Afterwards, you must
 * delete every element equal to nums[i] - 1 and every element equal to nums[i]
 * + 1.
 * 
 * 
 * Return the maximum number of points you can earn by applying the above
 * operation some number of times.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [3,4,2]
 * Output: 6
 * Explanation: You can perform the following operations:
 * - Delete 4 to earn 4 points. Consequently, 3 is also deleted. nums = [2].
 * - Delete 2 to earn 2 points. nums = [].
 * You earn a total of 6 points.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [2,2,3,3,3,4]
 * Output: 9
 * Explanation: You can perform the following operations:
 * - Delete a 3 to earn 3 points. All 2's and 4's are also deleted. nums =
 * [3,3].
 * - Delete a 3 again to earn 3 points. nums = [3].
 * - Delete a 3 once more to earn 3 points. nums = [].
 * You earn a total of 9 points.
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 2 * 10^4
 * 1 <= nums[i] <= 10^4
 * 
 * 
 */
/*
 * Similar to 198 House Robber
 * Time: O(n), Space: O(10001) = O(1)
 */

// @lc code=start
public partial class Solution
{
    public int DeleteAndEarn(int[] nums)
    {
        // create 1D DP to store the sum of point in corresponding nums[i]
        // i.e. [3 3 3]: dp[3] = total 9 points 
        int[] dp = new int[10001];
        for (int i = 0; i < nums.Length; i++)
        {
            dp[nums[i]] += nums[i];
        }

        // We cannot get the point adj. to us
        int p1 = 0, p2 = 0;
        for (int i = 1; i <= 10000; i++)
        {
            int tmp = p2;
            // There 2 cases:
            // 1: Not select points of current num = points of i - 1 = p2
            // 2: Select points of current num = points of i - 2 + points of i = p1 + dp[i]
            p2 = Math.Max(p2, p1 + dp[i]);
            p1 = tmp;
        }
        return p2;
    }
}
// @lc code=end


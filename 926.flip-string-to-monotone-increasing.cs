/*
 * @lc app=leetcode id=926 lang=csharp
 *
 * [926] Flip String to Monotone Increasing
 *
 * https://leetcode.com/problems/flip-string-to-monotone-increasing/description/
 *
 * algorithms
 * Medium (61.54%)
 * Likes:    4466
 * Dislikes: 179
 * Total Accepted:    197.9K
 * Total Submissions: 321.7K
 * Testcase Example:  '"00110"'
 *
 * A binary string is monotone increasing if it consists of some number of 0's
 * (possibly none), followed by some number of 1's (also possibly none).
 * 
 * You are given a binary string s. You can flip s[i] changing it from 0 to 1
 * or from 1 to 0.
 * 
 * Return the minimum number of flips to make s monotone increasing.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "00110"
 * Output: 1
 * Explanation: We flip the last digit to get 00111.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "010110"
 * Output: 2
 * Explanation: We flip to get 011111, or alternatively 000111.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: s = "00011000"
 * Output: 2
 * Explanation: We flip to get 00000000.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s.length <= 10^5
 * s[i] is either '0' or '1'.
 * 
 * 
 */
/*
 * Time: O(n), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    public int MinFlipsMonoIncr(string s)
    {
        int dp = 0;
        int countOne = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '0')
            {
                // if s[i] == '0', there are 2 cases
                // 1. flip the '0' to 1, so the result is dp + 1 where dp is the result of prev '0'
                // 2. flip all '1' to 0 and keep s[i] is 0, so the result is countOne
                dp = Math.Min(dp + 1, countOne);
            }
            else
                countOne++;
        }
        return dp;
    }
}
// @lc code=end


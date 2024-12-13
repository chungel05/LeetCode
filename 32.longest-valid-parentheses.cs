/*
 * @lc app=leetcode id=32 lang=csharp
 *
 * [32] Longest Valid Parentheses
 *
 * https://leetcode.com/problems/longest-valid-parentheses/description/
 *
 * algorithms
 * Hard (34.87%)
 * Likes:    12565
 * Dislikes: 421
 * Total Accepted:    823.8K
 * Total Submissions: 2.3M
 * Testcase Example:  '"(()"'
 *
 * Given a string containing just the characters '(' and ')', return the length
 * of the longest valid (well-formed) parentheses substring.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "(()"
 * Output: 2
 * Explanation: The longest valid parentheses substring is "()".
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = ")()())"
 * Output: 4
 * Explanation: The longest valid parentheses substring is "()()".
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: s = ""
 * Output: 0
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 0 <= s.length <= 3 * 10^4
 * s[i] is '(', or ')'.
 * 
 * 
 */
/*
 * Bottom up approach
 * Time: O(n), Space: O(n)
 */

// @lc code=start
public partial class Solution
{
    public int LongestValidParentheses(string s)
    {
        // create 1D DP dp[i] to store the longest valid len end at s[i - 1]
        // i.e. "()(", dp[2] = 2 which is end at s[1]
        int[] dp = new int[s.Length + 1];
        // to trace the longest valid len 
        int res = 0;

        // since we need to check s[i - 1] and s[i - 2], so we start at i = 2
        // until the end dp[s.Length]
        for (int i = 2; i <= s.Length; i++)
        {
            // if prev i - 1 char is ')'
            if (s[i - 1] == ')')
            {
                // we check the i - 2 char
                // if it is '(', so it is valid pair
                // dp[i] = 2 + dp[i - 2] where dp[i - 2] store the result end at s[i - 3]
                if (s[i - 2] == '(')
                    dp[i] = dp[i - 2] + 2;
                else
                {
                    // if it is ')'
                    // dp[i - 1] store the result end at s[i - 2]
                    // so j = (i - 1) - total len of valid pair (dp[i - 1]) - 1
                    // the s[j] char maybe pair with s[i - 1]
                    int j = (i - 1) - dp[i - 1] - 1;

                    // if s[j] pair with s[i - 1]
                    // the longest valid len end at s[i - 1]:
                    // result end at s[i - 2] + valid pair at s[i - 1] & s[j] + result end at s[j - 1]
                    // = dp[i - 1] + 2 + dp[j]
                    if (j >= 0 && s[j] == '(')
                        dp[i] = dp[i - 1] + dp[j] + 2;
                }
                res = Math.Max(res, dp[i]);
            }
        }
        return res;
    }
}
// @lc code=end


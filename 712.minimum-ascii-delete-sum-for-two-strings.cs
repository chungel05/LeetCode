/*
 * @lc app=leetcode id=712 lang=csharp
 *
 * [712] Minimum ASCII Delete Sum for Two Strings
 *
 * https://leetcode.com/problems/minimum-ascii-delete-sum-for-two-strings/description/
 *
 * algorithms
 * Medium (65.29%)
 * Likes:    4027
 * Dislikes: 107
 * Total Accepted:    154.8K
 * Total Submissions: 236.7K
 * Testcase Example:  '"sea"\n"eat"'
 *
 * Given two strings s1 and s2, return the lowest ASCII sum of deleted
 * characters to make two strings equal.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s1 = "sea", s2 = "eat"
 * Output: 231
 * Explanation: Deleting "s" from "sea" adds the ASCII value of "s" (115) to
 * the sum.
 * Deleting "t" from "eat" adds 116 to the sum.
 * At the end, both strings are equal, and 115 + 116 = 231 is the minimum sum
 * possible to achieve this.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s1 = "delete", s2 = "leet"
 * Output: 403
 * Explanation: Deleting "dee" from "delete" to turn the string into "let",
 * adds 100[d] + 101[e] + 101[e] to the sum.
 * Deleting "e" from "leet" adds 101[e] to the sum.
 * At the end, both strings are equal to "let", and the answer is
 * 100+101+101+101 = 403.
 * If instead we turned both strings into "lee" or "eet", we would get answers
 * of 433 or 417, which are higher.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s1.length, s2.length <= 1000
 * s1 and s2 consist of lowercase English letters.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int MinimumDeleteSum(string s1, string s2)
    {
        int m = s1.Length, n = s2.Length;
        // create 2D array to hold the min sum of removal
        int[][] dp = new int[m + 1][];

        for (int i = 0; i <= m; i++)
            dp[i] = new int[n + 1];

        // initialized base case, for s1, from end to start, we remove char stack up to 0
        // i.e. sea, dp[m - 1][n] = a, dp[1][n] = ea, dp[0][n] = sea
        for (int i = m - 1; i >= 0; i--)
            dp[i][n] = dp[i + 1][n] + (int)s1[i];

        // initialized base case, for s2, from end to start, we remove char stack up to 0
        // i.e. eat, dp[m][n - 1] = t, dp[m][1] = at, dp[m][0] = eat
        for (int i = n - 1; i >= 0; i--)
            dp[m][i] = dp[m][i + 1] + (int)s2[i];

        // loop from bottom right to top left
        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                // if s1[i] == s2[j], we get the value from dp[i + 1][j + 1] because we dont need to remove any chars
                if (s1[i] == s2[j])
                    dp[i][j] = dp[i + 1][j + 1];
                // else, we compare down side(i + 1, j) + s1 char and right side(i, j + 1) + s2 char
                // get the min removal sum
                else
                    dp[i][j] = Math.Min(dp[i + 1][j] + (int)s1[i], dp[i][j + 1] + (int)s2[j]);
            }
        }
        return dp[0][0];
    }
}
// @lc code=end


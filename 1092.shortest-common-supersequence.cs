/*
 * @lc app=leetcode id=1092 lang=csharp
 *
 * [1092] Shortest Common Supersequence 
 *
 * https://leetcode.com/problems/shortest-common-supersequence/description/
 *
 * algorithms
 * Hard (59.61%)
 * Likes:    5151
 * Dislikes: 76
 * Total Accepted:    161K
 * Total Submissions: 268.8K
 * Testcase Example:  '"abac"\n"cab"'
 *
 * Given two strings str1 and str2, return the shortest string that has both
 * str1 and str2 as subsequences. If there are multiple valid strings, return
 * any of them.
 * 
 * A string s is a subsequence of string t if deleting some number of
 * characters from t (possibly 0) results in the string s.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: str1 = "abac", str2 = "cab"
 * Output: "cabac"
 * Explanation: 
 * str1 = "abac" is a subsequence of "cabac" because we can delete the first
 * "c".
 * str2 = "cab" is a subsequence of "cabac" because we can delete the last
 * "ac".
 * The answer provided is the shortest such string that satisfies these
 * properties.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: str1 = "aaaaaaaa", str2 = "aaaaaaaa"
 * Output: "aaaaaaaa"
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= str1.length, str2.length <= 1000
 * str1 and str2 consist of lowercase English letters.
 * 
 * 
 */
/*
 * DP Bottom-up Approach
 * Time: O(n * m), Space: O(n * m)
 */

// @lc code=start
using System.Text;

public partial class Solution
{
    public string ShortestCommonSupersequence(string str1, string str2)
    {
        int n = str1.Length, m = str2.Length;
        int[][] dp = new int[n + 1][];
        for (int i = 0; i <= n; i++)
        {
            dp[i] = new int[m + 1];
            dp[i][m] = 0;
        }
        Array.Fill(dp[n], 0);

        // calc the max length of longest common seq
        for (int i = n - 1; i >= 0; i--)
        {
            for (int j = m - 1; j >= 0; j--)
            {
                if (str1[i] == str2[j])
                    dp[i][j] = dp[i + 1][j + 1] + 1;
                else
                    dp[i][j] = Math.Max(dp[i][j + 1], dp[i + 1][j]);
            }
        }

        // as the DP logic start from [n - 1, m - 1] to [0, 0]
        // and it get the max from dp[i + 1][j] or dp[i][j + 1]
        // so backtrack from [0, 0], move to [n - 1, m - 1]
        // move to the max value of dp[i + 1][j] or dp[i][j + 1] and get corresponding char
        StringBuilder sb = new StringBuilder();
        int idx1 = 0, idx2 = 0;
        while (idx1 < n || idx2 < m)
        {
            // if idx1 at the end of str1, just need to add str2[idx2]
            if (idx1 == n)
                sb.Append(str2[idx2++]);
            // if idx2 at the end of str2, just need to add str1[idx1]
            else if (idx2 == m)
                sb.Append(str1[idx1++]);
            // if str1 == str2, move to [idx1 + 1, idx2 + 1]
            else if (str1[idx1] == str2[idx2])
            {
                sb.Append(str1[idx1++]);
                idx2++;
            }
            // if str1 != str2 and dp[idx1 + 1][idx2] is larger, pick str1[idx1] and move to [idx1 + 1, idx2]
            else if (dp[idx1 + 1][idx2] > dp[idx1][idx2 + 1])
                sb.Append(str1[idx1++]);
            // if str1 != str2 and dp[idx1][idx2 + 1] is larger, pick str2[idx2] and move to [idx1, idx2 + 1]
            else
                sb.Append(str2[idx2++]);
        }

        return sb.ToString();
    }
}
// @lc code=end


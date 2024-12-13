/*
 * @lc app=leetcode id=44 lang=csharp
 *
 * [44] Wildcard Matching
 *
 * https://leetcode.com/problems/wildcard-matching/description/
 *
 * algorithms
 * Hard (28.71%)
 * Likes:    8460
 * Dislikes: 371
 * Total Accepted:    650.6K
 * Total Submissions: 2.2M
 * Testcase Example:  '"aa"\n"a"'
 *
 * Given an input string (s) and a pattern (p), implement wildcard pattern
 * matching with support for '?' and '*' where:
 * 
 * 
 * '?' Matches any single character.
 * '*' Matches any sequence of characters (including the empty sequence).
 * 
 * 
 * The matching should cover the entire input string (not partial).
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "aa", p = "a"
 * Output: false
 * Explanation: "a" does not match the entire string "aa".
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "aa", p = "*"
 * Output: true
 * Explanation: '*' matches any sequence.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: s = "cb", p = "?a"
 * Output: false
 * Explanation: '?' matches 'c', but the second letter is 'a', which does not
 * match 'b'.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 0 <= s.length, p.length <= 2000
 * s contains only lowercase English letters.
 * p contains only lowercase English letters, '?' or '*'.
 * 
 * 
 */
/*
 * Time: O(m * n), Space: O(m * n)
 */

// @lc code=start
public partial class Solution
{
    // DFS top-down approach with caching
    // convert to bottom-up approach
    /* private bool DFSIsMatch(string s, string p, int i, int j, int[][] dp)
    {
        if (i >= s.Length)
        {
            for (int k = j; k < p.Length; k++)
                if (p[k] != '*')
                    return false;
            return true;
        }

        if (j >= p.Length)
            return false;

        if (dp[i][j] != -1)
            return dp[i][j] == 1 ? true : false;

        dp[i][j] = 0;
        if (p[j] == '*')
        {
            if (DFSIsMatch(s, p, i + 1, j, dp) || DFSIsMatch(s, p, i, j + 1, dp) || DFSIsMatch(s, p, i + 1, j + 1, dp))
                dp[i][j] = 1;
        }
        else if (p[j] == '?')
        {
            if (DFSIsMatch(s, p, i + 1, j + 1, dp))
                dp[i][j] = 1;
        }
        else if (p[j] == s[i])
        {
            if (DFSIsMatch(s, p, i + 1, j + 1, dp))
                dp[i][j] = 1;
        }
        return dp[i][j] == 1 ? true : false;
    } */

    public bool IsMatch(string s, string p)
    {
        int m = s.Length, n = p.Length;
        // create 2D DP with [m + 1, n + 1] to store the result of checking index i at s and index j at p
        bool[][] dp = new bool[m + 1][];

        for (int i = 0; i <= m; i++)
        {
            dp[i] = new bool[n + 1];
        }

        // base case, if i >= s.Length && j >= p.Length, it is matched
        dp[m][n] = true;

        // base case, if j >= p.Length, it is not match, ignore here because we initialized array to false

        // base case, if i >= s.Length
        // depends on the char, if it is '*', it depends on dp[i][j + 1], other chars = false
        // i.e. "*a*", first '*' is false because it have 'a'; last '*' is true because no more char
        for (int j = p.Length - 1; j >= 0; j--)
        {
            if (p[j] == '*')
                dp[m][j] = dp[m][j + 1];
        }

        // loop from bottom right to top left
        for (int i = s.Length - 1; i >= 0; i--)
        {
            for (int j = p.Length - 1; j >= 0; j--)
            {
                // if it is '*', we will have 3 cases:
                // 1: move i + 1 and remain j to match '*' with other chars
                // 2: move j + 1 and remain i to ignore the '*' wildcard
                // 3: move i + 1 and j + 1 to continue
                // either one is true then dp[i][j] is true 
                if (p[j] == '*')
                    dp[i][j] = dp[i + 1][j] || dp[i][j + 1] || dp[i + 1][j + 1];
                // if it is '?', we can match to any char, so we move i + 1 and j + 1 to continue
                // if p[j] == s[i], it is matched, so we move i + 1 and j + 1 to continue
                else if (p[j] == '?' || p[j] == s[i])
                    dp[i][j] = dp[i + 1][j + 1];

                // others are not matched, we remain false in dp[i][j]
            }
        }

        return dp[0][0];
    }
}
// @lc code=end


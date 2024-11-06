/*
 * @lc app=leetcode id=10 lang=csharp
 *
 * [10] Regular Expression Matching
 *
 * https://leetcode.com/problems/regular-expression-matching/description/
 *
 * algorithms
 * Hard (28.44%)
 * Likes:    12352
 * Dislikes: 2211
 * Total Accepted:    1M
 * Total Submissions: 3.7M
 * Testcase Example:  '"aa"\n"a"'
 *
 * Given an input string s and a pattern p, implement regular expression
 * matching with support for '.' and '*' where:
 * 
 * 
 * '.' Matches any single character.​​​​
 * '*' Matches zero or more of the preceding element.
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
 * Input: s = "aa", p = "a*"
 * Output: true
 * Explanation: '*' means zero or more of the preceding element, 'a'.
 * Therefore, by repeating 'a' once, it becomes "aa".
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: s = "ab", p = ".*"
 * Output: true
 * Explanation: ".*" means "zero or more (*) of any character (.)".
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s.length <= 20
 * 1 <= p.length <= 20
 * s contains only lowercase English letters.
 * p contains only lowercase English letters, '.', and '*'.
 * It is guaranteed for each appearance of the character '*', there will be a
 * previous valid character to match.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public bool DFSIsMatch(string s, string p, int i, int j, Dictionary<(int, int), bool> dp)
    {
        if (j >= p.Length && i >= s.Length)
            return true;

        if (j >= p.Length)
            return false;

        var key = (i, j);
        if (dp.ContainsKey(key))
            return dp[key];

        dp[key] = false;
        bool match = (i < s.Length) && (s[i] == p[j] || p[j] == '.');
        if (j + 1 < p.Length && p[j + 1] == '*')
            dp[key] = DFSIsMatch(s, p, i, j + 2, dp) // not use *, so jump to j + 2
                     || match && DFSIsMatch(s, p, i + 1, j, dp); // use * with condition
        else
            dp[key] = match && DFSIsMatch(s, p, i + 1, j + 1, dp); // match and move to next char

        return dp[key];
    }

    public bool IsMatch(string s, string p)
    {
        Dictionary<(int, int), bool> dp = new Dictionary<(int, int), bool>();
        return DFSIsMatch(s, p, 0, 0, dp);
    }
}
// @lc code=end


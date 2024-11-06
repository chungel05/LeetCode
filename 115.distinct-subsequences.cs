/*
 * @lc app=leetcode id=115 lang=csharp
 *
 * [115] Distinct Subsequences
 *
 * https://leetcode.com/problems/distinct-subsequences/description/
 *
 * algorithms
 * Hard (48.46%)
 * Likes:    6773
 * Dislikes: 298
 * Total Accepted:    468.6K
 * Total Submissions: 963.3K
 * Testcase Example:  '"rabbbit"\n"rabbit"'
 *
 * Given two strings s and t, return the number of distinct subsequences of s
 * which equals t.
 * 
 * The test cases are generated so that the answer fits on a 32-bit signed
 * integer.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "rabbbit", t = "rabbit"
 * Output: 3
 * Explanation:
 * As shown below, there are 3 ways you can generate "rabbit" from s.
 * rabbbit
 * rabbbit
 * rabbbit
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "babgbag", t = "bag"
 * Output: 5
 * Explanation:
 * As shown below, there are 5 ways you can generate "bag" from s.
 * babgbag
 * babgbag
 * babgbag
 * babgbag
 * babgbag
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s.length, t.length <= 1000
 * s and t consist of English letters.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int DFSNumDistinct(string s, string t, int i, int j, Dictionary<(int, int), int> dp)
    {
        // Base case: s = "a", t = "" so always return 1, 1 match
        if (j >= t.Length)
            return 1;
        // Base case: s = "", t = "a" so always return 0, no match
        if (i >= s.Length)
            return 0;

        var key = (i, j);
        if (dp.ContainsKey(key))
            return dp[key];

        int res = 0;

        // s[i] == t[t], we can take it and move all pointer + 1
        // or we can move i + 1 and stay j to match again
        if (s[i] == t[j])
            res = DFSNumDistinct(s, t, i + 1, j, dp) + DFSNumDistinct(s, t, i + 1, j + 1, dp);
        // Not match, we only can move i + 1
        else
            res = DFSNumDistinct(s, t, i + 1, j, dp);

        dp[key] = res;
        return res;
    }

    public int NumDistinct(string s, string t)
    {
        Dictionary<(int, int), int> dp = new Dictionary<(int, int), int>();
        return DFSNumDistinct(s, t, 0, 0, dp);
    }
}
// @lc code=end


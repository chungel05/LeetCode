/*
 * @lc app=leetcode id=72 lang=csharp
 *
 * [72] Edit Distance
 *
 * https://leetcode.com/problems/edit-distance/description/
 *
 * algorithms
 * Medium (57.44%)
 * Likes:    15140
 * Dislikes: 245
 * Total Accepted:    997.2K
 * Total Submissions: 1.7M
 * Testcase Example:  '"horse"\n"ros"'
 *
 * Given two strings word1 and word2, return the minimum number of operations
 * required to convert word1 to word2.
 * 
 * You have the following three operations permitted on a word:
 * 
 * 
 * Insert a character
 * Delete a character
 * Replace a character
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: word1 = "horse", word2 = "ros"
 * Output: 3
 * Explanation: 
 * horse -> rorse (replace 'h' with 'r')
 * rorse -> rose (remove 'r')
 * rose -> ros (remove 'e')
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: word1 = "intention", word2 = "execution"
 * Output: 5
 * Explanation: 
 * intention -> inention (remove 't')
 * inention -> enention (replace 'i' with 'e')
 * enention -> exention (replace 'n' with 'x')
 * exention -> exection (replace 'n' with 'c')
 * exection -> execution (insert 'u')
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 0 <= word1.length, word2.length <= 500
 * word1 and word2 consist of lowercase English letters.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int DFSMinDistance(string w1, string w2, int i, int j, Dictionary<(int, int), int> dp)
    {
        if (i == w1.Length && j == w2.Length)
            return 0;

        if (i == w1.Length)
            return w2.Length - j;

        if (j == w2.Length)
            return w1.Length - i;

        var key = (i, j);
        if (dp.ContainsKey(key))
            return dp[key];

        int res = 0;
        if (w1[i] == w2[j])
            res = DFSMinDistance(w1, w2, i + 1, j + 1, dp);
        else
        {
            res = Math.Min(DFSMinDistance(w1, w2, i, j + 1, dp), DFSMinDistance(w1, w2, i + 1, j, dp));
            res = Math.Min(res, DFSMinDistance(w1, w2, i + 1, j + 1, dp));
            res += 1;
        }
        dp[key] = res;
        return res;
    }

    public int MinDistance(string word1, string word2)
    {
        Dictionary<(int, int), int> dp = new Dictionary<(int, int), int>();
        return DFSMinDistance(word1, word2, 0, 0, dp);
    }
}
// @lc code=end


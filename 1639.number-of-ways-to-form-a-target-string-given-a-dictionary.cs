/*
 * @lc app=leetcode id=1639 lang=csharp
 *
 * [1639] Number of Ways to Form a Target String Given a Dictionary
 *
 * https://leetcode.com/problems/number-of-ways-to-form-a-target-string-given-a-dictionary/description/
 *
 * algorithms
 * Hard (50.77%)
 * Likes:    1938
 * Dislikes: 112
 * Total Accepted:    116K
 * Total Submissions: 201.8K
 * Testcase Example:  '["acca","bbbb","caca"]\n"aba"'
 *
 * You are given a list of strings of the same length words and a string
 * target.
 * 
 * Your task is to form target using the given words under the following
 * rules:
 * 
 * 
 * target should be formed from left to right.
 * To form the i^th character (0-indexed) of target, you can choose the k^th
 * character of the j^th string in words if target[i] = words[j][k].
 * Once you use the k^th character of the j^th string of words, you can no
 * longer use the x^th character of any string in words where x <= k. In other
 * words, all characters to the left of or at index k become unusuable for
 * every string.
 * Repeat the process until you form the string target.
 * 
 * 
 * Notice that you can use multiple characters from the same string in words
 * provided the conditions above are met.
 * 
 * Return the number of ways to form target from words. Since the answer may be
 * too large, return it modulo 10^9 + 7.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: words = ["acca","bbbb","caca"], target = "aba"
 * Output: 6
 * Explanation: There are 6 ways to form target.
 * "aba" -> index 0 ("acca"), index 1 ("bbbb"), index 3 ("caca")
 * "aba" -> index 0 ("acca"), index 2 ("bbbb"), index 3 ("caca")
 * "aba" -> index 0 ("acca"), index 1 ("bbbb"), index 3 ("acca")
 * "aba" -> index 0 ("acca"), index 2 ("bbbb"), index 3 ("acca")
 * "aba" -> index 1 ("caca"), index 2 ("bbbb"), index 3 ("acca")
 * "aba" -> index 1 ("caca"), index 2 ("bbbb"), index 3 ("caca")
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: words = ["abba","baab"], target = "bab"
 * Output: 4
 * Explanation: There are 4 ways to form target.
 * "bab" -> index 0 ("baab"), index 1 ("baab"), index 2 ("abba")
 * "bab" -> index 0 ("baab"), index 1 ("baab"), index 3 ("baab")
 * "bab" -> index 0 ("baab"), index 2 ("baab"), index 3 ("baab")
 * "bab" -> index 1 ("abba"), index 2 ("baab"), index 3 ("baab")
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= words.length <= 1000
 * 1 <= words[i].length <= 1000
 * All strings in words have the same length.
 * 1 <= target.length <= 1000
 * words[i] and target contain only lowercase English letters.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    /* private int DFSNumWays(string[] words, string target, int i, int c, string currS, int[][] dp)
    {
        if (i == target.Length)
            return currS == target ? 1 : 0;

        if (dp[i][c] != -1)
            return dp[i][c];

        dp[i][c] = 0;
        for (int j = 0; j < words.Length; j++)
        {
            for (int k = c; k < words[0].Length; k++)
            {
                if (target[i] == words[j][k])
                {
                    dp[i][c] += DFSNumWays(words, target, i + 1, k + 1, currS + words[j][k], dp);
                    dp[i][c] %= 1000000007;
                }
            }
        }
        return dp[i][c];
    } */

    public int NumWays(string[] words, string target)
    {
        int wordLen = words[0].Length, targetLen = target.Length;
        int[][] dp = new int[targetLen + 1][];
        int[][] occurrence = new int[wordLen][];

        // count the occurrences by its index (position i)
        for (int i = 0; i < wordLen; i++)
        {
            occurrence[i] = new int[26];
            for (int j = 0; j < words.Length; j++)
            {
                occurrence[i][words[j][i] - 'a']++;
            }
        }

        // Initialized dp caching
        for (int i = 0; i <= targetLen; i++)
        {
            dp[i] = new int[wordLen + 1];
        }
        // base case 1: if col == wordLen, we cannot match with target, so return 0
        // base case 2: if row == targetLen, we match each char of target, so return 1
        Array.Fill(dp[targetLen], 1);

        for (int i = targetLen - 1; i >= 0; i--)
        {
            for (int j = wordLen - 1; j >= 0; j--)
            {
                // combination = (char count match in j * dp[i + 1][j + 1]) + dp[i][j + 1]
                // Skip current index, and move to next index
                long ans = dp[i][j + 1];

                // include current index
                ans += (long)dp[i + 1][j + 1] * occurrence[j][target[i] - 'a'];

                ans %= 1000000007;
                dp[i][j] = (int)ans;
            }
        }

        return dp[0][0];
    }
}
// @lc code=end


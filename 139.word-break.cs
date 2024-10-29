/*
 * @lc app=leetcode id=139 lang=csharp
 *
 * [139] Word Break
 *
 * https://leetcode.com/problems/word-break/description/
 *
 * algorithms
 * Medium (47.31%)
 * Likes:    17480
 * Dislikes: 820
 * Total Accepted:    1.8M
 * Total Submissions: 3.9M
 * Testcase Example:  '"leetcode"\n["leet","code"]'
 *
 * Given a string s and a dictionary of strings wordDict, return true if s can
 * be segmented into a space-separated sequence of one or more dictionary
 * words.
 * 
 * Note that the same word in the dictionary may be reused multiple times in
 * the segmentation.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "leetcode", wordDict = ["leet","code"]
 * Output: true
 * Explanation: Return true because "leetcode" can be segmented as "leet
 * code".
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "applepenapple", wordDict = ["apple","pen"]
 * Output: true
 * Explanation: Return true because "applepenapple" can be segmented as "apple
 * pen apple".
 * Note that you are allowed to reuse a dictionary word.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: s = "catsandog", wordDict = ["cats","dog","sand","and","cat"]
 * Output: false
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s.length <= 300
 * 1 <= wordDict.length <= 1000
 * 1 <= wordDict[i].length <= 20
 * s and wordDict[i] consist of only lowercase English letters.
 * All the strings of wordDict are unique.
 * 
 * 
 */
/*
 * Start the pointer from right hand side,
 * check each position, the dict contains the substring
 * if it is true, then combine with the remaining substring checking result which is store in dp[i]
 * we just need to find one possible case to indicate that from position i we can break all the remaining substring 
 * This DP approach is based on the bottom part result to determine the current result
 */

// @lc code=start
public partial class Solution
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        bool[] dp = new bool[s.Length + 1];
        dp[s.Length] = true;

        for (int i = s.Length - 1; i >= 0; i--)
        {
            foreach (string w in wordDict)
            {
                if (i + w.Length <= s.Length)
                {
                    if (s.Substring(i, w.Length) == w)
                        dp[i] = dp[i + w.Length];
                    if (dp[i])
                        break;
                }
            }
        }
        return dp[0];
    }
}
// @lc code=end


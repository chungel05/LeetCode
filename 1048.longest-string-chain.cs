/*
 * @lc app=leetcode id=1048 lang=csharp
 *
 * [1048] Longest String Chain
 *
 * https://leetcode.com/problems/longest-string-chain/description/
 *
 * algorithms
 * Medium (61.42%)
 * Likes:    7417
 * Dislikes: 259
 * Total Accepted:    438.9K
 * Total Submissions: 713.7K
 * Testcase Example:  '["a","b","ba","bca","bda","bdca"]'
 *
 * You are given an array of words where each word consists of lowercase
 * English letters.
 * 
 * wordA is a predecessor of wordB if and only if we can insert exactly one
 * letter anywhere in wordA without changing the order of the other characters
 * to make it equal to wordB.
 * 
 * 
 * For example, "abc" is a predecessor of "abac", while "cba" is not a
 * predecessor of "bcad".
 * 
 * 
 * A word chain is a sequence of words [word1, word2, ..., wordk] with k >= 1,
 * where word1 is a predecessor of word2, word2 is a predecessor of word3, and
 * so on. A single word is trivially a word chain with k == 1.
 * 
 * Return the length of the longest possible word chain with words chosen from
 * the given list of words.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: words = ["a","b","ba","bca","bda","bdca"]
 * Output: 4
 * Explanation: One of the longest word chains is ["a","ba","bda","bdca"].
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: words = ["xbc","pcxbcf","xb","cxbc","pcxbc"]
 * Output: 5
 * Explanation: All the words can be put in a word chain ["xb", "xbc", "cxbc",
 * "pcxbc", "pcxbcf"].
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: words = ["abcd","dbqca"]
 * Output: 1
 * Explanation: The trivial word chain ["abcd"] is one of the longest word
 * chains.
 * ["abcd","dbqca"] is not a valid word chain because the ordering of the
 * letters is changed.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= words.length <= 1000
 * 1 <= words[i].length <= 16
 * words[i] only consists of lowercase English letters.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int LongestStrChain(string[] words)
    {
        // we need to sort the word by len ascending
        Array.Sort(words, (x, y) => x.Length.CompareTo(y.Length));
        // create dictionary for easy lookup
        Dictionary<string, int> map = new Dictionary<string, int>();
        // create 1D DP to store the longest word chain at i index
        int[] dp = new int[words.Length];
        // base case, all word chain len are 1
        Array.Fill(dp, 1);

        // create dictionary lookup
        for (int i = 0; i < words.Length; i++)
        {
            map[words[i]] = i;
        }

        int res = 1;
        // loop for all words, from smaller len to largest len
        // everytime we reduce 1 char
        // and we need to lookup the DP which is predecessor of current word
        // if it is not sorted, predecessor may not calculate
        for (int i = 0; i < words.Length; i++)
        {
            // loop for every position to reduce 1 char
            for (int k = 0; k < words[i].Length; k++)
            {
                string newWord = words[i].Substring(0, k) + words[i].Substring(k + 1);
                // if we found the predecessor
                if (map.ContainsKey(newWord))
                {
                    // current dp result = max(dp[i], dp[predecessor] + 1)
                    dp[i] = Math.Max(dp[i], dp[map[newWord]] + 1);
                    // trace for the max len of word chain
                    res = Math.Max(dp[i], res);
                }
            }
        }
        return res;
    }
}
// @lc code=end


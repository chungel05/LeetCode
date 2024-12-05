/*
 * @lc app=leetcode id=472 lang=csharp
 *
 * [472] Concatenated Words
 *
 * https://leetcode.com/problems/concatenated-words/description/
 *
 * algorithms
 * Hard (49.34%)
 * Likes:    3917
 * Dislikes: 283
 * Total Accepted:    236.1K
 * Total Submissions: 478.7K
 * Testcase Example:  '["cat","cats","catsdogcats","dog","dogcatsdog","hippopotamuses","rat","ratcatdogcat"]'
 *
 * Given an array of strings words (without duplicates), return all the
 * concatenated words in the given list of words.
 * 
 * A concatenated word is defined as a string that is comprised entirely of at
 * least two shorter words (not necessarily distinct) in the given array.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: words =
 * ["cat","cats","catsdogcats","dog","dogcatsdog","hippopotamuses","rat","ratcatdogcat"]
 * Output: ["catsdogcats","dogcatsdog","ratcatdogcat"]
 * Explanation: "catsdogcats" can be concatenated by "cats", "dog" and "cats"; 
 * "dogcatsdog" can be concatenated by "dog", "cats" and "dog"; 
 * "ratcatdogcat" can be concatenated by "rat", "cat", "dog" and "cat".
 * 
 * Example 2:
 * 
 * 
 * Input: words = ["cat","dog","catdog"]
 * Output: ["catdog"]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= words.length <= 10^4
 * 1 <= words[i].length <= 30
 * words[i] consists of only lowercase English letters.
 * All the strings of words are unique.
 * 1 <= sum(words[i].length) <= 10^5
 * 
 * 
 */
/*
 * DFS Top down approach with caching
 * Time: O(n * l * l * l), Space: O(n * l) => space of dp
 * where we loop the no. of words => n
 * and for each word we loop the length => l
 * and we check the prefix and suffix => l
 * for the DFS, we have caching so we can reduce from l^2 => l

 */

// @lc code=start
public partial class Solution
{
    private bool DFSFindAllConcatenatedWordsInADict(HashSet<string> words, string currWord, Dictionary<string, bool> dp)
    {
        // Caching
        if (dp.ContainsKey(currWord))
            return dp[currWord];

        // for each char in current word, we try to split it and find whether exists in HashSet or not
        for (int i = 0; i < currWord.Length; i++)
        {
            string prefix = currWord.Substring(0, i);
            string suffix = currWord.Substring(i);
            // if prefix exists, we try to check suffix or break it again
            if (words.Contains(prefix) && (words.Contains(suffix) || DFSFindAllConcatenatedWordsInADict(words, suffix, dp)))
            {
                dp[currWord] = true;
                return true;
            }
        }
        dp[currWord] = false;
        return false;
    }

    public IList<string> FindAllConcatenatedWordsInADict(string[] words)
    {
        HashSet<string> wSet = new HashSet<string>(words);
        List<string> res = new List<string>();
        Dictionary<string, bool> dp = new Dictionary<string, bool>();

        // for each word, we try to break it and find whether it is concatenated by any 2 strings
        foreach (string w in wSet)
        {
            if (DFSFindAllConcatenatedWordsInADict(wSet, w, dp))
                res.Add(w);
        }
        return res;
    }
}
// @lc code=end


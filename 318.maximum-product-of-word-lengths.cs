/*
 * @lc app=leetcode id=318 lang=csharp
 *
 * [318] Maximum Product of Word Lengths
 *
 * https://leetcode.com/problems/maximum-product-of-word-lengths/description/
 *
 * algorithms
 * Medium (60.25%)
 * Likes:    3551
 * Dislikes: 141
 * Total Accepted:    227.3K
 * Total Submissions: 376.8K
 * Testcase Example:  '["abcw","baz","foo","bar","xtfn","abcdef"]'
 *
 * Given a string array words, return the maximum value of length(word[i]) *
 * length(word[j]) where the two words do not share common letters. If no such
 * two words exist, return 0.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: words = ["abcw","baz","foo","bar","xtfn","abcdef"]
 * Output: 16
 * Explanation: The two words can be "abcw", "xtfn".
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: words = ["a","ab","abc","d","cd","bcd","abcd"]
 * Output: 4
 * Explanation: The two words can be "ab", "cd".
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: words = ["a","aa","aaa","aaaa"]
 * Output: 0
 * Explanation: No such pair of words.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 2 <= words.length <= 1000
 * 1 <= words[i].length <= 1000
 * words[i] consists only of lowercase English letters.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int MaxProduct(string[] words)
    {
        int[] mask = new int[words.Length];

        for (int i = 0; i < words.Length; i++)
        {
            foreach (char c in words[i])
            {
                // each bit represent 1 char, zyx.....dcba, total 26 bit
                // i.e. if char c = b, it will shfit left 'b' - 'a' = 1 bit
                mask[i] |= 1 << (c - 'a');
            }
        }

        int res = 0;
        for (int i = 0; i < words.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                // if 2 strings are not share common chars, after logical & operation, it shd be 0
                if ((mask[i] & mask[j]) == 0)
                    res = Math.Max(res, words[i].Length * words[j].Length);
            }
        }
        return res;
    }
}
// @lc code=end


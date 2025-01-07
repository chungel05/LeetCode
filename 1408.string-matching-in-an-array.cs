/*
 * @lc app=leetcode id=1408 lang=csharp
 *
 * [1408] String Matching in an Array
 *
 * https://leetcode.com/problems/string-matching-in-an-array/description/
 *
 * algorithms
 * Easy (64.18%)
 * Likes:    930
 * Dislikes: 90
 * Total Accepted:    100.4K
 * Total Submissions: 156.2K
 * Testcase Example:  '["mass","as","hero","superhero"]'
 *
 * Given an array of string words, return all strings in words that is a
 * substring of another word. You can return the answer in any order.
 * 
 * A substring is a contiguous sequence of characters within a string
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: words = ["mass","as","hero","superhero"]
 * Output: ["as","hero"]
 * Explanation: "as" is substring of "mass" and "hero" is substring of
 * "superhero".
 * ["hero","as"] is also a valid answer.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: words = ["leetcode","et","code"]
 * Output: ["et","code"]
 * Explanation: "et", "code" are substring of "leetcode".
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: words = ["blue","green","bu"]
 * Output: []
 * Explanation: No string of words is substring of another string.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= words.length <= 100
 * 1 <= words[i].length <= 30
 * words[i] contains only lowercase English letters.
 * All the strings of words are unique.
 * 
 * 
 */
/*
 * Brute force approach
 * Time: O(n^2 * m), Space: O(1) ignore result array
 */

// @lc code=start
public partial class Solution
{
    public IList<string> StringMatching(string[] words)
    {
        // use HashSet to prevent duplicated string
        HashSet<string> res = new HashSet<string>();
        for (int i = 0; i < words.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (words[i].Contains(words[j]))
                    res.Add(words[j]);
                else if (words[j].Contains(words[i]))
                    res.Add(words[i]);
            }
        }
        return res.ToList();
    }
}
// @lc code=end


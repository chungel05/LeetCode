/*
 * @lc app=leetcode id=3 lang=csharp
 *
 * [3] Longest Substring Without Repeating Characters
 *
 * https://leetcode.com/problems/longest-substring-without-repeating-characters/description/
 *
 * algorithms
 * Medium (35.55%)
 * Likes:    40391
 * Dislikes: 1943
 * Total Accepted:    6.4M
 * Total Submissions: 18.1M
 * Testcase Example:  '"abcabcbb"'
 *
 * Given a string s, find the length of the longest substring without repeating
 * characters.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "abcabcbb"
 * Output: 3
 * Explanation: The answer is "abc", with the length of 3.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "bbbbb"
 * Output: 1
 * Explanation: The answer is "b", with the length of 1.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: s = "pwwkew"
 * Output: 3
 * Explanation: The answer is "wke", with the length of 3.
 * Notice that the answer must be a substring, "pwke" is a subsequence and not
 * a substring.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 0 <= s.length <= 5 * 10^4
 * s consists of English letters, digits, symbols and spaces.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        int maxLength = 0;
        List<char> charList = new List<char>();

        for (int i = 0; i < s.Length; i++)
        {
            int index = charList.IndexOf(s[i]);
            if (index > -1)
            {
                maxLength = Math.Max(maxLength, charList.Count);
                charList.RemoveRange(0, index + 1);
            }
            charList.Add(s[i]);
        }
        return Math.Max(maxLength, charList.Count);
    }
}
// @lc code=end


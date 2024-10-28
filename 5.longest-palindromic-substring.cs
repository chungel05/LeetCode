/*
 * @lc app=leetcode id=5 lang=csharp
 *
 * [5] Longest Palindromic Substring
 *
 * https://leetcode.com/problems/longest-palindromic-substring/description/
 *
 * algorithms
 * Medium (34.55%)
 * Likes:    29824
 * Dislikes: 1830
 * Total Accepted:    3.4M
 * Total Submissions: 9.8M
 * Testcase Example:  '"babad"'
 *
 * Given a string s, return the longest palindromic substring in s.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "babad"
 * Output: "bab"
 * Explanation: "aba" is also a valid answer.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "cbbd"
 * Output: "bb"
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s.length <= 1000
 * s consist of only digits and English letters.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public string LongestPalindrome(string s)
    {
        string res = "";
        int maxLen = 0;

        for (int i = 0; i < s.Length; i++)
        {
            // odd case
            int l = i, r = i;
            while (l >= 0 && r < s.Length && s[l] == s[r])
            {
                if (r - l + 1 > maxLen)
                {
                    maxLen = r - l + 1;
                    res = s.Substring(l, maxLen);
                }
                l--;
                r++;
            }

            // even case
            l = i;
            r = i + 1;
            while (l >= 0 && r < s.Length && s[l] == s[r])
            {
                if (r - l + 1 > maxLen)
                {
                    maxLen = r - l + 1;
                    res = s.Substring(l, maxLen);
                }
                l--;
                r++;
            }
        }
        return res;
    }
}
// @lc code=end


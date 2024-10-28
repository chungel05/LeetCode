/*
 * @lc app=leetcode id=647 lang=csharp
 *
 * [647] Palindromic Substrings
 *
 * https://leetcode.com/problems/palindromic-substrings/description/
 *
 * algorithms
 * Medium (70.72%)
 * Likes:    10903
 * Dislikes: 239
 * Total Accepted:    890.8K
 * Total Submissions: 1.3M
 * Testcase Example:  '"abc"'
 *
 * Given a string s, return the number of palindromic substrings in it.
 * 
 * A string is a palindrome when it reads the same backward as forward.
 * 
 * A substring is a contiguous sequence of characters within the string.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "abc"
 * Output: 3
 * Explanation: Three palindromic strings: "a", "b", "c".
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "aaa"
 * Output: 6
 * Explanation: Six palindromic strings: "a", "a", "a", "aa", "aa", "aaa".
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s.length <= 1000
 * s consists of lowercase English letters.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int CountSubstrings(string s)
    {
        int res = 0;

        for (int i = 0; i < s.Length; i++)
        {
            // odd case
            int l = i, r = i;
            while (l >= 0 && r < s.Length && s[l] == s[r])
            {
                res++;
                l--;
                r++;
            }

            // even case
            l = i;
            r = i + 1;
            while (l >= 0 && r < s.Length && s[l] == s[r])
            {
                res++;
                l--;
                r++;
            }
        }
        return res;
    }
}
// @lc code=end


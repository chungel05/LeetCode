/*
 * @lc app=leetcode id=1910 lang=csharp
 *
 * [1910] Remove All Occurrences of a Substring
 *
 * https://leetcode.com/problems/remove-all-occurrences-of-a-substring/description/
 *
 * algorithms
 * Medium (78.05%)
 * Likes:    1861
 * Dislikes: 65
 * Total Accepted:    154.9K
 * Total Submissions: 197.5K
 * Testcase Example:  '"daabcbaabcbc"\n"abc"'
 *
 * Given two strings s and part, perform the following operation on s until all
 * occurrences of the substring part are removed:
 * 
 * 
 * Find the leftmost occurrence of the substring part and remove it from s.
 * 
 * 
 * Return s after removing all occurrences of part.
 * 
 * A substring is a contiguous sequence of characters in a string.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "daabcbaabcbc", part = "abc"
 * Output: "dab"
 * Explanation: The following operations are done:
 * - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
 * - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
 * - s = "dababc", remove "abc" starting at index 3, so s = "dab".
 * Now s has no occurrences of "abc".
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "axxxxyyyyb", part = "xy"
 * Output: "ab"
 * Explanation: The following operations are done:
 * - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
 * - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
 * - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
 * - s = "axyb", remove "xy" starting at index 1 so s = "ab".
 * Now s has no occurrences of "xy".
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s.length <= 1000
 * 1 <= part.length <= 1000
 * s​​​​​​ and part consists of lowercase English letters.
 * 
 * 
 */
/*
 * Stack Approach
 * Time: O(n * p), Space: O(n)
 */

// @lc code=start
using System.Text;

public partial class Solution
{
    public string RemoveOccurrences(string s, string part)
    {
        int p = part.Length;
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
            // Append the char into StringBuilder, like stack.Push()
            sb.Append(s[i]);
            // if curr char == last char of part, and it is equal to part
            // remove it, like stack.Pop()
            if (sb.Length >= p && s[i] == part[p - 1] && sb.ToString(sb.Length - p, p) == part)
                sb.Remove(sb.Length - p, p);
        }
        return sb.ToString();
    }
}
// @lc code=end


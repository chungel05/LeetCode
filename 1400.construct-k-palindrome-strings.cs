/*
 * @lc app=leetcode id=1400 lang=csharp
 *
 * [1400] Construct K Palindrome Strings
 *
 * https://leetcode.com/problems/construct-k-palindrome-strings/description/
 *
 * algorithms
 * Medium (62.17%)
 * Likes:    1068
 * Dislikes: 97
 * Total Accepted:    57K
 * Total Submissions: 91.8K
 * Testcase Example:  '"annabelle"\n2'
 *
 * Given a string s and an integer k, return true if you can use all the
 * characters in s to construct k palindrome strings or false otherwise.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "annabelle", k = 2
 * Output: true
 * Explanation: You can construct two palindromes using all characters in s.
 * Some possible constructions "anna" + "elble", "anbna" + "elle", "anellena" +
 * "b"
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "leetcode", k = 3
 * Output: false
 * Explanation: It is impossible to construct 3 palindromes using all the
 * characters of s.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: s = "true", k = 4
 * Output: true
 * Explanation: The only possible solution is to put each character in a
 * separate string.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s.length <= 10^5
 * s consists of lowercase English letters.
 * 1 <= k <= 10^5
 * 
 * 
 */
/*
 * Count characters
 * Time: O(n + 26) => O(n), Space: O(26) => O(1)
 */

// @lc code=start
public partial class Solution
{
    public bool CanConstruct(string s, int k)
    {
        // Edge case, not enough char to form k palindrome string
        if (s.Length < k)
            return false;

        // count the occurrences of each char
        int[] charCount = new int[26];
        for (int i = 0; i < s.Length; i++)
        {
            charCount[s[i] - 'a']++;
        }

        // for the even no. of char, it can form palindrome by itself or combine with other char (even and odd)
        // so we only need to care about the odd no. of char
        int oddCount = 0;
        for (int i = 0; i < 26; i++)
        {
            // count the odd no. of char
            if (charCount[i] % 2 == 1)
                oddCount++;
        }

        // since odd no. of char only can form the palindrome by itself or combine with even char
        // so it needs to be <= k
        return oddCount <= k;
    }
}
// @lc code=end


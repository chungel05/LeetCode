/*
 * @lc app=leetcode id=395 lang=csharp
 *
 * [395] Longest Substring with At Least K Repeating Characters
 *
 * https://leetcode.com/problems/longest-substring-with-at-least-k-repeating-characters/description/
 *
 * algorithms
 * Medium (45.11%)
 * Likes:    6319
 * Dislikes: 526
 * Total Accepted:    241.7K
 * Total Submissions: 535.3K
 * Testcase Example:  '"aaabb"\n3'
 *
 * Given a string s and an integer k, return the length of the longest
 * substring of s such that the frequency of each character in this substring
 * is greater than or equal to k.
 * 
 * if no such substring exists, return 0.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "aaabb", k = 3
 * Output: 3
 * Explanation: The longest substring is "aaa", as 'a' is repeated 3 times.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "ababbc", k = 2
 * Output: 5
 * Explanation: The longest substring is "ababb", as 'a' is repeated 2 times
 * and 'b' is repeated 3 times.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s.length <= 10^4
 * s consists of only lowercase English letters.
 * 1 <= k <= 10^5
 * 
 * 
 */
/*
 * Time: O(n^2), Space: O(n)
 */

// @lc code=start
public partial class Solution
{
    public int LongestSubstring(string s, int k)
    {
        // Count the occurrance of each char
        int[] count = new int[26];
        for (int i = 0; i < s.Length; i++)
            count[s[i] - 'a']++;

        // start from 0, find the position of first char which count is < k
        int l = 0;
        while (l < s.Length && count[s[l] - 'a'] >= k)
            l++;

        // if l == s.Length - 1, it means that only last char count < k
        // if l == s.Length, it means that whole string are count >= k
        if (l >= s.Length - 1)
            return l;

        // After we found the first split char
        // we split it to first part substring and recheck
        int s1Len = LongestSubstring(s.Substring(0, l), k);

        // find the second part substring
        // we ignore the char which count is < k
        while (l < s.Length && count[s[l] - 'a'] < k)
            l++;

        // we split it to second part substring and recheck
        int s2Len = l < s.Length ? LongestSubstring(s.Substring(l), k) : 0;

        // return max result of s1 and s2
        return Math.Max(s1Len, s2Len);
    }
}
// @lc code=end


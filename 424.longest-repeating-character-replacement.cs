/*
 * @lc app=leetcode id=424 lang=csharp
 *
 * [424] Longest Repeating Character Replacement
 *
 * https://leetcode.com/problems/longest-repeating-character-replacement/description/
 *
 * algorithms
 * Medium (55.43%)
 * Likes:    10982
 * Dislikes: 566
 * Total Accepted:    890.4K
 * Total Submissions: 1.6M
 * Testcase Example:  '"ABAB"\n2'
 *
 * You are given a string s and an integer k. You can choose any character of
 * the string and change it to any other uppercase English character. You can
 * perform this operation at most k times.
 * 
 * Return the length of the longest substring containing the same letter you
 * can get after performing the above operations.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "ABAB", k = 2
 * Output: 4
 * Explanation: Replace the two 'A's with two 'B's or vice versa.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "AABABBA", k = 1
 * Output: 4
 * Explanation: Replace the one 'A' in the middle with 'B' and form "AABBBBA".
 * The substring "BBBB" has the longest repeating letters, which is 4.
 * There may exists other ways to achieve this answer too.
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s.length <= 10^5
 * s consists of only uppercase English letters.
 * 0 <= k <= s.length
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int CharacterReplacement(string s, int k)
    {
        int left = 0, maxLength = 1, mostFreq = 0;
        int[] charCount = new int[26];

        for (int right = 0; right < s.Length; right++)
        {
            charCount[s[right] - 'A']++;
            mostFreq = Math.Max(mostFreq, charCount[s[right] - 'A']);
            if (right - left + 1 - mostFreq > k)
            {
                charCount[s[left] - 'A']--;
                left++;
            }
            maxLength = Math.Max(maxLength, right - left + 1);
        }
        return maxLength;
    }
}
// @lc code=end


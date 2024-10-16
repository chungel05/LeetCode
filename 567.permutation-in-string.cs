/*
 * @lc app=leetcode id=567 lang=csharp
 *
 * [567] Permutation in String
 *
 * https://leetcode.com/problems/permutation-in-string/description/
 *
 * algorithms
 * Medium (46.33%)
 * Likes:    11902
 * Dislikes: 451
 * Total Accepted:    1.1M
 * Total Submissions: 2.3M
 * Testcase Example:  '"ab"\n"eidbaooo"'
 *
 * Given two strings s1 and s2, return true if s2 contains a permutation of s1,
 * or false otherwise.
 * 
 * In other words, return true if one of s1's permutations is the substring of
 * s2.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s1 = "ab", s2 = "eidbaooo"
 * Output: true
 * Explanation: s2 contains one permutation of s1 ("ba").
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s1 = "ab", s2 = "eidboaoo"
 * Output: false
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s1.length, s2.length <= 10^4
 * s1 and s2 consist of lowercase English letters.
 * 
 * 
 */

// @lc code=start
using System.Reflection.Metadata;

public partial class Solution
{
    public bool CheckInclusion(string s1, string s2)
    {
        int[] s1Count = new int[26];
        int[] s2Count = new int[26];

        if (s1.Length > s2.Length) return false;

        for (int i = 0; i < s1.Length; i++)
        {
            s1Count[s1[i] - 'a']++;
            s2Count[s2[i] - 'a']++;
        }

        int matches = 0;
        for (int i = 0; i < 26; i++)
        {
            if (s1Count[i] == s2Count[i])
                matches++;
        }

        int l = 0;
        for (int r = s1.Length; r < s2.Length; r++)
        {
            if (matches == 26)
                return true;

            int index = s2[r] - 'a';
            s2Count[index]++;
            if (s1Count[index] == s2Count[index]) // match after shift right
                matches++;
            else if (s1Count[index] + 1 == s2Count[index]) // match before, not match after shift right
                matches--;

            index = s2[l] - 'a';
            s2Count[index]--;
            if (s1Count[index] == s2Count[index]) // match after shif right
                matches++;
            else if (s1Count[index] - 1 == s2Count[index]) // match before, not match after shift right
                matches--;

            l++;
        }

        return matches == 26;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=1790 lang=csharp
 *
 * [1790] Check if One String Swap Can Make Strings Equal
 *
 * https://leetcode.com/problems/check-if-one-string-swap-can-make-strings-equal/description/
 *
 * algorithms
 * Easy (45.93%)
 * Likes:    1146
 * Dislikes: 61
 * Total Accepted:    123.7K
 * Total Submissions: 268.2K
 * Testcase Example:  '"bank"\n"kanb"'
 *
 * You are given two strings s1 and s2 of equal length. A string swap is an
 * operation where you choose two indices in a string (not necessarily
 * different) and swap the characters at these indices.
 * 
 * Return true if it is possible to make both strings equal by performing at
 * most one string swap on exactly one of the strings. Otherwise, return
 * false.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s1 = "bank", s2 = "kanb"
 * Output: true
 * Explanation: For example, swap the first character with the last character
 * of s2 to make "bank".
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s1 = "attack", s2 = "defend"
 * Output: false
 * Explanation: It is impossible to make them equal with one string swap.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: s1 = "kelb", s2 = "kelb"
 * Output: true
 * Explanation: The two strings are already equal, so no string swap operation
 * is required.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s1.length, s2.length <= 100
 * s1.length == s2.length
 * s1 and s2 consist of only lowercase English letters.
 * 
 * 
 */
/*
 * Array Checking Approach
 * Time: O(n), Space: O(26) => O(1)
 */

// @lc code=start
public partial class Solution
{
    public bool AreAlmostEqual(string s1, string s2)
    {
        // s1Array and s2Array store the freq. of each chars in s1 and s2
        // count store the diff. in s1 and s2
        int[] s1Array = new int[26];
        int[] s2Array = new int[26];
        int count = 0;
        for (int i = 0; i < s1.Length; i++)
        {
            // Add freq. of each char
            s1Array[s1[i] - 'a']++;
            s2Array[s2[i] - 'a']++;
            // count diff.
            if (s1[i] != s2[i])
                count++;

            // Since we only can swap at most 1 time, so if diff. > 2, cannot swap second time
            if (count > 2)
                return false;
        }

        // compare the freq.
        // if not the same, cannot form the same string
        for (int i = 0; i < 26; i++)
        {
            if (s1Array[i] != s2Array[i])
                return false;
        }
        return true;
    }
}
// @lc code=end


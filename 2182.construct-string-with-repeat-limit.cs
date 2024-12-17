/*
 * @lc app=leetcode id=2182 lang=csharp
 *
 * [2182] Construct String With Repeat Limit
 *
 * https://leetcode.com/problems/construct-string-with-repeat-limit/description/
 *
 * algorithms
 * Medium (54.78%)
 * Likes:    1104
 * Dislikes: 85
 * Total Accepted:    105.8K
 * Total Submissions: 148.6K
 * Testcase Example:  '"cczazcc"\n3'
 *
 * You are given a string s and an integer repeatLimit. Construct a new string
 * repeatLimitedString using the characters of s such that no letter appears
 * more than repeatLimit times in a row. You do not have to use all characters
 * from s.
 * 
 * Return the lexicographically largest repeatLimitedString possible.
 * 
 * A string a is lexicographically larger than a string b if in the first
 * position where a and b differ, string a has a letter that appears later in
 * the alphabet than the corresponding letter in b. If the first min(a.length,
 * b.length) characters do not differ, then the longer string is the
 * lexicographically larger one.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "cczazcc", repeatLimit = 3
 * Output: "zzcccac"
 * Explanation: We use all of the characters from s to construct the
 * repeatLimitedString "zzcccac".
 * The letter 'a' appears at most 1 time in a row.
 * The letter 'c' appears at most 3 times in a row.
 * The letter 'z' appears at most 2 times in a row.
 * Hence, no letter appears more than repeatLimit times in a row and the string
 * is a valid repeatLimitedString.
 * The string is the lexicographically largest repeatLimitedString possible so
 * we return "zzcccac".
 * Note that the string "zzcccca" is lexicographically larger but the letter
 * 'c' appears more than 3 times in a row, so it is not a valid
 * repeatLimitedString.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "aababab", repeatLimit = 2
 * Output: "bbabaa"
 * Explanation: We use only some of the characters from s to construct the
 * repeatLimitedString "bbabaa". 
 * The letter 'a' appears at most 2 times in a row.
 * The letter 'b' appears at most 2 times in a row.
 * Hence, no letter appears more than repeatLimit times in a row and the string
 * is a valid repeatLimitedString.
 * The string is the lexicographically largest repeatLimitedString possible so
 * we return "bbabaa".
 * Note that the string "bbabaaa" is lexicographically larger but the letter
 * 'a' appears more than 2 times in a row, so it is not a valid
 * repeatLimitedString.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= repeatLimit <= s.length <= 10^5
 * s consists of lowercase English letters.
 * 
 * 
 */

// @lc code=start
using System.Text;

public partial class Solution
{
    public string RepeatLimitedString(string s, int repeatLimit)
    {
        int[] charCount = new int[26];

        // count the occurrence of each char 
        for (int i = 0; i < s.Length; i++)
        {
            charCount[s[i] - 'a']++;
        }

        // using StringBuilder is faster
        StringBuilder sb = new StringBuilder();

        for (int i = 25; i >= 0; i--)
        {
            if (charCount[i] != 0)
            {
                // using j to record the next available char
                int j = i - 1;
                while (true)
                {
                    // append current char to the string by k times (where k = min(repeatLimit, charCount[i]))
                    sb.Append((char)('a' + i), Math.Min(repeatLimit, charCount[i]));
                    charCount[i] -= Math.Min(repeatLimit, charCount[i]);

                    // if no more current char, we can break and move to next available char
                    if (charCount[i] == 0)
                        break;

                    // otherwise, we found the next available char
                    while (j >= 0 && charCount[j] == 0)
                        j--;

                    // if next char not available, we can break, no matter the current char have count or not
                    if (j < 0)
                        break;

                    // append next available char as temp char between current char
                    sb.Append((char)('a' + j));
                    charCount[j]--;
                }
            }
        }

        return sb.ToString();
    }
}
// @lc code=end


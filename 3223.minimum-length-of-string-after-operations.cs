/*
 * @lc app=leetcode id=3223 lang=csharp
 *
 * [3223] Minimum Length of String After Operations
 *
 * https://leetcode.com/problems/minimum-length-of-string-after-operations/description/
 *
 * algorithms
 * Medium (55.38%)
 * Likes:    112
 * Dislikes: 3
 * Total Accepted:    33.4K
 * Total Submissions: 59K
 * Testcase Example:  '"abaacbcbb"'
 *
 * You are given a string s.
 * 
 * You can perform the following process on s any number of times:
 * 
 * 
 * Choose an index i in the string such that there is at least one character to
 * the left of index i that is equal to s[i], and at least one character to the
 * right that is also equal to s[i].
 * Delete the closest character to the left of index i that is equal to
 * s[i].
 * Delete the closest character to the right of index i that is equal to
 * s[i].
 * 
 * 
 * Return the minimum length of the final string s that you can achieve.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "abaacbcbb"
 * 
 * Output: 5
 * 
 * Explanation:
 * We do the following operations:
 * 
 * 
 * Choose index 2, then remove the characters at indices 0 and 3. The resulting
 * string is s = "bacbcbb".
 * Choose index 3, then remove the characters at indices 0 and 5. The resulting
 * string is s = "acbcb".
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "aa"
 * 
 * Output: 2
 * 
 * Explanation:
 * We cannot perform any operations, so we return the length of the original
 * string.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s.length <= 2 * 10^5
 * s consists only of lowercase English letters.
 * 
 * 
 */

// @lc code=start
using System.Numerics;

public partial class Solution
{
    // Occurrence Counting approach
    // Time: O(n + 26) => O(n), Space: O(26) => O(1)
    /* public int MinimumLength(string s)
    {
        // count the occurrence
        int[] charCount = new int[26];
        for (int i = 0; i < s.Length; i++)
        {
            charCount[s[i] - 'a']++;
        }

        int res = 0;
        // loop for each char 'a' to 'z'
        for (int i = 0; i < 26; i++)
        {
            if (charCount[i] == 0)
                continue;

            // since everytime we remove 2 chars, so at the end, we will have 2 or 1 left
            // so if it is even, res += 2
            if (charCount[i] % 2 == 0)
                res += 2;
            // if it is odd, res += 1
            else
                res += 1;
        }
        return res;
    } */

    // Bit Manipulation
    // Time: O(n), Space: O(1)
    public int MinimumLength(string s)
    {
        // charSeen to trace the char we had seen
        // oddEven to trace whether the char count is odd or even
        uint charSeen = 0, oddEven = 0;
        for (int i = 0; i < s.Length; i++)
        {
            uint bit = (uint)1 << (s[i] - 'a');
            charSeen |= bit;
            // oddEven XOR bit
            oddEven ^= bit;
        }

        // ans = charSeen bit count * 2 - odd bit count (which is bit set in oddEven)
        return (BitOperations.PopCount(charSeen) << 1) - BitOperations.PopCount(oddEven);
    }
}
// @lc code=end


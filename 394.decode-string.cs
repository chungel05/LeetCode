/*
 * @lc app=leetcode id=394 lang=csharp
 *
 * [394] Decode String
 *
 * https://leetcode.com/problems/decode-string/description/
 *
 * algorithms
 * Medium (59.98%)
 * Likes:    12971
 * Dislikes: 636
 * Total Accepted:    911K
 * Total Submissions: 1.5M
 * Testcase Example:  '"3[a]2[bc]"'
 *
 * Given an encoded string, return its decoded string.
 * 
 * The encoding rule is: k[encoded_string], where the encoded_string inside the
 * square brackets is being repeated exactly k times. Note that k is guaranteed
 * to be a positive integer.
 * 
 * You may assume that the input string is always valid; there are no extra
 * white spaces, square brackets are well-formed, etc. Furthermore, you may
 * assume that the original data does not contain any digits and that digits
 * are only for those repeat numbers, k. For example, there will not be input
 * like 3a or 2[4].
 * 
 * The test cases are generated so that the length of the output will never
 * exceed 10^5.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "3[a]2[bc]"
 * Output: "aaabcbc"
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "3[a2[c]]"
 * Output: "accaccacc"
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: s = "2[abc]3[cd]ef"
 * Output: "abcabccdcdcdef"
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s.length <= 30
 * s consists of lowercase English letters, digits, and square brackets
 * '[]'.
 * s is guaranteed to be a valid input.
 * All the integers in s are in the range [1, 300].
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    private string DFSDecodeString(string s, int left, int right)
    {
        int k = 0;
        string res = "";
        for (int i = left; i <= right; i++)
        {
            // if it is integer, we calc the k
            if (s[i] - '0' <= 9)
                k = k * 10 + (s[i] - '0');

            // if it is open bracket, we start to copy k times
            else if (s[i] == '[')
            {
                int open = 1; // trace the open bracket
                int newRight = i + 1; // find the content of whole [ and ]
                while (newRight <= right)
                {
                    if (s[newRight] == '[')
                        open++;
                    else if (s[newRight] == ']')
                    {
                        open--;
                        if (open == 0)
                            break;
                    }

                    newRight++;
                }
                // recursive call and copy k times
                // s[i] is open, s[newRight] is close
                res += string.Concat(Enumerable.Repeat(DFSDecodeString(s, i + 1, newRight - 1), k));

                // reset k and i
                k = 0;
                i = newRight;
            }

            // other char, add to res directly
            else
                res += s[i];
        }
        return res;
    }

    public string DecodeString(string s)
    {
        return DFSDecodeString(s, 0, s.Length - 1);
    }
}
// @lc code=end


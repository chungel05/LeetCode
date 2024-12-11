/*
 * @lc app=leetcode id=639 lang=csharp
 *
 * [639] Decode Ways II
 *
 * https://leetcode.com/problems/decode-ways-ii/description/
 *
 * algorithms
 * Hard (30.90%)
 * Likes:    1595
 * Dislikes: 820
 * Total Accepted:    78.6K
 * Total Submissions: 254.1K
 * Testcase Example:  '"*"'
 *
 * A message containing letters from A-Z can be encoded into numbers using the
 * following mapping:
 * 
 * 
 * 'A' -> "1"
 * 'B' -> "2"
 * ...
 * 'Z' -> "26"
 * 
 * 
 * To decode an encoded message, all the digits must be grouped then mapped
 * back into letters using the reverse of the mapping above (there may be
 * multiple ways). For example, "11106" can be mapped into:
 * 
 * 
 * "AAJF" with the grouping (1 1 10 6)
 * "KJF" with the grouping (11 10 6)
 * 
 * 
 * Note that the grouping (1 11 06) is invalid because "06" cannot be mapped
 * into 'F' since "6" is different from "06".
 * 
 * In addition to the mapping above, an encoded message may contain the '*'
 * character, which can represent any digit from '1' to '9' ('0' is excluded).
 * For example, the encoded message "1*" may represent any of the encoded
 * messages "11", "12", "13", "14", "15", "16", "17", "18", or "19". Decoding
 * "1*" is equivalent to decoding any of the encoded messages it can
 * represent.
 * 
 * Given a string s consisting of digits and '*' characters, return the number
 * of ways to decode it.
 * 
 * Since the answer may be very large, return it modulo 10^9 + 7.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "*"
 * Output: 9
 * Explanation: The encoded message can represent any of the encoded messages
 * "1", "2", "3", "4", "5", "6", "7", "8", or "9".
 * Each of these can be decoded to the strings "A", "B", "C", "D", "E", "F",
 * "G", "H", and "I" respectively.
 * Hence, there are a total of 9 ways to decode "*".
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "1*"
 * Output: 18
 * Explanation: The encoded message can represent any of the encoded messages
 * "11", "12", "13", "14", "15", "16", "17", "18", or "19".
 * Each of these encoded messages have 2 ways to be decoded (e.g. "11" can be
 * decoded to "AA" or "K").
 * Hence, there are a total of 9 * 2 = 18 ways to decode "1*".
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: s = "2*"
 * Output: 15
 * Explanation: The encoded message can represent any of the encoded messages
 * "21", "22", "23", "24", "25", "26", "27", "28", or "29".
 * "21", "22", "23", "24", "25", and "26" have 2 ways of being decoded, but
 * "27", "28", and "29" only have 1 way.
 * Hence, there are a total of (6 * 2) + (3 * 1) = 12 + 3 = 15 ways to decode
 * "2*".
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s.length <= 10^5
 * s[i] is a digit or '*'.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int NumDecodings(string s)
    {
        int mod = 1000000007;
        // create dp with long array to hold very large nums
        long[] dp = new long[s.Length + 1];
        // base case, 1 num = 1 possible case
        dp[s.Length] = 1;

        // loop from the end to 0
        for (int i = s.Length - 1; i >= 0; i--)
        {
            // single digit cases
            // if s[i] == '*', it can be 1 - 9, so the possible cases = 9 * dp[i + 1]
            if (s[i] == '*')
                dp[i] = 9 * dp[i + 1] % mod;
            // if s[i] != '0', it only have 1 possible case = 1 * dp[i + 1]
            else if (s[i] != '0')
                dp[i] = dp[i + 1];
            // if s[i] == '0', no possible case
            else
                dp[i] = 0;

            // double digit cases
            if (i + 1 < s.Length)
            {
                // pattern: '**', it can be 11 - 19, 21 - 26 = 15 possible cases
                if (s[i] == '*' && s[i + 1] == '*')
                    dp[i] = (dp[i] + 15 * dp[i + 2]) % mod;
                // pattern: '?*', depends on s[i]
                else if (s[i + 1] == '*')
                {
                    // if s[i] == '1', it can be 11 - 19 = 9 possible cases
                    if (s[i] == '1')
                        dp[i] = (dp[i] + 9 * dp[i + 2]) % mod;
                    // if s[i] == '2', it can be 21 - 26 = 6 possible cases
                    else if (s[i] == '2')
                        dp[i] = (dp[i] + 6 * dp[i + 2]) % mod;
                    // others, no possible case
                }
                // pattern: '*?', depends on s[i + 1]
                else if (s[i] == '*')
                {
                    // if s[i + 1] <= '6' (0 included), it can be 1 or 2 = 2 possible cases
                    if (s[i + 1] <= '6')
                        dp[i] = (dp[i] + 2 * dp[i + 2]) % mod;
                    // if s[i + 1] > '6', it can be 1 only = 1 possible case = 1 * dp[i + 2]
                    else
                        dp[i] = (dp[i] + dp[i + 2]) % mod;
                }
                // pattern: '1?' || '2?' <= '26', only 1 possible case = 1 * dp[i + 2]
                else if (s[i] == '1' || s[i] == '2' && s[i + 1] <= '6')
                    dp[i] = (dp[i] + dp[i + 2]) % mod;
                // other nums cannot form valid double digit pattern
            }
        }
        return (int)dp[0];
    }
}
// @lc code=end


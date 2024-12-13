/*
 * @lc app=leetcode id=87 lang=csharp
 *
 * [87] Scramble String
 *
 * https://leetcode.com/problems/scramble-string/description/
 *
 * algorithms
 * Hard (40.87%)
 * Likes:    3396
 * Dislikes: 1285
 * Total Accepted:    248.8K
 * Total Submissions: 604.2K
 * Testcase Example:  '"great"\n"rgeat"'
 *
 * We can scramble a string s to get a string t using the following
 * algorithm:
 * 
 * 
 * If the length of the string is 1, stop.
 * If the length of the string is > 1, do the following:
 * 
 * Split the string into two non-empty substrings at a random index, i.e., if
 * the string is s, divide it to x and y where s = x + y.
 * Randomly decide to swap the two substrings or to keep them in the same
 * order. i.e., after this step, s may become s = x + y or s = y + x.
 * Apply step 1 recursively on each of the two substrings x and y.
 * 
 * 
 * 
 * 
 * Given two strings s1 and s2 of the same length, return true if s2 is a
 * scrambled string of s1, otherwise, return false.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s1 = "great", s2 = "rgeat"
 * Output: true
 * Explanation: One possible scenario applied on s1 is:
 * "great" --> "gr/eat" // divide at random index.
 * "gr/eat" --> "gr/eat" // random decision is not to swap the two substrings
 * and keep them in order.
 * "gr/eat" --> "g/r / e/at" // apply the same algorithm recursively on both
 * substrings. divide at random index each of them.
 * "g/r / e/at" --> "r/g / e/at" // random decision was to swap the first
 * substring and to keep the second substring in the same order.
 * "r/g / e/at" --> "r/g / e/ a/t" // again apply the algorithm recursively,
 * divide "at" to "a/t".
 * "r/g / e/ a/t" --> "r/g / e/ a/t" // random decision is to keep both
 * substrings in the same order.
 * The algorithm stops now, and the result string is "rgeat" which is s2.
 * As one possible scenario led s1 to be scrambled to s2, we return true.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s1 = "abcde", s2 = "caebd"
 * Output: false
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: s1 = "a", s2 = "a"
 * Output: true
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * s1.length == s2.length
 * 1 <= s1.length <= 30
 * s1 and s2 consist of lowercase English letters.
 * 
 * 
 */
/*
 * DFS Top down approach with caching
 * Time: O(n^4), Space: O(n^3)
 */

// @lc code=start
public partial class Solution
{
    private bool DFSIsScramble(int s1Idx, int s2Idx, int length, int[][][] dp, string s1, string s2)
    {
        // if we cache the result, return it
        if (dp[s1Idx][s2Idx][length] != -1)
            return dp[s1Idx][s2Idx][length] == 1 ? true : false;

        // base case, if len of partition = 1, we just compare the s1[s1Idx] and s2[s2Idx]
        if (length == 1)
            return s1[s1Idx] == s2[s2Idx];

        // looping for the partition len, from 1 until len - 1, i.e. current partition len = 4, the first partition we can take 1 to 3 chars
        for (int i = 1; i < length; i++)
        {
            // Case 1: without swap
            // first segment = s1Idx to i and s2Idx to i, total len of partition = i
            // second segment = s1Idx + i to length and s2Idx + i to length, total len of partition = length - i
            if (DFSIsScramble(s1Idx, s2Idx, i, dp, s1, s2) && DFSIsScramble(s1Idx + i, s2Idx + i, length - i, dp, s1, s2))
            {
                dp[s1Idx][s2Idx][length] = 1;
                return true;
            }

            // Case 2: swap
            // first segment = s1Idx to i and s2Idx + (length - i) to length, total len of partition = i
            // second segment = s1Idx + i to length and s2Idx to length - i, total len of partition = length - i
            if (DFSIsScramble(s1Idx, s2Idx + length - i, i, dp, s1, s2) && DFSIsScramble(s1Idx + i, s2Idx, length - i, dp, s1, s2))
            {
                dp[s1Idx][s2Idx][length] = 1;
                return true;
            }
        }
        dp[s1Idx][s2Idx][length] = 0;
        return false;
    }

    public bool IsScramble(string s1, string s2)
    {
        if (s1 == s2)
            return true;

        int length = s1.Length;
        int[][][] dp = new int[length][][];

        for (int i = 0; i < length; i++)
        {
            dp[i] = new int[length][];
            for (int j = 0; j < length; j++)
            {
                dp[i][j] = new int[length + 1];
                Array.Fill(dp[i][j], -1);
            }
        }

        return DFSIsScramble(0, 0, length, dp, s1, s2);
    }
}
// @lc code=end


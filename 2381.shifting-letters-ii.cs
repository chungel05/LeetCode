/*
 * @lc app=leetcode id=2381 lang=csharp
 *
 * [2381] Shifting Letters II
 *
 * https://leetcode.com/problems/shifting-letters-ii/description/
 *
 * algorithms
 * Medium (38.00%)
 * Likes:    813
 * Dislikes: 20
 * Total Accepted:    28.2K
 * Total Submissions: 70.5K
 * Testcase Example:  '"abc"\n[[0,1,0],[1,2,1],[0,2,1]]'
 *
 * You are given a string s of lowercase English letters and a 2D integer array
 * shifts where shifts[i] = [starti, endi, directioni]. For every i, shift the
 * characters in s from the index starti to the index endi (inclusive) forward
 * if directioni = 1, or shift the characters backward if directioni = 0.
 * 
 * Shifting a character forward means replacing it with the next letter in the
 * alphabet (wrapping around so that 'z' becomes 'a'). Similarly, shifting a
 * character backward means replacing it with the previous letter in the
 * alphabet (wrapping around so that 'a' becomes 'z').
 * 
 * Return the final string after all such shifts to s are applied.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "abc", shifts = [[0,1,0],[1,2,1],[0,2,1]]
 * Output: "ace"
 * Explanation: Firstly, shift the characters from index 0 to index 1 backward.
 * Now s = "zac".
 * Secondly, shift the characters from index 1 to index 2 forward. Now s =
 * "zbd".
 * Finally, shift the characters from index 0 to index 2 forward. Now s =
 * "ace".
 * 
 * Example 2:
 * 
 * 
 * Input: s = "dztz", shifts = [[0,0,0],[1,1,1]]
 * Output: "catz"
 * Explanation: Firstly, shift the characters from index 0 to index 0 backward.
 * Now s = "cztz".
 * Finally, shift the characters from index 1 to index 1 forward. Now s =
 * "catz".
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s.length, shifts.length <= 5 * 10^4
 * shifts[i].length == 3
 * 0 <= starti <= endi < s.length
 * 0 <= directioni <= 1
 * s consists of lowercase English letters.
 * 
 * 
 */
/*
 * Line Sweep Approach
 * Time: O(n + q) where n = s.Length, q = shifts.Length
 * Space: O(n)
 */

// @lc code=start
public partial class Solution
{
    public string ShiftingLetters(string s, int[][] shifts)
    {
        // using Line sweep approach to record the start and end + 1 point because it is range inclusive
        // Case 1: Forward - start = +1, end + 1 = -1
        // Case 2: Backward - start = -1, end + 1 = +1
        // In order to prevent index overflow, use s.Length + 1 for the prefixSum
        int[] prefixSumShift = new int[s.Length + 1];
        for (int i = 0; i < shifts.Length; i++)
        {
            int increment = shifts[i][2] == 1 ? 1 : -1;
            prefixSumShift[shifts[i][0]] += increment;
            prefixSumShift[shifts[i][1] + 1] -= increment;
        }

        // using char[] to build string is faster than concat string
        char[] res = new char[s.Length];
        int runningShift = 0;
        for (int i = 0; i < s.Length; i++)
        {
            // runningShift = the steps needed to shift, accumulated from prev
            runningShift += prefixSumShift[i];
            int currChar = s[i] - 'a';
            // insert new char where needed to handle z -> a and a -> z cases
            res[i] = (char)('a' + (26 + (currChar + runningShift) % 26) % 26);
        }
        return new string(res);
    }
}
// @lc code=end


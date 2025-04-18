/*
 * @lc app=leetcode id=38 lang=csharp
 *
 * [38] Count and Say
 *
 * https://leetcode.com/problems/count-and-say/description/
 *
 * algorithms
 * Medium (56.61%)
 * Likes:    4365
 * Dislikes: 8625
 * Total Accepted:    1.1M
 * Total Submissions: 1.9M
 * Testcase Example:  '1'
 *
 * The count-and-say sequence is a sequence of digit strings defined by the
 * recursive formula:
 * 
 * 
 * countAndSay(1) = "1"
 * countAndSay(n) is the run-length encoding of countAndSay(n - 1).
 * 
 * 
 * Run-length encoding (RLE) is a string compression method that works by
 * replacing consecutive identical characters (repeated 2 or more times) with
 * the concatenation of the character and the number marking the count of the
 * characters (length of the run). For example, to compress the string
 * "3322251" we replace "33" with "23", replace "222" with "32", replace "5"
 * with "15" and replace "1" with "11". Thus the compressed string becomes
 * "23321511".
 * 
 * Given a positive integer n, return the n^th element of the count-and-say
 * sequence.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: n = 4
 * 
 * Output: "1211"
 * 
 * Explanation:
 * 
 * 
 * countAndSay(1) = "1"
 * countAndSay(2) = RLE of "1" = "11"
 * countAndSay(3) = RLE of "11" = "21"
 * countAndSay(4) = RLE of "21" = "1211"
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: n = 1
 * 
 * Output: "1"
 * 
 * Explanation:
 * 
 * This is the base case.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= n <= 30
 * 
 * 
 * 
 * Follow up: Could you solve it iteratively?
 */
/*
 * Recursion Approach
 * Time: O(n * l) where l = Length of string
 * Space: O(n * l)
 */

// @lc code=start
using System.Text;

public partial class Solution
{
    public string CountAndSay(int n)
    {
        // base case, n = 1
        if (n == 1)
            return "1";

        // Get prev string
        string prev = CountAndSay(n - 1);
        // start from prev[0], count = 1
        int count = 1;
        StringBuilder sb = new StringBuilder();
        // since 0 already counted, so loop from 1
        for (int i = 1; i < prev.Length; i++)
        {
            // if not the same
            if (prev[i] != prev[i - 1])
            {
                // add to string
                sb.Append(count);
                sb.Append(prev[i - 1]);
                // reset counter
                count = 0;
            }
            count++;
        }

        // last set of digit
        sb.Append(count);
        sb.Append(prev[prev.Length - 1]);
        return sb.ToString();
    }
}
// @lc code=end


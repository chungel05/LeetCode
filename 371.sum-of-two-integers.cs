/*
 * @lc app=leetcode id=371 lang=csharp
 *
 * [371] Sum of Two Integers
 *
 * https://leetcode.com/problems/sum-of-two-integers/description/
 *
 * algorithms
 * Medium (52.61%)
 * Likes:    4299
 * Dislikes: 5604
 * Total Accepted:    530.1K
 * Total Submissions: 1M
 * Testcase Example:  '1\n2'
 *
 * Given two integers a and b, return the sum of the two integers without using
 * the operators + and -.
 * 
 * 
 * Example 1:
 * Input: a = 1, b = 2
 * Output: 3
 * Example 2:
 * Input: a = 2, b = 3
 * Output: 5
 * 
 * 
 * Constraints:
 * 
 * 
 * -1000 <= a, b <= 1000
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int GetSum(int a, int b)
    {
        while (b != 0)
        {
            // only carry (1,1) will be pop out, and shift 1 bit left 
            // a XOR b until b does not have carry
            int carry = (a & b) << 1;
            a = a ^ b;
            b = carry;
        }
        return a;
    }
}
// @lc code=end


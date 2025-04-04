/*
 * @lc app=leetcode id=7 lang=csharp
 *
 * [7] Reverse Integer
 *
 * https://leetcode.com/problems/reverse-integer/description/
 *
 * algorithms
 * Medium (29.24%)
 * Likes:    13442
 * Dislikes: 13645
 * Total Accepted:    3.6M
 * Total Submissions: 12.3M
 * Testcase Example:  '123'
 *
 * Given a signed 32-bit integer x, return x with its digits reversed. If
 * reversing x causes the value to go outside the signed 32-bit integer range
 * [-2^31, 2^31 - 1], then return 0.
 * 
 * Assume the environment does not allow you to store 64-bit integers (signed
 * or unsigned).
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: x = 123
 * Output: 321
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: x = -123
 * Output: -321
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: x = 120
 * Output: 21
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * -2^31 <= x <= 2^31 - 1
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int Reverse(int x)
    {
        int res = 0;
        while (x != 0)
        {
            int digit = x % 10;
            x = x / 10;

            if (res > int.MaxValue / 10 || (res == int.MaxValue / 10 && digit > int.MaxValue % 10))
                return 0;
            if (res < int.MinValue / 10 || (res == int.MinValue / 10 && digit < int.MinValue % 10))
                return 0;

            res = res * 10 + digit;
        }

        return res;
    }
}
// @lc code=end


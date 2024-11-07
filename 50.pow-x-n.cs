/*
 * @lc app=leetcode id=50 lang=csharp
 *
 * [50] Pow(x, n)
 *
 * https://leetcode.com/problems/powx-n/description/
 *
 * algorithms
 * Medium (35.69%)
 * Likes:    10084
 * Dislikes: 9766
 * Total Accepted:    1.9M
 * Total Submissions: 5.3M
 * Testcase Example:  '2.00000\n10'
 *
 * Implement pow(x, n), which calculates x raised to the power n (i.e.,
 * x^n).
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: x = 2.00000, n = 10
 * Output: 1024.00000
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: x = 2.10000, n = 3
 * Output: 9.26100
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: x = 2.00000, n = -2
 * Output: 0.25000
 * Explanation: 2^-2 = 1/2^2 = 1/4 = 0.25
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * -100.0 < x < 100.0
 * -2^31 <= n <= 2^31-1
 * n is an integer.
 * Either x is not zero or n > 0.
 * -10^4 <= x^n <= 10^4
 * 
 * 
 */
/*
 * 2^10 = 2^5 * 2^5
 * so we can divide it into 2 part
 */

// @lc code=start
public partial class Solution
{
    public double SubMyPow(double x, int n)
    {
        if (n == 0)
            return 1;

        double res = SubMyPow(x, n / 2);
        return n % 2 == 0 ? res * res : x * res * res;
    }

    public double MyPow(double x, int n)
    {
        if (x == 0)
            return 0;
        if (n == 0)
            return 1;

        double res = SubMyPow(x, n);
        return n >= 0 ? res : 1 / res;
    }
}
// @lc code=end


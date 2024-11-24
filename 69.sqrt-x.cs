/*
 * @lc app=leetcode id=69 lang=csharp
 *
 * [69] Sqrt(x)
 *
 * https://leetcode.com/problems/sqrtx/description/
 *
 * algorithms
 * Easy (39.44%)
 * Likes:    8450
 * Dislikes: 4541
 * Total Accepted:    2.3M
 * Total Submissions: 5.7M
 * Testcase Example:  '4'
 *
 * Given a non-negative integer x, return the square root of x rounded down to
 * the nearest integer. The returned integer should be non-negative as well.
 * 
 * You must not use any built-in exponent function or operator.
 * 
 * 
 * For example, do not use pow(x, 0.5) in c++ or x ** 0.5 in python.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: x = 4
 * Output: 2
 * Explanation: The square root of 4 is 2, so we return 2.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: x = 8
 * Output: 2
 * Explanation: The square root of 8 is 2.82842..., and since we round it down
 * to the nearest integer, 2 is returned.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 0 <= x <= 2^31 - 1
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int MySqrt(int x)
    {
        long l = 0, r = x;
        while (l < r)
        {
            // need to add 1 because we want to avoid infinity loop
            // i.e. l = 2, r = 3; in this case, we want to get m = 3
            // because l and possible answer
            long m = (long)(l + r + 1) / 2;
            if (m * m <= x)
                l = m;
            else
                r = m - 1;
        }
        return (int)l;
    }
}
// @lc code=end


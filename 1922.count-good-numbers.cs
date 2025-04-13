/*
 * @lc app=leetcode id=1922 lang=csharp
 *
 * [1922] Count Good Numbers
 *
 * https://leetcode.com/problems/count-good-numbers/description/
 *
 * algorithms
 * Medium (46.89%)
 * Likes:    1994
 * Dislikes: 537
 * Total Accepted:    185.5K
 * Total Submissions: 330.4K
 * Testcase Example:  '1'
 *
 * A digit string is good if the digits (0-indexed) at even indices are even
 * and the digits at odd indices are prime (2, 3, 5, or 7).
 * 
 * 
 * For example, "2582" is good because the digits (2 and 8) at even positions
 * are even and the digits (5 and 2) at odd positions are prime. However,
 * "3245" is not good because 3 is at an even index but is not even.
 * 
 * 
 * Given an integer n, return the total number of good digit strings of length
 * n. Since the answer may be large, return it modulo 10^9 + 7.
 * 
 * A digit string is a string consisting of digits 0 through 9 that may contain
 * leading zeros.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: n = 1
 * Output: 5
 * Explanation: The good numbers of length 1 are "0", "2", "4", "6", "8".
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: n = 4
 * Output: 400
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: n = 50
 * Output: 564908303
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= n <= 10^15
 * 
 * 
 */
/*
 * Math Approach
 * Time: O(log n), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    // Fast Exponentiation to calc x^n
    // Time: O(log n)
    private long FastExponentiation(int x, long n)
    {
        long ans = 1;
        long num = x;
        long mod = 1_000_000_007;
        while (n > 0)
        {
            // handle n = odd number
            if (n % 2 == 1)
                ans = ans * num % mod;

            // Everytime calc x * x which is x^2 => x^4 => x^8 etc.
            num = num * num % mod;
            // because everytime calc x^2 etc., so divided by 2
            n /= 2;
        }
        return ans;
    }

    public int CountGoodNumbers(long n)
    {
        long mod = 1_000_000_007;
        // when digit is even, there are floor((n + 1) / 2) position
        // when digit is odd, there are floor(n / 2) position
        // i.e. n = 5, there are 0, 2, 4 is even digit and 1, 3 is odd digit
        // even digit have 5 possibilities which are 0, 2, 4, 6, 8
        // odd digit have 4 possibilities which are 2, 3, 5, 7
        // since digit string in this question can have leading zeros,
        // so total combination is: 5^((n + 1) / 2) * 4^(n / 2)
        // i.e. n = 5, total combination = 5 * 4 * 5 * 4 * 5 = 5^3 * 4^2
        return (int)(FastExponentiation(5, (n + 1) / 2) * FastExponentiation(4, n / 2) % mod);
    }
}
// @lc code=end


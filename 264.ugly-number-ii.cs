/*
 * @lc app=leetcode id=264 lang=csharp
 *
 * [264] Ugly Number II
 *
 * https://leetcode.com/problems/ugly-number-ii/description/
 *
 * algorithms
 * Medium (49.14%)
 * Likes:    6575
 * Dislikes: 400
 * Total Accepted:    465K
 * Total Submissions: 946.8K
 * Testcase Example:  '10'
 *
 * An ugly number is a positive integer whose prime factors are limited to 2,
 * 3, and 5.
 * 
 * Given an integer n, return the n^th ugly number.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: n = 10
 * Output: 12
 * Explanation: [1, 2, 3, 4, 5, 6, 8, 9, 10, 12] is the sequence of the first
 * 10 ugly numbers.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: n = 1
 * Output: 1
 * Explanation: 1 has no prime factors, therefore all of its prime factors are
 * limited to 2, 3, and 5.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= n <= 1690
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int NthUglyNumber(int n)
    {
        int[] dp = new int[n];
        dp[0] = 1;
        int index2 = 0;
        int index3 = 0;
        int index5 = 0;

        for (int i = 1; i < n; i++)
        {
            int n2 = dp[index2] * 2;
            int n3 = dp[index3] * 3;
            int n5 = dp[index5] * 5;

            dp[i] = Math.Min(n5, Math.Min(n2, n3));
            // if same num, 2 pointer need to increase
            // i.e. n2 = 6, n3 = 6
            if (dp[i] == n2)
                index2++;
            if (dp[i] == n3)
                index3++;
            if (dp[i] == n5)
                index5++;
        }
        return dp[n - 1];
    }
}
// @lc code=end


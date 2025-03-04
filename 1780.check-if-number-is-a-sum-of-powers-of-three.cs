/*
 * @lc app=leetcode id=1780 lang=csharp
 *
 * [1780] Check if Number is a Sum of Powers of Three
 *
 * https://leetcode.com/problems/check-if-number-is-a-sum-of-powers-of-three/description/
 *
 * algorithms
 * Medium (68.19%)
 * Likes:    1057
 * Dislikes: 39
 * Total Accepted:    56.9K
 * Total Submissions: 80.7K
 * Testcase Example:  '12'
 *
 * Given an integer n, return true if it is possible to represent n as the sum
 * of distinct powers of three. Otherwise, return false.
 * 
 * An integer y is a power of three if there exists an integer x such that y ==
 * 3^x.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: n = 12
 * Output: true
 * Explanation: 12 = 3^1 + 3^2
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: n = 91
 * Output: true
 * Explanation: 91 = 3^0 + 3^2 + 3^4
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: n = 21
 * Output: false
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= n <= 10^7
 * 
 * 
 */
/*
 * Math Approach - Ternary presentation
 * Time: O(log3(n)), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    // every number can be represented as Ternary presentation with coefficient 0, 1, 2
    // i.e. 5 = 1 * 3^1 + 2 * 3^0
    // Question is restricted to use 0, 1 (2 is not allowed)
    public bool CheckPowersOfThree(int n)
    {
        while (n > 0)
        {
            // since 2 is not allowed, so return false
            if (n % 3 == 2)
                return false;

            n /= 3;
        }
        return true;
    }
}
// @lc code=end


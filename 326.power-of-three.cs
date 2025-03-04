/*
 * @lc app=leetcode id=326 lang=csharp
 *
 * [326] Power of Three
 *
 * https://leetcode.com/problems/power-of-three/description/
 *
 * algorithms
 * Easy (47.12%)
 * Likes:    3200
 * Dislikes: 286
 * Total Accepted:    972.4K
 * Total Submissions: 2M
 * Testcase Example:  '27'
 *
 * Given an integer n, return true if it is a power of three. Otherwise, return
 * false.
 * 
 * An integer n is a power of three, if there exists an integer x such that n
 * == 3^x.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: n = 27
 * Output: true
 * Explanation: 27 = 3^3
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: n = 0
 * Output: false
 * Explanation: There is no x where 3^x = 0.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: n = -1
 * Output: false
 * Explanation: There is no x where 3^x = (-1).
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * -2^31 <= n <= 2^31 - 1
 * 
 * 
 * 
 * Follow up: Could you solve it without loops/recursion?
 */
/*
 * Math Approach
 * Time: O(1), Space: O(1)
 * For any prime number, 
 * M <= N that is a power of 3, M divides N (N % M == 0)
 * M <= N that is not a power 3, M does not divide N (N % M != 0)
 */

// @lc code=start
public partial class Solution
{
    public bool IsPowerOfThree(int n)
    {
        // int m = (int)Math.Pow(3, Math.Floor(Math.Log10(Int32.MaxValue) / Math.Log10(3)));
        // m = 1162261467
        return n > 0 && 1162261467 % n == 0;
    }
}
// @lc code=end


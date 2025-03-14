/*
 * @lc app=leetcode id=70 lang=csharp
 *
 * [70] Climbing Stairs
 *
 * https://leetcode.com/problems/climbing-stairs/description/
 *
 * algorithms
 * Easy (53.16%)
 * Likes:    22355
 * Dislikes: 887
 * Total Accepted:    3.7M
 * Total Submissions: 6.9M
 * Testcase Example:  '2'
 *
 * You are climbing a staircase. It takes n steps to reach the top.
 * 
 * Each time you can either climb 1 or 2 steps. In how many distinct ways can
 * you climb to the top?
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: n = 2
 * Output: 2
 * Explanation: There are two ways to climb to the top.
 * 1. 1 step + 1 step
 * 2. 2 steps
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: n = 3
 * Output: 3
 * Explanation: There are three ways to climb to the top.
 * 1. 1 step + 1 step + 1 step
 * 2. 1 step + 2 steps
 * 3. 2 steps + 1 step
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= n <= 45
 * 
 * 
 */
/*
 * Fibonacci sequence from bottom to top approach
 */

// @lc code=start
public partial class Solution
{
    public int ClimbStairs(int n)
    {
        int first = 1, second = 1;

        for (int i = 0; i < n - 1; i++)
        {
            int temp = second;
            second = first + second;
            first = temp;
        }
        return second;
    }
}
// @lc code=end


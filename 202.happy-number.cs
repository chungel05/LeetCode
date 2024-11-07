/*
 * @lc app=leetcode id=202 lang=csharp
 *
 * [202] Happy Number
 *
 * https://leetcode.com/problems/happy-number/description/
 *
 * algorithms
 * Easy (56.90%)
 * Likes:    10653
 * Dislikes: 1508
 * Total Accepted:    1.6M
 * Total Submissions: 2.9M
 * Testcase Example:  '19'
 *
 * Write an algorithm to determine if a number n is happy.
 * 
 * A happy number is a number defined by the following process:
 * 
 * 
 * Starting with any positive integer, replace the number by the sum of the
 * squares of its digits.
 * Repeat the process until the number equals 1 (where it will stay), or it
 * loops endlessly in a cycle which does not include 1.
 * Those numbers for which this process ends in 1 are happy.
 * 
 * 
 * Return true if n is a happy number, and false if not.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: n = 19
 * Output: true
 * Explanation:
 * 1^2 + 9^2 = 82
 * 8^2 + 2^2 = 68
 * 6^2 + 8^2 = 100
 * 1^2 + 0^2 + 0^2 = 1
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: n = 2
 * Output: false
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= n <= 2^31 - 1
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public bool IsHappy(int n)
    {
        HashSet<int> dict = new HashSet<int>();
        while (!dict.Contains(n))
        {
            dict.Add(n);
            int sum = 0;
            while (n != 0)
            {
                int digit = n % 10;
                n = n / 10;
                sum += digit * digit;
            }

            if (sum == 1)
                return true;

            n = sum;
        }
        return false;
    }
}
// @lc code=end


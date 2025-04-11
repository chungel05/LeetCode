/*
 * @lc app=leetcode id=2843 lang=csharp
 *
 * [2843]   Count Symmetric Integers
 *
 * https://leetcode.com/problems/count-symmetric-integers/description/
 *
 * algorithms
 * Easy (74.63%)
 * Likes:    303
 * Dislikes: 23
 * Total Accepted:    64.1K
 * Total Submissions: 84.6K
 * Testcase Example:  '1\n100'
 *
 * You are given two positive integers low and high.
 * 
 * An integer x consisting of 2 * n digits is symmetric if the sum of the first
 * n digits of x is equal to the sum of the last n digits of x. Numbers with an
 * odd number of digits are never symmetric.
 * 
 * Return the number of symmetric integers in the range [low, high].
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: low = 1, high = 100
 * Output: 9
 * Explanation: There are 9 symmetric integers between 1 and 100: 11, 22, 33,
 * 44, 55, 66, 77, 88, and 99.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: low = 1200, high = 1230
 * Output: 4
 * Explanation: There are 4 symmetric integers between 1200 and 1230: 1203,
 * 1212, 1221, and 1230.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= low <= high <= 10^4
 * 
 * 
 */
/*
 * Brute Force Approach
 * Time: O(high - low), O(1)
 */

// @lc code=start
public partial class Solution
{
    private int CountDigit(int num)
    {
        int count = 0;
        while (num != 0)
        {
            count++;
            num /= 10;
        }
        return count;
    }

    private int SumOfNumDigit(int num, int digit)
    {
        int sum = 0;
        while (digit != 0)
        {
            sum += num % 10;
            num /= 10;
            digit--;
        }
        return sum;
    }

    public int CountSymmetricIntegers(int low, int high)
    {
        int ans = 0;
        for (int i = low; i <= high; i++)
        {
            int count = CountDigit(i);
            if (count % 2 == 0)
            {
                int totalSum = SumOfNumDigit(i, count);
                if (totalSum == 2 * SumOfNumDigit(i, count / 2))
                    ans++;
            }
        }
        return ans;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=66 lang=csharp
 *
 * [66] Plus One
 *
 * https://leetcode.com/problems/plus-one/description/
 *
 * algorithms
 * Easy (46.28%)
 * Likes:    9678
 * Dislikes: 5431
 * Total Accepted:    2.6M
 * Total Submissions: 5.5M
 * Testcase Example:  '[1,2,3]'
 *
 * You are given a large integer represented as an integer array digits, where
 * each digits[i] is the i^th digit of the integer. The digits are ordered from
 * most significant to least significant in left-to-right order. The large
 * integer does not contain any leading 0's.
 * 
 * Increment the large integer by one and return the resulting array of
 * digits.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: digits = [1,2,3]
 * Output: [1,2,4]
 * Explanation: The array represents the integer 123.
 * Incrementing by one gives 123 + 1 = 124.
 * Thus, the result should be [1,2,4].
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: digits = [4,3,2,1]
 * Output: [4,3,2,2]
 * Explanation: The array represents the integer 4321.
 * Incrementing by one gives 4321 + 1 = 4322.
 * Thus, the result should be [4,3,2,2].
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: digits = [9]
 * Output: [1,0]
 * Explanation: The array represents the integer 9.
 * Incrementing by one gives 9 + 1 = 10.
 * Thus, the result should be [1,0].
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= digits.length <= 100
 * 0 <= digits[i] <= 9
 * digits does not contain any leading 0's.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int[] PlusOne(int[] digits)
    {
        int[] res = new int[digits.Length + 1];
        int carry = 1;
        res[0] = 1;
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            res[i + 1] = (digits[i] + carry) % 10;
            carry = (digits[i] + carry >= 10) ? 1 : 0;
        }

        if (carry == 0)
            return res.Skip(1).ToArray();
        return res;
    }
}
// @lc code=end


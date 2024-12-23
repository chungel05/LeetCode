/*
 * @lc app=leetcode id=43 lang=csharp
 *
 * [43] Multiply Strings
 *
 * https://leetcode.com/problems/multiply-strings/description/
 *
 * algorithms
 * Medium (41.07%)
 * Likes:    7187
 * Dislikes: 3421
 * Total Accepted:    875.4K
 * Total Submissions: 2.1M
 * Testcase Example:  '"2"\n"3"'
 *
 * Given two non-negative integers num1 and num2 represented as strings, return
 * the product of num1 and num2, also represented as a string.
 * 
 * Note: You must not use any built-in BigInteger library or convert the inputs
 * to integer directly.
 * 
 * 
 * Example 1:
 * Input: num1 = "2", num2 = "3"
 * Output: "6"
 * Example 2:
 * Input: num1 = "123", num2 = "456"
 * Output: "56088"
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= num1.length, num2.length <= 200
 * num1 and num2 consist of digits only.
 * Both num1 and num2 do not contain any leading zero, except the number 0
 * itself.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public string Multiply(string num1, string num2)
    {
        if (num1 == "0" || num2 == "0")
            return "0";

        int[] res = new int[num1.Length + num2.Length];
        char[] n1 = num1.Reverse().ToArray();
        char[] n2 = num2.Reverse().ToArray();

        for (int i = 0; i < n1.Length; i++)
        {
            for (int j = 0; j < n2.Length; j++)
            {
                res[i + j] += (n1[i] - '0') * (n2[j] - '0');
                res[i + j + 1] += res[i + j] / 10;
                res[i + j] = res[i + j] % 10;
            }
        }

        res = res.Reverse().ToArray();
        int lead = 0;
        while (res[lead] == 0)
            lead++;

        res = res.Skip(lead).ToArray();
        return string.Join("", res);
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=224 lang=csharp
 *
 * [224] Basic Calculator
 *
 * https://leetcode.com/problems/basic-calculator/description/
 *
 * algorithms
 * Hard (44.02%)
 * Likes:    6440
 * Dislikes: 513
 * Total Accepted:    520.8K
 * Total Submissions: 1.2M
 * Testcase Example:  '"1 + 1"'
 *
 * Given a string s representing a valid expression, implement a basic
 * calculator to evaluate it, and return the result of the evaluation.
 * 
 * Note: You are not allowed to use any built-in function which evaluates
 * strings as mathematical expressions, such as eval().
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "1 + 1"
 * Output: 2
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = " 2-1 + 2 "
 * Output: 3
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: s = "(1+(4+5+2)-3)+(6+8)"
 * Output: 23
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s.length <= 3 * 10^5
 * s consists of digits, '+', '-', '(', ')', and ' '.
 * s represents a valid expression.
 * '+' is not used as a unary operation (i.e., "+1" and "+(2 + 3)" is
 * invalid).
 * '-' could be used as a unary operation (i.e., "-1" and "-(2 + 3)" is
 * valid).
 * There will be no two consecutive operators in the input.
 * Every number and running calculation will fit in a signed 32-bit integer.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int Calculate(string s)
    {
        Stack<int> stack = new Stack<int>();
        int res = 0;
        int sign = 1;
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            // digit
            if (char.IsDigit(c))
            {
                int start = i;
                int num = 0;
                // get whole num until next +/-/(/), i.e.: 234
                while (start < s.Length && char.IsDigit(s[start]))
                {
                    num = num * 10 + (s[start] - '0');
                    start++;
                }
                res += sign * num;
                // set i = last digit, because i will add 1 by for loop
                i = start - 1;
            }
            else if (c == '+')
                sign = 1;
            else if (c == '-')
                sign = -1;
            else if (c == '(')
            {
                // push current res and current sign to stack
                stack.Push(res);
                stack.Push(sign);
                // reset
                res = 0;
                sign = 1;
            }
            else if (c == ')')
            {
                // first pop = sign, second pop = prev res
                res = stack.Pop() * res + stack.Pop();
            }
        }
        return res;
    }
}
// @lc code=end


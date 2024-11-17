/*
 * @lc app=leetcode id=1249 lang=csharp
 *
 * [1249] Minimum Remove to Make Valid Parentheses
 *
 * https://leetcode.com/problems/minimum-remove-to-make-valid-parentheses/description/
 *
 * algorithms
 * Medium (69.44%)
 * Likes:    7000
 * Dislikes: 148
 * Total Accepted:    826.6K
 * Total Submissions: 1.2M
 * Testcase Example:  '"lee(t(c)o)de)"'
 *
 * Given a string s of '(' , ')' and lowercase English characters.
 * 
 * Your task is to remove the minimum number of parentheses ( '(' or ')', in
 * any positions ) so that the resulting parentheses string is valid and return
 * any valid string.
 * 
 * Formally, a parentheses string is valid if and only if:
 * 
 * 
 * It is the empty string, contains only lowercase characters, or
 * It can be written as AB (A concatenated with B), where A and B are valid
 * strings, or
 * It can be written as (A), where A is a valid string.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "lee(t(c)o)de)"
 * Output: "lee(t(c)o)de"
 * Explanation: "lee(t(co)de)" , "lee(t(c)ode)" would also be accepted.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "a)b(c)d"
 * Output: "ab(c)d"
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: s = "))(("
 * Output: ""
 * Explanation: An empty string is also valid.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s.length <= 10^5
 * s[i] is either '(' , ')', or lowercase English letter.
 * 
 * 
 */

// @lc code=start
using System.Text;

public partial class Solution
{
    public string MinRemoveToMakeValid(string s)
    {
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
                stack.Push(i);
            else if (s[i] == ')')
            {
                if (stack.TryPeek(out int index))
                {
                    if (s[index] == '(')
                        stack.Pop();
                    else
                        stack.Push(i);
                }
                else
                    stack.Push(i);
            }
        }

        List<char> res = s.ToList();
        while (stack.Count > 0)
        {
            res.RemoveAt(stack.Pop());
        }
        return string.Join("", res);
    }
}
// @lc code=end


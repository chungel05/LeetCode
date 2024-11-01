/*
 * @lc app=leetcode id=678 lang=csharp
 *
 * [678] Valid Parenthesis String
 *
 * https://leetcode.com/problems/valid-parenthesis-string/description/
 *
 * algorithms
 * Medium (38.26%)
 * Likes:    6270
 * Dislikes: 195
 * Total Accepted:    415.9K
 * Total Submissions: 1.1M
 * Testcase Example:  '"()"'
 *
 * Given a string s containing only three types of characters: '(', ')' and
 * '*', return true if s is valid.
 * 
 * The following rules define a valid string:
 * 
 * 
 * Any left parenthesis '(' must have a corresponding right parenthesis
 * ')'.
 * Any right parenthesis ')' must have a corresponding left parenthesis
 * '('.
 * Left parenthesis '(' must go before the corresponding right parenthesis
 * ')'.
 * '*' could be treated as a single right parenthesis ')' or a single left
 * parenthesis '(' or an empty string "".
 * 
 * 
 * 
 * Example 1:
 * Input: s = "()"
 * Output: true
 * Example 2:
 * Input: s = "(*)"
 * Output: true
 * Example 3:
 * Input: s = "(*))"
 * Output: true
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s.length <= 100
 * s[i] is '(', ')' or '*'.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public bool CheckValidString(string s)
    {
        int leftPar = 0;
        int rightPar = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                leftPar++;
                rightPar++;
            }
            else if (s[i] == ')')
            {
                leftPar--;
                rightPar--;
            }
            else
            {
                leftPar++;
                rightPar--;
            }

            if (rightPar < 0)
                rightPar = 0;

            if (leftPar < 0)
                return false;
        }

        return rightPar == 0;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=856 lang=csharp
 *
 * [856] Score of Parentheses
 *
 * https://leetcode.com/problems/score-of-parentheses/description/
 *
 * algorithms
 * Medium (64.00%)
 * Likes:    5462
 * Dislikes: 220
 * Total Accepted:    196.4K
 * Total Submissions: 307.5K
 * Testcase Example:  '"()"'
 *
 * Given a balanced parentheses string s, return the score of the string.
 * 
 * The score of a balanced parentheses string is based on the following
 * rule:
 * 
 * 
 * "()" has score 1.
 * AB has score A + B, where A and B are balanced parentheses strings.
 * (A) has score 2 * A, where A is a balanced parentheses string.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "()"
 * Output: 1
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "(())"
 * Output: 2
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: s = "()()"
 * Output: 2
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 2 <= s.length <= 50
 * s consists of only '(' and ')'.
 * s is a balanced parentheses string.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    private int DFSScoreOfParentheses(string s, int left, int right)
    {
        if (left >= right)
            return 0;

        int point = 0;
        for (int i = left; i <= right; i++)
        {
            if (s[i] == '(')
            {
                int newRight = i + 1;
                int open = 1;
                while (newRight <= right)
                {
                    if (s[newRight] == '(')
                        open++;
                    else if (s[newRight] == ')')
                        open--;

                    if (open == 0)
                    {
                        int inside = DFSScoreOfParentheses(s, i + 1, newRight - 1);
                        point += inside == 0 ? 1 : 2 * inside;
                        break;
                    }
                    newRight++;
                }
                i = newRight;
            }
        }
        return point;
    }

    public int ScoreOfParentheses(string s)
    {
        return DFSScoreOfParentheses(s, 0, s.Length - 1);
    }
}
// @lc code=end


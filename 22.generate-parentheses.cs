/*
 * @lc app=leetcode id=22 lang=csharp
 *
 * [22] Generate Parentheses
 *
 * https://leetcode.com/problems/generate-parentheses/description/
 *
 * algorithms
 * Medium (75.63%)
 * Likes:    21426
 * Dislikes: 979
 * Total Accepted:    2M
 * Total Submissions: 2.7M
 * Testcase Example:  '3'
 *
 * Given n pairs of parentheses, write a function to generate all combinations
 * of well-formed parentheses.
 * 
 * 
 * Example 1:
 * Input: n = 3
 * Output: ["((()))","(()())","(())()","()(())","()()()"]
 * Example 2:
 * Input: n = 1
 * Output: ["()"]
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= n <= 8
 * 
 * 
 */

// @lc code=start
using System.Runtime.CompilerServices;

public partial class Solution
{
    public void GenerateParenthesisSub(int n, int left, int right, string current, IList<string> result)
    {
        if (left == n && right == n)
        {
            result.Add(current);
            return;
        }
        if (left > n) return;
        if (right > left) return;

        GenerateParenthesisSub(n, left + 1, right, current + "(", result);
        GenerateParenthesisSub(n, left, right + 1, current + ")", result);

    }
    public IList<string> GenerateParenthesis(int n)
    {
        var result = new List<string>();
        GenerateParenthesisSub(n, 0, 0, "", result);
        return result;
    }
}
// @lc code=end


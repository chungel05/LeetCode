/*
 * @lc app=leetcode id=3174 lang=csharp
 *
 * [3174] Clear Digits
 *
 * https://leetcode.com/problems/clear-digits/description/
 *
 * algorithms
 * Easy (73.23%)
 * Likes:    131
 * Dislikes: 3
 * Total Accepted:    64.7K
 * Total Submissions: 88K
 * Testcase Example:  '"abc"'
 *
 * You are given a string s.
 * 
 * Your task is to remove all digits by doing this operation repeatedly:
 * 
 * 
 * Delete the first digit and the closest non-digit character to its left.
 * 
 * 
 * Return the resulting string after removing all digits.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "abc"
 * 
 * Output: "abc"
 * 
 * Explanation:
 * 
 * There is no digit in the string.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "cb34"
 * 
 * Output: ""
 * 
 * Explanation:
 * 
 * First, we apply the operation on s[2], and s becomes "c4".
 * 
 * Then we apply the operation on s[1], and s becomes "".
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s.length <= 100
 * s consists only of lowercase English letters and digits.
 * The input is generated such that it is possible to delete all digits.
 * 
 * 
 */
/*
 * Simplify Stack Approach
 * Time: O(n), Space: O(n)
 */

// @lc code=start
using System.Text;

public partial class Solution
{
    public string ClearDigits(string s)
    {
        // using StringBuilder to improve performance
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
            // if it is not digit, push to stack, which is add to string
            if (!char.IsDigit(s[i]))
                sb.Append(s[i]);
            // if it is digit, ignore it and pop the top of stack, which is remove the last char
            else
                sb.Remove(sb.Length - 1, 1);
        }

        // since the string is computed, so no need to loop the stack again, which improve time and space complexity
        return sb.ToString();
    }
}
// @lc code=end


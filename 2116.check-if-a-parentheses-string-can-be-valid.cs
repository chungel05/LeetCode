/*
 * @lc app=leetcode id=2116 lang=csharp
 *
 * [2116] Check if a Parentheses String Can Be Valid
 *
 * https://leetcode.com/problems/check-if-a-parentheses-string-can-be-valid/description/
 *
 * algorithms
 * Medium (32.27%)
 * Likes:    1231
 * Dislikes: 56
 * Total Accepted:    33.5K
 * Total Submissions: 100.4K
 * Testcase Example:  '"))()))"\n"010100"'
 *
 * A parentheses string is a non-empty string consisting only of '(' and ')'.
 * It is valid if any of the following conditions is true:
 * 
 * 
 * It is ().
 * It can be written as AB (A concatenated with B), where A and B are valid
 * parentheses strings.
 * It can be written as (A), where A is a valid parentheses string.
 * 
 * 
 * You are given a parentheses string s and a string locked, both of length n.
 * locked is a binary string consisting only of '0's and '1's. For each index i
 * of locked,
 * 
 * 
 * If locked[i] is '1', you cannot change s[i].
 * But if locked[i] is '0', you can change s[i] to either '(' or ')'.
 * 
 * 
 * Return true if you can make s a valid parentheses string. Otherwise, return
 * false.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "))()))", locked = "010100"
 * Output: true
 * Explanation: locked[1] == '1' and locked[3] == '1', so we cannot change s[1]
 * or s[3].
 * We change s[0] and s[4] to '(' while leaving s[2] and s[5] unchanged to make
 * s valid.
 * 
 * Example 2:
 * 
 * 
 * Input: s = "()()", locked = "0000"
 * Output: true
 * Explanation: We do not need to make any changes because s is already
 * valid.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: s = ")", locked = "0"
 * Output: false
 * Explanation: locked permits us to change s[0]. 
 * Changing s[0] to either '(' or ')' will not make s valid.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * n == s.length == locked.length
 * 1 <= n <= 10^5
 * s[i] is either '(' or ')'.
 * locked[i] is either '0' or '1'.
 * 
 * 
 */
/*
 * Greedy approach
 * Time: O(n), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    // Left-to-Right and Right-to-Left check
    /* public bool CanBeValid(string s, string locked)
    {
        int n = s.Length;
        if (n % 2 == 1)
            return false;

        int balance = 0;
        for (int i = 0; i < n; i++)
        {
            if (locked[i] == '0' || s[i] == '(')
                balance++;
            else
                balance--;

            if (balance < 0)
                return false;
        }

        balance = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            if (locked[i] == '0' || s[i] == ')')
                balance++;
            else
                balance--;

            if (balance < 0)
                return false;
        }

        return true;
    } */

    public bool CanBeValid(string s, string locked)
    {
        int n = s.Length;
        // edge case: if odd num, cannot form valid pattern
        if (n % 2 == 1)
            return false;

        int maxOpen = 0, minOpen = 0;
        for (int i = 0; i < n; i++)
        {
            // if it can be flip
            if (locked[i] == '0')
            {
                // assume it is open
                maxOpen++;
                // assume it is close
                minOpen--;
            }
            else if (s[i] == '(')
            {
                // must be open
                maxOpen++;
                minOpen++;
            }
            else
            {
                // must be close
                maxOpen--;
                minOpen--;
            }

            // if max num of Open cannot fulfill Close, return false
            if (maxOpen < 0)
                return false;
            // if min num of Open < 0, reset to 0
            // we use it to check whether to much open at the end, i.e. ****)(
            if (minOpen < 0)
                minOpen = 0;
        }

        // after checking from Left-to-Right, basically Open + wildcard can fulfill Close
        // but we also need to confirm from Right-to-Left
        // which is indicated by minOpen == 0
        return minOpen == 0;
    }
}
// @lc code=end


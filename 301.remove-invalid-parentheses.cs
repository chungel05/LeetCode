/*
 * @lc app=leetcode id=301 lang=csharp
 *
 * [301] Remove Invalid Parentheses
 *
 * https://leetcode.com/problems/remove-invalid-parentheses/description/
 *
 * algorithms
 * Hard (48.60%)
 * Likes:    5914
 * Dislikes: 291
 * Total Accepted:    453.2K
 * Total Submissions: 930.6K
 * Testcase Example:  '"()())()"'
 *
 * Given a string s that contains parentheses and letters, remove the minimum
 * number of invalid parentheses to make the input string valid.
 * 
 * Return a list of unique strings that are valid with the minimum number of
 * removals. You may return the answer in any order.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "()())()"
 * Output: ["(())()","()()()"]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "(a)())()"
 * Output: ["(a())()","(a)()()"]
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: s = ")("
 * Output: [""]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s.length <= 25
 * s consists of lowercase English letters and parentheses '(' and ')'.
 * There will be at most 20 parentheses in s.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    private void DFSRemoveInvalidParentheses(string s, int i, int leftRemoval, int rightRemoval, int leftCount, int rightCount, string currS, HashSet<string> res)
    {
        // Base case, if end of string
        if (i == s.Length)
        {
            // if all left and right removal count are 0, it means that it is valid
            // we added to result
            if (leftRemoval == 0 && rightRemoval == 0)
                res.Add(currS);
            return;
        }

        // if remaining chars < left and right total removal count, it is invalid
        // if count of left '(' < count of right ')', it is invalid
        if (s.Length - i < leftRemoval + rightRemoval || leftCount < rightCount)
            return;

        char currChar = s[i];
        // curr char is '(', we can select to remove it if left removal count > 0
        if (currChar == '(' && leftRemoval > 0)
            DFSRemoveInvalidParentheses(s, i + 1, leftRemoval - 1, rightRemoval, leftCount, rightCount, currS, res);

        // curr char is ')', we can select to remove it if right removal count > 0
        if (currChar == ')' && rightRemoval > 0)
            DFSRemoveInvalidParentheses(s, i + 1, leftRemoval, rightRemoval - 1, leftCount, rightCount, currS, res);

        // keep curr char left '(' or right ')'
        int left = currChar == '(' ? 1 : 0;
        int right = currChar == ')' ? 1 : 0;
        DFSRemoveInvalidParentheses(s, i + 1, leftRemoval, rightRemoval, leftCount + left, rightCount + right, currS + currChar, res);
    }

    public IList<string> RemoveInvalidParentheses(string s)
    {
        // Count the open and close needed to remove
        // The remaining count of left and right are needed to remove
        int leftCount = 0, rightCount = 0;
        for (int i = 0; i < s.Length; i++)
        {
            // increase left if s[i] = '('
            if (s[i] == '(')
                leftCount++;
            else if (s[i] == ')')
            {
                // if s[i] = ')'
                // if we have left before, we can reduce it because it is () balanced pair
                if (leftCount > 0)
                    leftCount--;
                // otherwise, we need to remove additional ')'
                else
                    rightCount++;
            }
        }

        // Create HashSet to remove duplicated pattern
        HashSet<string> res = new HashSet<string>();

        // DFS to traversal all combination
        DFSRemoveInvalidParentheses(s, 0, leftCount, rightCount, 0, 0, "", res);
        return new List<string>(res);
    }
}
// @lc code=end


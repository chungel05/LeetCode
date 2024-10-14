/*
 * @lc app=leetcode id=20 lang=csharp
 *
 * [20] Valid Parentheses
 */

// @lc code=start
public partial class Solution
{
    public bool IsValid(string s)
    {
        Dictionary<char, char> dict = new Dictionary<char, char>(){
            {')', '('},
            {']', '['},
            {'}', '{'}
        };
        Stack<char> stack = new Stack<char>();

        foreach (char c in s)
        {
            if (dict.ContainsKey(c))
            {
                if (stack.Count == 0 || stack.Pop() != dict[c])
                    return false;
            }
            else
                stack.Push(c);
        }
        return stack.Count == 0;
    }
}
// @lc code=end


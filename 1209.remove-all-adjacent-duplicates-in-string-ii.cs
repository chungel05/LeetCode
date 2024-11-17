/*
 * @lc app=leetcode id=1209 lang=csharp
 *
 * [1209] Remove All Adjacent Duplicates in String II
 *
 * https://leetcode.com/problems/remove-all-adjacent-duplicates-in-string-ii/description/
 *
 * algorithms
 * Medium (58.39%)
 * Likes:    5835
 * Dislikes: 117
 * Total Accepted:    342.5K
 * Total Submissions: 584.3K
 * Testcase Example:  '"abcd"\n2'
 *
 * You are given a string s and an integer k, a k duplicate removal consists of
 * choosing k adjacent and equal letters from s and removing them, causing the
 * left and the right side of the deleted substring to concatenate together.
 * 
 * We repeatedly make k duplicate removals on s until we no longer can.
 * 
 * Return the final string after all such duplicate removals have been made. It
 * is guaranteed that the answer is unique.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "abcd", k = 2
 * Output: "abcd"
 * Explanation: There's nothing to delete.
 * 
 * Example 2:
 * 
 * 
 * Input: s = "deeedbbcccbdaa", k = 3
 * Output: "aa"
 * Explanation: 
 * First delete "eee" and "ccc", get "ddbbbdaa"
 * Then delete "bbb", get "dddaa"
 * Finally delete "ddd", get "aa"
 * 
 * Example 3:
 * 
 * 
 * Input: s = "pbbcggttciiippooaais", k = 2
 * Output: "ps"
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s.length <= 10^5
 * 2 <= k <= 10^4
 * s only contains lowercase English letters.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public string RemoveDuplicates(string s, int k)
    {
        Stack<(char c, int count)> stack = new Stack<(char c, int count)>();

        for (int i = 0; i < s.Length; i++)
        {
            if (stack.TryPeek(out var element))
            {
                if (s[i] == element.c)
                {
                    element.count++;
                    stack.Pop();
                    if (element.count < k)
                        stack.Push((element.c, element.count));
                }
                else
                    stack.Push((s[i], 1));
            }
            else
                stack.Push((s[i], 1));
        }

        string res = "";
        while (stack.Count > 0)
        {
            (char c, int count) = stack.Pop();
            char[] tmp = new char[count];
            Array.Fill(tmp, c);

            res = string.Join("", tmp) + res;
        }
        return res;
    }
}
// @lc code=end


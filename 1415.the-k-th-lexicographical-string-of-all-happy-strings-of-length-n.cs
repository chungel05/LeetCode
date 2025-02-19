/*
 * @lc app=leetcode id=1415 lang=csharp
 *
 * [1415] The k-th Lexicographical String of All Happy Strings of Length n
 *
 * https://leetcode.com/problems/the-k-th-lexicographical-string-of-all-happy-strings-of-length-n/description/
 *
 * algorithms
 * Medium (75.15%)
 * Likes:    993
 * Dislikes: 27
 * Total Accepted:    44.9K
 * Total Submissions: 59.7K
 * Testcase Example:  '1\n3'
 *
 * A happy string is a string that:
 * 
 * 
 * consists only of letters of the set ['a', 'b', 'c'].
 * s[i] != s[i + 1] for all values of i from 1 to s.length - 1 (string is
 * 1-indexed).
 * 
 * 
 * For example, strings "abc", "ac", "b" and "abcbabcbcb" are all happy strings
 * and strings "aa", "baa" and "ababbc" are not happy strings.
 * 
 * Given two integers n and k, consider a list of all happy strings of length n
 * sorted in lexicographical order.
 * 
 * Return the kth string of this list or return an empty string if there are
 * less than k happy strings of length n.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: n = 1, k = 3
 * Output: "c"
 * Explanation: The list ["a", "b", "c"] contains all happy strings of length
 * 1. The third string is "c".
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: n = 1, k = 4
 * Output: ""
 * Explanation: There are only 3 happy strings of length 1.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: n = 3, k = 9
 * Output: "cab"
 * Explanation: There are 12 different happy string of length 3 ["aba", "abc",
 * "aca", "acb", "bab", "bac", "bca", "bcb", "cab", "cac", "cba", "cbc"]. You
 * will find the 9^th string = "cab"
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= n <= 10
 * 1 <= k <= 100
 * 
 * 
 */

// @lc code=start
using System.Text;

public partial class Solution
{
    // DFS Backtracking Approach
    // Time: O(2^n), Space: O(n)
    /* private void DFSGetHappyString(int n, int k, string currPath, List<string> paths)
    {
        if (paths.Count == k)
            return;

        if (currPath.Length == n)
        {
            paths.Add(currPath);
            return;
        }

        for (char i = 'a'; i <= 'c'; i++)
        {
            if (currPath.Length > 0 && currPath[currPath.Length - 1] == i)
                continue;

            DFSGetHappyString(n, k, currPath + i, paths);
        }
    } */

    // Math Approach
    // Time: O(n), Space: O(1)
    // Total combination = 3 * 2^(n-1)
    // First identify the first char (3), then can check by 2 different group to find out the next char (2^(n-1))
    public string GetHappyString(int n, int k)
    {
        int total = 3 * (1 << (n - 1));
        if (k > total)
            return "";

        StringBuilder sb = new StringBuilder();

        // first char
        // check whether first char is [a, b, c]
        int curr = 0;
        for (int i = 0; i < 3; i++)
        {
            if (curr + (1 << (n - 1)) >= k)
            {
                sb.Append((char)('a' + i));
                break;
            }
            curr += (1 << (n - 1));
        }

        // other chars
        for (int i = 1; i < n; i++)
        {
            int mid = (1 << (n - 1 - i));
            // group of smaller than mid-point
            // [a: b], [b: a], [c: a]
            if (curr + mid >= k)
            {
                sb.Append(sb[sb.Length - 1] == 'a' ? 'b' : 'a');
            }
            // group of larger than mid-point
            // [a: c], [b: c], [c: b]
            else
            {
                sb.Append(sb[sb.Length - 1] == 'c' ? 'b' : 'c');
                curr += mid;
            }
        }
        return sb.ToString();
    }
}
// @lc code=end


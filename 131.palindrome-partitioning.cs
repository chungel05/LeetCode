/*
 * @lc app=leetcode id=131 lang=csharp
 *
 * [131] Palindrome Partitioning
 *
 * https://leetcode.com/problems/palindrome-partitioning/description/
 *
 * algorithms
 * Medium (70.42%)
 * Likes:    13099
 * Dislikes: 511
 * Total Accepted:    984.6K
 * Total Submissions: 1.4M
 * Testcase Example:  '"aab"'
 *
 * Given a string s, partition s such that every substring of the partition is
 * a palindrome. Return all possible palindrome partitioning of s.
 * 
 * 
 * Example 1:
 * Input: s = "aab"
 * Output: [["a","a","b"],["aa","b"]]
 * Example 2:
 * Input: s = "a"
 * Output: [["a"]]
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s.length <= 16
 * s contains only lowercase English letters.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public bool CheckPalindrome(string s)
    {
        int left = 0, right = s.Length - 1;

        while (left < right)
        {
            if (s[left] != s[right])
                return false;
            left++;
            right--;
        }
        return true;
    }

    public IList<IList<string>> Partition(string s)
    {
        List<IList<string>> res = new List<IList<string>>();
        string currWord = "";
        for (int i = 0; i < s.Length; i++)
        {
            currWord += s[i];
            if (currWord.Length == 1 || CheckPalindrome(currWord))
            {
                if (i + 1 == s.Length)
                    res.Add(new List<string>() { currWord });
                else
                {
                    foreach (var list in Partition(s.Substring(i + 1)))
                    {
                        List<string> tmp = new List<string>() { currWord };
                        tmp.AddRange(list);
                        res.Add(tmp);
                    }
                }
            }
        }
        return res;
    }
}
// @lc code=end


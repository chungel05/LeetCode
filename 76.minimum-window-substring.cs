/*
 * @lc app=leetcode id=76 lang=csharp
 *
 * [76] Minimum Window Substring
 *
 * https://leetcode.com/problems/minimum-window-substring/description/
 *
 * algorithms
 * Hard (43.82%)
 * Likes:    18177
 * Dislikes: 751
 * Total Accepted:    1.5M
 * Total Submissions: 3.4M
 * Testcase Example:  '"ADOBECODEBANC"\n"ABC"'
 *
 * Given two strings s and t of lengths m and n respectively, return the
 * minimum window substring of s such that every character in t (including
 * duplicates) is included in the window. If there is no such substring, return
 * the empty string "".
 * 
 * The testcases will be generated such that the answer is unique.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "ADOBECODEBANC", t = "ABC"
 * Output: "BANC"
 * Explanation: The minimum window substring "BANC" includes 'A', 'B', and 'C'
 * from string t.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "a", t = "a"
 * Output: "a"
 * Explanation: The entire string s is the minimum window.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: s = "a", t = "aa"
 * Output: ""
 * Explanation: Both 'a's from t must be included in the window.
 * Since the largest window of s only has one 'a', return empty string.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * m == s.length
 * n == t.length
 * 1 <= m, n <= 10^5
 * s and t consist of uppercase and lowercase English letters.
 * 
 * 
 * 
 * Follow up: Could you find an algorithm that runs in O(m + n) time?
 * 
 */

// @lc code=start
public partial class Solution
{
    public string MinWindow(string s, string t)
    {
        if (s.Length < t.Length)
            return "";

        Dictionary<char, int> tCount = new Dictionary<char, int>();
        foreach (char c in t)
        {
            if (tCount.ContainsKey(c))
                tCount[c]++;
            else
                tCount[c] = 1;
        }

        int left = 0, minLen = s.Length + 1, minStart = 0, matched = 0;
        for (int right = 0; right < s.Length; right++)
        {
            if (tCount.ContainsKey(s[right]))
            {
                tCount[s[right]]--;
                if (tCount[s[right]] == 0)
                    matched++;
            }

            while (matched == tCount.Count)
            {
                if (minLen > right - left + 1)
                {
                    minLen = right - left + 1;
                    minStart = left;
                }

                char leftChar = s[left];
                left++;
                if (tCount.ContainsKey(leftChar))
                {
                    if (tCount[leftChar] == 0)
                        matched--;
                    tCount[leftChar]++;
                }
            }
        }
        return minLen > s.Length ? "" : s.Substring(minStart, minLen);
    }
}
// @lc code=end


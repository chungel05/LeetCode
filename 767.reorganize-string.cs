/*
 * @lc app=leetcode id=767 lang=csharp
 *
 * [767] Reorganize String
 *
 * https://leetcode.com/problems/reorganize-string/description/
 *
 * algorithms
 * Medium (55.10%)
 * Likes:    8674
 * Dislikes: 264
 * Total Accepted:    441.3K
 * Total Submissions: 797.5K
 * Testcase Example:  '"aab"'
 *
 * Given a string s, rearrange the characters of s so that any two adjacent
 * characters are not the same.
 * 
 * Return any possible rearrangement of s or return "" if not possible.
 * 
 * 
 * Example 1:
 * Input: s = "aab"
 * Output: "aba"
 * Example 2:
 * Input: s = "aaab"
 * Output: ""
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s.length <= 500
 * s consists of lowercase English letters.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public string ReorganizeString(string s)
    {
        Dictionary<char, int> dict = new Dictionary<char, int>();
        PriorityQueue<char, int> maxheap = new PriorityQueue<char, int>();
        Queue<char> q = new Queue<char>();

        for (int i = 0; i < s.Length; i++)
        {
            if (!dict.ContainsKey(s[i]))
                dict[s[i]] = 0;
            dict[s[i]]++;
        }

        foreach (var pair in dict)
            maxheap.Enqueue(pair.Key, -pair.Value);

        string res = "";
        char prev = ' ';
        while (maxheap.Count > 0 || q.Count > 0)
        {
            if (maxheap.Count == 0 && q.Count > 0 && q.Peek() == prev)
                break;
            while (q.Count > 0 && q.Peek() != prev)
            {
                char tmp = q.Dequeue();
                maxheap.Enqueue(tmp, -dict[tmp]);
            }
            if (maxheap.Count > 0)
            {
                char c = maxheap.Dequeue();
                res += c;
                dict[c]--;

                if (dict[c] != 0)
                    q.Enqueue(c);

                prev = c;
            }
        }

        return q.Count > 0 ? "" : res;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=763 lang=csharp
 *
 * [763] Partition Labels
 *
 * https://leetcode.com/problems/partition-labels/description/
 *
 * algorithms
 * Medium (80.05%)
 * Likes:    10380
 * Dislikes: 404
 * Total Accepted:    570.3K
 * Total Submissions: 712.2K
 * Testcase Example:  '"ababcbacadefegdehijhklij"'
 *
 * You are given a string s. We want to partition the string into as many parts
 * as possible so that each letter appears in at most one part.
 * 
 * Note that the partition is done so that after concatenating all the parts in
 * order, the resultant string should be s.
 * 
 * Return a list of integers representing the size of these parts.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "ababcbacadefegdehijhklij"
 * Output: [9,7,8]
 * Explanation:
 * The partition is "ababcbaca", "defegde", "hijhklij".
 * This is a partition so that each letter appears in at most one part.
 * A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it
 * splits s into less parts.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "eccbbbbdec"
 * Output: [10]
 * 
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
    public IList<int> PartitionLabels(string s)
    {
        // Record last position of each char
        Dictionary<char, int> count = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            count[s[i]] = i;
        }

        int last = 0;
        int start = 0;
        List<int> res = new List<int>();
        for (int i = 0; i < s.Length; i++)
        {
            // looping char and get the largest index
            last = Math.Max(count[s[i]], last);

            // if we stand at last index, add to result
            if (last == i)
            {
                res.Add(last - start + 1);
                start = last + 1;
            }
        }
        return res;
    }
}
// @lc code=end


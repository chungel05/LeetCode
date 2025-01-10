/*
 * @lc app=leetcode id=916 lang=csharp
 *
 * [916] Word Subsets
 *
 * https://leetcode.com/problems/word-subsets/description/
 *
 * algorithms
 * Medium (51.78%)
 * Likes:    2731
 * Dislikes: 237
 * Total Accepted:    118.4K
 * Total Submissions: 229.1K
 * Testcase Example:  '["amazon","apple","facebook","google","leetcode"]\n["e","o"]'
 *
 * You are given two string arrays words1 and words2.
 * 
 * A string b is a subset of string a if every letter in b occurs in a
 * including multiplicity.
 * 
 * 
 * For example, "wrr" is a subset of "warrior" but is not a subset of
 * "world".
 * 
 * 
 * A string a from words1 is universal if for every string b in words2, b is a
 * subset of a.
 * 
 * Return an array of all the universal strings in words1. You may return the
 * answer in any order.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: words1 = ["amazon","apple","facebook","google","leetcode"], words2 =
 * ["e","o"]
 * Output: ["facebook","google","leetcode"]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: words1 = ["amazon","apple","facebook","google","leetcode"], words2 =
 * ["l","e"]
 * Output: ["apple","google","leetcode"]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= words1.length, words2.length <= 10^4
 * 1 <= words1[i].length, words2[i].length <= 10
 * words1[i] and words2[i] consist only of lowercase English letters.
 * All the strings of words1 are unique.
 * 
 * 
 */
/*
 * Brute force approach
 * Time: O(n1 + n2), Space: O(26) => O(1)
 */

// @lc code=start
public partial class Solution
{
    public IList<string> WordSubsets(string[] words1, string[] words2)
    {
        int[] words2Map = new int[26];
        // for each word in words2, count the occurrences of char
        // Compare with prev result, only get the max occurrences of char
        // Time: O(n2 * m) => O(n2) which constraint is m <= 10
        for (int i = 0; i < words2.Length; i++)
        {
            int[] tmpCount = new int[26];
            for (int j = 0; j < words2[i].Length; j++)
            {
                int c = words2[i][j] - 'a';
                tmpCount[c]++;
                words2Map[c] = Math.Max(words2Map[c], tmpCount[c]);
            }
        }

        List<string> res = new List<string>();
        // for each word in words1, we compare the occurrences of char with words2 array
        // if it is smaller than words2 requirement, then it is not universal
        // Time: O(n1 * m) => O(n1) which constraint is m <= 10
        for (int i = 0; i < words1.Length; i++)
        {
            int[] words1Map = new int[26];
            for (int j = 0; j < words1[i].Length; j++)
                words1Map[words1[i][j] - 'a']++;

            // assume it is universal
            res.Add(words1[i]);
            for (int j = 0; j < 26; j++)
            {
                if (words1Map[j] < words2Map[j])
                {
                    // since it is not fulfil the requirement, so we remove it
                    res.RemoveAt(res.Count - 1);
                    break;
                }
            }
        }

        return res;
    }
}
// @lc code=end


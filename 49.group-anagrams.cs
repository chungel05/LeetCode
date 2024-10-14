/*
 * @lc app=leetcode id=49 lang=csharp
 *
 * [49] Group Anagrams
 *
 * https://leetcode.com/problems/group-anagrams/description/
 *
 * algorithms
 * Medium (69.55%)
 * Likes:    19573
 * Dislikes: 641
 * Total Accepted:    3.2M
 * Total Submissions: 4.6M
 * Testcase Example:  '["eat","tea","tan","ate","nat","bat"]'
 *
 * Given an array of strings strs, group the anagrams together. You can return
 * the answer in any order.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: strs = ["eat","tea","tan","ate","nat","bat"]
 * 
 * Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
 * 
 * Explanation:
 * 
 * 
 * There is no string in strs that can be rearranged to form "bat".
 * The strings "nat" and "tan" are anagrams as they can be rearranged to form
 * each other.
 * The strings "ate", "eat", and "tea" are anagrams as they can be rearranged
 * to form each other.
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: strs = [""]
 * 
 * Output: [[""]]
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: strs = ["a"]
 * 
 * Output: [["a"]]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= strs.length <= 10^4
 * 0 <= strs[i].length <= 100
 * strs[i] consists of lowercase English letters.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();

        foreach (string str in strs)
        {
            char[] charArray = str.ToCharArray();
            Array.Sort(charArray);
            string sortedStr = new string(charArray);
            if (result.ContainsKey(sortedStr))
                result[sortedStr].Add(str);
            else
                result[sortedStr] = new List<string>() { str };
        }

        return result.Values.Cast<IList<string>>().ToList();
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=2559 lang=csharp
 *
 * [2559] Count Vowel Strings in Ranges
 *
 * https://leetcode.com/problems/count-vowel-strings-in-ranges/description/
 *
 * algorithms
 * Medium (52.94%)
 * Likes:    552
 * Dislikes: 34
 * Total Accepted:    49.5K
 * Total Submissions: 83.2K
 * Testcase Example:  '["aba","bcb","ece","aa","e"]\n[[0,2],[1,4],[1,1]]'
 *
 * You are given a 0-indexed array of strings words and a 2D array of integers
 * queries.
 * 
 * Each query queries[i] = [li, ri] asks us to find the number of strings
 * present in the range li to ri (both inclusive) of words that start and end
 * with a vowel.
 * 
 * Return an array ans of size queries.length, where ans[i] is the answer to
 * the i^th query.
 * 
 * Note that the vowel letters are 'a', 'e', 'i', 'o', and 'u'.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: words = ["aba","bcb","ece","aa","e"], queries = [[0,2],[1,4],[1,1]]
 * Output: [2,3,0]
 * Explanation: The strings starting and ending with a vowel are "aba", "ece",
 * "aa" and "e".
 * The answer to the query [0,2] is 2 (strings "aba" and "ece").
 * to query [1,4] is 3 (strings "ece", "aa", "e").
 * to query [1,1] is 0.
 * We return [2,3,0].
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: words = ["a","e","i"], queries = [[0,2],[0,1],[2,2]]
 * Output: [3,2,1]
 * Explanation: Every string satisfies the conditions, so we return [3,2,1].
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= words.length <= 10^5
 * 1 <= words[i].length <= 40
 * words[i] consists only of lowercase English letters.
 * sum(words[i].length) <= 3 * 10^5
 * 1 <= queries.length <= 10^5
 * 0 <= li <= ri < words.length
 * 
 * 
 */
/*
 * Time: O(n), Space: O(n) - prefixSum
 */

// @lc code=start
public partial class Solution
{
    public int[] VowelStrings(string[] words, int[][] queries)
    {
        HashSet<char> vowel = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u' };
        int[] prefixSum = new int[words.Length + 1];

        // Since the queries [i, j] is checking the vowel from left [i] to right [j]
        // so we can pre-calc the prefixSum of [0...i...j...n - 1]
        for (int i = 0; i < words.Length; i++)
        {
            int n = words[i].Length;
            // if start and end are vowel, we add count, and assign the prefixSum
            if (vowel.Contains(words[i][0]) && vowel.Contains(words[i][n - 1]))
                prefixSum[i + 1] = prefixSum[i] + 1;
            else
                prefixSum[i + 1] = prefixSum[i];
        }

        int[] ans = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            // ans of queries [i, j] = prefixSum[j + 1] - prefixSum[i]
            ans[i] = prefixSum[queries[i][1] + 1] - prefixSum[queries[i][0]];
        }
        return ans;
    }
}
// @lc code=end


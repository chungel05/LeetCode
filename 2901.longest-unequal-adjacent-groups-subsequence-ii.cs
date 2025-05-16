/*
 * @lc app=leetcode id=2901 lang=csharp
 *
 * [2901] Longest Unequal Adjacent Groups Subsequence II
 *
 * https://leetcode.com/problems/longest-unequal-adjacent-groups-subsequence-ii/description/
 *
 * algorithms
 * Medium (27.46%)
 * Likes:    231
 * Dislikes: 38
 * Total Accepted:    15.5K
 * Total Submissions: 49.3K
 * Testcase Example:  '["bab","dab","cab"]\n[1,2,2]'
 *
 * You are given a string array words, and an array groups, both arrays having
 * length n.
 * 
 * The hamming distance between two strings of equal length is the number of
 * positions at which the corresponding characters are different.
 * 
 * You need to select the longest subsequence from an array of indices [0, 1,
 * ..., n - 1], such that for the subsequence denoted as [i0, i1, ..., ik-1]
 * having length k, the following holds:
 * 
 * 
 * For adjacent indices in the subsequence, their corresponding groups are
 * unequal, i.e., groups[ij] != groups[ij+1], for each j where 0 < j + 1 <
 * k.
 * words[ij] and words[ij+1] are equal in length, and the hamming distance
 * between them is 1, where 0 < j + 1 < k, for all indices in the
 * subsequence.
 * 
 * 
 * Return a string array containing the words corresponding to the indices (in
 * order) in the selected subsequence. If there are multiple answers, return
 * any of them.
 * 
 * Note: strings in words may be unequal in length.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: words = ["bab","dab","cab"], groups = [1,2,2]
 * 
 * Output: ["bab","cab"]
 * 
 * Explanation: A subsequence that can be selected is [0,2].
 * 
 * 
 * groups[0] != groups[2]
 * words[0].length == words[2].length, and the hamming distance between them is
 * 1.
 * 
 * 
 * So, a valid answer is [words[0],words[2]] = ["bab","cab"].
 * 
 * Another subsequence that can be selected is [0,1].
 * 
 * 
 * groups[0] != groups[1]
 * words[0].length == words[1].length, and the hamming distance between them is
 * 1.
 * 
 * 
 * So, another valid answer is [words[0],words[1]] = ["bab","dab"].
 * 
 * It can be shown that the length of the longest subsequence of indices that
 * satisfies the conditions is 2.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: words = ["a","b","c","d"], groups = [1,2,3,4]
 * 
 * Output: ["a","b","c","d"]
 * 
 * Explanation: We can select the subsequence [0,1,2,3].
 * 
 * It satisfies both conditions.
 * 
 * Hence, the answer is [words[0],words[1],words[2],words[3]] =
 * ["a","b","c","d"].
 * 
 * It has the longest length among all subsequences of indices that satisfy the
 * conditions.
 * 
 * Hence, it is the only answer.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= n == words.length == groups.length <= 1000
 * 1 <= words[i].length <= 10
 * 1 <= groups[i] <= n
 * words consists of distinct strings.
 * words[i] consists of lowercase English letters.
 * 
 * 
 */
/*
 * DP Approach
 * Time: O(n^2 * l) where l is average length of words, Space: O(n)
 */

// @lc code=start
public partial class Solution
{
    // when w1.Length == w2.Length, find the hamming distance
    // if res != 1, return false
    private bool CheckWordsInLongestSubsequence(string w1, string w2)
    {
        int res = 0;
        for (int i = 0; i < w1.Length; i++)
        {
            if (w1[i] != w2[i])
                res++;

            // return false quickly when res > 1
            if (res > 1)
                return false;
        }
        return res == 1;
    }

    public IList<string> GetWordsInLongestSubsequence(string[] words, int[] groups)
    {
        int n = groups.Length;
        // record the max valid length ended at index i 
        int[] dp = new int[n];
        // record the prev index j that can connect with index i
        int[] prev = new int[n];
        // the end index of max valid length
        int endIdx = 0;

        // initialization
        for (int i = 0; i < n; i++)
        {
            dp[i] = 1;
            prev[i] = -1;
        }

        // for each index i, find the possible words[j] that can connect with under all conditions
        for (int i = 0; i < n; i++)
        {
            for (int j = i - 1; j >= 0; j--)
            {
                // 3 invalid conditions
                if (groups[j] == groups[i] || words[j].Length != words[i].Length || !CheckWordsInLongestSubsequence(words[j], words[i]))
                    continue;

                // update max length ended at index i
                if (dp[j] + 1 > dp[i])
                {
                    dp[i] = dp[j] + 1;
                    prev[i] = j;
                }
            }

            // update the end index
            if (dp[i] > dp[endIdx])
                endIdx = i;
        }

        // start from end index, backtracking to construct the ans
        List<string> ans = new List<string>();
        for (int i = endIdx; i != -1; i = prev[i])
            ans.Insert(0, words[i]);

        return ans;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=2900 lang=csharp
 *
 * [2900] Longest Unequal Adjacent Groups Subsequence I
 *
 * https://leetcode.com/problems/longest-unequal-adjacent-groups-subsequence-i/description/
 *
 * algorithms
 * Easy (61.94%)
 * Likes:    207
 * Dislikes: 102
 * Total Accepted:    39K
 * Total Submissions: 65.2K
 * Testcase Example:  '["c"]\n[0]'
 *
 * You are given a string array words and a binary array groups both of length
 * n, where words[i] is associated with groups[i].
 * 
 * Your task is to select the longest alternating subsequence from words. A
 * subsequence of words is alternating if for any two consecutive strings in
 * the sequence, their corresponding elements in the binary array groups
 * differ. Essentially, you are to choose strings such that adjacent elements
 * have non-matching corresponding bits in the groups array.
 * 
 * Formally, you need to find the longest subsequence of an array of indices
 * [0, 1, ..., n - 1] denoted as [i0, i1, ..., ik-1], such that groups[ij] !=
 * groups[ij+1] for each 0 <= j < k - 1 and then find the words corresponding
 * to these indices.
 * 
 * Return the selected subsequence. If there are multiple answers, return any
 * of them.
 * 
 * Note: The elements in words are distinct.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: words = ["e","a","b"], groups = [0,0,1]
 * 
 * Output: ["e","b"]
 * 
 * Explanation: A subsequence that can be selected is ["e","b"] because
 * groups[0] != groups[2]. Another subsequence that can be selected is
 * ["a","b"] because groups[1] != groups[2]. It can be demonstrated that the
 * length of the longest subsequence of indices that satisfies the condition is
 * 2.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: words = ["a","b","c","d"], groups = [1,0,1,1]
 * 
 * Output: ["a","b","c"]
 * 
 * Explanation: A subsequence that can be selected is ["a","b","c"] because
 * groups[0] != groups[1] and groups[1] != groups[2]. Another subsequence that
 * can be selected is ["a","b","d"] because groups[0] != groups[1] and
 * groups[1] != groups[3]. It can be shown that the length of the longest
 * subsequence of indices that satisfies the condition is 3.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= n == words.length == groups.length <= 100
 * 1 <= words[i].length <= 10
 * groups[i] is either 0 or 1.
 * words consists of distinct strings.
 * words[i] consists of lowercase English letters.
 * 
 * 
 */
/*
 * Greedy Approach
 * Time: O(n), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    // In DP Approach, we need to find the valid max length end at index i
    // such that dp[i] = max(dp[i], dp[j] + 1), where j < i and groups[j] != group[i]
    // so we can loop for index i and j to find the max length
    // which is O(n^2)

    // Actually we can simplify it,
    // the valid max length must come from the last dp[j] + 1, where j < i and groups[j] != group[i]
    // that means each groups[i] can form a sub group
    // i.e. [[0,0,0], [1,1], [0], [1], [0,0]]
    // the max length must be same as sub groups
    // so we can just get one of the elements from each sub group
    public IList<string> GetLongestSubsequence(string[] words, int[] groups)
    {
        List<string> ans = new List<string>();
        for (int i = 0; i < groups.Length; i++)
        {
            // get the first element of each sub group, which is the turning point
            if (i == 0 || groups[i] != groups[i - 1])
                ans.Add(words[i]);
        }
        return ans;
    }
}
// @lc code=end


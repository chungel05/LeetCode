/*
 * @lc app=leetcode id=873 lang=csharp
 *
 * [873] Length of Longest Fibonacci Subsequence
 *
 * https://leetcode.com/problems/length-of-longest-fibonacci-subsequence/description/
 *
 * algorithms
 * Medium (48.45%)
 * Likes:    2174
 * Dislikes: 84
 * Total Accepted:    86.7K
 * Total Submissions: 170.3K
 * Testcase Example:  '[1,2,3,4,5,6,7,8]'
 *
 * A sequence x1, x2, ..., xn is Fibonacci-like if:
 * 
 * 
 * n >= 3
 * xi + xi+1 == xi+2 for all i + 2 <= n
 * 
 * 
 * Given a strictly increasing array arr of positive integers forming a
 * sequence, return the length of the longest Fibonacci-like subsequence of
 * arr. If one does not exist, return 0.
 * 
 * A subsequence is derived from another sequence arr by deleting any number of
 * elements (including none) from arr, without changing the order of the
 * remaining elements. For example, [3, 5, 8] is a subsequence of [3, 4, 5, 6,
 * 7, 8].
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: arr = [1,2,3,4,5,6,7,8]
 * Output: 5
 * Explanation: The longest subsequence that is fibonacci-like: [1,2,3,5,8].
 * 
 * Example 2:
 * 
 * 
 * Input: arr = [1,3,7,11,12,14,18]
 * Output: 3
 * Explanation: The longest subsequence that is fibonacci-like: [1,11,12],
 * [3,11,14] or [7,11,18].
 * 
 * 
 * Constraints:
 * 
 * 
 * 3 <= arr.length <= 1000
 * 1 <= arr[i] < arr[i + 1] <= 10^9
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    // DFS Top-down Approach (memoization)
    // Time: O(n^2), Space: O(n^2)
    /* private int DFSLenLongestFibSubseq(int[] arr, int i, int j, Dictionary<int, int> idxMap, int[][] dp)
    {
        if (!idxMap.ContainsKey(arr[i] + arr[j]))
            return 0;

        if (dp[i][j] != -1)
            return dp[i][j];

        // continue to find the next number
        dp[i][j] = 1 + DFSLenLongestFibSubseq(arr, j, idxMap[arr[i] + arr[j]], idxMap, dp);
        return dp[i][j];
    }

    public int LenLongestFibSubseq(int[] arr)
    {
        Dictionary<int, int> idxMap = new Dictionary<int, int>();
        int[][] dp = new int[arr.Length][];
        for (int i = 0; i < arr.Length; i++)
        {
            idxMap[arr[i]] = i;
            dp[i] = new int[arr.Length];
            Array.Fill(dp[i], -1);
        }

        int maxLen = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                // if already computed, no need to check again
                if (dp[i][j] != -1)
                    continue;

                maxLen = Math.Max(maxLen, DFSLenLongestFibSubseq(arr, i, j, idxMap, dp));
            }
        }
        // as the result only count the no. of elements after first 2 nums, so needed to add 2
        return maxLen == 0 ? 0 : maxLen + 2;
    } */

    // Bottom-up Approach
    // Time: O(n^2), Space: O(n^2)
    public int LenLongestFibSubseq(int[] arr)
    {
        // use dictionary to check the existence and corresponding index
        Dictionary<int, int> idxMap = new Dictionary<int, int>();
        int[][] dp = new int[arr.Length][];
        for (int i = 0; i < arr.Length; i++)
        {
            idxMap[arr[i]] = i;
            // initialized dp
            dp[i] = new int[arr.Length];
            Array.Fill(dp[i], -1);
        }

        int maxLen = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                // pattern: diff(Xi) + arr[j](Xi+1) = arr[i](Xi+2)
                int diff = arr[i] - arr[j];
                // if Xi found, then current dp[Xi+1][Xi+2] = dp[Xi][Xi+1] + 1
                if (diff < arr[j] && idxMap.TryGetValue(diff, out int idx))
                    dp[j][i] = dp[idx][j] + 1;
                // else it is length of 2
                else
                    dp[j][i] = 2;

                maxLen = Math.Max(maxLen, dp[j][i]);
            }
        }
        // if maxLen > 2, then it is valid Fibonacci-like seq, else 0
        return maxLen > 2 ? maxLen : 0;
    }
}
// @lc code=end


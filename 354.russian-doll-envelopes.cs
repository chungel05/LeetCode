/*
 * @lc app=leetcode id=354 lang=csharp
 *
 * [354] Russian Doll Envelopes
 *
 * https://leetcode.com/problems/russian-doll-envelopes/description/
 *
 * algorithms
 * Hard (37.09%)
 * Likes:    6100
 * Dislikes: 153
 * Total Accepted:    235.3K
 * Total Submissions: 634.4K
 * Testcase Example:  '[[5,4],[6,4],[6,7],[2,3]]'
 *
 * You are given a 2D array of integers envelopes where envelopes[i] = [wi, hi]
 * represents the width and the height of an envelope.
 * 
 * One envelope can fit into another if and only if both the width and height
 * of one envelope are greater than the other envelope's width and height.
 * 
 * Return the maximum number of envelopes you can Russian doll (i.e., put one
 * inside the other).
 * 
 * Note: You cannot rotate an envelope.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: envelopes = [[5,4],[6,4],[6,7],[2,3]]
 * Output: 3
 * Explanation: The maximum number of envelopes you can Russian doll is 3
 * ([2,3] => [5,4] => [6,7]).
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: envelopes = [[1,1],[1,1],[1,1]]
 * Output: 1
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= envelopes.length <= 10^5
 * envelopes[i].length == 2
 * 1 <= wi, hi <= 10^5
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int MaxEnvelopes(int[][] envelopes)
    {
        int[] dp = new int[envelopes.Length + 1];
        // Sort array, width in ascending, height in decending
        Array.Sort(envelopes, (x, y) =>
        {
            if (x[0] == y[0])
                return y[1].CompareTo(x[1]);
            return x[0].CompareTo(y[0]);
        });

        dp[1] = envelopes[0][1];
        int maxHeightIdx = 1;
        // do Largest Increasing Sequence in height
        for (int i = 1; i < envelopes.Length; i++)
        {
            int currHeight = envelopes[i][1];
            if (currHeight > dp[maxHeightIdx])
                dp[++maxHeightIdx] = currHeight;
            else
            {
                // Binary Search
                // find the smallest height in dp such that it is >= currHeight
                int left = 1, right = maxHeightIdx;
                while (left < right)
                {
                    int mid = (left + right) / 2;
                    if (dp[mid] >= currHeight)
                        right = mid;
                    else
                        left = mid + 1;
                }

                // update dp, to maintain it as strictly increasing
                // and with the smallest height possibility in each index
                dp[left] = currHeight;
            }
        }
        return maxHeightIdx;
    }
}
// @lc code=end


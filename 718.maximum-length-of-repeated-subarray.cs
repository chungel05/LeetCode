/*
 * @lc app=leetcode id=718 lang=csharp
 *
 * [718] Maximum Length of Repeated Subarray
 *
 * https://leetcode.com/problems/maximum-length-of-repeated-subarray/description/
 *
 * algorithms
 * Medium (50.97%)
 * Likes:    6872
 * Dislikes: 172
 * Total Accepted:    321.6K
 * Total Submissions: 630.9K
 * Testcase Example:  '[1,2,3,2,1]\n[3,2,1,4,7]'
 *
 * Given two integer arrays nums1 and nums2, return the maximum length of a
 * subarray that appears in both arrays.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums1 = [1,2,3,2,1], nums2 = [3,2,1,4,7]
 * Output: 3
 * Explanation: The repeated subarray with maximum length is [3,2,1].
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums1 = [0,0,0,0,0], nums2 = [0,0,0,0,0]
 * Output: 5
 * Explanation: The repeated subarray with maximum length is [0,0,0,0,0].
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums1.length, nums2.length <= 1000
 * 0 <= nums1[i], nums2[i] <= 100
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int FindLength(int[] nums1, int[] nums2)
    {
        int m = nums1.Length, n = nums2.Length;
        // create dp with dp[m+1][n+1], record the accumulated length of subarray in [i][j]
        int[][] dp = new int[m + 1][];

        // initialized dp with base case value = 0, no repeated subarray, i.e. len = 0
        for (int i = 0; i <= m; i++)
        {
            dp[i] = new int[n + 1];
            Array.Fill(dp[i], 0);
        }

        // use int max to trace the max len of repeated subarray, base case = 0
        int max = 0;
        // loop from bottom right to top left
        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                // if [i] == [j], so the len will be 1 + dp[i + 1][j + 1] which is next num in 1 and 2
                // else because [i] != [j], so len will remain 0
                if (nums1[i] == nums2[j])
                {
                    dp[i][j] = 1 + dp[i + 1][j + 1];
                    max = Math.Max(max, dp[i][j]);
                }
            }
        }
        return max;
    }
}
// @lc code=end


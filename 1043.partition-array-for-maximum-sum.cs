/*
 * @lc app=leetcode id=1043 lang=csharp
 *
 * [1043] Partition Array for Maximum Sum
 *
 * https://leetcode.com/problems/partition-array-for-maximum-sum/description/
 *
 * algorithms
 * Medium (76.73%)
 * Likes:    4788
 * Dislikes: 429
 * Total Accepted:    211.2K
 * Total Submissions: 275.3K
 * Testcase Example:  '[1,15,7,9,2,5,10]\n3'
 *
 * Given an integer array arr, partition the array into (contiguous) subarrays
 * of length at most k. After partitioning, each subarray has their values
 * changed to become the maximum value of that subarray.
 * 
 * Return the largest sum of the given array after partitioning. Test cases are
 * generated so that the answer fits in a 32-bit integer.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: arr = [1,15,7,9,2,5,10], k = 3
 * Output: 84
 * Explanation: arr becomes [15,15,15,9,10,10,10]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: arr = [1,4,1,5,7,3,6,1,9,9,3], k = 4
 * Output: 83
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: arr = [1], k = 1
 * Output: 1
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= arr.length <= 500
 * 0 <= arr[i] <= 10^9
 * 1 <= k <= arr.length
 * 
 * 
 */
/*
 * Time: O(n * k), Space: O(n)
 */

// @lc code=start
public partial class Solution
{
    public int MaxSumAfterPartitioning(int[] arr, int k)
    {
        // create 1D dp to store the max sum at position i
        // i.e. [1,15,7,9,2,5,10], at position n - 1, we only can get last 1 element, so the max sum = dp[n - 1] = 10
        int[] dp = new int[arr.Length + 1];

        // loop from the end to 0
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            int max = 0;
            // since we need to loop from i to at most k elements
            // so we need to check i + k and arr.Length which one is min
            for (int j = i; j < Math.Min(arr.Length, i + k); j++)
            {
                // get the max element
                max = Math.Max(max, arr[j]);

                // get the sum of subarray in different k cases
                // Sum = max * k (which is j - i + 1) + dp[j + 1] (which is max sum at j + 1 position)
                dp[i] = Math.Max(dp[i], max * (j - i + 1) + dp[j + 1]);
            }
        }
        return dp[0];
    }
}
// @lc code=end


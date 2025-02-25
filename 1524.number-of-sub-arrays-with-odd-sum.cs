/*
 * @lc app=leetcode id=1524 lang=csharp
 *
 * [1524] Number of Sub-arrays With Odd Sum
 *
 * https://leetcode.com/problems/number-of-sub-arrays-with-odd-sum/description/
 *
 * algorithms
 * Medium (43.84%)
 * Likes:    1399
 * Dislikes: 62
 * Total Accepted:    45K
 * Total Submissions: 101.5K
 * Testcase Example:  '[1,3,5]'
 *
 * Given an array of integers arr, return the number of subarrays with an odd
 * sum.
 * 
 * Since the answer can be very large, return it modulo 10^9 + 7.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: arr = [1,3,5]
 * Output: 4
 * Explanation: All subarrays are [[1],[1,3],[1,3,5],[3],[3,5],[5]]
 * All sub-arrays sum are [1,4,9,3,8,5].
 * Odd sums are [1,9,3,5] so the answer is 4.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: arr = [2,4,6]
 * Output: 0
 * Explanation: All subarrays are [[2],[2,4],[2,4,6],[4],[4,6],[6]]
 * All sub-arrays sum are [2,6,12,4,10,6].
 * All sub-arrays have even sum and the answer is 0.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: arr = [1,2,3,4,5,6,7]
 * Output: 16
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= arr.length <= 10^5
 * 1 <= arr[i] <= 100
 * 
 * 
 */
/*
 * Prefix Sum Approach
 * Time: O(n), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    // Prefix Sum Approach
    /* public int NumOfSubarrays(int[] arr)
    {
        int odd = 0;
        int even = 0;
        int sum = 0;
        long ans = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
            // even + even = even => even - even = even
            // odd + odd = even => even - odd = odd
            // odd + even = odd => odd - odd = even & odd - even = odd
            // so, in order to gen the odd combinations,
            // even sum need to find the PrefixSum[i] which is odd
            // odd sum need to find the PrefixSum[i] which is even + 1 (odd sum itself)
            if ((sum & 1) == 0)
            {
                ans += odd;
                even++;
            }
            else
            {
                ans += even + 1;
                odd++;
            }
        }
        return (int)(ans % (1e9 + 7));
    } */


    // Simplify Prefix Sum Approach
    // for every arr[i], it will gen i + 1 new combination from prev i combination
    // i.e. [1,2,3,4,5], when i = 4
    // new combinations: [5], [4,5], [3,4,5], [2,3,4,5], [1,2,3,4,5]
    // prev combinations: [4], [3,4], [2,3,4], [1,2,3,4]
    // if arr[i] is odd num, then overall new odd combinations = prev even combinations + 1 (5 itself)
    // if arr[i] is even num, then overall new odd combinations = prev odd combinations
    public int NumOfSubarrays(int[] arr)
    {
        int odd = 0;
        long ans = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            // if arr[i] is odd, new odd = prev even + 1 = i(total prev combinations) - prev odd + 1 (arr[i] itself)
            // if arr[i] is even, new odd = odd
            odd = (arr[i] & 1) == 0 ? odd : i - odd + 1;
            // add the new odd combinations
            ans += odd;
        }
        return (int)(ans % (1e9 + 7));
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=560 lang=csharp
 *
 * [560] Subarray Sum Equals K
 *
 * https://leetcode.com/problems/subarray-sum-equals-k/description/
 *
 * algorithms
 * Medium (44.19%)
 * Likes:    22115
 * Dislikes: 690
 * Total Accepted:    1.5M
 * Total Submissions: 3.3M
 * Testcase Example:  '[1,1,1]\n2'
 *
 * Given an array of integers nums and an integer k, return the total number of
 * subarrays whose sum equals to k.
 * 
 * A subarray is a contiguous non-empty sequence of elements within an
 * array.
 * 
 * 
 * Example 1:
 * Input: nums = [1,1,1], k = 2
 * Output: 2
 * Example 2:
 * Input: nums = [1,2,3], k = 3
 * Output: 2
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 2 * 10^4
 * -1000 <= nums[i] <= 1000
 * -10^7 <= k <= 10^7
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int SubarraySum(int[] nums, int k)
    {
        int res = 0, sum = 0;
        Dictionary<int, int> dict = new Dictionary<int, int>();

        // base case, if nums[i] == k, nums[i] - k = 0, which is subarray sum equal to k
        dict[0] = 1;

        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];

            // key = sum - k => sum - key = k, so every occurrance of key util nums[i] is possible subarray
            if (dict.ContainsKey(sum - k))
                res += dict[sum - k];

            // record occurrance
            if (dict.ContainsKey(sum))
                dict[sum]++;
            else
                dict[sum] = 1;
        }
        return res;
    }
}
// @lc code=end


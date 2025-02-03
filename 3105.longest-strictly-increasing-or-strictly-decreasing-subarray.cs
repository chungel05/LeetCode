/*
 * @lc app=leetcode id=3105 lang=csharp
 *
 * [3105] Longest Strictly Increasing or Strictly Decreasing Subarray
 *
 * https://leetcode.com/problems/longest-strictly-increasing-or-strictly-decreasing-subarray/description/
 *
 * algorithms
 * Easy (57.22%)
 * Likes:    171
 * Dislikes: 12
 * Total Accepted:    57.1K
 * Total Submissions: 96.1K
 * Testcase Example:  '[1,4,3,3,2]'
 *
 * You are given an array of integers nums. Return the length of the longest
 * subarray of nums which is either strictly increasing or strictly
 * decreasing.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [1,4,3,3,2]
 * 
 * Output: 2
 * 
 * Explanation:
 * 
 * The strictly increasing subarrays of nums are [1], [2], [3], [3], [4], and
 * [1,4].
 * 
 * The strictly decreasing subarrays of nums are [1], [2], [3], [3], [4],
 * [3,2], and [4,3].
 * 
 * Hence, we return 2.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [3,3,3,3]
 * 
 * Output: 1
 * 
 * Explanation:
 * 
 * The strictly increasing subarrays of nums are [3], [3], [3], and [3].
 * 
 * The strictly decreasing subarrays of nums are [3], [3], [3], and [3].
 * 
 * Hence, we return 1.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: nums = [3,2,1]
 * 
 * Output: 3
 * 
 * Explanation:
 * 
 * The strictly increasing subarrays of nums are [3], [2], and [1].
 * 
 * The strictly decreasing subarrays of nums are [3], [2], [1], [3,2], [2,1],
 * and [3,2,1].
 * 
 * Hence, we return 3.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 50
 * 1 <= nums[i] <= 50
 * 
 * 
 */
/*
 * Array Checking Approach
 * Time: O(n), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    public int LongestMonotonicSubarray(int[] nums)
    {
        int maxLen = 1, increasing = 1, decreasing = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            // Check max length of strictly increasing seq
            increasing = nums[i] > nums[i - 1] ? increasing + 1 : 1;
            // Check max length of strictly decreasing seq
            decreasing = nums[i] < nums[i - 1] ? decreasing + 1 : 1;
            maxLen = Math.Max(maxLen, Math.Max(increasing, decreasing));
        }

        return maxLen;
    }
}
// @lc code=end


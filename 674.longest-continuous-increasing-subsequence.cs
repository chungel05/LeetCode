/*
 * @lc app=leetcode id=674 lang=csharp
 *
 * [674] Longest Continuous Increasing Subsequence
 *
 * https://leetcode.com/problems/longest-continuous-increasing-subsequence/description/
 *
 * algorithms
 * Easy (50.57%)
 * Likes:    2367
 * Dislikes: 183
 * Total Accepted:    287.7K
 * Total Submissions: 567.5K
 * Testcase Example:  '[1,3,5,4,7]'
 *
 * Given an unsorted array of integers nums, return the length of the longest
 * continuous increasing subsequence (i.e. subarray). The subsequence must be
 * strictly increasing.
 * 
 * A continuous increasing subsequence is defined by two indices l and r (l <
 * r) such that it is [nums[l], nums[l + 1], ..., nums[r - 1], nums[r]] and for
 * each l <= i < r, nums[i] < nums[i + 1].
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [1,3,5,4,7]
 * Output: 3
 * Explanation: The longest continuous increasing subsequence is [1,3,5] with
 * length 3.
 * Even though [1,3,5,7] is an increasing subsequence, it is not continuous as
 * elements 5 and 7 are separated by element
 * 4.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [2,2,2,2,2]
 * Output: 1
 * Explanation: The longest continuous increasing subsequence is [2] with
 * length 1. Note that it must be strictly
 * increasing.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 10^4
 * -10^9 <= nums[i] <= 10^9
 * 
 * 
 */
/*
 * Time: O(n), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    public int FindLengthOfLCIS(int[] nums)
    {
        int max = 1, res = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            // if curr num > prev num, max++
            if (nums[i] > nums[i - 1])
                max += 1;
            // else reset to 1
            else
                max = 1;
            res = Math.Max(max, res);
        }
        return res;
    }
}
// @lc code=end


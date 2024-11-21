/*
 * @lc app=leetcode id=1004 lang=csharp
 *
 * [1004] Max Consecutive Ones III
 *
 * https://leetcode.com/problems/max-consecutive-ones-iii/description/
 *
 * algorithms
 * Medium (64.24%)
 * Likes:    8912
 * Dislikes: 150
 * Total Accepted:    756K
 * Total Submissions: 1.2M
 * Testcase Example:  '[1,1,1,0,0,0,1,1,1,1,0]\n2'
 *
 * Given a binary array nums and an integer k, return the maximum number of
 * consecutive 1's in the array if you can flip at most k 0's.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [1,1,1,0,0,0,1,1,1,1,0], k = 2
 * Output: 6
 * Explanation: [1,1,1,0,0,1,1,1,1,1,1]
 * Bolded numbers were flipped from 0 to 1. The longest subarray is
 * underlined.
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1], k = 3
 * Output: 10
 * Explanation: [0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,1,1,1,1]
 * Bolded numbers were flipped from 0 to 1. The longest subarray is
 * underlined.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 10^5
 * nums[i] is either 0 or 1.
 * 0 <= k <= nums.length
 * 
 * 
 */
/*
 * Time: O(n), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    public int LongestOnes(int[] nums, int k)
    {
        int l = 0, max = 0;
        for (int r = 0; r < nums.Length; r++)
        {
            if (nums[r] == 0)
                k--;

            // if k < 0, we move left pointer until we found first 0
            while (k < 0)
            {
                if (nums[l] == 0)
                    k++;
                l++;
            }

            max = Math.Max(max, r - l + 1);
        }
        return max;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=283 lang=csharp
 *
 * [283] Move Zeroes
 *
 * https://leetcode.com/problems/move-zeroes/description/
 *
 * algorithms
 * Easy (62.17%)
 * Likes:    17165
 * Dislikes: 491
 * Total Accepted:    3.5M
 * Total Submissions: 5.6M
 * Testcase Example:  '[0,1,0,3,12]'
 *
 * Given an integer array nums, move all 0's to the end of it while maintaining
 * the relative order of the non-zero elements.
 * 
 * Note that you must do this in-place without making a copy of the array.
 * 
 * 
 * Example 1:
 * Input: nums = [0,1,0,3,12]
 * Output: [1,3,12,0,0]
 * Example 2:
 * Input: nums = [0]
 * Output: [0]
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 10^4
 * -2^31 <= nums[i] <= 2^31 - 1
 * 
 * 
 * 
 * Follow up: Could you minimize the total number of operations done?
 */
/*
 * Two Pointers Approach - Same Direction
 * Time: O(n), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    public void MoveZeroes(int[] nums)
    {
        int l = 0;
        for (int r = 0; r < nums.Length; r++)
        {
            // find next the non-zero integer
            if (nums[r] != 0)
            {
                // swap with the most left hand side of zero
                // if l == r, it means no zero in front of r
                // we will also do the swap
                int tmp = nums[l];
                nums[l] = nums[r];
                nums[r] = tmp;

                // After swap we increment left index
                l++;
            }
        }
    }
}
// @lc code=end


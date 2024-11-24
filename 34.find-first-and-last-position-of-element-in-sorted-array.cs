/*
 * @lc app=leetcode id=34 lang=csharp
 *
 * [34] Find First and Last Position of Element in Sorted Array
 *
 * https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/description/
 *
 * algorithms
 * Medium (45.32%)
 * Likes:    21015
 * Dislikes: 547
 * Total Accepted:    2.3M
 * Total Submissions: 5.1M
 * Testcase Example:  '[5,7,7,8,8,10]\n8'
 *
 * Given an array of integers nums sorted in non-decreasing order, find the
 * starting and ending position of a given target value.
 * 
 * If target is not found in the array, return [-1, -1].
 * 
 * You must write an algorithm with O(log n) runtime complexity.
 * 
 * 
 * Example 1:
 * Input: nums = [5,7,7,8,8,10], target = 8
 * Output: [3,4]
 * Example 2:
 * Input: nums = [5,7,7,8,8,10], target = 6
 * Output: [-1,-1]
 * Example 3:
 * Input: nums = [], target = 0
 * Output: [-1,-1]
 * 
 * 
 * Constraints:
 * 
 * 
 * 0 <= nums.length <= 10^5
 * -10^9 <= nums[i] <= 10^9
 * nums is a non-decreasing array.
 * -10^9 <= target <= 10^9
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    private int SearchFirstGreaterEqual(int[] nums, int target)
    {
        // in order to handle nums.Length == 1 case
        // we set r = nums.Length
        int l = 0, r = nums.Length;
        while (l < r)
        {
            int m = (l + r) / 2;
            if (nums[m] >= target)
                r = m;
            else
                l = m + 1;
        }
        return l;
    }

    public int[] SearchRange(int[] nums, int target)
    {
        // find target first appear position, which is left
        int l = SearchFirstGreaterEqual(nums, target);

        // find (target + 1) first appear position
        // then the end of target position will be right - 1
        int r = SearchFirstGreaterEqual(nums, target + 1);

        // if different target found in the same position
        // it means that we cannot find both nums
        if (l == r)
            return new int[] { -1, -1 };
        return new int[] { l, r - 1 };
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=540 lang=csharp
 *
 * [540] Single Element in a Sorted Array
 *
 * https://leetcode.com/problems/single-element-in-a-sorted-array/description/
 *
 * algorithms
 * Medium (59.29%)
 * Likes:    11525
 * Dislikes: 203
 * Total Accepted:    777.8K
 * Total Submissions: 1.3M
 * Testcase Example:  '[1,1,2,3,3,4,4,8,8]'
 *
 * You are given a sorted array consisting of only integers where every element
 * appears exactly twice, except for one element which appears exactly once.
 * 
 * Return the single element that appears only once.
 * 
 * Your solution must run in O(log n) time and O(1) space.
 * 
 * 
 * Example 1:
 * Input: nums = [1,1,2,3,3,4,4,8,8]
 * Output: 2
 * Example 2:
 * Input: nums = [3,3,7,7,10,11,11]
 * Output: 10
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 10^5
 * 0 <= nums[i] <= 10^5
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int SingleNonDuplicate(int[] nums)
    {
        int left = 0, right = nums.Length - 1;
        while (left < right)
        {
            int mid = (left + right) / 2;

            // even num XOR 1 will always plus 1, because even num end of 0
            // odd num XOR 1 will always minus 1, because odd num end of 1
            // so even num of mid must be same with mid + 1, otherwise it will be left side
            // odd num of mid must be same with mid - 1, otherwise it will be left side
            if (nums[mid] != nums[mid ^ 1])
                right = mid;
            else
                left = mid + 1;

        }
        return nums[left];
    }
}
// @lc code=end


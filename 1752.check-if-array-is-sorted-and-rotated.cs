/*
 * @lc app=leetcode id=1752 lang=csharp
 *
 * [1752] Check if Array Is Sorted and Rotated
 *
 * https://leetcode.com/problems/check-if-array-is-sorted-and-rotated/description/
 *
 * algorithms
 * Easy (51.72%)
 * Likes:    3560
 * Dislikes: 215
 * Total Accepted:    396.4K
 * Total Submissions: 760.2K
 * Testcase Example:  '[3,4,5,1,2]'
 *
 * Given an array nums, return true if the array was originally sorted in
 * non-decreasing order, then rotated some number of positions (including
 * zero). Otherwise, return false.
 * 
 * There may be duplicates in the original array.
 * 
 * Note: An array A rotated by x positions results in an array B of the same
 * length such that A[i] == B[(i+x) % A.length], where % is the modulo
 * operation.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [3,4,5,1,2]
 * Output: true
 * Explanation: [1,2,3,4,5] is the original sorted array.
 * You can rotate the array by x = 3 positions to begin on the the element of
 * value 3: [3,4,5,1,2].
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [2,1,3,4]
 * Output: false
 * Explanation: There is no sorted array once rotated that can make nums.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: nums = [1,2,3]
 * Output: true
 * Explanation: [1,2,3] is the original sorted array.
 * You can rotate the array by x = 0 positions (i.e. no rotation) to make
 * nums.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 100
 * 1 <= nums[i] <= 100
 * 
 * 
 */
/*
 * Array checking
 * Time: O(n), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    // Three cases needed to return true:
    // 1: [1,2,3,4,5], no turning point, so after the first loop, and last/first element check, count = 1
    // 2: [3,4,5,1,2], 1 turning point, so after the first loop, and last/first element check, count = 1
    // 3: [1,1,1,1,1], no turning point, so after the first loop, and last/first element check, count = 0
    // so if violate 2 condition, return false
    public bool Check(int[] nums)
    {
        int count = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i - 1] > nums[i])
                count++;
        }

        if (nums[nums.Length - 1] > nums[0])
            count++;

        return count <= 1;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=2161 lang=csharp
 *
 * [2161] Partition Array According to Given Pivot
 *
 * https://leetcode.com/problems/partition-array-according-to-given-pivot/description/
 *
 * algorithms
 * Medium (85.20%)
 * Likes:    1177
 * Dislikes: 91
 * Total Accepted:    98.2K
 * Total Submissions: 114.3K
 * Testcase Example:  '[9,12,5,10,14,3,10]\n10'
 *
 * You are given a 0-indexed integer array nums and an integer pivot. Rearrange
 * nums such that the following conditions are satisfied:
 * 
 * 
 * Every element less than pivot appears before every element greater than
 * pivot.
 * Every element equal to pivot appears in between the elements less than and
 * greater than pivot.
 * The relative order of the elements less than pivot and the elements greater
 * than pivot is maintained.
 * 
 * More formally, consider every pi, pj where pi is the new position of the
 * i^th element and pj is the new position of the j^th element. If i < j and
 * both elements are smaller (or larger) than pivot, then pi < pj.
 * 
 * 
 * 
 * 
 * Return nums after the rearrangement.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [9,12,5,10,14,3,10], pivot = 10
 * Output: [9,5,3,10,10,12,14]
 * Explanation: 
 * The elements 9, 5, and 3 are less than the pivot so they are on the left
 * side of the array.
 * The elements 12 and 14 are greater than the pivot so they are on the right
 * side of the array.
 * The relative ordering of the elements less than and greater than pivot is
 * also maintained. [9, 5, 3] and [12, 14] are the respective orderings.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [-3,4,3,2], pivot = 2
 * Output: [-3,2,4,3]
 * Explanation: 
 * The element -3 is less than the pivot so it is on the left side of the
 * array.
 * The elements 4 and 3 are greater than the pivot so they are on the right
 * side of the array.
 * The relative ordering of the elements less than and greater than pivot is
 * also maintained. [-3] and [4, 3] are the respective orderings.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 10^5
 * -10^6 <= nums[i] <= 10^6
 * pivot equals to an element of nums.
 * 
 * 
 */
/*
 * Two Pointer Approach (Different direction)
 * Time: O(n), Space: O(n)
 */

// @lc code=start
public partial class Solution
{
    public int[] PivotArray(int[] nums, int pivot)
    {
        int[] ans = new int[nums.Length];
        // create 2 pointers, from left and right
        int less = 0, greater = nums.Length - 1;

        // start from both direction, i = [0, n - 1], j = [n - 1, 0]
        // push the nums[i] < pivot to left side
        // push the nums[j] > pivot to right side
        for (int i = 0, j = nums.Length - 1; i < nums.Length; i++, j--)
        {
            if (nums[i] < pivot)
                ans[less++] = nums[i];
            if (nums[j] > pivot)
                ans[greater--] = nums[j];
        }

        // create for the nums[i] == pivot
        while (less <= greater)
            ans[less++] = pivot;

        return ans;
    }
}
// @lc code=end


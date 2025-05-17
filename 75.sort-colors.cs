/*
 * @lc app=leetcode id=75 lang=csharp
 *
 * [75] Sort Colors
 *
 * https://leetcode.com/problems/sort-colors/description/
 *
 * algorithms
 * Medium (65.19%)
 * Likes:    18988
 * Dislikes: 676
 * Total Accepted:    2.4M
 * Total Submissions: 3.7M
 * Testcase Example:  '[2,0,2,1,1,0]'
 *
 * Given an array nums with n objects colored red, white, or blue, sort them
 * in-place so that objects of the same color are adjacent, with the colors in
 * the order red, white, and blue.
 * 
 * We will use the integers 0, 1, and 2 to represent the color red, white, and
 * blue, respectively.
 * 
 * You must solve this problem without using the library's sort function.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [2,0,2,1,1,0]
 * Output: [0,0,1,1,2,2]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [2,0,1]
 * Output: [0,1,2]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * n == nums.length
 * 1 <= n <= 300
 * nums[i] is either 0, 1, or 2.
 * 
 * 
 * 
 * Follow up: Could you come up with a one-pass algorithm using only constant
 * extra space?
 * 
 */
/*
 * Two Pointer Approach
 * Time: O(n), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    public void SortColors(int[] nums)
    {
        int left = 0, right = nums.Length - 1;
        for (int i = 0; i <= right; i++)
        {
            // swap 0 to the left hand side
            if (nums[i] == 0)
            {
                nums[i] = nums[left];
                nums[left++] = 0;
            }
            // swap 2 to the right hand side
            else if (nums[i] == 2)
            {
                nums[i] = nums[right];
                nums[right--] = 2;
                // handle again for the current position i
                i--;
            }
        }
    }

    /* public void SortColors(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            int key = nums[i];
            int j = i - 1;
            while (j >= 0 && key < nums[j])
            {
                nums[j + 1] = nums[j];
                j--;
            }
            nums[j + 1] = key;
        }
    } */
}
// @lc code=end


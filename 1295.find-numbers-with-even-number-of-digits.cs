/*
 * @lc app=leetcode id=1295 lang=csharp
 *
 * [1295] Find Numbers with Even Number of Digits
 *
 * https://leetcode.com/problems/find-numbers-with-even-number-of-digits/description/
 *
 * algorithms
 * Easy (77.50%)
 * Likes:    2514
 * Dislikes: 130
 * Total Accepted:    790.6K
 * Total Submissions: 1M
 * Testcase Example:  '[12,345,2,6,7896]'
 *
 * Given an array nums of integers, return how many of them contain an even
 * number of digits.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [12,345,2,6,7896]
 * Output: 2
 * Explanation: 
 * 12 contains 2 digits (even number of digits). 
 * 345 contains 3 digits (odd number of digits). 
 * 2 contains 1 digit (odd number of digits). 
 * 6 contains 1 digit (odd number of digits). 
 * 7896 contains 4 digits (even number of digits). 
 * Therefore only 12 and 7896 contain an even number of digits.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [555,901,482,1771]
 * Output: 1 
 * Explanation: 
 * Only 1771 contains an even number of digits.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 500
 * 1 <= nums[i] <= 10^5
 * 
 * 
 */
/*
 * Math Approach
 * Time: O(n log m), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    public int FindNumbers(int[] nums)
    {
        int ans = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            // calc the no. of digits
            int count = 0;
            while (nums[i] != 0)
            {
                count++;
                nums[i] /= 10;
            }

            // if count is even
            if ((count & 1) == 0)
                ans++;
        }
        return ans;
    }
}
// @lc code=end


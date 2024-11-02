/*
 * @lc app=leetcode id=136 lang=csharp
 *
 * [136] Single Number
 *
 * https://leetcode.com/problems/single-number/description/
 *
 * algorithms
 * Easy (74.28%)
 * Likes:    16829
 * Dislikes: 754
 * Total Accepted:    3.2M
 * Total Submissions: 4.3M
 * Testcase Example:  '[2,2,1]'
 *
 * Given a non-empty array of integers nums, every element appears twice except
 * for one. Find that single one.
 * 
 * You must implement a solution with a linear runtime complexity and use only
 * constant extra space.
 * 
 * 
 * Example 1:
 * Input: nums = [2,2,1]
 * Output: 1
 * Example 2:
 * Input: nums = [4,1,2,1,2]
 * Output: 4
 * Example 3:
 * Input: nums = [1]
 * Output: 1
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 3 * 10^4
 * -3 * 10^4 <= nums[i] <= 3 * 10^4
 * Each element in the array appears twice except for one element which appears
 * only once.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int SingleNumber(int[] nums)
    {
        /* HashSet<int> count = new HashSet<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (count.Contains(nums[i]))
                count.Remove(nums[i]);
            else
                count.Add(nums[i]);
        }
        return count.FirstOrDefault(); */

        // Bit Manipulation
        // A ^ A = 0, 0 ^ 0 = 0, B ^ 0 = B 
        // so any nums appear twice will be 0 and the single one will be the result.
        int res = 0;
        for (int i = 0; i < nums.Length; i++)
            res ^= nums[i];

        return res;
    }
}
// @lc code=end


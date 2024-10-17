/*
 * @lc app=leetcode id=287 lang=csharp
 *
 * [287] Find the Duplicate Number
 *
 * https://leetcode.com/problems/find-the-duplicate-number/description/
 *
 * algorithms
 * Medium (61.67%)
 * Likes:    23596
 * Dislikes: 4834
 * Total Accepted:    1.9M
 * Total Submissions: 3.1M
 * Testcase Example:  '[1,3,4,2,2]'
 *
 * Given an array of integers nums containing n + 1 integers where each integer
 * is in the range [1, n] inclusive.
 * 
 * There is only one repeated number in nums, return this repeated number.
 * 
 * You must solve the problem without modifying the array nums and using only
 * constant extra space.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [1,3,4,2,2]
 * Output: 2
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [3,1,3,4,2]
 * Output: 3
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: nums = [3,3,3,3,3]
 * Output: 3
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= n <= 10^5
 * nums.length == n + 1
 * 1 <= nums[i] <= n
 * All the integers in nums appear only once except for precisely one integer
 * which appears two or more times.
 * 
 * 
 * 
 * Follow up:
 * 
 * 
 * How can we prove that at least one duplicate number must exist in nums?
 * Can you solve the problem in linear runtime complexity?
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int FindDuplicate(int[] nums)
    {
        // Re-phase nums array to linked list
        // [1,3,4,2,2] = 1->3->2->4->2 4 back to 2 and construct a cycle
        // Multiple number point to same number = cycle
        // find the intersaction by using slow and fash pointer
        int slow = 0, fast = 0;
        while (true)
        {
            slow = nums[slow];
            fast = nums[nums[fast]];
            if (slow == fast)
                break;
        }

        // Use Floyd's Tortoise and Hare algorithm to find the cycle entrance
        // Distance from head to entrance always = distance from intersection to entrance
        // 2 slow = 1 fast
        // 2 (p + c - x) = p + c - x + c
        // 2p + 2c - 2x = p + 2c - x
        // p = x
        int slow2 = 0;
        while (true)
        {
            slow = nums[slow];
            slow2 = nums[slow2];
            if (slow == slow2)
                return slow;
        }
    }
}
// @lc code=end


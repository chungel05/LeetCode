/*
 * @lc app=leetcode id=1 lang=csharp
 *
 * [1] Two Sum
 */

// @lc code=start
public partial class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            int remaining = target - nums[i];
            int anotherNum = Array.IndexOf(nums, remaining);
            if (anotherNum != -1 && anotherNum != i)
                return new int[] { i, anotherNum };
        }
        return new int[] { };
    }
}
// @lc code=end


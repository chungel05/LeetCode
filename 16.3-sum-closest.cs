/*
 * @lc app=leetcode id=16 lang=csharp
 *
 * [16] 3Sum Closest
 *
 * https://leetcode.com/problems/3sum-closest/description/
 *
 * algorithms
 * Medium (46.13%)
 * Likes:    10662
 * Dislikes: 579
 * Total Accepted:    1.3M
 * Total Submissions: 2.9M
 * Testcase Example:  '[-1,2,1,-4]\n1'
 *
 * Given an integer array nums of length n and an integer target, find three
 * integers in nums such that the sum is closest to target.
 * 
 * Return the sum of the three integers.
 * 
 * You may assume that each input would have exactly one solution.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [-1,2,1,-4], target = 1
 * Output: 2
 * Explanation: The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [0,0,0], target = 1
 * Output: 0
 * Explanation: The sum that is closest to the target is 0. (0 + 0 + 0 =
 * 0).
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 3 <= nums.length <= 500
 * -1000 <= nums[i] <= 1000
 * -10^4 <= target <= 10^4
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int ThreeSumClosest(int[] nums, int target)
    {
        Array.Sort(nums);

        int res = int.MaxValue;
        for (int i = 0; i < nums.Length; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
                continue;

            int l = i + 1, r = nums.Length - 1;
            while (l < r)
            {
                int sum = nums[i] + nums[l] + nums[r];

                if (sum > target)
                    r--;
                else if (sum < target)
                    l++;
                else
                    return sum;

                if (Math.Abs(sum - target) < Math.Abs(res - target))
                    res = sum;
            }
        }
        return res;
    }
}
// @lc code=end


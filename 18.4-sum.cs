/*
 * @lc app=leetcode id=18 lang=csharp
 *
 * [18] 4Sum
 *
 * https://leetcode.com/problems/4sum/description/
 *
 * algorithms
 * Medium (36.82%)
 * Likes:    11591
 * Dislikes: 1419
 * Total Accepted:    1.1M
 * Total Submissions: 3M
 * Testcase Example:  '[1,0,-1,0,-2,2]\n0'
 *
 * Given an array nums of n integers, return an array of all the unique
 * quadruplets [nums[a], nums[b], nums[c], nums[d]] such that:
 * 
 * 
 * 0 <= a, b, c, d < n
 * a, b, c, and d are distinct.
 * nums[a] + nums[b] + nums[c] + nums[d] == target
 * 
 * 
 * You may return the answer in any order.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [1,0,-1,0,-2,2], target = 0
 * Output: [[-2,-1,1,2],[-2,0,0,2],[-1,0,0,1]]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [2,2,2,2,2], target = 8
 * Output: [[2,2,2,2]]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 200
 * -10^9 <= nums[i] <= 10^9
 * -10^9 <= target <= 10^9
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        List<IList<int>> res = new List<IList<int>>();
        Array.Sort(nums);

        for (int i = 0; i < nums.Length; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
                continue;

            for (int j = i + 1; j < nums.Length; j++)
            {
                if (j > i + 1 && nums[j] == nums[j - 1])
                    continue;

                int l = j + 1, r = nums.Length - 1;
                while (l < r)
                {
                    long sum = (long)nums[i] + nums[j] + nums[l] + nums[r];
                    if (sum > target)
                        r--;
                    else if (sum < target)
                        l++;
                    else
                    {
                        res.Add(new List<int>() { nums[i], nums[j], nums[l], nums[r] });
                        l++;
                        r--;
                        while (l < r && nums[l] == nums[l - 1])
                            l++;
                    }
                }
            }
        }
        return res;
    }
}
// @lc code=end


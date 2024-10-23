/*
 * @lc app=leetcode id=90 lang=csharp
 *
 * [90] Subsets II
 *
 * https://leetcode.com/problems/subsets-ii/description/
 *
 * algorithms
 * Medium (58.18%)
 * Likes:    9945
 * Dislikes: 337
 * Total Accepted:    1M
 * Total Submissions: 1.8M
 * Testcase Example:  '[1,2,2]'
 *
 * Given an integer array nums that may contain duplicates, return all possible
 * subsets (the power set).
 * 
 * The solution set must not contain duplicate subsets. Return the solution in
 * any order.
 * 
 * 
 * Example 1:
 * Input: nums = [1,2,2]
 * Output: [[],[1],[1,2],[1,2,2],[2],[2,2]]
 * Example 2:
 * Input: nums = [0]
 * Output: [[],[0]]
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 10
 * -10 <= nums[i] <= 10
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public void BacktrackSubsetsWithDup(int[] nums, int i, List<int> subset, List<IList<int>> res)
    {
        if (i >= nums.Length)
        {
            res.Add(new List<int>(subset));
            return;
        }

        // Include current num and move to next num
        subset.Add(nums[i]);
        BacktrackSubsetsWithDup(nums, i + 1, subset, res);

        // Not include current num and move to next num which is not the same
        while (i + 1 < nums.Length && nums[i] == nums[i + 1])
            i++;

        subset.RemoveAt(subset.Count - 1);
        BacktrackSubsetsWithDup(nums, i + 1, subset, res);
    }

    public IList<IList<int>> SubsetsWithDup(int[] nums)
    {
        List<IList<int>> res = new List<IList<int>>();
        List<int> subset = new List<int>();
        Array.Sort(nums);
        BacktrackSubsetsWithDup(nums, 0, subset, res);
        return res;
    }
}
// @lc code=end


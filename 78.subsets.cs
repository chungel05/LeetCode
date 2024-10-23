/*
 * @lc app=leetcode id=78 lang=csharp
 *
 * [78] Subsets
 *
 * https://leetcode.com/problems/subsets/description/
 *
 * algorithms
 * Medium (79.37%)
 * Likes:    17573
 * Dislikes: 285
 * Total Accepted:    2.2M
 * Total Submissions: 2.7M
 * Testcase Example:  '[1,2,3]'
 *
 * Given an integer array nums of unique elements, return all possible subsets
 * (the power set).
 * 
 * The solution set must not contain duplicate subsets. Return the solution in
 * any order.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [1,2,3]
 * Output: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [0]
 * Output: [[],[0]]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 10
 * -10 <= nums[i] <= 10
 * All the numbers of nums are unique.
 * 
 * 
 */

/*
*                          []
*              [1]                    []
*      [1,2]         [1]         [2]      []
* [1,2,3]  [1,2] [1,3]  [1]  [2,3] [2]  [3] []
*/

// @lc code=start
public partial class Solution
{
    public void BacktrackSubsets(int[] nums, int index, List<int> subset, IList<IList<int>> res)
    {
        if (index >= nums.Length)
        {
            res.Add(new List<int>(subset));
            return;
        }

        // Include current num -> move to next level
        subset.Add(nums[index]);
        BacktrackSubsets(nums, index + 1, subset, res);

        // Not Include current num -> move to next level
        subset.RemoveAt(subset.Count - 1);
        BacktrackSubsets(nums, index + 1, subset, res);
    }

    public IList<IList<int>> Subsets(int[] nums)
    {
        List<IList<int>> res = new List<IList<int>>();
        List<int> subset = new List<int>();
        BacktrackSubsets(nums, 0, subset, res);
        return res;
    }
}
// @lc code=end


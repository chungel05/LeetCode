/*
 * @lc app=leetcode id=40 lang=csharp
 *
 * [40] Combination Sum II
 *
 * https://leetcode.com/problems/combination-sum-ii/description/
 *
 * algorithms
 * Medium (56.53%)
 * Likes:    11141
 * Dislikes: 325
 * Total Accepted:    1.2M
 * Total Submissions: 2.1M
 * Testcase Example:  '[10,1,2,7,6,1,5]\n8'
 *
 * Given a collection of candidate numbers (candidates) and a target number
 * (target), find all unique combinations in candidates where the candidate
 * numbers sum to target.
 * 
 * Each number in candidates may only be used once in the combination.
 * 
 * Note: The solution set must not contain duplicate combinations.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: candidates = [10,1,2,7,6,1,5], target = 8
 * Output: 
 * [
 * [1,1,6],
 * [1,2,5],
 * [1,7],
 * [2,6]
 * ]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: candidates = [2,5,2,1,2], target = 5
 * Output: 
 * [
 * [1,2,2],
 * [5]
 * ]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= candidates.length <= 100
 * 1 <= candidates[i] <= 50
 * 1 <= target <= 30
 * 
 * 
 */

// @lc code=start
using System.Data.Common;
using System.Reflection.Metadata;

public partial class Solution
{
    public void BacktrackCombinationSum2(int[] candidates, int target, int i, int sum, List<int> subset, List<IList<int>> res)
    {
        if (sum == target)
        {
            res.Add(new List<int>(subset));
            return;
        }

        if (sum > target || i >= candidates.Length)
            return;

        // Include current num and move to next num
        subset.Add(candidates[i]);
        BacktrackCombinationSum2(candidates, target, i + 1, sum + candidates[i], subset, res);

        // Not include current num and move to next num which is not the same
        while (i + 1 < candidates.Length && candidates[i] == candidates[i + 1])
            i++;

        subset.RemoveAt(subset.Count - 1);
        BacktrackCombinationSum2(candidates, target, i + 1, sum, subset, res);
    }

    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        List<IList<int>> res = new List<IList<int>>();
        List<int> subset = new List<int>();
        Array.Sort(candidates);
        BacktrackCombinationSum2(candidates, target, 0, 0, subset, res);
        return res;
    }
}
// @lc code=end


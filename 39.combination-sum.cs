/*
 * @lc app=leetcode id=39 lang=csharp
 *
 * [39] Combination Sum
 *
 * https://leetcode.com/problems/combination-sum/description/
 *
 * algorithms
 * Medium (72.89%)
 * Likes:    19164
 * Dislikes: 441
 * Total Accepted:    2.2M
 * Total Submissions: 3M
 * Testcase Example:  '[2,3,6,7]\n7'
 *
 * Given an array of distinct integers candidates and a target integer target,
 * return a list of all unique combinations of candidates where the chosen
 * numbers sum to target. You may return the combinations in any order.
 * 
 * The same number may be chosen from candidates an unlimited number of times.
 * Two combinations are unique if the frequency of at least one of the chosen
 * numbers is different.
 * 
 * The test cases are generated such that the number of unique combinations
 * that sum up to target is less than 150 combinations for the given input.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: candidates = [2,3,6,7], target = 7
 * Output: [[2,2,3],[7]]
 * Explanation:
 * 2 and 3 are candidates, and 2 + 2 + 3 = 7. Note that 2 can be used multiple
 * times.
 * 7 is a candidate, and 7 = 7.
 * These are the only two combinations.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: candidates = [2,3,5], target = 8
 * Output: [[2,2,2,2],[2,3,3],[3,5]]
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: candidates = [2], target = 1
 * Output: []
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= candidates.length <= 30
 * 2 <= candidates[i] <= 40
 * All elements of candidates are distinct.
 * 1 <= target <= 40
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public void BacktrackCombinationSum(int[] candidates, int target, int i, int sum, List<int> subset, IList<IList<int>> res)
    {
        if (sum == target)
        {
            res.Add(new List<int>(subset));
            return;
        }
        if (i >= candidates.Length || sum > target)
            return;

        // Include num and can select same num
        subset.Add(candidates[i]);
        BacktrackCombinationSum(candidates, target, i, sum + candidates[i], subset, res);

        // Not include num then move to next num
        subset.RemoveAt(subset.Count - 1);
        BacktrackCombinationSum(candidates, target, i + 1, sum, subset, res);
    }

    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        List<IList<int>> res = new List<IList<int>>();
        List<int> subset = new List<int>();
        BacktrackCombinationSum(candidates, target, 0, 0, subset, res);
        return res;
    }
}
// @lc code=end


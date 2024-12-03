/*
 * @lc app=leetcode id=77 lang=csharp
 *
 * [77] Combinations
 *
 * https://leetcode.com/problems/combinations/description/
 *
 * algorithms
 * Medium (71.42%)
 * Likes:    8379
 * Dislikes: 232
 * Total Accepted:    1M
 * Total Submissions: 1.4M
 * Testcase Example:  '4\n2'
 *
 * Given two integers n and k, return all possible combinations of k numbers
 * chosen from the range [1, n].
 * 
 * You may return the answer in any order.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: n = 4, k = 2
 * Output: [[1,2],[1,3],[1,4],[2,3],[2,4],[3,4]]
 * Explanation: There are 4 choose 2 = 6 total combinations.
 * Note that combinations are unordered, i.e., [1,2] and [2,1] are considered
 * to be the same combination.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: n = 1, k = 1
 * Output: [[1]]
 * Explanation: There is 1 choose 1 = 1 total combination.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= n <= 20
 * 1 <= k <= n
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    private void DFSCombine(int n, int k, int i, List<int> path, List<IList<int>> res)
    {
        // Current path count = k, we have enough nums, added to result
        if (path.Count == k)
        {
            res.Add(new List<int>(path));
            return;
        }

        // if current index i > n, it means that we are out of range, no need to continue
        if (i > n)
            return;

        // Case 1: Add num to curr path
        path.Add(i);
        DFSCombine(n, k, i + 1, path, res);
        // Case 2: Not add num to curr path
        path.RemoveAt(path.Count - 1);
        DFSCombine(n, k, i + 1, path, res);
    }

    public IList<IList<int>> Combine(int n, int k)
    {
        List<IList<int>> res = new List<IList<int>>();
        DFSCombine(n, k, 1, new List<int>(), res);

        return res;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=46 lang=csharp
 *
 * [46] Permutations
 *
 * https://leetcode.com/problems/permutations/description/
 *
 * algorithms
 * Medium (79.36%)
 * Likes:    19345
 * Dislikes: 337
 * Total Accepted:    2.3M
 * Total Submissions: 2.9M
 * Testcase Example:  '[1,2,3]'
 *
 * Given an array nums of distinct integers, return all the possible
 * permutations. You can return the answer in any order.
 * 
 * 
 * Example 1:
 * Input: nums = [1,2,3]
 * Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
 * Example 2:
 * Input: nums = [0,1]
 * Output: [[0,1],[1,0]]
 * Example 3:
 * Input: nums = [1]
 * Output: [[1]]
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 6
 * -10 <= nums[i] <= 10
 * All the integers of nums are unique.
 * 
 * 
 */
/*
* Default case running result as follow:
* Pick 1 and get [3,2] and [2,3] -> add 1 at the end -> [3,2,1] [2,3,1]
* Pick 2 and get [3,1] and [1,3] -> add 2 at the end -> [3,1,2] [1,3,2]
* Pick 3 and get [2,1] and [1,2] -> add 3 at the end -> [2,1,3] [1,2,3]
* [3,2,1] [2,3,1] [3,1,2] [1,3,2] [2,1,3] [1,2,3]
*/

// @lc code=start
public partial class Solution
{
    public IList<IList<int>> Permute(int[] nums)
    {
        List<IList<int>> res = new List<IList<int>>();
        if (nums.Length == 1)
        {
            List<int> last = new List<int>();
            last.Add(nums[0]);
            res.Add(last);
            return res;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            int n = nums[i];
            int[] remain = new int[nums.Length - 1];
            int index = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                    remain[index++] = nums[j];
            }

            IList<IList<int>> permutes = Permute(remain);
            foreach (var permute in permutes)
            {
                permute.Add(n);
                res.Add(permute);
            }
        }
        return res;
    }
}
// @lc code=end


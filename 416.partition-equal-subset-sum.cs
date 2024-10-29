/*
 * @lc app=leetcode id=416 lang=csharp
 *
 * [416] Partition Equal Subset Sum
 *
 * https://leetcode.com/problems/partition-equal-subset-sum/description/
 *
 * algorithms
 * Medium (46.79%)
 * Likes:    12491
 * Dislikes: 255
 * Total Accepted:    958.4K
 * Total Submissions: 2M
 * Testcase Example:  '[1,5,11,5]'
 *
 * Given an integer array nums, return true if you can partition the array into
 * two subsets such that the sum of the elements in both subsets is equal or
 * false otherwise.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [1,5,11,5]
 * Output: true
 * Explanation: The array can be partitioned as [1, 5, 5] and [11].
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [1,2,3,5]
 * Output: false
 * Explanation: The array cannot be partitioned into equal sum subsets.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 200
 * 1 <= nums[i] <= 100
 * 
 * 
 */
/*
 * Start from right hand side, create all the possible sum that can sum to target (total sum / 2)
 */

// @lc code=start
public partial class Solution
{
    public bool CanPartition(int[] nums)
    {
        if (nums.Sum() % 2 != 0)
            return false;

        HashSet<int> dp = new HashSet<int>();
        dp.Add(0);
        int t = nums.Sum() / 2;

        for (int i = nums.Length - 1; i >= 0; i--)
        {
            HashSet<int> next = new HashSet<int>();
            foreach (int j in dp)
            {
                if (j + nums[i] == t)
                    return true;
                next.Add(j + nums[i]);
                next.Add(j);
            }
            dp = next;
        }
        return false;
    }
}
// @lc code=end


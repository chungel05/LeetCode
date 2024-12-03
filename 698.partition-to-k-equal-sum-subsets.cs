/*
 * @lc app=leetcode id=698 lang=csharp
 *
 * [698] Partition to K Equal Sum Subsets
 *
 * https://leetcode.com/problems/partition-to-k-equal-sum-subsets/description/
 *
 * algorithms
 * Medium (38.14%)
 * Likes:    7222
 * Dislikes: 519
 * Total Accepted:    286.2K
 * Total Submissions: 751.3K
 * Testcase Example:  '[4,3,2,3,5,2,1]\n4'
 *
 * Given an integer array nums and an integer k, return true if it is possible
 * to divide this array into k non-empty subsets whose sums are all equal.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [4,3,2,3,5,2,1], k = 4
 * Output: true
 * Explanation: It is possible to divide it into 4 subsets (5), (1, 4), (2,3),
 * (2,3) with equal sums.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [1,2,3,4], k = 3
 * Output: false
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= k <= nums.length <= 16
 * 1 <= nums[i] <= 10^4
 * The frequency of each element is in the range [1, 4].
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    private bool DFSCanPartitionKSubsets(int[] nums, int target, int[] subSet, int i)
    {
        // Index start from nums.Length - 1 to 0, which is from largest to smallest
        // if index i is out of range, we check the sum of each subset
        if (i < 0)
        {
            for (int j = 0; j < subSet.Length; j++)
            {
                if (subSet[j] != target)
                    return false;
            }
            return true;
        }

        for (int j = 0; j < subSet.Length; j++)
        {
            // for each subset, we try to add num[i]
            subSet[j] += nums[i];
            // if sum of subset already larger than target, we move to next subset
            // we continue check by DFS of next nums[i - 1]
            if (subSet[j] <= target && DFSCanPartitionKSubsets(nums, target, subSet, i - 1))
                return true;

            // if current path is not success, we remove the num[i] and move to next subset
            subSet[j] -= nums[i];

            // Since nums[i] are >= 1, if original subset[j] is 0, we no need to check other subset because 0 is the smallest
            if (subSet[j] == 0)
                break;
        }
        return false;
    }

    public bool CanPartitionKSubsets(int[] nums, int k)
    {
        // if nums can divide into k subsets and equal sum, its sum must be divisible by k 
        if (nums.Sum() % k != 0)
            return false;

        // Calc the target sum of each subset which is target * k = total sum
        int target = nums.Sum() / k;
        // To record the sum of each subset
        int[] subSet = new int[k];

        // Sort the nums
        Array.Sort(nums);
        return DFSCanPartitionKSubsets(nums, target, subSet, nums.Length - 1);
    }
}
// @lc code=end


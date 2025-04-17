/*
 * @lc app=leetcode id=2176 lang=csharp
 *
 * [2176] Count Equal and Divisible Pairs in an Array
 *
 * https://leetcode.com/problems/count-equal-and-divisible-pairs-in-an-array/description/
 *
 * algorithms
 * Easy (79.72%)
 * Likes:    695
 * Dislikes: 37
 * Total Accepted:    101K
 * Total Submissions: 125.7K
 * Testcase Example:  '[3,1,2,2,2,1,3]\n2'
 *
 * Given a 0-indexed integer array nums of length n and an integer k, return
 * the number of pairs (i, j) where 0 <= i < j < n, such that nums[i] ==
 * nums[j] and (i * j) is divisible by k.
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [3,1,2,2,2,1,3], k = 2
 * Output: 4
 * Explanation:
 * There are 4 pairs that meet all the requirements:
 * - nums[0] == nums[6], and 0 * 6 == 0, which is divisible by 2.
 * - nums[2] == nums[3], and 2 * 3 == 6, which is divisible by 2.
 * - nums[2] == nums[4], and 2 * 4 == 8, which is divisible by 2.
 * - nums[3] == nums[4], and 3 * 4 == 12, which is divisible by 2.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [1,2,3,4], k = 1
 * Output: 0
 * Explanation: Since no value in nums is repeated, there are no pairs (i,j)
 * that meet all the requirements.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 100
 * 1 <= nums[i], k <= 100
 * 
 * 
 */
/*
 * Hash Table Approach
 * Time: O(n^2), Space: O(n)
 */

// @lc code=start
public partial class Solution
{
    // Brute Force Approach
    // Time: O(n^2)
    /* public int CountPairs(int[] nums, int k)
    {
        int ans = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[i] == nums[j] && (i * j) % k == 0)
                    ans++;
            }
        }
        return ans;
    } */

    // Hash Table Approach
    // Time: O(n^2)
    public int CountPairs(int[] nums, int k)
    {
        Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
        int ans = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            // Condition 1: nums[i] == nums[j]
            if (dict.ContainsKey(nums[i]))
            {
                foreach (int idx in dict[nums[i]])
                {
                    // Condition 2: (i * j) % k == 0
                    if ((idx * i) % k == 0)
                        ans++;
                }
            }
            else
                dict[nums[i]] = new List<int>();

            dict[nums[i]].Add(i);
        }
        return ans;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=525 lang=csharp
 *
 * [525] Contiguous Array
 *
 * https://leetcode.com/problems/contiguous-array/description/
 *
 * algorithms
 * Medium (48.95%)
 * Likes:    8089
 * Dislikes: 398
 * Total Accepted:    502K
 * Total Submissions: 1M
 * Testcase Example:  '[0,1]'
 *
 * Given a binary array nums, return the maximum length of a contiguous
 * subarray with an equal number of 0 and 1.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [0,1]
 * Output: 2
 * Explanation: [0, 1] is the longest contiguous subarray with an equal number
 * of 0 and 1.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [0,1,0]
 * Output: 2
 * Explanation: [0, 1] (or [1, 0]) is a longest contiguous subarray with equal
 * number of 0 and 1.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 10^5
 * nums[i] is either 0 or 1.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int FindMaxLength(int[] nums)
    {
        int res = 0, sum = 0;
        Dictionary<int, int> count = new Dictionary<int, int>();

        //base case, if sum == 0, i + 1 is possible result
        // i + 1 = i - (-1)
        count[0] = -1;
        for (int i = 0; i < nums.Length; i++)
        {
            // prefix Sum
            sum += nums[i] == 0 ? -1 : 1;

            // if dictionary contains same key, update result
            // i.e. -4 - (-4) = 0, possible result
            if (count.ContainsKey(sum))
                res = Math.Max(res, i - count[sum]);
            else
                count[sum] = i;
        }

        return res;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=45 lang=csharp
 *
 * [45] Jump Game II
 *
 * https://leetcode.com/problems/jump-game-ii/description/
 *
 * algorithms
 * Medium (40.77%)
 * Likes:    14901
 * Dislikes: 606
 * Total Accepted:    1.5M
 * Total Submissions: 3.6M
 * Testcase Example:  '[2,3,1,1,4]'
 *
 * You are given a 0-indexed array of integers nums of length n. You are
 * initially positioned at nums[0].
 * 
 * Each element nums[i] represents the maximum length of a forward jump from
 * index i. In other words, if you are at nums[i], you can jump to any nums[i +
 * j] where:
 * 
 * 
 * 0 <= j <= nums[i] and
 * i + j < n
 * 
 * 
 * Return the minimum number of jumps to reach nums[n - 1]. The test cases are
 * generated such that you can reach nums[n - 1].
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [2,3,1,1,4]
 * Output: 2
 * Explanation: The minimum number of jumps to reach the last index is 2. Jump
 * 1 step from index 0 to 1, then 3 steps to the last index.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [2,3,0,1,4]
 * Output: 2
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 10^4
 * 0 <= nums[i] <= 1000
 * It's guaranteed that you can reach nums[n - 1].
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int Jump(int[] nums)
    {
        // Initial window = 0,0
        int L = 0, R = 0;
        int count = 0;

        while (R < nums.Length - 1)
        {
            int maxIndex = 0;
            // Get the new window we can arrive
            for (int i = L; i <= R; i++)
            {
                maxIndex = Math.Max(maxIndex, i + nums[i]);
            }

            // move to the new window
            L = R + 1;
            R = maxIndex;
            count++;
        }
        return count;
    }
}
// @lc code=end


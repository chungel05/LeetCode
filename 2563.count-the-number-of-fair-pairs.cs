/*
 * @lc app=leetcode id=2563 lang=csharp
 *
 * [2563] Count the Number of Fair Pairs
 *
 * https://leetcode.com/problems/count-the-number-of-fair-pairs/description/
 *
 * algorithms
 * Medium (33.37%)
 * Likes:    1624
 * Dislikes: 114
 * Total Accepted:    138.9K
 * Total Submissions: 281K
 * Testcase Example:  '[0,1,7,4,4,5]\n3\n6'
 *
 * Given a 0-indexed integer array nums of size n and two integers lower and
 * upper, return the number of fair pairs.
 * 
 * A pair (i, j) is fair if:
 * 
 * 
 * 0 <= i < j < n, and
 * lower <= nums[i] + nums[j] <= upper
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [0,1,7,4,4,5], lower = 3, upper = 6
 * Output: 6
 * Explanation: There are 6 fair pairs: (0,3), (0,4), (0,5), (1,3), (1,4), and
 * (1,5).
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [1,7,9,2,5], lower = 11, upper = 11
 * Output: 1
 * Explanation: There is a single fair pair: (2,3).
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 10^5
 * nums.length == n
 * -10^9 <= nums[i] <= 10^9
 * -10^9 <= lower <= upper <= 10^9
 * 
 * 
 */
/*
 * Two Pointer - Boundary to middle
 * Time: O(n log n), Space: O(n)
 */

// @lc code=start
public partial class Solution
{
    // Lower bound, which find the no. of pairs of sum < value
    private long LBOfCountFairPairs(int[] nums, int value)
    {
        int left = 0, right = nums.Length - 1;
        long ans = 0;

        // Two pointer from boundary to middle
        // since i < j, so left need to < right
        while (left < right)
        {
            int sum = nums[left] + nums[right];
            // if sum < value, then [left, left + 1, ..., right - 1] can pair with right
            if (sum < value)
            {
                // combination = right - left, which is all nums[i] match with nums[right]
                ans += right - left;
                // move left pointer to make the sum larger
                left++;
            }
            else
            {
                // if sum >= right, which is invalid window, try to make it smaller
                right--;
            }
        }
        return ans;
    }

    public long CountFairPairs(int[] nums, int lower, int upper)
    {
        Array.Sort(nums);

        // ans = lower <= total combinations of pair <= upper
        // LBOfCountFairPairs(nums, upper + 1) = total combinations of pair <= upper
        // LBOfCountFairPairs(nums, lower) = total combinations of pair < lower
        // so remove all combinations < lower(which remain <= lower) is the ans 
        return LBOfCountFairPairs(nums, upper + 1) - LBOfCountFairPairs(nums, lower);
    }
}
// @lc code=end


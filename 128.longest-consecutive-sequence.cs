/*
 * @lc app=leetcode id=128 lang=csharp
 *
 * [128] Longest Consecutive Sequence
 *
 * https://leetcode.com/problems/longest-consecutive-sequence/description/
 *
 * algorithms
 * Medium (47.50%)
 * Likes:    20441
 * Dislikes: 1053
 * Total Accepted:    2.1M
 * Total Submissions: 4.4M
 * Testcase Example:  '[100,4,200,1,3,2]'
 *
 * Given an unsorted array of integers nums, return the length of the longest
 * consecutive elements sequence.
 * 
 * You must write an algorithm that runs in O(n) time.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [100,4,200,1,3,2]
 * Output: 4
 * Explanation: The longest consecutive elements sequence is [1, 2, 3, 4].
 * Therefore its length is 4.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [0,3,7,2,5,8,4,6,0,1]
 * Output: 9
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 0 <= nums.length <= 10^5
 * -10^9 <= nums[i] <= 10^9
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        HashSet<int> numsList = new HashSet<int>(nums);
        int longestSequence = 0;

        foreach (int num in numsList)
        {
            if (!numsList.Contains(num - 1))
            {
                int i = 1;
                while (numsList.Contains(num + i))
                    i++;
                longestSequence = Math.Max(longestSequence, i);
            }
        }
        return longestSequence;
    }
}
// @lc code=end


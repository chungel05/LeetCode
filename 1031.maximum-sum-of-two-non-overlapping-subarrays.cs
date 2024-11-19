/*
 * @lc app=leetcode id=1031 lang=csharp
 *
 * [1031] Maximum Sum of Two Non-Overlapping Subarrays
 *
 * https://leetcode.com/problems/maximum-sum-of-two-non-overlapping-subarrays/description/
 *
 * algorithms
 * Medium (59.93%)
 * Likes:    2575
 * Dislikes: 84
 * Total Accepted:    74.4K
 * Total Submissions: 124.2K
 * Testcase Example:  '[0,6,5,2,2,5,1,9,4]\n1\n2'
 *
 * Given an integer array nums and two integers firstLen and secondLen, return
 * the maximum sum of elements in two non-overlapping subarrays with lengths
 * firstLen and secondLen.
 * 
 * The array with length firstLen could occur before or after the array with
 * length secondLen, but they have to be non-overlapping.
 * 
 * A subarray is a contiguous part of an array.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [0,6,5,2,2,5,1,9,4], firstLen = 1, secondLen = 2
 * Output: 20
 * Explanation: One choice of subarrays is [9] with length 1, and [6,5] with
 * length 2.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [3,8,1,3,2,1,8,9,0], firstLen = 3, secondLen = 2
 * Output: 29
 * Explanation: One choice of subarrays is [3,8,1] with length 3, and [8,9]
 * with length 2.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: nums = [2,1,5,6,0,9,5,0,3,8], firstLen = 4, secondLen = 3
 * Output: 31
 * Explanation: One choice of subarrays is [5,6,0,9] with length 4, and [0,3,8]
 * with length 3.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= firstLen, secondLen <= 1000
 * 2 <= firstLen + secondLen <= 1000
 * firstLen + secondLen <= nums.length <= 1000
 * 0 <= nums[i] <= 1000
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int MaxSumTwoNoOverlap(int[] nums, int firstLen, int secondLen)
    {
        // calc the prefix sum
        int[] prefixSum = new int[nums.Length + 1];
        for (int i = 0; i < nums.Length; i++)
        {
            prefixSum[i + 1] = prefixSum[i] + nums[i];
        }

        int max = 0;
        int tmpMax = 0;
        // case 1: firstLen then secondLen
        // for each firstLen "max" num, combine possible secondLen
        for (int i = firstLen; i + secondLen - 1 < nums.Length; i++)
        {
            tmpMax = Math.Max(tmpMax, prefixSum[i] - prefixSum[i - firstLen]);
            max = Math.Max(max, tmpMax + prefixSum[i + secondLen] - prefixSum[i]);
        }

        // reset tmpMax, because it will affect by prev max num of firstLen
        tmpMax = 0;

        // case 2: secondLen then firstLen
        // for each secondLen "max" num, combine possible firstLen
        for (int i = secondLen; i + firstLen - 1 < nums.Length; i++)
        {
            tmpMax = Math.Max(tmpMax, prefixSum[i] - prefixSum[i - secondLen]);
            max = Math.Max(max, tmpMax + prefixSum[i + firstLen] - prefixSum[i]);
        }
        return max;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=2444 lang=csharp
 *
 * [2444] Count Subarrays With Fixed Bounds
 *
 * https://leetcode.com/problems/count-subarrays-with-fixed-bounds/description/
 *
 * algorithms
 * Hard (67.85%)
 * Likes:    3286
 * Dislikes: 84
 * Total Accepted:    157.9K
 * Total Submissions: 232K
 * Testcase Example:  '[1,3,5,2,7,5]\n1\n5'
 *
 * You are given an integer array nums and two integers minK and maxK.
 * 
 * A fixed-bound subarray of nums is a subarray that satisfies the following
 * conditions:
 * 
 * 
 * The minimum value in the subarray is equal to minK.
 * The maximum value in the subarray is equal to maxK.
 * 
 * 
 * Return the number of fixed-bound subarrays.
 * 
 * A subarray is a contiguous part of an array.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [1,3,5,2,7,5], minK = 1, maxK = 5
 * Output: 2
 * Explanation: The fixed-bound subarrays are [1,3,5] and [1,3,5,2].
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [1,1,1,1], minK = 1, maxK = 1
 * Output: 10
 * Explanation: Every subarray of nums is a fixed-bound subarray. There are 10
 * possible subarrays.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 2 <= nums.length <= 10^5
 * 1 <= nums[i], minK, maxK <= 10^6
 * 
 * 
 */
/*
 * Two Pointer Variation Approach
 * Variated start index (bad), find the valid window
 * Time: O(n), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    public long CountSubarrays(int[] nums, int minK, int maxK)
    {
        // Set jBad as the start index (initial -1) of new array
        // if jMin and jMax are > jBad, there are [jBad + 1, min(jMin, jMax)] possible combinations
        // i.e. possible combinations = min(jMin, jMax) - (jBad + 1) + 1 = min(jMin, jMax) - jBad
        // if jMin or jMax <= jBad, possible combinations = 0 because new array cannot find valid window
        // i.e. [1,3,5,2,7,5] => array 1: [1,3,5,2] / array 2: [5]
        int jBad = -1, jMin = -1, jMax = -1;
        long ans = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] < minK || nums[i] > maxK)
                jBad = i;

            if (nums[i] == minK)
                jMin = i;

            if (nums[i] == maxK)
                jMax = i;

            // if jMin or jMax <= jBad, takes 0 as result
            ans += Math.Max(0, Math.Min(jMin, jMax) - jBad);
        }
        return ans;
    }
}
// @lc code=end


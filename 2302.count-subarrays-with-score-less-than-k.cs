/*
 * @lc app=leetcode id=2302 lang=csharp
 *
 * [2302] Count Subarrays With Score Less Than K
 *
 * https://leetcode.com/problems/count-subarrays-with-score-less-than-k/description/
 *
 * algorithms
 * Hard (55.47%)
 * Likes:    1135
 * Dislikes: 33
 * Total Accepted:    43.5K
 * Total Submissions: 76.5K
 * Testcase Example:  '[2,1,4,3,5]\n10'
 *
 * The score of an array is defined as the product of its sum and its
 * length.
 * 
 * 
 * For example, the score of [1, 2, 3, 4, 5] is (1 + 2 + 3 + 4 + 5) * 5 = 75.
 * 
 * 
 * Given a positive integer array nums and an integer k, return the number of
 * non-empty subarrays of nums whose score is strictly less than k.
 * 
 * A subarray is a contiguous sequence of elements within an array.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [2,1,4,3,5], k = 10
 * Output: 6
 * Explanation:
 * The 6 subarrays having scores less than 10 are:
 * - [2] with score 2 * 1 = 2.
 * - [1] with score 1 * 1 = 1.
 * - [4] with score 4 * 1 = 4.
 * - [3] with score 3 * 1 = 3. 
 * - [5] with score 5 * 1 = 5.
 * - [2,1] with score (2 + 1) * 2 = 6.
 * Note that subarrays such as [1,4] and [4,3,5] are not considered because
 * their scores are 10 and 36 respectively, while we need scores strictly less
 * than 10.
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [1,1,1], k = 5
 * Output: 5
 * Explanation:
 * Every subarray except [1,1,1] has a score less than 5.
 * [1,1,1] has a score (1 + 1 + 1) * 3 = 9, which is greater than 5.
 * Thus, there are 5 subarrays having scores less than 5.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 10^5
 * 1 <= nums[i] <= 10^5
 * 1 <= k <= 10^15
 * 
 * 
 */
/*
 * Two Pointer Approach - Sliding Window
 * Time: O(n), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    // For any max length of valid window, all the subarray inside are valid
    // So everytime the window expand, there are (r - l + 1) combinations valid
    // i.e. [1,2,3,4]
    // if [1,2,3] are valid window, there are total 1+2+3 = 6 valid combinations
    // if new num not valid, then shrink the window and find the max size of new valid window
    public long CountSubarrays(int[] nums, long k)
    {
        long sum = 0;
        long ans = 0;
        int l = 0;
        for (int r = 0; r < nums.Length; r++)
        {
            // add the nums[r] to the sum
            sum += nums[r];
            // if not valid, shrink the window until it valid
            while (sum * (r - l + 1) >= k)
            {
                sum -= nums[l++];
            }
            // for every valid window, (r - l + 1) combinations will be added to ans
            ans += r - l + 1;
        }
        return ans;
    }
}
// @lc code=end


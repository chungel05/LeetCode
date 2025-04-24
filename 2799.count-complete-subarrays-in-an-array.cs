/*
 * @lc app=leetcode id=2799 lang=csharp
 *
 * [2799] Count Complete Subarrays in an Array
 *
 * https://leetcode.com/problems/count-complete-subarrays-in-an-array/description/
 *
 * algorithms
 * Medium (65.68%)
 * Likes:    602
 * Dislikes: 14
 * Total Accepted:    48.4K
 * Total Submissions: 74.8K
 * Testcase Example:  '[1,3,1,2,2]'
 *
 * You are given an array nums consisting of positive integers.
 * 
 * We call a subarray of an array complete if the following condition is
 * satisfied:
 * 
 * 
 * The number of distinct elements in the subarray is equal to the number of
 * distinct elements in the whole array.
 * 
 * 
 * Return the number of complete subarrays.
 * 
 * A subarray is a contiguous non-empty part of an array.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [1,3,1,2,2]
 * Output: 4
 * Explanation: The complete subarrays are the following: [1,3,1,2],
 * [1,3,1,2,2], [3,1,2] and [3,1,2,2].
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [5,5,5,5]
 * Output: 10
 * Explanation: The array consists only of the integer 5, so any subarray is
 * complete. The number of subarrays that we can choose is 10.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 1000
 * 1 <= nums[i] <= 2000
 * 
 * 
 */
/*
 * Two Pointer - Sliding Window
 * Time: O(n), Space: O(n)
 */

// @lc code=start
public partial class Solution
{
    public int CountCompleteSubarrays(int[] nums)
    {
        // Store nums into hashset, find the no. of distinct elements
        HashSet<int> hash = new HashSet<int>(nums);
        // Count the occurrences of each element
        Dictionary<int, int> count = new Dictionary<int, int>();
        int n = nums.Length;

        // total distinct elements
        int distinct = hash.Count;
        // current distinct elements
        int curr = 0;
        int ans = 0;
        // left pointer
        int l = 0;
        for (int r = 0; r < n; r++)
        {
            // get the count of current nums[r]
            count.TryGetValue(nums[r], out int v);
            // if it is new element, current distinct + 1
            curr += v == 0 ? 1 : 0;
            // increment occurrences of nums[r]
            count[nums[r]] = v + 1;

            // if it is valid window
            while (curr == distinct)
            {
                //every valid window, add possible combination to ans
                ans += n - r;

                // move l pointer and decrement the occurrences
                count[nums[l]]--;
                if (count[nums[l]] == 0)
                    curr--;
                l++;
            }
        }
        return ans;
    }
}
// @lc code=end


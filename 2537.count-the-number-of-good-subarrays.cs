/*
 * @lc app=leetcode id=2537 lang=csharp
 *
 * [2537] Count the Number of Good Subarrays
 *
 * https://leetcode.com/problems/count-the-number-of-good-subarrays/description/
 *
 * algorithms
 * Medium (51.74%)
 * Likes:    1012
 * Dislikes: 34
 * Total Accepted:    37.9K
 * Total Submissions: 64.5K
 * Testcase Example:  '[1,1,1,1,1]\n10'
 *
 * Given an integer array nums and an integer k, return the number of good
 * subarrays of nums.
 * 
 * A subarray arr is good if there are at least k pairs of indices (i, j) such
 * that i < j and arr[i] == arr[j].
 * 
 * A subarray is a contiguous non-empty sequence of elements within an
 * array.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [1,1,1,1,1], k = 10
 * Output: 1
 * Explanation: The only good subarray is the array nums itself.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [3,1,4,3,2,2,4], k = 2
 * Output: 4
 * Explanation: There are 4 different good subarrays:
 * - [3,1,4,3,2,2] that has 2 pairs.
 * - [3,1,4,3,2,2,4] that has 3 pairs.
 * - [1,4,3,2,2,4] that has 2 pairs.
 * - [4,3,2,2,4] that has 2 pairs.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 10^5
 * 1 <= nums[i], k <= 10^9
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
    public long CountGood(int[] nums, int k)
    {
        // dict to count the nums occurrences
        Dictionary<int, int> count = new Dictionary<int, int>();
        int n = nums.Length;
        long ans = 0;
        int pairs = 0;
        // left, right pointer
        int l = 0, r = 0;

        while (r < n)
        {
            // Get the occurrences of current nums[r]
            count.TryGetValue(nums[r], out int v);
            // if it is 0, then there is no pair yet
            // if it is 1, then there is 1 pair
            // if it is 5, then there is 4 pair, because new nums[r] can pair with each prev. occurrences
            pairs += v;

            // increment occurrences of nums[r]
            // without checking the key, use v + 1 to initialize(0) or add
            count[nums[r]] = v + 1;

            // if pairs >= k, it is valid window
            while (pairs >= k)
            {
                // for each valid window, add the possible combinations, which is from r to n
                ans += n - r;
                // shrink the window
                count[nums[l]]--;
                // decrement the pairs, which is count after -1
                pairs -= count[nums[l]];
                l++;
            }

            // move r pointer
            r++;
        }
        return ans;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=2364 lang=csharp
 *
 * [2364] Count Number of Bad Pairs
 *
 * https://leetcode.com/problems/count-number-of-bad-pairs/description/
 *
 * algorithms
 * Medium (41.98%)
 * Likes:    1025
 * Dislikes: 27
 * Total Accepted:    36.7K
 * Total Submissions: 86.9K
 * Testcase Example:  '[4,1,3,3]'
 *
 * You are given a 0-indexed integer array nums. A pair of indices (i, j) is a
 * bad pair if i < j and j - i != nums[j] - nums[i].
 * 
 * Return the total number of bad pairs in nums.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [4,1,3,3]
 * Output: 5
 * Explanation: The pair (0, 1) is a bad pair since 1 - 0 != 1 - 4.
 * The pair (0, 2) is a bad pair since 2 - 0 != 3 - 4, 2 != -1.
 * The pair (0, 3) is a bad pair since 3 - 0 != 3 - 4, 3 != -1.
 * The pair (1, 2) is a bad pair since 2 - 1 != 3 - 1, 1 != 2.
 * The pair (2, 3) is a bad pair since 3 - 2 != 3 - 3, 1 != 0.
 * There are a total of 5 bad pairs, so we return 5.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [1,2,3,4,5]
 * Output: 0
 * Explanation: There are no bad pairs.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 10^5
 * 1 <= nums[i] <= 10^9
 * 
 * 
 */
/*
 * Occurrence Counting Approach
 * Time: O(n), Space: O(n)
 */

// @lc code=start
public partial class Solution
{
    // Good Pair: j - i == nums[j] - nums[i]
    // => nums[j] - j == nums[i] - i
    // which is using Hash to check the diff. of nums[i] - i exists or not
    // if diff. exists, then occurrence of diff. is good pair, others are bad pairs
    public long CountBadPairs(int[] nums)
    {
        // use dictionary to keep tracking the occurrence of diff.
        Dictionary<int, int> freq = new Dictionary<int, int>();
        // ans to keep bad pairs, since nums.length <= 10^5, so ans maybe > 2^31 - 1
        long ans = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            // calc the diff.
            int diff = nums[i] - i;
            // if not exists, set to 0
            if (!freq.ContainsKey(diff))
                freq[diff] = 0;

            // i = no. of bad pairs
            // i.e. [1, 2, 3], when i = 2, prev. pair will be 0 and 1 which is 2
            // so bad pairs = total possible bad pairs - good pairs
            // bad pairs = i - freq[diff], freq[diff] maybe 0
            ans += i - freq[diff];

            // increment freq for next element
            freq[diff]++;
        }
        return ans;
    }
}
// @lc code=end


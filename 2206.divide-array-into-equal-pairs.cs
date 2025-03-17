/*
 * @lc app=leetcode id=2206 lang=csharp
 *
 * [2206] Divide Array Into Equal Pairs
 *
 * https://leetcode.com/problems/divide-array-into-equal-pairs/description/
 *
 * algorithms
 * Easy (73.89%)
 * Likes:    768
 * Dislikes: 38
 * Total Accepted:    103.2K
 * Total Submissions: 137.9K
 * Testcase Example:  '[3,2,3,2,2,2]'
 *
 * You are given an integer array nums consisting of 2 * n integers.
 * 
 * You need to divide nums into n pairs such that:
 * 
 * 
 * Each element belongs to exactly one pair.
 * The elements present in a pair are equal.
 * 
 * 
 * Return true if nums can be divided into n pairs, otherwise return false.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [3,2,3,2,2,2]
 * Output: true
 * Explanation: 
 * There are 6 elements in nums, so they should be divided into 6 / 2 = 3
 * pairs.
 * If nums is divided into the pairs (2, 2), (3, 3), and (2, 2), it will
 * satisfy all the conditions.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [1,2,3,4]
 * Output: false
 * Explanation: 
 * There is no way to divide nums into 4 / 2 = 2 pairs such that the pairs
 * satisfy every condition.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * nums.length == 2 * n
 * 1 <= n <= 500
 * 1 <= nums[i] <= 500
 * 
 * 
 */
/*
 * Map Counting Approach
 * Time: O(n), Space: O(n)
 */

// @lc code=start
public partial class Solution
{
    public bool DivideArray(int[] nums)
    {
        // 1 <= nums[i] <= 500
        int[] count = new int[500 + 1];
        // count the occurrences
        for (int i = 0; i < nums.Length; i++)
        {
            count[nums[i]]++;
        }

        // check all the val
        for (int i = 1; i <= 500; i++)
        {
            // if it has odd no. of val i, it cannot form a valid pair
            // return false
            if ((count[i] & 1) != 0)
                return false;
        }
        // all val can form valid pairs
        return true;
    }
}
// @lc code=end


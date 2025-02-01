/*
 * @lc app=leetcode id=3151 lang=csharp
 *
 * [3151] Special Array I
 *
 * https://leetcode.com/problems/special-array-i/description/
 *
 * algorithms
 * Easy (75.73%)
 * Likes:    133
 * Dislikes: 10
 * Total Accepted:    70.8K
 * Total Submissions: 93.4K
 * Testcase Example:  '[1]'
 *
 * An array is considered special if every pair of its adjacent elements
 * contains two numbers with different parity.
 * 
 * You are given an array of integers nums. Return true if nums is a special
 * array, otherwise, return false.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [1]
 * 
 * Output: true
 * 
 * Explanation:
 * 
 * There is only one element. So the answer is true.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [2,1,4]
 * 
 * Output: true
 * 
 * Explanation:
 * 
 * There is only two pairs: (2,1) and (1,4), and both of them contain numbers
 * with different parity. So the answer is true.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: nums = [4,3,1,6]
 * 
 * Output: false
 * 
 * Explanation:
 * 
 * nums[1] and nums[2] are both odd. So the answer is false.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 100
 * 1 <= nums[i] <= 100
 * 
 * 
 */
/*
 * Array checking with prev. num
 * Time: O(n), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    public bool IsArraySpecial(int[] nums)
    {
        // start from nums[1], if nums.Length = 1, skip and return true
        for (int i = 1; i < nums.Length; i++)
        {
            // compare with prev. nums
            // if they are odd / even, return false
            if (nums[i - 1] % 2 == nums[i] % 2)
                return false;
        }

        return true;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=1863 lang=csharp
 *
 * [1863] Sum of All Subset XOR Totals
 *
 * https://leetcode.com/problems/sum-of-all-subset-xor-totals/description/
 *
 * algorithms
 * Easy (87.78%)
 * Likes:    2255
 * Dislikes: 276
 * Total Accepted:    210.6K
 * Total Submissions: 239.1K
 * Testcase Example:  '[1,3]'
 *
 * The XOR total of an array is defined as the bitwise XOR of all its elements,
 * or 0 if the array is empty.
 * 
 * 
 * For example, the XOR total of the array [2,5,6] is 2 XOR 5 XOR 6 = 1.
 * 
 * 
 * Given an array nums, return the sum of all XOR totals for every subset of
 * nums. 
 * 
 * Note: Subsets with the same elements should be counted multiple times.
 * 
 * An array a is a subset of an array b if a can be obtained from b by deleting
 * some (possibly zero) elements of b.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [1,3]
 * Output: 6
 * Explanation: The 4 subsets of [1,3] are:
 * - The empty subset has an XOR total of 0.
 * - [1] has an XOR total of 1.
 * - [3] has an XOR total of 3.
 * - [1,3] has an XOR total of 1 XOR 3 = 2.
 * 0 + 1 + 3 + 2 = 6
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [5,1,6]
 * Output: 28
 * Explanation: The 8 subsets of [5,1,6] are:
 * - The empty subset has an XOR total of 0.
 * - [5] has an XOR total of 5.
 * - [1] has an XOR total of 1.
 * - [6] has an XOR total of 6.
 * - [5,1] has an XOR total of 5 XOR 1 = 4.
 * - [5,6] has an XOR total of 5 XOR 6 = 3.
 * - [1,6] has an XOR total of 1 XOR 6 = 7.
 * - [5,1,6] has an XOR total of 5 XOR 1 XOR 6 = 2.
 * 0 + 5 + 1 + 6 + 4 + 3 + 7 + 2 = 28
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: nums = [3,4,5,6,7,8]
 * Output: 480
 * Explanation: The sum of all XOR totals for every subset is 480.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 12
 * 1 <= nums[i] <= 20
 * 
 * 
 */
/*
 * Bit Manipulation Approach
 * Time: O(n), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    // i.e. [1, 3, 5]
    // Combination:
    // 0      0  0  0
    // 1      0  0  1
    // 3      0  1  1
    // 1,3    0  1  0
    // 5      1  0  1
    // 1,5    1  0  0
    // 3,5    1  1  0
    // 1,3,5  1  1  1
    // Since we will have combination of 2^n
    // if new number added, i-th bit will be flip according to XOR operation
    // so for each i-th bit, if it is set by some num, it will have half combinations contain 1, i.e. 2^i * 2^(n - 1)
    // to sum it up = (2^0 + 2^1 + 2^2) * 2^(n - 1)
    public int SubsetXORSum(int[] nums)
    {
        int ans = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            // by OR operation, we get the 2^0 + 2^1 + 2^2 + ..., depending on bit set or not
            ans |= nums[i];
        }
        // ans = ans * 2^(n - 1) which is shift left n - 1 times
        return ans << (nums.Length - 1);
    }

    // Brute Force Approach, get all possible combination and sum
    // Time: O(n * 2^n), Space: O(2^n)
    /* public int SubsetXORSum(int[] nums)
    {
        List<int> ans = new List<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = ans.Count - 1; j >= 0; j--)
            {
                ans.Add(ans[j] ^ nums[i]);
            }
            ans.Add(nums[i]);
        }
        return ans.Sum();
    } */
}
// @lc code=end


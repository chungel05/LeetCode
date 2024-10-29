/*
 * @lc app=leetcode id=152 lang=csharp
 *
 * [152] Maximum Product Subarray
 *
 * https://leetcode.com/problems/maximum-product-subarray/description/
 *
 * algorithms
 * Medium (34.00%)
 * Likes:    18821
 * Dislikes: 743
 * Total Accepted:    1.4M
 * Total Submissions: 4.2M
 * Testcase Example:  '[2,3,-2,4]'
 *
 * Given an integer array nums, find a subarray that has the largest product,
 * and return the product.
 * 
 * The test cases are generated so that the answer will fit in a 32-bit
 * integer.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [2,3,-2,4]
 * Output: 6
 * Explanation: [2,3] has the largest product 6.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [-2,0,-1]
 * Output: 0
 * Explanation: The result cannot be 2, because [-2,-1] is not a subarray.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 2 * 10^4
 * -10 <= nums[i] <= 10
 * The product of any subarray of nums is guaranteed to fit in a 32-bit
 * integer.
 * 
 * 
 */
/*
 * keep tracking the product
 * use maxVal and minVal to include positive num (+)sign and negative num (-)sign
 * if it is 0, the maxVal and minVal are 0.
 * next num will reset the maxVal if it is positive and reset the minVal if it is negative
 */

// @lc code=start
public partial class Solution
{
    public int MaxProduct(int[] nums)
    {
        int maxVal = 1;
        int minVal = 1;
        int res = int.MinValue;

        for (int i = 0; i < nums.Length; i++)
        {
            int a = maxVal * nums[i];
            int b = minVal * nums[i];
            maxVal = Math.Max(Math.Max(a, b), nums[i]);
            minVal = Math.Min(Math.Min(a, b), nums[i]);
            res = Math.Max(res, maxVal);
        }
        return res;
    }
}
// @lc code=end


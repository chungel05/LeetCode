/*
 * @lc app=leetcode id=1726 lang=csharp
 *
 * [1726] Tuple with Same Product
 *
 * https://leetcode.com/problems/tuple-with-same-product/description/
 *
 * algorithms
 * Medium (61.31%)
 * Likes:    1257
 * Dislikes: 52
 * Total Accepted:    170.9K
 * Total Submissions: 243.5K
 * Testcase Example:  '[2,3,4,6]'
 *
 * Given an array nums of distinct positive integers, return the number of
 * tuples (a, b, c, d) such that a * b = c * d where a, b, c, and d are
 * elements of nums, and a != b != c != d.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [2,3,4,6]
 * Output: 8
 * Explanation: There are 8 valid tuples:
 * (2,6,3,4) , (2,6,4,3) , (6,2,3,4) , (6,2,4,3)
 * (3,4,2,6) , (4,3,2,6) , (3,4,6,2) , (4,3,6,2)
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [1,2,4,5,10]
 * Output: 16
 * Explanation: There are 16 valid tuples:
 * (1,10,2,5) , (1,10,5,2) , (10,1,2,5) , (10,1,5,2)
 * (2,5,1,10) , (2,5,10,1) , (5,2,1,10) , (5,2,10,1)
 * (2,10,4,5) , (2,10,5,4) , (10,2,4,5) , (10,2,5,4)
 * (4,5,2,10) , (4,5,10,2) , (5,4,2,10) , (5,4,10,2)
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 1000
 * 1 <= nums[i] <= 10^4
 * All elements in nums are distinct.
 * 
 * 
 */
/*
 * Occurrence counting approach
 * Time: O(n^2), Space: O(n^2)
 */

// @lc code=start
public partial class Solution
{
    public int TupleSameProduct(int[] nums)
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        int ans = 0;
        // loop through all combinations, which is O(n^2)
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                // Count the occurrence of product of each combinations
                int product = nums[i] * nums[j];
                if (!dict.ContainsKey(product))
                    dict[product] = 0;
                dict[product]++;

                // if occurrence > 1 then it is match with the condition a * b = c * d
                // each matching will create 8 combinations
                // if occurrence already match before, i.e. dict[product] = 4 after new combination added
                // we need to match new combination with prev. combination 3 times, which is 8 * 3
                if (dict[product] > 1)
                {
                    ans += 8 * (dict[product] - 1);
                }
            }
        }

        return ans;
    }
}
// @lc code=end


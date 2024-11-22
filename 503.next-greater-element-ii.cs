/*
 * @lc app=leetcode id=503 lang=csharp
 *
 * [503] Next Greater Element II
 *
 * https://leetcode.com/problems/next-greater-element-ii/description/
 *
 * algorithms
 * Medium (64.84%)
 * Likes:    8171
 * Dislikes: 200
 * Total Accepted:    478K
 * Total Submissions: 735.4K
 * Testcase Example:  '[1,2,1]'
 *
 * Given a circular integer array nums (i.e., the next element of
 * nums[nums.length - 1] is nums[0]), return the next greater number for every
 * element in nums.
 * 
 * The next greater number of a number x is the first greater number to its
 * traversing-order next in the array, which means you could search circularly
 * to find its next greater number. If it doesn't exist, return -1 for this
 * number.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [1,2,1]
 * Output: [2,-1,2]
 * Explanation: The first 1's next greater number is 2; 
 * The number 2 can't find next greater number. 
 * The second 1's next greater number needs to search circularly, which is also
 * 2.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [1,2,3,4,3]
 * Output: [2,3,4,-1,4]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 10^4
 * -10^9 <= nums[i] <= 10^9
 * 
 * 
 */
/*
 * Time: O(n), Space: O(n)
 */

// @lc code=start
public partial class Solution
{
    public int[] NextGreaterElements(int[] nums)
    {
        Stack<int> stack = new Stack<int>();
        int[] res = new int[nums.Length];
        Array.Fill(res, -1);

        for (int i = 0; i < 2 * nums.Length; i++)
        {
            int j = i % nums.Length;
            while (stack.Count > 0 && nums[stack.Peek()] < nums[j])
            {
                res[stack.Pop()] = nums[j];
            }

            // we only push the i within nums.Length
            // to avoid duplicate
            if (i < nums.Length)
                stack.Push(j);
        }
        return res;
    }
}
// @lc code=end


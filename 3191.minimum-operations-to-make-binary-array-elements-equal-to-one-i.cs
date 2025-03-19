/*
 * @lc app=leetcode id=3191 lang=csharp
 *
 * [3191] Minimum Operations to Make Binary Array Elements Equal to One I
 *
 * https://leetcode.com/problems/minimum-operations-to-make-binary-array-elements-equal-to-one-i/description/
 *
 * algorithms
 * Medium (71.09%)
 * Likes:    176
 * Dislikes: 9
 * Total Accepted:    50.5K
 * Total Submissions: 71.1K
 * Testcase Example:  '[0,1,1,1,0,0]'
 *
 * You are given a binary array nums.
 * 
 * You can do the following operation on the array any number of times
 * (possibly zero):
 * 
 * 
 * Choose any 3 consecutive elements from the array and flip all of them.
 * 
 * 
 * Flipping an element means changing its value from 0 to 1, and from 1 to 0.
 * 
 * Return the minimum number of operations required to make all elements in
 * nums equal to 1. If it is impossible, return -1.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [0,1,1,1,0,0]
 * 
 * Output: 3
 * 
 * Explanation:
 * We can do the following operations:
 * 
 * 
 * Choose the elements at indices 0, 1 and 2. The resulting array is nums =
 * [1,0,0,1,0,0].
 * Choose the elements at indices 1, 2 and 3. The resulting array is nums =
 * [1,1,1,0,0,0].
 * Choose the elements at indices 3, 4 and 5. The resulting array is nums =
 * [1,1,1,1,1,1].
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [0,1,1,1]
 * 
 * Output: -1
 * 
 * Explanation:
 * It is impossible to make all elements equal to 1.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 3 <= nums.length <= 10^5
 * 0 <= nums[i] <= 1
 * 
 * 
 */
/*
 * Two Pointer - Sliding Window
 * Time: O(n), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    public int MinOperations(int[] nums)
    {
        int ans = 0;
        // loop from [0, n - 1], fixed window of 3
        for (int i = 0; i < nums.Length; i++)
        {
            // if current nums[i] is 0, it needs to flip
            if (nums[i] == 0)
            {
                // if not enough (3) elements to flip, return -1
                if (i >= nums.Length - 2)
                    return -1;

                // flip the value and count the operations
                ans++;
                nums[i + 1] = nums[i + 1] ^ 1;
                nums[i + 2] = nums[i + 2] ^ 1;
            }
        }
        return ans;
    }
}
// @lc code=end


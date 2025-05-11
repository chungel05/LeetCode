/*
 * @lc app=leetcode id=1550 lang=csharp
 *
 * [1550] Three Consecutive Odds
 *
 * https://leetcode.com/problems/three-consecutive-odds/description/
 *
 * algorithms
 * Easy (68.28%)
 * Likes:    1181
 * Dislikes: 95
 * Total Accepted:    307.2K
 * Total Submissions: 449.6K
 * Testcase Example:  '[2,6,4,1]'
 *
 * Given an integer array arr, return true if there are three consecutive odd
 * numbers in the array. Otherwise, return false.
 * 
 * Example 1:
 * 
 * 
 * Input: arr = [2,6,4,1]
 * Output: false
 * Explanation: There are no three consecutive odds.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: arr = [1,2,34,3,4,5,7,23,12]
 * Output: true
 * Explanation: [5,7,23] are three consecutive odds.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= arr.length <= 1000
 * 1 <= arr[i] <= 1000
 * 
 * 
 */
/*
 * Counting Approach
 * Time: O(n), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    public bool ThreeConsecutiveOdds(int[] arr)
    {
        int count = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            // count the odd nums, if it is even, reset to 0
            count = (arr[i] & 1) == 1 ? count + 1 : 0;
            // if already have 3 consecutive odd nums, break the loop and return ans
            if (count == 3)
                return true;
        }

        return false;
    }
}
// @lc code=end


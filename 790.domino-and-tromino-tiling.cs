/*
 * @lc app=leetcode id=790 lang=csharp
 *
 * [790] Domino and Tromino Tiling
 *
 * https://leetcode.com/problems/domino-and-tromino-tiling/description/
 *
 * algorithms
 * Medium (49.62%)
 * Likes:    3657
 * Dislikes: 1186
 * Total Accepted:    176.5K
 * Total Submissions: 362.3K
 * Testcase Example:  '3'
 *
 * You have two types of tiles: a 2 x 1 domino shape and a tromino shape. You
 * may rotate these shapes.
 * 
 * Given an integer n, return the number of ways to tile an 2 x n board. Since
 * the answer may be very large, return it modulo 10^9 + 7.
 * 
 * In a tiling, every square must be covered by a tile. Two tilings are
 * different if and only if there are two 4-directionally adjacent cells on the
 * board such that exactly one of the tilings has both squares occupied by a
 * tile.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: n = 3
 * Output: 5
 * Explanation: The five different ways are show above.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: n = 1
 * Output: 1
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= n <= 1000
 * 
 * 
 */
/*
 * DP Approach
 * Time: O(n), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    // 2 type of tiles: Domino and Tromino
    // can be rotate as 6 cases:
    // 1: ┃, 2: ━, 3: ┏, 4: ┗, 5: ┓, 6: ┛
    // to complete T(n), we can have 1,2,5,6 at the end
    // which is T(n) = [T(n - 1) + Type 1] + [T(n - 2) + 2 Type 2] + [T_down(n - 1) + Type 5] + [T_up(n - 1) + Type 6]
    // and T_up(n) = [T_down(n - 1) + Type 2] + [T(n - 2) + Type 3]
    // and T_down(n) = [T_up(n - 1) + Type 2] + [T(n - 2) + Type 4]
    // so we have T(n) = T(n - 1) + T(n - 2) + T_down(n - 1) + T_up(n - 1)
    // T_up(n - 1) = T_down(n - 2) + T(n - 3)
    // T_down(n - 1) = T_up(n - 2) + T(n - 3)
    // combining 3 formula => T(n) = T(n - 1) + T(n - 2) + T_down(n - 2) + T(n - 3) + T_up(n - 2) + T(n - 3)
    // by T(n) - T(n - 1) =  T(n - 1) + T(n - 2) + T_down(n - 2) + T(n - 3) + T_up(n - 2) + T(n - 3)
    //                       - T(n - 2) - T(n - 3) - T_down(n - 2) - T_up(n - 2)
    // finally, we have T(n) - T(n - 1) = T(n - 1) + T(n - 3)
    // => T(n) = 2 * T(n - 1) + T(n - 3)
    public int NumTilings(int n)
    {
        long i3 = 1, i2 = 1, i1 = 2;

        // base case:
        // T(0) = 0, T(1) = 1, T(2) = 2
        if (n == 0)
            return 0;
        else if (n == 1)
            return 1;
        else if (n == 2)
            return 2;

        // T(n) = 2 * T(n - 1) + T(n - 3)
        for (int i = 3; i <= n; i++)
        {
            long curr = (2 * (long)i1 + i3) % 1_000_000_007;
            i3 = i2;
            i2 = i1;
            i1 = curr;
        }
        return (int)i1;
    }
}
// @lc code=end


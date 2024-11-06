/*
 * @lc app=leetcode id=518 lang=csharp
 *
 * [518] Coin Change II
 *
 * https://leetcode.com/problems/coin-change-ii/description/
 *
 * algorithms
 * Medium (64.46%)
 * Likes:    9513
 * Dislikes: 175
 * Total Accepted:    709.5K
 * Total Submissions: 1.1M
 * Testcase Example:  '5\n[1,2,5]'
 *
 * You are given an integer array coins representing coins of different
 * denominations and an integer amount representing a total amount of money.
 * 
 * Return the number of combinations that make up that amount. If that amount
 * of money cannot be made up by any combination of the coins, return 0.
 * 
 * You may assume that you have an infinite number of each kind of coin.
 * 
 * The answer is guaranteed to fit into a signed 32-bit integer.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: amount = 5, coins = [1,2,5]
 * Output: 4
 * Explanation: there are four ways to make up the amount:
 * 5=5
 * 5=2+2+1
 * 5=2+1+1+1
 * 5=1+1+1+1+1
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: amount = 3, coins = [2]
 * Output: 0
 * Explanation: the amount of 3 cannot be made up just with coins of 2.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: amount = 10, coins = [10]
 * Output: 1
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= coins.length <= 300
 * 1 <= coins[i] <= 5000
 * All the values of coins are unique.
 * 0 <= amount <= 5000
 * 
 * 
 */
/*      5   4   3   2   1   0  
 *    +---+---+---+---+---+---+
 *  1 | 4 | 3 | 2 | 2 | 1 | 1 |
 *    +---+---+---+---+---+---+
 *  2 | 1 | 1 | 0 | 1 | 0 | 1 |
 *    +---+---+---+---+---+---+
 *  5 | 1 | 0 | 0 | 0 | 0 | 1 |
 *    +---+---+---+---+---+---+
 */

// @lc code=start
public partial class Solution
{
    public int Change(int amount, int[] coins)
    {
        int[][] dp = new int[coins.Length][];
        for (int i = 0; i < coins.Length; i++)
        {
            dp[i] = new int[amount + 1];
            dp[i][0] = 1;
        }

        for (int i = coins.Length - 1; i >= 0; i--)
        {
            for (int j = 1; j <= amount; j++)
            {
                dp[i][j] = 0;
                if (j - coins[i] >= 0)
                    dp[i][j] += dp[i][j - coins[i]];
                if (i + 1 < coins.Length)
                    dp[i][j] += dp[i + 1][j];
            }
        }
        return dp[0][amount];
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=322 lang=csharp
 *
 * [322] Coin Change
 *
 * https://leetcode.com/problems/coin-change/description/
 *
 * algorithms
 * Medium (44.95%)
 * Likes:    19262
 * Dislikes: 472
 * Total Accepted:    2M
 * Total Submissions: 4.5M
 * Testcase Example:  '[1,2,5]\n11'
 *
 * You are given an integer array coins representing coins of different
 * denominations and an integer amount representing a total amount of money.
 * 
 * Return the fewest number of coins that you need to make up that amount. If
 * that amount of money cannot be made up by any combination of the coins,
 * return -1.
 * 
 * You may assume that you have an infinite number of each kind of coin.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: coins = [1,2,5], amount = 11
 * Output: 3
 * Explanation: 11 = 5 + 5 + 1
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: coins = [2], amount = 3
 * Output: -1
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: coins = [1], amount = 0
 * Output: 0
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= coins.length <= 12
 * 1 <= coins[i] <= 2^31 - 1
 * 0 <= amount <= 10^4
 * 
 * 
 */
/*
 * Bottom-up DP approach
 * calc each amount with min coins, until the target amount
 */

// @lc code=start
public partial class Solution
{
    public int CoinChange(int[] coins, int amount)
    {
        // from 0 to target amount = amount + 1
        int[] dp = new int[amount + 1];
        // make sure the initial coin num is bigger than amount
        Array.Fill(dp, amount + 1);
        dp[0] = 0;

        for (int i = 1; i <= amount; i++)
        {
            foreach (int coin in coins)
            {
                if (coin <= i)
                {
                    // [$3] = $1 * 1 + dp[$2] or
                    // [$3] = $3 * 1 + dp[$0]
                    dp[i] = Math.Min(dp[i], 1 + dp[i - coin]);
                }
            }
        }
        // initial value is larger than amount, so check whether we have min value or not
        return dp[amount] > amount ? -1 : dp[amount];
    }
}
// @lc code=end


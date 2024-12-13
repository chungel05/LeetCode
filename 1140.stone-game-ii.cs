/*
 * @lc app=leetcode id=1140 lang=csharp
 *
 * [1140] Stone Game II
 *
 * https://leetcode.com/problems/stone-game-ii/description/
 *
 * algorithms
 * Medium (73.26%)
 * Likes:    3333
 * Dislikes: 903
 * Total Accepted:    179.5K
 * Total Submissions: 245.4K
 * Testcase Example:  '[2,7,9,4,4]'
 *
 * Alice and Bob continue their games with piles of stones. There are a number
 * of piles arranged in a row, and each pile has a positive integer number of
 * stones piles[i]. The objective of the game is to end with the most stones.
 * 
 * Alice and Bob take turns, with Alice starting first.
 * 
 * On each player's turn, that player can take all the stones in the first X
 * remaining piles, where 1 <= X <= 2M. Then, we set M = max(M, X). Initially,
 * M = 1.
 * 
 * The game continues until all the stones have been taken.
 * 
 * Assuming Alice and Bob play optimally, return the maximum number of stones
 * Alice can get.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: piles = [2,7,9,4,4]
 * 
 * Output: 10
 * 
 * Explanation:
 * 
 * 
 * If Alice takes one pile at the beginning, Bob takes two piles, then Alice
 * takes 2 piles again. Alice can get 2 + 4 + 4 = 10 stones in total.
 * If Alice takes two piles at the beginning, then Bob can take all three piles
 * left. In this case, Alice get 2 + 7 = 9 stones in total.
 * 
 * 
 * So we return 10 since it's larger.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: piles = [1,2,3,4,5,100]
 * 
 * Output: 104
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= piles.length <= 100
 * 1 <= piles[i] <= 10^4
 * 
 * 
 */
/*
 * DFS Top down approach with caching
 * Time: O(n^3), Space: O(n^2)
 */

// @lc code=start
public partial class Solution
{
    private int DFSStoneGameII(int[] piles, int i, int M, int[] prefixSum, int[][] dp)
    {
        // if player can take all, then just return remaining total points
        if (2 * M >= piles.Length - i)
            return prefixSum[piles.Length] - prefixSum[i];

        if (dp[i][M] != -1)
            return dp[i][M];

        int max = 0;
        // try all possibilities to max the points current player can get
        for (int j = 1; j <= 2 * M; j++)
        {
            // prefixSum[n] - prefixSum[i] = points from i to n
            // DFSStoneGameII return max point another player can get
            // so current player can get = remaining all the points - max point another player can get
            max = Math.Max(max, prefixSum[piles.Length] - prefixSum[i] - DFSStoneGameII(piles, i + j, Math.Max(j, M), prefixSum, dp));
        }
        dp[i][M] = max;
        return max;
    }

    public int StoneGameII(int[] piles)
    {
        int[][] dp = new int[piles.Length][];
        int[] prefixSum = new int[piles.Length + 1];
        for (int i = 0; i < piles.Length; i++)
        {
            prefixSum[i + 1] = prefixSum[i] + piles[i];
            dp[i] = new int[piles.Length + 1];
            Array.Fill(dp[i], -1);
        }

        return DFSStoneGameII(piles, 0, 1, prefixSum, dp);
    }
}
// @lc code=end


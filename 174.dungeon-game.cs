/*
 * @lc app=leetcode id=174 lang=csharp
 *
 * [174] Dungeon Game
 *
 * https://leetcode.com/problems/dungeon-game/description/
 *
 * algorithms
 * Hard (38.57%)
 * Likes:    5901
 * Dislikes: 113
 * Total Accepted:    242.7K
 * Total Submissions: 626.3K
 * Testcase Example:  '[[-2,-3,3],[-5,-10,1],[10,30,-5]]'
 *
 * The demons had captured the princess and imprisoned her in the bottom-right
 * corner of a dungeon. The dungeon consists of m x n rooms laid out in a 2D
 * grid. Our valiant knight was initially positioned in the top-left room and
 * must fight his way through dungeon to rescue the princess.
 * 
 * The knight has an initial health point represented by a positive integer. If
 * at any point his health point drops to 0 or below, he dies immediately.
 * 
 * Some of the rooms are guarded by demons (represented by negative integers),
 * so the knight loses health upon entering these rooms; other rooms are either
 * empty (represented as 0) or contain magic orbs that increase the knight's
 * health (represented by positive integers).
 * 
 * To reach the princess as quickly as possible, the knight decides to move
 * only rightward or downward in each step.
 * 
 * Return the knight's minimum initial health so that he can rescue the
 * princess.
 * 
 * Note that any room can contain threats or power-ups, even the first room the
 * knight enters and the bottom-right room where the princess is imprisoned.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: dungeon = [[-2,-3,3],[-5,-10,1],[10,30,-5]]
 * Output: 7
 * Explanation: The initial health of the knight must be at least 7 if he
 * follows the optimal path: RIGHT-> RIGHT -> DOWN -> DOWN.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: dungeon = [[0]]
 * Output: 1
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * m == dungeon.length
 * n == dungeon[i].length
 * 1 <= m, n <= 200
 * -1000 <= dungeon[i][j] <= 1000
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int CalculateMinimumHP(int[][] dungeon)
    {
        int m = dungeon.Length, n = dungeon[0].Length;
        // create 2D dp to store the min health needed in [i][j] in order to move right or down
        int[][] dp = new int[m + 1][];

        // initialized the dp to all max value
        for (int i = 0; i <= m; i++)
        {
            dp[i] = new int[n + 1];
            Array.Fill(dp[i], int.MaxValue);
        }

        // base case, [m - 1][n - 1] move to right [m - 1][n] and down [m][n - 1]
        // both of them are needed to have min 1 health
        dp[m - 1][n] = dp[m][n - 1] = 1;

        // loop from bottom right to top left
        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                // select the min health required to move right or down
                // min health required - current requirement = total health needed in current cell
                int healthNeeded = Math.Min(dp[i + 1][j], dp[i][j + 1]) - dungeon[i][j];
                // at least 1 for the hero to be alive
                dp[i][j] = Math.Max(healthNeeded, 1);
            }
        }
        return dp[0][0];
    }
}
// @lc code=end


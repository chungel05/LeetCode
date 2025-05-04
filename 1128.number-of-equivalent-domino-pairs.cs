/*
 * @lc app=leetcode id=1128 lang=csharp
 *
 * [1128] Number of Equivalent Domino Pairs
 *
 * https://leetcode.com/problems/number-of-equivalent-domino-pairs/description/
 *
 * algorithms
 * Easy (48.68%)
 * Likes:    716
 * Dislikes: 336
 * Total Accepted:    79.4K
 * Total Submissions: 161K
 * Testcase Example:  '[[1,2],[2,1],[3,4],[5,6]]'
 *
 * Given a list of dominoes, dominoes[i] = [a, b] is equivalent to dominoes[j]
 * = [c, d] if and only if either (a == c and b == d), or (a == d and b == c) -
 * that is, one domino can be rotated to be equal to another domino.
 * 
 * Return the number of pairs (i, j) for which 0 <= i < j < dominoes.length,
 * and dominoes[i] is equivalent to dominoes[j].
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: dominoes = [[1,2],[2,1],[3,4],[5,6]]
 * Output: 1
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: dominoes = [[1,2],[1,2],[1,1],[1,2],[2,2]]
 * Output: 3
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= dominoes.length <= 4 * 10^4
 * dominoes[i].length == 2
 * 1 <= dominoes[i][j] <= 9
 * 
 * 
 */
/*
 * Hash Table Approach
 * Time: O(n), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    public int NumEquivDominoPairs(int[][] dominoes)
    {
        // key = [11, 99]
        int[] count = new int[100];
        int ans = 0;
        for (int i = 0; i < dominoes.Length; i++)
        {
            // standardize the key pattern
            int key = dominoes[i][0] > dominoes[i][1] ? dominoes[i][0] * 10 + dominoes[i][1] : dominoes[i][1] * 10 + dominoes[i][0];
            // pairs = last pattern occurrences
            ans += count[key];
            // increment the pattern by 1
            count[key]++;
        }
        return ans;
    }
}
// @lc code=end


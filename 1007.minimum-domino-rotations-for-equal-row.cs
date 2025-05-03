/*
 * @lc app=leetcode id=1007 lang=csharp
 *
 * [1007] Minimum Domino Rotations For Equal Row
 *
 * https://leetcode.com/problems/minimum-domino-rotations-for-equal-row/description/
 *
 * algorithms
 * Medium (52.26%)
 * Likes:    2885
 * Dislikes: 256
 * Total Accepted:    216.1K
 * Total Submissions: 412.3K
 * Testcase Example:  '[2,1,2,4,2,2]\n[5,2,6,2,3,2]'
 *
 * In a row of dominoes, tops[i] and bottoms[i] represent the top and bottom
 * halves of the i^th domino. (A domino is a tile with two numbers from 1 to 6
 * - one on each half of the tile.)
 * 
 * We may rotate the i^th domino, so that tops[i] and bottoms[i] swap values.
 * 
 * Return the minimum number of rotations so that all the values in tops are
 * the same, or all the values in bottoms are the same.
 * 
 * If it cannot be done, return -1.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: tops = [2,1,2,4,2,2], bottoms = [5,2,6,2,3,2]
 * Output: 2
 * Explanation: 
 * The first figure represents the dominoes as given by tops and bottoms:
 * before we do any rotations.
 * If we rotate the second and fourth dominoes, we can make every value in the
 * top row equal to 2, as indicated by the second figure.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: tops = [3,5,1,2,3], bottoms = [3,6,3,3,4]
 * Output: -1
 * Explanation: 
 * In this case, it is not possible to rotate the dominoes to make one row of
 * values equal.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 2 <= tops.length <= 2 * 10^4
 * bottoms.length == tops.length
 * 1 <= tops[i], bottoms[i] <= 6
 * 
 * 
 */
/*
 * Counting Occurrence
 * Time: O(n), Space: O(1) 
 */

// @lc code=start
public partial class Solution
{
    public int MinDominoRotations(int[] tops, int[] bottoms)
    {
        int n = tops.Length;
        int[] countTop = new int[7];
        int[] countBot = new int[7];
        int[] same = new int[7];

        // counting the occurrences of top and bottom separately
        for (int i = 0; i < n; i++)
        {
            countTop[tops[i]]++;
            countBot[bottoms[i]]++;
            // if it is same, count in same
            if (tops[i] == bottoms[i])
                same[tops[i]]++;
        }

        // checking [1, 6]
        for (int i = 1; i < 7; i++)
        {
            // if topCount + botCount - same == n, then it is ans, there is only one ans
            // min flip is topCount - same / botCount - same, return the min one
            if (countTop[i] + countBot[i] - same[i] == n)
                return Math.Min(countTop[i], countBot[i]) - same[i];
        }

        // not possible, return -1
        return -1;
    }

    // Check tops[0] and bottoms[0] Approach
    // Time: O(n), Space: O(1)
    /* private int CompareMinDominoRotations(int[] tops, int[] bottoms, int target)
    {
        int flipTop = 0, flipBot = 0;
        for (int i = 0; i < tops.Length; i++)
        {
            // not equal to target, so not possible, return -1
            if (tops[i] != target && bottoms[i] != target)
                return -1;

            // count the flip operation
            if (tops[i] != target)
                flipBot++;

            if (bottoms[i] != target)
                flipTop++;
        }

        // return the min one
        return Math.Min(flipTop, flipBot);
    }

    public int MinDominoRotations(int[] tops, int[] bottoms)
    {
        // to make the tops/bottoms to be the same, either all equal to tops[0] / bottoms[0]
        int top = CompareMinDominoRotations(tops, bottoms, tops[0]);
        int bot = CompareMinDominoRotations(tops, bottoms, bottoms[0]);

        // top/bot may be min rotation/-1, so return the max value such min rotation > -1
        return Math.Max(top, bot);
    } */
}
// @lc code=end


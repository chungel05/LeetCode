/*
 * @lc app=leetcode id=838 lang=csharp
 *
 * [838] Push Dominoes
 *
 * https://leetcode.com/problems/push-dominoes/description/
 *
 * algorithms
 * Medium (57.26%)
 * Likes:    3452
 * Dislikes: 233
 * Total Accepted:    136.1K
 * Total Submissions: 235.1K
 * Testcase Example:  '"RR.L"'
 *
 * There are n dominoes in a line, and we place each domino vertically upright.
 * In the beginning, we simultaneously push some of the dominoes either to the
 * left or to the right.
 * 
 * After each second, each domino that is falling to the left pushes the
 * adjacent domino on the left. Similarly, the dominoes falling to the right
 * push their adjacent dominoes standing on the right.
 * 
 * When a vertical domino has dominoes falling on it from both sides, it stays
 * still due to the balance of the forces.
 * 
 * For the purposes of this question, we will consider that a falling domino
 * expends no additional force to a falling or already fallen domino.
 * 
 * You are given a string dominoes representing the initial state where:
 * 
 * 
 * dominoes[i] = 'L', if the i^th domino has been pushed to the left,
 * dominoes[i] = 'R', if the i^th domino has been pushed to the right, and
 * dominoes[i] = '.', if the i^th domino has not been pushed.
 * 
 * 
 * Return a string representing the final state.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: dominoes = "RR.L"
 * Output: "RR.L"
 * Explanation: The first domino expends no additional force on the second
 * domino.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: dominoes = ".L.R...LR..L.."
 * Output: "LL.RR.LLRRLL.."
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * n == dominoes.length
 * 1 <= n <= 10^5
 * dominoes[i] is either 'L', 'R', or '.'.
 * 
 * 
 */
/*
 * Two Pointer Approach
 * Time: O(n), Space: O(n)
 */

// @lc code=start
using System.Text;

public partial class Solution
{
    // Two Pointer Approach
    public string PushDominoes(string dominoes)
    {
        int idx = -1;
        char last = ' ';
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < dominoes.Length; i++)
        {
            // if current dominoes is Right
            if (dominoes[i] == 'R')
            {
                // last dominoes is also Right, then fill [idx + 1, i - 1] as 'R'
                if (last == 'R')
                    sb.Append('R', i - idx - 1);
                // last dominoes is ' ' or Left, then fill [idx + 1, i - 1] as '.'
                else
                    sb.Append('.', i - idx - 1);

                // insert current dominoes[i] and update pointer
                sb.Append('R');
                idx = i;
                last = 'R';
            }
            // if current dominoes is Left
            else if (dominoes[i] == 'L')
            {
                // last dominoes is Right
                if (last == 'R')
                {
                    // calc the space
                    int count = i - idx - 1;
                    // half of space is 'R'
                    sb.Append('R', count / 2);

                    // if space is odd, then middle one is '.'
                    if ((count & 1) == 1)
                        sb.Append('.');

                    // half of space is 'L'
                    sb.Append('L', count / 2);
                }
                // last dominoes is ' ' or Left, then fill [idx + 1, i - 1] as 'L'
                else
                    sb.Append('L', i - idx - 1);

                // insert current dominoes[i] and update pointer
                sb.Append('L');
                idx = i;
                last = 'L';
            }
        }

        // last part
        // if last is 'R', then fill [idx + 1, n - 1] as 'R'
        if (last == 'R')
            sb.Append('R', dominoes.Length - idx - 1);
        // if last is ' ' or 'L', then fill [idx + 1, n - 1] as '.'
        else
            sb.Append('.', dominoes.Length - idx - 1);

        return sb.ToString();
    }

    // Net Force Approach
    // Time: O(n), Space: O(n)
    /* public string PushDominoes(string dominoes)
    {
        int n = dominoes.Length;
        int[] forces = new int[n];

        // Force from Right
        int f = 0;
        for (int i = 0; i < n; i++)
        {
            if (dominoes[i] == 'R')
                f = n;
            else if (dominoes[i] == 'L')
                f = 0;
            else
                f = Math.Max(f - 1, 0);

            forces[i] += f;
        }

        // Force from Left
        f = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            if (dominoes[i] == 'L')
                f = n;
            else if (dominoes[i] == 'R')
                f = 0;
            else
                f = Math.Max(f - 1, 0);

            forces[i] -= f;
        }

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < n; i++)
            sb.Append(forces[i] > 0 ? 'R' : forces[i] < 0 ? 'L' : '.');

        return sb.ToString();
    } */
}
// @lc code=end


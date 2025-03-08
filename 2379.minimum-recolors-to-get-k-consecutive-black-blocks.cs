/*
 * @lc app=leetcode id=2379 lang=csharp
 *
 * [2379] Minimum Recolors to Get K Consecutive Black Blocks
 *
 * https://leetcode.com/problems/minimum-recolors-to-get-k-consecutive-black-blocks/description/
 *
 * algorithms
 * Easy (59.41%)
 * Likes:    783
 * Dislikes: 22
 * Total Accepted:    65.7K
 * Total Submissions: 109.5K
 * Testcase Example:  '"WBBWWBBWBW"\n7'
 *
 * You are given a 0-indexed string blocks of length n, where blocks[i] is
 * either 'W' or 'B', representing the color of the i^th block. The characters
 * 'W' and 'B' denote the colors white and black, respectively.
 * 
 * You are also given an integer k, which is the desired number of consecutive
 * black blocks.
 * 
 * In one operation, you can recolor a white block such that it becomes a black
 * block.
 * 
 * Return the minimum number of operations needed such that there is at least
 * one occurrence of k consecutive black blocks.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: blocks = "WBBWWBBWBW", k = 7
 * Output: 3
 * Explanation:
 * One way to achieve 7 consecutive black blocks is to recolor the 0th, 3rd,
 * and 4th blocks
 * so that blocks = "BBBBBBBWBW". 
 * It can be shown that there is no way to achieve 7 consecutive black blocks
 * in less than 3 operations.
 * Therefore, we return 3.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: blocks = "WBWBBBW", k = 2
 * Output: 0
 * Explanation:
 * No changes need to be made, since 2 consecutive black blocks already exist.
 * Therefore, we return 0.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * n == blocks.length
 * 1 <= n <= 100
 * blocks[i] is either 'W' or 'B'.
 * 1 <= k <= n
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
    public int MinimumRecolors(string blocks, int k)
    {
        // max operations = k
        int ans = k;
        // count the white block
        int white = 0;
        // left pointer
        int left = 0;
        // right pointer
        for (int right = 0; right < blocks.Length; right++)
        {
            // if blocks[right] is white, count +1
            if (blocks[right] == 'W')
                white++;

            // if window fulfil
            if (right - left + 1 >= k)
            {
                // if window exceed k, move left hand side by 1
                if (right - left + 1 > k)
                    white -= blocks[left++] == 'W' ? 1 : 0;

                // update ans
                ans = Math.Min(ans, white);
            }
        }
        return ans;
    }
}
// @lc code=end


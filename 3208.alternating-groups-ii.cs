/*
 * @lc app=leetcode id=3208 lang=csharp
 *
 * [3208] Alternating Groups II
 *
 * https://leetcode.com/problems/alternating-groups-ii/description/
 *
 * algorithms
 * Medium (40.83%)
 * Likes:    179
 * Dislikes: 11
 * Total Accepted:    28.1K
 * Total Submissions: 64.9K
 * Testcase Example:  '[0,1,0,1,0]\n3'
 *
 * There is a circle of red and blue tiles. You are given an array of integers
 * colors and an integer k. The color of tile i is represented by
 * colors[i]:
 * 
 * 
 * colors[i] == 0 means that tile i is red.
 * colors[i] == 1 means that tile i is blue.
 * 
 * 
 * An alternating group is every k contiguous tiles in the circle with
 * alternating colors (each tile in the group except the first and last one has
 * a different color from its left and right tiles).
 * 
 * Return the number of alternating groups.
 * 
 * Note that since colors represents a circle, the first and the last tiles are
 * considered to be next to each other.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: colors = [0,1,0,1,0], k = 3
 * 
 * Output: 3
 * 
 * Explanation:
 * 
 * 
 * 
 * Alternating groups:
 * 
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: colors = [0,1,0,0,1,0,1], k = 6
 * 
 * Output: 2
 * 
 * Explanation:
 * 
 * 
 * 
 * Alternating groups:
 * 
 * 
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: colors = [1,1,0,1], k = 4
 * 
 * Output: 0
 * 
 * Explanation:
 * 
 * 
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 3 <= colors.length <= 10^5
 * 0 <= colors[i] <= 1
 * 3 <= k <= colors.length
 * 
 * 
 */
/*
 * Two Pointer Approach - Sliding Window
 * Time: O(n + k), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    public int NumberOfAlternatingGroups(int[] colors, int k)
    {
        int n = colors.Length;
        // variable to count the alternating group
        int ans = 0;
        // variable to record the start index of group
        int left = 0;
        // max possible group = [n - 1, n + k - 2]
        // i.e. n = 5, k = 3; last group = [4, 6]
        for (int right = 1; right < n - 1 + k; right++)
        {
            // if current color == prev. color, reset start index to current index
            if (colors[(right - 1) % n] == colors[right % n])
            {
                left = right;
                continue;
            }

            // if sliding window == k, count as valid group
            // and move start index +1
            if (right - left + 1 == k)
            {
                ans++;
                left++;
            }
        }
        return ans;
    }
}
// @lc code=end


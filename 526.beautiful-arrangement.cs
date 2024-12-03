/*
 * @lc app=leetcode id=526 lang=csharp
 *
 * [526] Beautiful Arrangement
 *
 * https://leetcode.com/problems/beautiful-arrangement/description/
 *
 * algorithms
 * Medium (64.34%)
 * Likes:    3264
 * Dislikes: 372
 * Total Accepted:    185.8K
 * Total Submissions: 288.6K
 * Testcase Example:  '2'
 *
 * Suppose you have n integers labeled 1 through n. A permutation of those n
 * integers perm (1-indexed) is considered a beautiful arrangement if for every
 * i (1 <= i <= n), either of the following is true:
 * 
 * 
 * perm[i] is divisible by i.
 * i is divisible by perm[i].
 * 
 * 
 * Given an integer n, return the number of the beautiful arrangements that you
 * can construct.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: n = 2
 * Output: 2
 * Explanation: 
 * The first beautiful arrangement is [1,2]:
 * ⁠   - perm[1] = 1 is divisible by i = 1
 * ⁠   - perm[2] = 2 is divisible by i = 2
 * The second beautiful arrangement is [2,1]:
 * ⁠   - perm[1] = 2 is divisible by i = 1
 * ⁠   - i = 2 is divisible by perm[2] = 1
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
 * 1 <= n <= 15
 * 
 * 
 */
/*
 * Time: O(n * 2^n), we have n possible slot and each slot have 2^n possibilities
 * Space: O(2^n), we have 2^n recursive stacks
 */

// @lc code=start
public partial class Solution
{
    private int DFSCountArrangement(int n, int index, bool[] used)
    {
        // index start from n to 1, if index <= 0, current path is valid, we return 1
        if (index <= 0)
            return 1;

        int path = 0;
        // we try to put index into different perm[i]
        for (int i = n; i > 0; i--)
        {
            // if perm[i] is used, we skip it
            if (used[i])
                continue;

            // mark as used
            used[i] = true;
            // if it fulfill the requirements, we continue DFS to check next index, which is index - 1
            if (index % i == 0 || i % index == 0)
                path += DFSCountArrangement(n, index - 1, used);
            // reset to check other possibility
            used[i] = false;
        }
        return path;
    }

    public int CountArrangement(int n)
    {
        return DFSCountArrangement(n, n, new bool[n + 1]);
    }
}
// @lc code=end


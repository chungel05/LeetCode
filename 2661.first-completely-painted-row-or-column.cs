/*
 * @lc app=leetcode id=2661 lang=csharp
 *
 * [2661] First Completely Painted Row or Column
 *
 * https://leetcode.com/problems/first-completely-painted-row-or-column/description/
 *
 * algorithms
 * Medium (50.97%)
 * Likes:    467
 * Dislikes: 13
 * Total Accepted:    30.8K
 * Total Submissions: 59.1K
 * Testcase Example:  '[1,3,4,2]\n[[1,4],[2,3]]'
 *
 * You are given a 0-indexed integer array arr, and an m x n integer matrix
 * mat. arr and mat both contain all the integers in the range [1, m * n].
 * 
 * Go through each index i in arr starting from index 0 and paint the cell in
 * mat containing the integer arr[i].
 * 
 * Return the smallest index i at which either a row or a column will be
 * completely painted in mat.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: arr = [1,3,4,2], mat = [[1,4],[2,3]]
 * Output: 2
 * Explanation: The moves are shown in order, and both the first row and second
 * column of the matrix become fully painted at arr[2].
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: arr = [2,8,7,4,1,3,5,6,9], mat = [[3,2,5],[1,4,6],[8,7,9]]
 * Output: 3
 * Explanation: The second column becomes fully painted at arr[3].
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * m == mat.length
 * n = mat[i].length
 * arr.length == m * n
 * 1 <= m, n <= 10^5
 * 1 <= m * n <= 10^5
 * 1 <= arr[i], mat[r][c] <= m * n
 * All the integers of arr are unique.
 * All the integers of mat are unique.
 * 
 * 
 */
/*
 * Array approach (replacing dictionary)
 * Time: O(mn), Space: O(mn)
 */

// @lc code=start
public partial class Solution
{
    public int FirstCompleteIndex(int[] arr, int[][] mat)
    {
        int m = mat.Length, n = mat[0].Length;
        int[][] dict = new int[m * n + 1][];
        int[] row = new int[m];
        int[] col = new int[n];

        // loop through the matrix and record the corresponding row i and col j
        // since it is unique number [1, m * n], so can use array instead of dictionary
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                dict[mat[i][j]] = new int[] { i, j };
            }
        }

        // loop through arr
        for (int i = 0; i < arr.Length; i++)
        {
            // find the corresponding row x and col y in dict
            int x = dict[arr[i]][0];
            int y = dict[arr[i]][1];
            // increment 1 to indicate row and col are filled
            row[x]++;
            col[y]++;

            // if such row or col already filled, return index i
            // p.s. row need to match no. of col = n and col need to match no. of row = m
            if (row[x] == n || col[y] == m)
                return i;
        }
        return -1;
    }
}
// @lc code=end


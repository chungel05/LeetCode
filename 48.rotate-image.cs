/*
 * @lc app=leetcode id=48 lang=csharp
 *
 * [48] Rotate Image
 *
 * https://leetcode.com/problems/rotate-image/description/
 *
 * algorithms
 * Medium (76.07%)
 * Likes:    17990
 * Dislikes: 852
 * Total Accepted:    2M
 * Total Submissions: 2.6M
 * Testcase Example:  '[[1,2,3],[4,5,6],[7,8,9]]'
 *
 * You are given an n x n 2D matrix representing an image, rotate the image by
 * 90 degrees (clockwise).
 * 
 * You have to rotate the image in-place, which means you have to modify the
 * input 2D matrix directly. DO NOT allocate another 2D matrix and do the
 * rotation.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
 * Output: [[7,4,1],[8,5,2],[9,6,3]]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: matrix = [[5,1,9,11],[2,4,8,10],[13,3,6,7],[15,14,12,16]]
 * Output: [[15,13,2,5],[14,3,4,1],[12,6,8,9],[16,7,10,11]]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * n == matrix.length == matrix[i].length
 * 1 <= n <= 20
 * -1000 <= matrix[i][j] <= 1000
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public void Rotate(int[][] matrix)
    {
        int l = 0, r = matrix.Length - 1;

        while (l < r)
        {
            int top = l;
            int bottom = r;

            for (int i = 0; i < r - l; i++)
            {
                int tmp = matrix[top][l + i];
                matrix[top][l + i] = matrix[bottom - i][l];
                matrix[bottom - i][l] = matrix[bottom][r - i];
                matrix[bottom][r - i] = matrix[top + i][r];
                matrix[top + i][r] = tmp;
            }
            l++;
            r--;
        }
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=74 lang=csharp
 *
 * [74] Search a 2D Matrix
 *
 * https://leetcode.com/problems/search-a-2d-matrix/description/
 *
 * algorithms
 * Medium (51.14%)
 * Likes:    16057
 * Dislikes: 425
 * Total Accepted:    2M
 * Total Submissions: 4M
 * Testcase Example:  '[[1,3,5,7],[10,11,16,20],[23,30,34,60]]\n3'
 *
 * You are given an m x n integer matrix matrix with the following two
 * properties:
 * 
 * 
 * Each row is sorted in non-decreasing order.
 * The first integer of each row is greater than the last integer of the
 * previous row.
 * 
 * 
 * Given an integer target, return true if target is in matrix or false
 * otherwise.
 * 
 * You must write a solution in O(log(m * n)) time complexity.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 3
 * Output: true
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 13
 * Output: false
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * m == matrix.length
 * n == matrix[i].length
 * 1 <= m, n <= 100
 * -10^4 <= matrix[i][j], target <= 10^4
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        int m = matrix.Length, n = matrix[0].Length;
        int left = 0, right = m * n - 1;
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            int midValue = matrix[mid / n][mid % n];
            if (midValue == target)
                return true;
            else if (midValue < target)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return matrix[left / n][left % n] == target;
    }
}
// @lc code=end


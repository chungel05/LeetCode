/*
 * @lc app=leetcode id=130 lang=csharp
 *
 * [130] Surrounded Regions
 *
 * https://leetcode.com/problems/surrounded-regions/description/
 *
 * algorithms
 * Medium (40.93%)
 * Likes:    8833
 * Dislikes: 1931
 * Total Accepted:    810.6K
 * Total Submissions: 2M
 * Testcase Example:  '[["X","X","X","X"],["X","O","O","X"],["X","X","O","X"],["X","O","X","X"]]'
 *
 * You are given an m x n matrix board containing letters 'X' and 'O', capture
 * regions that are surrounded:
 * 
 * 
 * Connect: A cell is connected to adjacent cells horizontally or
 * vertically.
 * Region: To form a region connect every 'O' cell.
 * Surround: The region is surrounded with 'X' cells if you can connect the
 * region with 'X' cells and none of the region cells are on the edge of the
 * board.
 * 
 * 
 * A surrounded region is captured by replacing all 'O's with 'X's in the input
 * matrix board.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: board =
 * [["X","X","X","X"],["X","O","O","X"],["X","X","O","X"],["X","O","X","X"]]
 * 
 * Output:
 * [["X","X","X","X"],["X","X","X","X"],["X","X","X","X"],["X","O","X","X"]]
 * 
 * Explanation:
 * 
 * In the above diagram, the bottom region is not captured because it is on the
 * edge of the board and cannot be surrounded.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: board = [["X"]]
 * 
 * Output: [["X"]]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * m == board.length
 * n == board[i].length
 * 1 <= m, n <= 200
 * board[i][j] is 'X' or 'O'.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public void DFSSolve(char[][] board, int row, int col)
    {
        if (row < 0 || col < 0 || row >= board.Length || col >= board[0].Length || board[row][col] != 'O')
            return;


        board[row][col] = 'T';
        DFSSolve(board, row + 1, col);
        DFSSolve(board, row - 1, col);
        DFSSolve(board, row, col + 1);
        DFSSolve(board, row, col - 1);
    }

    public void Solve(char[][] board)
    {
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                // Start from edge, mark all the possible path can reach edge
                if (i == 0 || j == 0 || i == board.Length - 1 || j == board[0].Length - 1)
                    DFSSolve(board, i, j);
            }
        }

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                if (board[i][j] == 'O')
                    board[i][j] = 'X';
                else if (board[i][j] == 'T')
                    board[i][j] = 'O';
            }
        }
    }
}
// @lc code=end


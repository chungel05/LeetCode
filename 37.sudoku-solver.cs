/*
 * @lc app=leetcode id=37 lang=csharp
 *
 * [37] Sudoku Solver
 *
 * https://leetcode.com/problems/sudoku-solver/description/
 *
 * algorithms
 * Hard (63.04%)
 * Likes:    9781
 * Dislikes: 274
 * Total Accepted:    680K
 * Total Submissions: 1.1M
 * Testcase Example:  '[["5","3",".",".","7",".",".",".","."],["6",".",".","1","9","5",".",".","."],[".","9","8",".",".",".",".","6","."],["8",".",".",".","6",".",".",".","3"],["4",".",".","8",".","3",".",".","1"],["7",".",".",".","2",".",".",".","6"],[".","6",".",".",".",".","2","8","."],[".",".",".","4","1","9",".",".","5"],[".",".",".",".","8",".",".","7","9"]]'
 *
 * Write a program to solve a Sudoku puzzle by filling the empty cells.
 * 
 * A sudoku solution must satisfy all of the following rules:
 * 
 * 
 * Each of the digits 1-9 must occur exactly once in each row.
 * Each of the digits 1-9 must occur exactly once in each column.
 * Each of the digits 1-9 must occur exactly once in each of the 9 3x3
 * sub-boxes of the grid.
 * 
 * 
 * The '.' character indicates empty cells.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: board =
 * [["5","3",".",".","7",".",".",".","."],["6",".",".","1","9","5",".",".","."],[".","9","8",".",".",".",".","6","."],["8",".",".",".","6",".",".",".","3"],["4",".",".","8",".","3",".",".","1"],["7",".",".",".","2",".",".",".","6"],[".","6",".",".",".",".","2","8","."],[".",".",".","4","1","9",".",".","5"],[".",".",".",".","8",".",".","7","9"]]
 * Output:
 * [["5","3","4","6","7","8","9","1","2"],["6","7","2","1","9","5","3","4","8"],["1","9","8","3","4","2","5","6","7"],["8","5","9","7","6","1","4","2","3"],["4","2","6","8","5","3","7","9","1"],["7","1","3","9","2","4","8","5","6"],["9","6","1","5","3","7","2","8","4"],["2","8","7","4","1","9","6","3","5"],["3","4","5","2","8","6","1","7","9"]]
 * Explanation: The input board is shown above and the only valid solution is
 * shown below:
 * 
 * 
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * board.length == 9
 * board[i].length == 9
 * board[i][j] is a digit or '.'.
 * It is guaranteed that the input board has only one solution.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    private bool DFSSolveSudoku(char[][] board, int i, List<int> position, bool[][] row, bool[][] col, bool[][][] group)
    {
        // if end of list, it is solved
        if (i == position.Count)
            return true;

        // position = i * 9 + j, so we break it down
        int rowNum = position[i] / 9;
        int colNum = position[i] % 9;

        for (int k = 0; k < 9; k++)
        {
            // if the value k can fit to all constrain
            if (!row[rowNum][k] && !col[colNum][k] && !group[rowNum / 3][colNum / 3][k])
            {
                // Marked as used
                row[rowNum][k] = true;
                col[colNum][k] = true;
                group[rowNum / 3][colNum / 3][k] = true;
                board[rowNum][colNum] = (char)('1' + k);

                // Continue to check current path, if it can solved, we no need to check other path
                if (DFSSolveSudoku(board, i + 1, position, row, col, group))
                    return true;

                // Check other path by reseting the prev marks
                row[rowNum][k] = false;
                col[colNum][k] = false;
                group[rowNum / 3][colNum / 3][k] = false;
            }
        }
        return false;
    }

    public void SolveSudoku(char[][] board)
    {
        // Create list to trace the empty position
        List<int> position = new List<int>();

        // Create row to trace the status of each value in each row
        bool[][] row = new bool[9][];
        // Create col to trace the status of each value in each col
        bool[][] col = new bool[9][];
        // Create group to trace the status of each value in each group, group = i / 3, j / 3
        bool[][][] group = new bool[3][][];

        for (int i = 0; i < 9; i++)
        {
            // to prevent reset the bool array, we need to check whether it is initialized or not
            if (row[i] == null)
                row[i] = new bool[9];
            if (group[i / 3] == null)
                group[i / 3] = new bool[3][];
            for (int j = 0; j < 9; j++)
            {
                // to prevent reset the bool array, we need to check whether it is initialized or not
                if (col[j] == null)
                    col[j] = new bool[9];
                if (group[i / 3][j / 3] == null)
                    group[i / 3][j / 3] = new bool[9];

                // if it is empty, we add it to List, nums = 0 - 8, 9 - 17, 18 - 26, 27 - 35, 36 - 44 ...
                if (board[i][j] == '.')
                    position.Add(i * 9 + j);
                else
                {
                    // Set constrain by its corresponding i, j and value
                    int value = board[i][j] - '1';
                    row[i][value] = true;
                    col[j][value] = true;
                    group[i / 3][j / 3][value] = true;
                }
            }
        }
        DFSSolveSudoku(board, 0, position, row, col, group);
    }
}
// @lc code=end


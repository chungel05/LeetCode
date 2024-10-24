/*
 * @lc app=leetcode id=51 lang=csharp
 *
 * [51] N-Queens
 *
 * https://leetcode.com/problems/n-queens/description/
 *
 * algorithms
 * Hard (70.20%)
 * Likes:    12654
 * Dislikes: 298
 * Total Accepted:    828K
 * Total Submissions: 1.2M
 * Testcase Example:  '4'
 *
 * The n-queens puzzle is the problem of placing n queens on an n x n
 * chessboard such that no two queens attack each other.
 * 
 * Given an integer n, return all distinct solutions to the n-queens puzzle.
 * You may return the answer in any order.
 * 
 * Each solution contains a distinct board configuration of the n-queens'
 * placement, where 'Q' and '.' both indicate a queen and an empty space,
 * respectively.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: n = 4
 * Output: [[".Q..","...Q","Q...","..Q."],["..Q.","Q...","...Q",".Q.."]]
 * Explanation: There exist two distinct solutions to the 4-queens puzzle as
 * shown above
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: n = 1
 * Output: [["Q"]]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= n <= 9
 * 
 * 
 */
/*
* Time Complexity:
* First row = n (col length) options
* Second row = n-1 options becase the first col is occupied
* Third row = n-2 options
* .....
* So the time complexity is O(n!)
*/
// @lc code=start
using System.Xml;

public partial class Solution
{
    public void BacktrackSolveNQueens(int row, int n, char[][] board, List<IList<string>> res,
        HashSet<int> colMap, HashSet<int> posDiag, HashSet<int> negDiag)
    {
        // if row = n, the path is completed and n queen is added on each row, so we add to result
        if (row == n)
        {
            List<string> tmp = new List<string>();
            foreach (char[] s in board)
            {
                tmp.Add(string.Join("", s));
            }
            res.Add(tmp);
            return;
        }

        for (int col = 0; col < n; col++)
        {
            if (colMap.Contains(col) || posDiag.Contains(row + col) || negDiag.Contains(row - col))
                continue;

            board[row][col] = 'Q';
            colMap.Add(col);
            posDiag.Add(row + col);
            negDiag.Add(row - col);

            BacktrackSolveNQueens(row + 1, n, board, res, colMap, posDiag, negDiag);

            board[row][col] = '.';
            colMap.Remove(col);
            posDiag.Remove(row + col);
            negDiag.Remove(row - col);
        }
    }

    public IList<IList<string>> SolveNQueens(int n)
    {
        List<IList<string>> res = new List<IList<string>>();
        HashSet<int> colMap = new HashSet<int>();
        // row + i, col - i => row + col = k
        // row - i, col + i => row + col = k
        HashSet<int> posDiag = new HashSet<int>();
        // row + i, col + i => row - col = k
        // row - i, col - i => row - col = k
        HashSet<int> negDiag = new HashSet<int>();

        char[][] board = new char[n][];
        for (int i = 0; i < n; i++)
        {
            board[i] = new char[n];
            Array.Fill(board[i], '.');
        }

        BacktrackSolveNQueens(0, n, board, res, colMap, posDiag, negDiag);
        return res;
    }
}
// @lc code=end


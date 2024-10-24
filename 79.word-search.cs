/*
 * @lc app=leetcode id=79 lang=csharp
 *
 * [79] Word Search
 *
 * https://leetcode.com/problems/word-search/description/
 *
 * algorithms
 * Medium (43.74%)
 * Likes:    16131
 * Dislikes: 686
 * Total Accepted:    1.8M
 * Total Submissions: 4.2M
 * Testcase Example:  '[["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]]\n"ABCCED"'
 *
 * Given an m x n grid of characters board and a string word, return true if
 * word exists in the grid.
 * 
 * The word can be constructed from letters of sequentially adjacent cells,
 * where adjacent cells are horizontally or vertically neighboring. The same
 * letter cell may not be used more than once.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word
 * = "ABCCED"
 * Output: true
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word
 * = "SEE"
 * Output: true
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word
 * = "ABCB"
 * Output: false
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * m == board.length
 * n = board[i].length
 * 1 <= m, n <= 6
 * 1 <= word.length <= 15
 * board and word consists of only lowercase and uppercase English letters.
 * 
 * 
 * 
 * Follow up: Could you use search pruning to make your solution faster with a
 * larger board?
 * 
 */

// @lc code=start
using System.Data;

public partial class Solution
{
    public bool BacktrackExist(char[][] board, string word, int index, int row, int col)
    {
        if (index == word.Length)
            return true;

        if (row < 0 ||
            col < 0 ||
            row >= board.Length ||
            col >= board[0].Length ||
            // visited.Contains(row + "," + col) ||
            board[row][col] != word[index])
            return false;

        // visited.Add(row + "," + col);
        // replace char in board to indicate it is visited
        board[row][col] = '#';

        if (BacktrackExist(board, word, index + 1, row - 1, col) ||
            BacktrackExist(board, word, index + 1, row + 1, col) ||
            BacktrackExist(board, word, index + 1, row, col - 1) ||
            BacktrackExist(board, word, index + 1, row, col + 1))
            return true;

        // visited.Remove(row + "," + col);
        board[row][col] = word[index];
        return false;
    }

    public bool Exist(char[][] board, string word)
    {
        List<string> visited = new List<string>();
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                if (board[i][j] == word[0])
                {
                    if (BacktrackExist(board, word, 0, i, j))
                        return true;
                }
            }

        }

        return false;
    }
}
// @lc code=end


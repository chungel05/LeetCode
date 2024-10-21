/*
 * @lc app=leetcode id=212 lang=csharp
 *
 * [212] Word Search II
 *
 * https://leetcode.com/problems/word-search-ii/description/
 *
 * algorithms
 * Hard (36.64%)
 * Likes:    9544
 * Dislikes: 472
 * Total Accepted:    711.3K
 * Total Submissions: 1.9M
 * Testcase Example:  '[["o","a","a","n"],["e","t","a","e"],["i","h","k","r"],["i","f","l","v"]]\n' +
  '["oath","pea","eat","rain"]'
 *
 * Given an m x n board of characters and a list of strings words, return all
 * words on the board.
 * 
 * Each word must be constructed from letters of sequentially adjacent cells,
 * where adjacent cells are horizontally or vertically neighboring. The same
 * letter cell may not be used more than once in a word.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: board =
 * [["o","a","a","n"],["e","t","a","e"],["i","h","k","r"],["i","f","l","v"]],
 * words = ["oath","pea","eat","rain"]
 * Output: ["eat","oath"]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: board = [["a","b"],["c","d"]], words = ["abcb"]
 * Output: []
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * m == board.length
 * n == board[i].length
 * 1 <= m, n <= 12
 * board[i][j] is a lowercase English letter.
 * 1 <= words.length <= 3 * 10^4
 * 1 <= words[i].length <= 10
 * words[i] consists of lowercase English letters.
 * All the strings of words are unique.
 * 
 * 
 */

// @lc code=start

public class FindWordsTree
{
    public Dictionary<char, FindWordsTree> childnode { get; set; }
    public bool isEndOfWord { get; set; }
    public int refs { get; set; }

    public FindWordsTree()
    {
        childnode = new Dictionary<char, FindWordsTree>();
        refs = 0;
    }

    public void AddWord(string word)
    {
        FindWordsTree curr = this;
        curr.refs++;
        foreach (char c in word)
        {
            if (!curr.childnode.ContainsKey(c))
                curr.childnode[c] = new FindWordsTree();
            curr = curr.childnode[c];
            curr.refs++;
        }
        curr.isEndOfWord = true;
    }

    // In order to reduce time for large trie, add ref to record the total occurrence
    // Remove occurrence if wording is added to result
    public void RemoveWord(string word)
    {
        FindWordsTree curr = this;
        curr.refs--;
        foreach (char c in word)
        {
            if (curr.childnode.ContainsKey(c))
            {
                curr = curr.childnode[c];
                curr.refs--;
            }
        }
    }
}

public partial class Solution
{
    private int ROWS;
    private int COLS;

    public void DFSFindWords(int row, int col, string word, char[][] board, FindWordsTree node, List<string> res, List<string> visited, FindWordsTree root)
    {
        if (row < 0 || // row is out of bound
            col < 0 || // col is out of bound
            row == ROWS || // row is out of bound
            col == COLS || // col is out of bound
            !node.childnode.ContainsKey(board[row][col]) || // board char is not exist in the current trie
            visited.Contains(row + "," + col) || // board char is visited before
            node.childnode[board[row][col]].refs < 1) // board char in the trie exists but all occurrences are added to result
            return;

        visited.Add(row + "," + col); // mark as visited
        node = node.childnode[board[row][col]]; // move to next node
        word += board[row][col]; // add char to word
        if (node.isEndOfWord)
        {
            node.isEndOfWord = false; // prevent same word add to result again
            res.Add(word); // add complete word to result
            root.RemoveWord(word); // remove word occurrence
        }

        // continue to check all the possibility
        DFSFindWords(row - 1, col, word, board, node, res, visited, root);
        DFSFindWords(row + 1, col, word, board, node, res, visited, root);
        DFSFindWords(row, col - 1, word, board, node, res, visited, root);
        DFSFindWords(row, col + 1, word, board, node, res, visited, root);
        visited.Remove(row + "," + col); // remove visited in order to reuse in upper level
    }

    public IList<string> FindWords(char[][] board, string[] words)
    {
        FindWordsTree root = new FindWordsTree();
        foreach (string s in words)
            root.AddWord(s);

        ROWS = board.Length;
        COLS = board[0].Length;
        List<string> res = new List<string>();
        List<string> visited = new List<string>();

        for (int i = 0; i < ROWS; i++)
        {
            for (int j = 0; j < COLS; j++)
                DFSFindWords(i, j, "", board, root, res, visited, root);
        }

        return res;
    }
}
// @lc code=end


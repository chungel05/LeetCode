/*
 * @lc app=leetcode id=1079 lang=csharp
 *
 * [1079] Letter Tile Possibilities
 *
 * https://leetcode.com/problems/letter-tile-possibilities/description/
 *
 * algorithms
 * Medium (76.44%)
 * Likes:    2548
 * Dislikes: 72
 * Total Accepted:    111.6K
 * Total Submissions: 145.7K
 * Testcase Example:  '"AAB"'
 *
 * You have n  tiles, where each tile has one letter tiles[i] printed on it.
 * 
 * Return the number of possible non-empty sequences of letters you can make
 * using the letters printed on those tiles.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: tiles = "AAB"
 * Output: 8
 * Explanation: The possible sequences are "A", "B", "AA", "AB", "BA", "AAB",
 * "ABA", "BAA".
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: tiles = "AAABBC"
 * Output: 188
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: tiles = "V"
 * Output: 1
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= tiles.length <= 7
 * tiles consists of uppercase English letters.
 * 
 * 
 */
/*
 * DFS Backtracking Approach
 * Time: O(k^n), where k is unique no. of chars in string, n is length of string
 * Space: O(n)
 */

// @lc code=start
public partial class Solution
{
    private int DFSNumTilePossibilities(char[] tiles, bool[] visited)
    {
        int res = 0;

        // for each unique char, it forms the combination
        // it can also forms the combinations with other char
        // i.e. "AAB" => "A", "AA", "AAB", "AB", "ABA"; "B", "BA", "BAA"
        for (int j = 0; j < tiles.Length; j++)
        {
            // if it is used in the current path, we skip it
            if (visited[j])
                continue;

            // if it is same as prev. char and prev. char is not used, we skip it
            // i.e. "A" is used, second "A" can form "AA",
            // once second "A" completed and mark as not used,
            // third "A" will not form "AA" with first "A" because it is duplicated
            if (j > 0 && tiles[j] == tiles[j - 1] && !visited[j - 1])
                continue;

            // mark as visited
            visited[j] = true;
            // count current path
            res++;
            // form combination with other chars
            res += DFSNumTilePossibilities(tiles, visited);
            // reset visited
            visited[j] = false;
        }
        return res;
    }

    public int NumTilePossibilities(string tiles)
    {
        // sort the string to char array, to prevent duplication
        char[] sorted = tiles.ToCharArray();
        // use visited to mark as used
        bool[] visited = new bool[tiles.Length];
        Array.Sort(sorted);

        return DFSNumTilePossibilities(sorted, visited);
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=1366 lang=csharp
 *
 * [1366] Rank Teams by Votes
 *
 * https://leetcode.com/problems/rank-teams-by-votes/description/
 *
 * algorithms
 * Medium (58.69%)
 * Likes:    1492
 * Dislikes: 178
 * Total Accepted:    85.6K
 * Total Submissions: 145.2K
 * Testcase Example:  '["ABC","ACB","ABC","ACB","ACB"]'
 *
 * In a special ranking system, each voter gives a rank from highest to lowest
 * to all teams participating in the competition.
 * 
 * The ordering of teams is decided by who received the most position-one
 * votes. If two or more teams tie in the first position, we consider the
 * second position to resolve the conflict, if they tie again, we continue this
 * process until the ties are resolved. If two or more teams are still tied
 * after considering all positions, we rank them alphabetically based on their
 * team letter.
 * 
 * You are given an array of strings votes which is the votes of all voters in
 * the ranking systems. Sort all teams according to the ranking system
 * described above.
 * 
 * Return a string of all teams sorted by the ranking system.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: votes = ["ABC","ACB","ABC","ACB","ACB"]
 * Output: "ACB"
 * Explanation: 
 * Team A was ranked first place by 5 voters. No other team was voted as first
 * place, so team A is the first team.
 * Team B was ranked second by 2 voters and ranked third by 3 voters.
 * Team C was ranked second by 3 voters and ranked third by 2 voters.
 * As most of the voters ranked C second, team C is the second team, and team B
 * is the third.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: votes = ["WXYZ","XYZW"]
 * Output: "XWYZ"
 * Explanation:
 * X is the winner due to the tie-breaking rule. X has the same votes as W for
 * the first position, but X has one vote in the second position, while W does
 * not have any votes in the second position. 
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: votes = ["ZMNAGUEDSJYLBOPHRQICWFXTVK"]
 * Output: "ZMNAGUEDSJYLBOPHRQICWFXTVK"
 * Explanation: Only one voter, so their votes are used for the ranking.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= votes.length <= 1000
 * 1 <= votes[i].length <= 26
 * votes[i].length == votes[j].length for 0 <= i, j < votes.length.
 * votes[i][j] is an English uppercase letter.
 * All characters of votes[i] are unique.
 * All the characters that occur in votes[0] also occur in votes[j] where 1 <=
 * j < votes.length.
 * 
 * 
 */
/*
 * Counting & Sorting Approach
 * Time: O(m * n), Space: O(26m)
 */

// @lc code=start
using System.Text;

public partial class Solution
{
    public string RankTeams(string[] votes)
    {
        int m = votes[0].Length;
        int[][] rank = new int[26][];
        int[] team = new int[26];
        for (int i = 0; i < 26; i++)
        {
            // initialized
            rank[i] = new int[m];
            // corresponding index of each team
            team[i] = i;
        }

        // count the occurrences
        for (int i = 0; i < votes.Length; i++)
        {
            for (int j = 0; j < m; j++)
            {
                rank[votes[i][j] - 'A'][j]++;
            }
        }

        // Sorting team by using the corresponding rank
        Array.Sort(team, (a, b) =>
        {
            // By position
            for (int i = 0; i < m; i++)
            {
                if (rank[a][i] != rank[b][i])
                    return rank[b][i] - rank[a][i];
            }
            // if tie, by alphabetical order, which is value itself
            return a - b;
        });

        // get the corresponding order and construct result
        // non-voted team will be at the end of team array which is >= m
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < m; i++)
        {
            sb.Append((char)(team[i] + 'A'));
        }
        return sb.ToString();
    }
}
// @lc code=end


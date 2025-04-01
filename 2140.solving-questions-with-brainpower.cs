/*
 * @lc app=leetcode id=2140 lang=csharp
 *
 * [2140] Solving Questions With Brainpower
 *
 * https://leetcode.com/problems/solving-questions-with-brainpower/description/
 *
 * algorithms
 * Medium (55.09%)
 * Likes:    2418
 * Dislikes: 62
 * Total Accepted:    122.1K
 * Total Submissions: 218.7K
 * Testcase Example:  '[[3,2],[4,3],[4,4],[2,5]]'
 *
 * You are given a 0-indexed 2D integer array questions where questions[i] =
 * [pointsi, brainpoweri].
 * 
 * The array describes the questions of an exam, where you have to process the
 * questions in order (i.e., starting from question 0) and make a decision
 * whether to solve or skip each question. Solving question i will earn you
 * pointsi points but you will be unable to solve each of the next brainpoweri
 * questions. If you skip question i, you get to make the decision on the next
 * question.
 * 
 * 
 * For example, given questions = [[3, 2], [4, 3], [4, 4], [2,
 * 5]]:
 * 
 * 
 * If question 0 is solved, you will earn 3 points but you will be unable to
 * solve questions 1 and 2.
 * If instead, question 0 is skipped and question 1 is solved, you will earn 4
 * points but you will be unable to solve questions 2 and 3.
 * 
 * 
 * 
 * 
 * Return the maximum points you can earn for the exam.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: questions = [[3,2],[4,3],[4,4],[2,5]]
 * Output: 5
 * Explanation: The maximum points can be earned by solving questions 0 and 3.
 * - Solve question 0: Earn 3 points, will be unable to solve the next 2
 * questions
 * - Unable to solve questions 1 and 2
 * - Solve question 3: Earn 2 points
 * Total points earned: 3 + 2 = 5. There is no other way to earn 5 or more
 * points.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: questions = [[1,1],[2,2],[3,3],[4,4],[5,5]]
 * Output: 7
 * Explanation: The maximum points can be earned by solving questions 1 and 4.
 * - Skip question 0
 * - Solve question 1: Earn 2 points, will be unable to solve the next 2
 * questions
 * - Unable to solve questions 2 and 3
 * - Solve question 4: Earn 5 points
 * Total points earned: 2 + 5 = 7. There is no other way to earn 7 or more
 * points.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= questions.length <= 10^5
 * questions[i].length == 2
 * 1 <= pointsi, brainpoweri <= 10^5
 * 
 * 
 */
/*
 * Bottom-up DP Approach
 * Time: O(n), Space: O(n)
 */

// @lc code=start
public partial class Solution
{
    public long MostPoints(int[][] questions)
    {
        int n = questions.Length;
        // dp array
        long[] dp = new long[n + 1];
        for (int i = n - 1; i >= 0; i--)
        {
            long point = questions[i][0];
            int nextQuestion = Math.Min(i + questions[i][1] + 1, n);
            // Max of each index i, will be:
            // 1. Answer question i (point) + Points after q question
            // 2. Skip question i and get dp[i + 1]
            dp[i] = Math.Max(dp[i + 1], point + dp[nextQuestion]);
        }
        return dp[0];
    }
}
// @lc code=end


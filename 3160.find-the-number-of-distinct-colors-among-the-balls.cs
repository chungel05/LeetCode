/*
 * @lc app=leetcode id=3160 lang=csharp
 *
 * [3160] Find the Number of Distinct Colors Among the Balls
 *
 * https://leetcode.com/problems/find-the-number-of-distinct-colors-among-the-balls/description/
 *
 * algorithms
 * Medium (41.33%)
 * Likes:    209
 * Dislikes: 20
 * Total Accepted:    40.7K
 * Total Submissions: 88.4K
 * Testcase Example:  '4\n[[1,4],[2,5],[1,3],[3,4]]'
 *
 * You are given an integer limit and a 2D array queries of size n x 2.
 * 
 * There are limit + 1 balls with distinct labels in the range [0, limit].
 * Initially, all balls are uncolored. For every query in queries that is of
 * the form [x, y], you mark ball x with the color y. After each query, you
 * need to find the number of distinct colors among the balls.
 * 
 * Return an array result of length n, where result[i] denotes the number of
 * distinct colors after i^th query.
 * 
 * Note that when answering a query, lack of a color will not be considered as
 * a color.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: limit = 4, queries = [[1,4],[2,5],[1,3],[3,4]]
 * 
 * Output: [1,2,2,3]
 * 
 * Explanation:
 * 
 * 
 * 
 * 
 * After query 0, ball 1 has color 4.
 * After query 1, ball 1 has color 4, and ball 2 has color 5.
 * After query 2, ball 1 has color 3, and ball 2 has color 5.
 * After query 3, ball 1 has color 3, ball 2 has color 5, and ball 3 has color
 * 4.
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: limit = 4, queries = [[0,1],[1,2],[2,2],[3,4],[4,5]]
 * 
 * Output: [1,2,2,3,4]
 * 
 * Explanation:
 * 
 * 
 * 
 * 
 * After query 0, ball 0 has color 1.
 * After query 1, ball 0 has color 1, and ball 1 has color 2.
 * After query 2, ball 0 has color 1, and balls 1 and 2 have color 2.
 * After query 3, ball 0 has color 1, balls 1 and 2 have color 2, and ball 3
 * has color 4.
 * After query 4, ball 0 has color 1, balls 1 and 2 have color 2, ball 3 has
 * color 4, and ball 4 has color 5.
 * 
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= limit <= 10^9
 * 1 <= n == queries.length <= 10^5
 * queries[i].length == 2
 * 0 <= queries[i][0] <= limit
 * 1 <= queries[i][1] <= 10^9
 * 
 * 
 */
/*
 * Occurrence counting approach
 * Time: O(q), Space: O(n) where n = limit + 1
 */

// @lc code=start
public partial class Solution
{
    public int[] QueryResults(int limit, int[][] queries)
    {
        // use dict to control the usage of memory, i.e. not all the balls will be painted and at most limit + 1 different color
        Dictionary<int, int> balls = new Dictionary<int, int>();
        Dictionary<int, int> color = new Dictionary<int, int>();
        int[] ans = new int[queries.Length];
        // loop through the queries
        for (int i = 0; i < queries.Length; i++)
        {
            int b = queries[i][0];
            int c = queries[i][1];

            // if balls[b] exists, then it is repainted to new color
            if (balls.ContainsKey(b))
            {
                // reduce the count of original color
                color[balls[b]]--;
                // if no more balls in original color, then remove it
                if (color[balls[b]] == 0)
                    color.Remove(balls[b]);
            }

            // mark the balls[b] to color c
            balls[b] = c;
            // check the new color exist or not
            // if not exist, Add c to color dictionary
            if (!color.ContainsKey(c))
                color[c] = 1;
            // if exist, just increase the count
            else
                color[c]++;

            // ans after each query will be the count of distinct color in dictionary
            ans[i] = color.Count;
        }
        return ans;
    }
}
// @lc code=end


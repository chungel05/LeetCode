/*
 * @lc app=leetcode id=1014 lang=csharp
 *
 * [1014] Best Sightseeing Pair
 *
 * https://leetcode.com/problems/best-sightseeing-pair/description/
 *
 * algorithms
 * Medium (59.45%)
 * Likes:    2807
 * Dislikes: 67
 * Total Accepted:    127K
 * Total Submissions: 210.4K
 * Testcase Example:  '[8,1,5,2,6]'
 *
 * You are given an integer array values where values[i] represents the value
 * of the i^th sightseeing spot. Two sightseeing spots i and j have a distance
 * j - i between them.
 * 
 * The score of a pair (i < j) of sightseeing spots is values[i] + values[j] +
 * i - j: the sum of the values of the sightseeing spots, minus the distance
 * between them.
 * 
 * Return the maximum score of a pair of sightseeing spots.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: values = [8,1,5,2,6]
 * Output: 11
 * Explanation: i = 0, j = 2, values[i] + values[j] + i - j = 8 + 5 + 0 - 2 =
 * 11
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: values = [1,2]
 * Output: 2
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 2 <= values.length <= 5 * 10^4
 * 1 <= values[i] <= 1000
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int MaxScoreSightseeingPair(int[] values)
    {
        // scores formula: values[i] + valuse[j] + i - j = (values[i] + i) + (values[j] - j)
        // we need to find the max of i pair and loop over the current j

        // max keep track of max value of i pair
        // res keep track of max result we found
        int max = 0, res = 0;
        for (int j = 0; j < values.Length; j++)
        {
            // try to get (max i pair + current j pair) and compare with the previous result
            res = Math.Max(max + values[j] - j, res);

            // tracking the max i pair
            max = Math.Max(max, values[j] + j);
        }
        return res;
    }
}
// @lc code=end


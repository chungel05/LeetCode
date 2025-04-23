/*
 * @lc app=leetcode id=1399 lang=csharp
 *
 * [1399] Count Largest Group
 *
 * https://leetcode.com/problems/count-largest-group/description/
 *
 * algorithms
 * Easy (66.49%)
 * Likes:    459
 * Dislikes: 1000
 * Total Accepted:    53.9K
 * Total Submissions: 81K
 * Testcase Example:  '13'
 *
 * You are given an integer n.
 * 
 * Each number from 1 to n is grouped according to the sum of its digits.
 * 
 * Return the number of groups that have the largest size.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: n = 13
 * Output: 4
 * Explanation: There are 9 groups in total, they are grouped according sum of
 * its digits of numbers from 1 to 13:
 * [1,10], [2,11], [3,12], [4,13], [5], [6], [7], [8], [9].
 * There are 4 groups with largest size.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: n = 2
 * Output: 2
 * Explanation: There are 2 groups [1], [2] of size 1.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= n <= 10^4
 * 
 * 
 */
/*
 * Hash Table Approach
 * Time: O(n log n), Space: O(37) => O(1)
 */

// @lc code=start
public partial class Solution
{
    // Hash Table Approach
    public int CountLargestGroup(int n)
    {
        int[] group = new int[37];
        int max = 0;
        for (int i = 1; i <= n; i++)
        {
            int sum = 0;
            int num = i;
            // Time: O(log n)
            while (num != 0)
            {
                sum += num % 10;
                num /= 10;
            }
            group[sum]++;

            // tracking the max length of groups
            max = Math.Max(max, group[sum]);
        }

        int ans = 0;
        for (int i = 1; i < 37; i++)
        {
            if (group[i] == max)
                ans++;
        }

        return ans;
    }

    // DP Approach
    // using dp to help to calc the sum of digits in O(1)
    // Time: O(n), Space: O(n)
    /* public int CountLargestGroup(int n)
    {
        int[] dp = new int[n + 1];
        int[] group = new int[37];
        int max = 0;
        for (int i = 1; i <= n; i++)
        {
            // for each num, it construct by prefix + single digit
            // i.e. [123]: prefix = 12, single digit = 3
            // which sum of digits of [123] = dp[12] + 123 % 10
            // Time: O(1)
            int prefix = i / 10;
            dp[i] = dp[prefix] + i % 10;
            group[dp[i]]++;

            max = Math.Max(max, group[dp[i]]);
        }

        int ans = 0;
        for (int i = 1; i < 37; i++)
        {
            if (group[i] == max)
                ans++;
        }
        return ans;
    } */
}
// @lc code=end


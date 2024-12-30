/*
 * @lc app=leetcode id=2466 lang=csharp
 *
 * [2466] Count Ways To Build Good Strings
 *
 * https://leetcode.com/problems/count-ways-to-build-good-strings/description/
 *
 * algorithms
 * Medium (54.35%)
 * Likes:    1726
 * Dislikes: 155
 * Total Accepted:    82.7K
 * Total Submissions: 152.2K
 * Testcase Example:  '3\n3\n1\n1'
 *
 * Given the integers zero, one, low, and high, we can construct a string by
 * starting with an empty string, and then at each step perform either of the
 * following:
 * 
 * 
 * Append the character '0' zero times.
 * Append the character '1' one times.
 * 
 * 
 * This can be performed any number of times.
 * 
 * A good string is a string constructed by the above process having a length
 * between low and high (inclusive).
 * 
 * Return the number of different good strings that can be constructed
 * satisfying these properties. Since the answer can be large, return it modulo
 * 10^9 + 7.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: low = 3, high = 3, zero = 1, one = 1
 * Output: 8
 * Explanation: 
 * One possible valid good string is "011". 
 * It can be constructed as follows: "" -> "0" -> "01" -> "011". 
 * All binary strings from "000" to "111" are good strings in this example.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: low = 2, high = 3, zero = 1, one = 2
 * Output: 5
 * Explanation: The good strings are "00", "11", "000", "110", and "011".
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= low <= high <= 10^5
 * 1 <= zero, one <= low
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    /* private int DFSCountGoodStrings(int low, int high, int zero, int one, int i, int[] dp)
    {
        if (i > high)
            return 0;

        if (dp[i] != -1)
            return dp[i];

        long ans = 0;
        if (i >= low)
            ans += 1;

        // take 0
        ans += (long)DFSCountGoodStrings(low, high, zero, one, i + zero, dp);

        // take 1
        ans += (long)DFSCountGoodStrings(low, high, zero, one, i + one, dp);

        ans %= 1000000007;

        dp[i] = (int)ans;

        return dp[i];
    } */

    public int CountGoodStrings(int low, int high, int zero, int one)
    {
        int[] dp = new int[high + 1];
        Array.Fill(dp, -1);

        // base case: if i > high, which is dp[high + 1...], it is invalid, so we return 0 possible string

        // from i = high to 0, we calc the possible good strings
        for (int i = high; i >= 0; i--)
        {
            // the possible good strings at current position i:
            // case 1: we take zeros and get the result after we take zero, which is dp[i + zero]
            // case 2: we take ones and get the result after we take one, which is dp[i + one]
            // case 3: if current position already have len >= low, we count as 1 good string

            long ans = 0;
            // if i already >= low, it is good string as well, so we +1
            if (i >= low)
                ans += 1;

            // take zeros
            ans += i + zero > high ? 0 : (long)dp[i + zero];
            // take ones
            ans += i + one > high ? 0 : (long)dp[i + one];

            ans %= 1000000007;
            dp[i] = (int)ans;
        }
        return dp[0];
    }
}
// @lc code=end


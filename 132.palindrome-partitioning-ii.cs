/*
 * @lc app=leetcode id=132 lang=csharp
 *
 * [132] Palindrome Partitioning II
 *
 * https://leetcode.com/problems/palindrome-partitioning-ii/description/
 *
 * algorithms
 * Hard (34.39%)
 * Likes:    5560
 * Dislikes: 142
 * Total Accepted:    311.8K
 * Total Submissions: 902.3K
 * Testcase Example:  '"aab"'
 *
 * Given a string s, partition s such that every substring of the partition is
 * a palindrome.
 * 
 * Return the minimum cuts needed for a palindrome partitioning of s.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "aab"
 * Output: 1
 * Explanation: The palindrome partitioning ["aa","b"] could be produced using
 * 1 cut.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "a"
 * Output: 0
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: s = "ab"
 * Output: 1
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s.length <= 2000
 * s consists of lowercase English letters only.
 * 
 * 
 */
/*
 * Time: O(n^2), Space: O(n)
 */

// @lc code=start
public partial class Solution
{
    public int MinCut(string s)
    {
        int n = s.Length;
        bool[][] isPalindrome = new bool[n][];

        for (int i = 0; i < n; i++)
        {
            isPalindrome[i] = new bool[n];
            Array.Fill(isPalindrome[i], true);
        }

        // create array to store info. whether [start...end] is Palindrome
        // if s[start] == s[end], then we just need to check isPalindrome[start + 1][end - 1]
        // i.e. abbbbba, a == a, we just need to check [bbbbb]
        for (int start = n - 1; start >= 0; start--)
        {
            for (int end = start + 1; end < n; end++)
                isPalindrome[start][end] = s[start] == s[end] && isPalindrome[start + 1][end - 1];
        }

        // create dp for bottom-up approach
        int[] dp = new int[n + 1];
        // base case: i == n, dp[n] = 0, no Palindrome
        Array.Fill(dp, 0);

        for (int i = n - 1; i >= 0; i--)
        {
            // initialized dp[i] as max value
            dp[i] = int.MaxValue;
            for (int j = i; j < n; j++)
            {
                // for [i...j], if it is Palindrome, the count of Palindrome in [i...j...n-1] is 1 + dp[j + 1]
                if (isPalindrome[i][j])
                    // our target = get the min count of Palindrome as possible
                    dp[i] = Math.Min(1 + dp[j + 1], dp[i]);
            }
        }

        // dp[0] = min count of Palindrome in [0...n-1], cut = dp[0] - 1
        return dp[0] - 1;
    }
}
// @lc code=end


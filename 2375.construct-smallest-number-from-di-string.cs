/*
 * @lc app=leetcode id=2375 lang=csharp
 *
 * [2375] Construct Smallest Number From DI String
 *
 * https://leetcode.com/problems/construct-smallest-number-from-di-string/description/
 *
 * algorithms
 * Medium (76.37%)
 * Likes:    988
 * Dislikes: 48
 * Total Accepted:    40.4K
 * Total Submissions: 52.4K
 * Testcase Example:  '"IIIDIDDD"'
 *
 * You are given a 0-indexed string pattern of length n consisting of the
 * characters 'I' meaning increasing and 'D' meaning decreasing.
 * 
 * A 0-indexed string num of length n + 1 is created using the following
 * conditions:
 * 
 * 
 * num consists of the digits '1' to '9', where each digit is used at most
 * once.
 * If pattern[i] == 'I', then num[i] < num[i + 1].
 * If pattern[i] == 'D', then num[i] > num[i + 1].
 * 
 * 
 * Return the lexicographically smallest possible string num that meets the
 * conditions.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: pattern = "IIIDIDDD"
 * Output: "123549876"
 * Explanation:
 * At indices 0, 1, 2, and 4 we must have that num[i] < num[i+1].
 * At indices 3, 5, 6, and 7 we must have that num[i] > num[i+1].
 * Some possible values of num are "245639871", "135749862", and "123849765".
 * It can be proven that "123549876" is the smallest possible num that meets
 * the conditions.
 * Note that "123414321" is not possible because the digit '1' is used more
 * than once.
 * 
 * Example 2:
 * 
 * 
 * Input: pattern = "DDD"
 * Output: "4321"
 * Explanation:
 * Some possible values of num are "9876", "7321", and "8742".
 * It can be proven that "4321" is the smallest possible num that meets the
 * conditions.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= pattern.length <= 8
 * pattern consists of only the letters 'I' and 'D'.
 * 
 * 
 */
/*
 * Greedy Approach
 * Time: O(n), Space: O(n)
 */

// @lc code=start
public partial class Solution
{
    public string SmallestNumber(string pattern)
    {
        int prev = 0;
        char[] ans = new char[pattern.Length + 1];

        for (int i = 0; i <= pattern.Length; i++)
        {
            // set ans[i] to corresponding num
            ans[i] = (char)(i + '1');
            // if pattern[i] == 'D', will not move prev, until meet pattern[i] == 'I'
            if (i == pattern.Length || pattern[i] == 'I')
            {
                // reverse the array [prev, i], prev maybe same as i, which is no need to reverse
                Array.Reverse(ans, prev, i - prev + 1);
                prev = i + 1;
            }
        }
        return new string(ans);
    }
}
// @lc code=end


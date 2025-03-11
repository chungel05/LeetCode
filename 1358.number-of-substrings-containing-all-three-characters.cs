/*
 * @lc app=leetcode id=1358 lang=csharp
 *
 * [1358] Number of Substrings Containing All Three Characters
 *
 * https://leetcode.com/problems/number-of-substrings-containing-all-three-characters/description/
 *
 * algorithms
 * Medium (67.95%)
 * Likes:    3522
 * Dislikes: 60
 * Total Accepted:    177.3K
 * Total Submissions: 257.1K
 * Testcase Example:  '"abcabc"'
 *
 * Given a string s consisting only of characters a, b and c.
 * 
 * Return the number of substrings containing at least one occurrence of all
 * these characters a, b and c.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "abcabc"
 * Output: 10
 * Explanation: The substrings containing at least one occurrence of the
 * characters a, b and c are "abc", "abca", "abcab", "abcabc", "bca", "bcab",
 * "bcabc", "cab", "cabc" and "abc" (again). 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "aaacb"
 * Output: 3
 * Explanation: The substrings containing at least one occurrence of the
 * characters a, b and c are "aaacb", "aacb" and "acb". 
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: s = "abc"
 * Output: 1
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 3 <= s.length <= 5 x 10^4
 * s only consists of a, b or c characters.
 * 
 * 
 */
/*
 * Two Pointer - Sliding Window
 * Time: O(n), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    public int NumberOfSubstrings(string s)
    {
        // array to count the a/b/c occurrences
        int[] count = new int[3];
        // int to indicate current window is valid or not
        int curr = 0;
        // Two Pointers of left
        int left = 0;
        int ans = 0;

        // Start expand window by right pointer [0, n - 1]
        for (int right = 0; right < s.Length; right++)
        {
            // count the occurrence
            count[s[right] - 'a']++;
            // mark it by using bitwise
            curr |= 1 << s[right] - 'a';

            // if current window is valid, which is 111(binary) = 7
            while (curr == 7)
            {
                // every combination are valid
                ans += s.Length - right;
                // shrink the window by move left pointer
                count[s[left] - 'a']--;
                // remove in indicator
                if (count[s[left] - 'a'] == 0)
                    curr ^= 1 << s[left] - 'a';

                left++;
            }
        }
        return ans;
    }
}
// @lc code=end


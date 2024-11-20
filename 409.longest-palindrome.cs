/*
 * @lc app=leetcode id=409 lang=csharp
 *
 * [409] Longest Palindrome
 *
 * https://leetcode.com/problems/longest-palindrome/description/
 *
 * algorithms
 * Easy (55.38%)
 * Likes:    5992
 * Dislikes: 420
 * Total Accepted:    849.7K
 * Total Submissions: 1.5M
 * Testcase Example:  '"abccccdd"'
 *
 * Given a string s which consists of lowercase or uppercase letters, return
 * the length of the longest palindrome that can be built with those letters.
 * 
 * Letters are case sensitive, for example, "Aa" is not considered a
 * palindrome.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "abccccdd"
 * Output: 7
 * Explanation: One longest palindrome that can be built is "dccaccd", whose
 * length is 7.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "a"
 * Output: 1
 * Explanation: The longest palindrome that can be built is "a", whose length
 * is 1.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s.length <= 2000
 * s consists of lowercase and/or uppercase English letters only.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int LongestPalindrome(string s)
    {
        // count the occurrance
        Dictionary<char, int> dict = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (!dict.ContainsKey(s[i]))
                dict[s[i]] = 0;
            dict[s[i]]++;
        }

        int max = 0;
        foreach (var pair in dict)
        {
            // if count % 2 == 0, means that we can have all char at both side
            // i.e. count = 3, we only can have 1 char at left and 1 char at right
            max += pair.Value - (pair.Value % 2);

            // we only can have 1 possible center char which is odd num
            if (max % 2 == 0 && pair.Value % 2 == 1)
                max++;
        }
        return max;
    }
}
// @lc code=end


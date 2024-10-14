/*
 * @lc app=leetcode id=125 lang=csharp
 *
 * [125] Valid Palindrome
 *
 * https://leetcode.com/problems/valid-palindrome/description/
 *
 * algorithms
 * Easy (48.90%)
 * Likes:    9620
 * Dislikes: 8434
 * Total Accepted:    3.5M
 * Total Submissions: 7.1M
 * Testcase Example:  '"A man, a plan, a canal: Panama"'
 *
 * A phrase is a palindrome if, after converting all uppercase letters into
 * lowercase letters and removing all non-alphanumeric characters, it reads the
 * same forward and backward. Alphanumeric characters include letters and
 * numbers.
 * 
 * Given a string s, return true if it is a palindrome, or false otherwise.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "A man, a plan, a canal: Panama"
 * Output: true
 * Explanation: "amanaplanacanalpanama" is a palindrome.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "race a car"
 * Output: false
 * Explanation: "raceacar" is not a palindrome.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: s = " "
 * Output: true
 * Explanation: s is an empty string "" after removing non-alphanumeric
 * characters.
 * Since an empty string reads the same forward and backward, it is a
 * palindrome.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s.length <= 2 * 10^5
 * s consists only of printable ASCII characters.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public bool IsPalindrome(string s)
    {
        int l = 0, r = s.Length - 1;
        s = s.ToLower();
        while (l < r)
        {
            if ((s[l] - '0' > 9 || s[l] - '0' < 0) && (s[l] - 'a' > 25 || s[l] - 'a' < 0))
                l++;
            else if ((s[r] - 'a' > 25 || s[r] - 'a' < 0) && (s[r] - '0' > 9 || s[r] - '0' < 0))
                r--;
            else
            {
                if (s[l] != s[r])
                    return false;
                else
                {
                    l++;
                    r--;
                }
            }
        }
        return true;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=17 lang=csharp
 *
 * [17] Letter Combinations of a Phone Number
 *
 * https://leetcode.com/problems/letter-combinations-of-a-phone-number/description/
 *
 * algorithms
 * Medium (61.91%)
 * Likes:    18959
 * Dislikes: 1019
 * Total Accepted:    2.3M
 * Total Submissions: 3.6M
 * Testcase Example:  '"23"'
 *
 * Given a string containing digits from 2-9 inclusive, return all possible
 * letter combinations that the number could represent. Return the answer in
 * any order.
 * 
 * A mapping of digits to letters (just like on the telephone buttons) is given
 * below. Note that 1 does not map to any letters.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: digits = "23"
 * Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: digits = ""
 * Output: []
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: digits = "2"
 * Output: ["a","b","c"]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 0 <= digits.length <= 4
 * digits[i] is a digit in the range ['2', '9'].
 * 
 * 
 */

// @lc code=start
using System.Security.Cryptography.X509Certificates;

public partial class Solution
{
    public IList<string> LetterCombinations(string digits)
    {
        Dictionary<char, string> map = new Dictionary<char, string>()
        {
            ['2'] = "abc",
            ['3'] = "def",
            ['4'] = "ghi",
            ['5'] = "jkl",
            ['6'] = "mno",
            ['7'] = "pqrs",
            ['8'] = "tuv",
            ['9'] = "wxyz"
        };
        List<string> res = new List<string>();

        if (digits.Length != 0)
        {
            if (map.ContainsKey(digits[0]))
            {
                foreach (char c in map[digits[0]])
                {
                    if (digits.Length == 1)
                        res.Add(c.ToString());
                    else
                    {
                        foreach (string s in LetterCombinations(digits.Substring(1)))
                        {
                            res.Add(c + s);
                        }
                    }
                }
            }
        }
        return res;
    }
}
// @lc code=end


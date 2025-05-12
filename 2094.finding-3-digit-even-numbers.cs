/*
 * @lc app=leetcode id=2094 lang=csharp
 *
 * [2094] Finding 3-Digit Even Numbers
 *
 * https://leetcode.com/problems/finding-3-digit-even-numbers/description/
 *
 * algorithms
 * Easy (61.65%)
 * Likes:    924
 * Dislikes: 286
 * Total Accepted:    47.6K
 * Total Submissions: 72.4K
 * Testcase Example:  '[2,1,3,0]'
 *
 * You are given an integer array digits, where each element is a digit. The
 * array may contain duplicates.
 * 
 * You need to find all the unique integers that follow the given
 * requirements:
 * 
 * 
 * The integer consists of the concatenation of three elements from digits in
 * any arbitrary order.
 * The integer does not have leading zeros.
 * The integer is even.
 * 
 * 
 * For example, if the given digits were [1, 2, 3], integers 132 and 312 follow
 * the requirements.
 * 
 * Return a sorted array of the unique integers.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: digits = [2,1,3,0]
 * Output: [102,120,130,132,210,230,302,310,312,320]
 * Explanation: All the possible integers that follow the requirements are in
 * the output array. 
 * Notice that there are no odd integers or integers with leading zeros.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: digits = [2,2,8,8,2]
 * Output: [222,228,282,288,822,828,882]
 * Explanation: The same digit can be used as many times as it appears in
 * digits. 
 * In this example, the digit 8 is used twice each time in 288, 828, and
 * 882. 
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: digits = [3,7,5]
 * Output: []
 * Explanation: No even integers can be formed using the given digits.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 3 <= digits.length <= 100
 * 0 <= digits[i] <= 9
 * 
 * 
 */
/*
 * Counting Approach
 * Time: O(n + 450), Space: O(20)
 */

// @lc code=start
public partial class Solution
{
    public int[] FindEvenNumbers(int[] digits)
    {
        int[] freq = new int[10];
        int[] curr = new int[10];
        List<int> ans = new List<int>();
        // Count the digits freq
        for (int i = 0; i < digits.Length; i++)
        {
            freq[digits[i]]++;
        }

        // since the range is not large, so can enumerate each possible even number [100, 999]
        for (int i = 100; i < 999; i += 2)
        {
            // find the 3 digits
            int x1 = i % 10;
            int x2 = (i / 10) % 10;
            int x3 = i / 100;

            // increment its freq
            curr[x1]++;
            curr[x2]++;
            curr[x3]++;

            // if it is possible to form, add to ans
            if (curr[x1] <= freq[x1] && curr[x2] <= freq[x2] && curr[x3] <= freq[x3])
                ans.Add(i);

            // reset to 0
            curr[x1] = 0;
            curr[x2] = 0;
            curr[x3] = 0;
        }

        // output as array
        return ans.ToArray();
    }
}
// @lc code=end


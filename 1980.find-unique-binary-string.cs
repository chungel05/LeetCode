/*
 * @lc app=leetcode id=1980 lang=csharp
 *
 * [1980] Find Unique Binary String
 *
 * https://leetcode.com/problems/find-unique-binary-string/description/
 *
 * algorithms
 * Medium (74.75%)
 * Likes:    2057
 * Dislikes: 79
 * Total Accepted:    157.1K
 * Total Submissions: 208.8K
 * Testcase Example:  '["01","10"]'
 *
 * Given an array of strings nums containing n unique binary strings each of
 * length n, return a binary string of length n that does not appear in nums.
 * If there are multiple answers, you may return any of them.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = ["01","10"]
 * Output: "11"
 * Explanation: "11" does not appear in nums. "00" would also be correct.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = ["00","01"]
 * Output: "11"
 * Explanation: "11" does not appear in nums. "10" would also be correct.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: nums = ["111","011","001"]
 * Output: "101"
 * Explanation: "101" does not appear in nums. "000", "010", "100", and "110"
 * would also be correct.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * n == nums.length
 * 1 <= n <= 16
 * nums[i].length == n
 * nums[i] is either '0' or '1'.
 * All the strings of nums are unique.
 * 
 * 
 */
/*
 * Bit Manipulation
 * Time: O(n), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    // To make it different to each nums[i], the ans[i] should be opposite to nums[i][i]
    // i.e. ["001", "010", "100"]
    // first bit = "1", no matter other bits are the same, ans must different to "001" because of first bit
    // second bit = "0" => "10", no matter other bits are the same, ans must different to "010" because of second bit
    // third bit = "1" => "101", no matter other bits are the same, ans must different to "100" because of third bit
    public string FindDifferentBinaryString(string[] nums)
    {
        string ans = "";
        for (int i = 0; i < nums.Length; i++)
        {
            ans += nums[i][i] == '1' ? '0' : '1';
        }

        return ans;
    }
}
// @lc code=end


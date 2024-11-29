/*
 * @lc app=leetcode id=93 lang=csharp
 *
 * [93] Restore IP Addresses
 *
 * https://leetcode.com/problems/restore-ip-addresses/description/
 *
 * algorithms
 * Medium (51.23%)
 * Likes:    5320
 * Dislikes: 801
 * Total Accepted:    498.7K
 * Total Submissions: 966K
 * Testcase Example:  '"25525511135"'
 *
 * A valid IP address consists of exactly four integers separated by single
 * dots. Each integer is between 0 and 255 (inclusive) and cannot have leading
 * zeros.
 * 
 * 
 * For example, "0.1.2.201" and "192.168.1.1" are valid IP addresses, but
 * "0.011.255.245", "192.168.1.312" and "192.168@1.1" are invalid IP
 * addresses.
 * 
 * 
 * Given a string s containing only digits, return all possible valid IP
 * addresses that can be formed by inserting dots into s. You are not allowed
 * to reorder or remove any digits in s. You may return the valid IP addresses
 * in any order.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "25525511135"
 * Output: ["255.255.11.135","255.255.111.35"]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "0000"
 * Output: ["0.0.0.0"]
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: s = "101023"
 * Output: ["1.0.10.23","1.0.102.3","10.1.0.23","10.10.2.3","101.0.2.3"]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s.length <= 20
 * s consists of digits only.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    private void DFSRestoreIpAddresses(string s, int left, int right, List<int> path, List<string> res)
    {
        // base case: if path have 4 segments and no more string to read, we add to result
        if (path.Count == 4 && left > right)
        {
            string ip = string.Join(".", path);
            res.Add(ip);
            return;
        }

        // if either one above condition is true, we will return
        // 1. we have 4 or more segments but still need to read remaining string
        // 2. we have 0-3 segments but no string to read
        if (path.Count >= 4 || left > right)
            return;

        // if the first char is '0', we only have 1 possible case, which 0.XXX
        if (s[left] == '0')
        {
            path.Add(0);
            DFSRestoreIpAddresses(s, left + 1, right, path, res);
            path.RemoveAt(path.Count - 1);
            return;
        }

        // otherwise, we will combine the possible k
        int k = 0;
        for (int i = left; i <= right; i++)
        {
            k = k * 10 + (s[i] - '0');
            if (k <= 255)
            {
                path.Add(k);
                DFSRestoreIpAddresses(s, i + 1, right, path, res);
                path.RemoveAt(path.Count - 1);
            }
            else
                break;
        }
    }

    public IList<string> RestoreIpAddresses(string s)
    {
        List<string> res = new List<string>();
        DFSRestoreIpAddresses(s, 0, s.Length - 1, new List<int>(), res);

        return res;
    }
}
// @lc code=end


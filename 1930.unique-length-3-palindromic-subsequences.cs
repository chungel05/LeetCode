/*
 * @lc app=leetcode id=1930 lang=csharp
 *
 * [1930] Unique Length-3 Palindromic Subsequences
 *
 * https://leetcode.com/problems/unique-length-3-palindromic-subsequences/description/
 *
 * algorithms
 * Medium (66.07%)
 * Likes:    1784
 * Dislikes: 80
 * Total Accepted:    116.9K
 * Total Submissions: 175.9K
 * Testcase Example:  '"aabca"'
 *
 * Given a string s, return the number of unique palindromes of length three
 * that are a subsequence of s.
 * 
 * Note that even if there are multiple ways to obtain the same subsequence, it
 * is still only counted once.
 * 
 * A palindrome is a string that reads the same forwards and backwards.
 * 
 * A subsequence of a string is a new string generated from the original string
 * with some characters (can be none) deleted without changing the relative
 * order of the remaining characters.
 * 
 * 
 * For example, "ace" is a subsequence of "abcde".
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "aabca"
 * Output: 3
 * Explanation: The 3 palindromic subsequences of length 3 are:
 * - "aba" (subsequence of "aabca")
 * - "aaa" (subsequence of "aabca")
 * - "aca" (subsequence of "aabca")
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "adc"
 * Output: 0
 * Explanation: There are no palindromic subsequences of length 3 in "adc".
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: s = "bbcbaba"
 * Output: 4
 * Explanation: The 4 palindromic subsequences of length 3 are:
 * - "bbb" (subsequence of "bbcbaba")
 * - "bcb" (subsequence of "bbcbaba")
 * - "bab" (subsequence of "bbcbaba")
 * - "aba" (subsequence of "bbcbaba")
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 3 <= s.length <= 10^5
 * s consists of only lowercase English letters.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    // Count the unique char between same char s[left] and s[right]
    // Time: O(26n) => O(n), Space: O(26) => O(1)
    /* public int CountPalindromicSubsequence(string s)
    {
        int[] left = new int[26];
        int[] right = new int[26];
        Array.Fill(left, -1);

        // find the first index (left) of each char a ~ z
        // find the last index (right) of each char a ~ z
        for (int i = 0; i < s.Length; i++)
        {
            if (left[s[i] - 'a'] == -1)
                left[s[i] - 'a'] = i;
            right[s[i] - 'a'] = i;
        }

        int res = 0;
        // loop from a ~ z, total 26 times, which s[left[c]] == s[right[c]] 
        for (char c = 'a'; c <= 'z'; c++)
        {
            // count the unique char between [left[c] + 1, right[c] - 1]
            // use HashSet to record the visited char
            HashSet<char> visited = new HashSet<char>();
            for (int j = left[c - 'a'] + 1; j < right[c - 'a']; j++)
            {
                if (!visited.Contains(s[j]))
                {
                    visited.Add(s[j]);
                    res++;
                }
            }
        }
        return res;
    } */

    // Bitmask to check current position i's left [0, i - 1] and right[i + 1, n] have same char (a ~ z) to form palindrome
    // Time: O(26 + 2n) => O(n), Space: O(26) => O(1)
    public int CountPalindromicSubsequence(string s)
    {
        // count the char occurences and build the right mask
        int[] count = new int[26];
        int rightMask = 0;
        for (int i = 0; i < s.Length; i++)
        {
            count[s[i] - 'a']++;
            rightMask |= 1 << s[i] - 'a';
        }

        // start i from 0 to n - 1 
        int leftMask = 0;
        int[] res = new int[26];
        for (int i = 0; i < s.Length; i++)
        {
            // reduce the count of char x (mid) in occurences
            int mid = s[i] - 'a';
            count[mid]--;

            // if char x is 0, we update the right mask because no more x on the right side
            // to update the mask, we use NOT(1 << s[i] - 'a'), we can only emit the bit representing char x
            if (count[mid] == 0)
                rightMask &= ~(1 << mid);

            // at position i, the result is leftMask & rightMask
            // since it may duplicated with prev same char x, so we use |= to add the new result
            res[mid] |= (leftMask & rightMask);

            // update left mask
            leftMask |= 1 << mid;
        }

        // calc the total combination
        int ans = 0;

        // for each mid char x, we get the possible combination
        for (int i = 0; i < 26; i++)
        {
            while (res[i] != 0)
            {
                // add the count of right most bit, 1 or 0
                ans += (res[i] & 1);
                // shift right to count the total num of bit 1
                res[i] >>= 1;
            }
        }
        return ans;
    }
}
// @lc code=end


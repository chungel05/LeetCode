/*
 * @lc app=leetcode id=3306 lang=csharp
 *
 * [3306] Count of Substrings Containing Every Vowel and K Consonants II
 *
 * https://leetcode.com/problems/count-of-substrings-containing-every-vowel-and-k-consonants-ii/description/
 *
 * algorithms
 * Medium (20.09%)
 * Likes:    184
 * Dislikes: 11
 * Total Accepted:    11.8K
 * Total Submissions: 53.2K
 * Testcase Example:  '"aeioqq"\n1'
 *
 * You are given a string word and a non-negative integer k.
 * 
 * Return the total number of substrings of word that contain every vowel ('a',
 * 'e', 'i', 'o', and 'u') at least once and exactly k consonants.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: word = "aeioqq", k = 1
 * 
 * Output: 0
 * 
 * Explanation:
 * 
 * There is no substring with every vowel.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: word = "aeiou", k = 0
 * 
 * Output: 1
 * 
 * Explanation:
 * 
 * The only substring with every vowel and zero consonants is word[0..4], which
 * is "aeiou".
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: word = "ieaouqqieaouqq", k = 1
 * 
 * Output: 3
 * 
 * Explanation:
 * 
 * The substrings with every vowel and one consonant are:
 * 
 * 
 * word[0..5], which is "ieaouq".
 * word[6..11], which is "qieaou".
 * word[7..12], which is "ieaouq".
 * 
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 5 <= word.length <= 2 * 10^5
 * word consists only of lowercase English letters.
 * 0 <= k <= word.length - 5
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
    private long AtLeastK(string word, int k)
    {
        int n = word.Length;
        // Dictionary to count the vowel occurrences
        Dictionary<char, int> vowelsCount = new Dictionary<char, int>();
        // int to count the consonants
        int consonants = 0;
        // int to check whether it is vowel
        int vowel = (1 << 'a' - 'a') | (1 << 'e' - 'a') | (1 << 'i' - 'a') | (1 << 'o' - 'a') | (1 << 'u' - 'a');
        long ans = 0;

        // Two Point of left and right
        int left = 0;

        // move right pointer [0, n - 1]
        for (int right = 0; right < n; right++)
        {
            // if it is vowel
            if ((vowel | (1 << word[right] - 'a')) == vowel)
            {
                // add occurrence
                if (!vowelsCount.ContainsKey(word[right]))
                    vowelsCount[word[right]] = 0;
                vowelsCount[word[right]]++;
            }
            else
                // add consonant
                consonants++;

            // if current window is valid, ignore k constraint
            while (vowelsCount.Count == 5 && consonants >= k)
            {
                // from right to n - 1, all substrings are valid, so combination = n - 1 - right + 1 = n - right
                ans += n - right;

                // move left pointer and remove corresponding vowel or consonant
                if ((vowel | (1 << word[left] - 'a')) == vowel)
                {
                    vowelsCount[word[left]]--;
                    if (vowelsCount[word[left]] == 0)
                        vowelsCount.Remove(word[left]);
                }
                else
                    consonants--;

                left++;
            }
        }
        return ans;
    }

    public long CountOfSubstrings(string word, int k)
    {
        // ans = All substrings with at least k - All substrings with at least k + 1
        // i.e. k = 2,
        // AtLeastK(word, k) = substrings with 2 consonants + substrings with 3 consonants + ...
        // AtLeastK(word, k + 1) = substrings with 3 consonants + substrings with 4 consonants + ...
        // so ans = AtLeastK(word, k) - AtLeastK(word, k + 1)
        return AtLeastK(word, k) - AtLeastK(word, k + 1);
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=299 lang=csharp
 *
 * [299] Bulls and Cows
 *
 * https://leetcode.com/problems/bulls-and-cows/description/
 *
 * algorithms
 * Medium (50.69%)
 * Likes:    2474
 * Dislikes: 1788
 * Total Accepted:    391.3K
 * Total Submissions: 770.6K
 * Testcase Example:  '"1807"\n"7810"'
 *
 * You are playing the Bulls and Cows game with your friend.
 * 
 * You write down a secret number and ask your friend to guess what the number
 * is. When your friend makes a guess, you provide a hint with the following
 * info:
 * 
 * 
 * The number of "bulls", which are digits in the guess that are in the correct
 * position.
 * The number of "cows", which are digits in the guess that are in your secret
 * number but are located in the wrong position. Specifically, the non-bull
 * digits in the guess that could be rearranged such that they become bulls.
 * 
 * 
 * Given the secret number secret and your friend's guess guess, return the
 * hint for your friend's guess.
 * 
 * The hint should be formatted as "xAyB", where x is the number of bulls and y
 * is the number of cows. Note that both secret and guess may contain duplicate
 * digits.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: secret = "1807", guess = "7810"
 * Output: "1A3B"
 * Explanation: Bulls are connected with a '|' and cows are underlined:
 * "1807"
 * ⁠ |
 * "7810"
 * 
 * Example 2:
 * 
 * 
 * Input: secret = "1123", guess = "0111"
 * Output: "1A1B"
 * Explanation: Bulls are connected with a '|' and cows are underlined:
 * "1123"        "1123"
 * ⁠ |      or     |
 * "0111"        "0111"
 * Note that only one of the two unmatched 1s is counted as a cow since the
 * non-bull digits can only be rearranged to allow one 1 to be a bull.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= secret.length, guess.length <= 1000
 * secret.length == guess.length
 * secret and guess consist of digits only.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public string GetHint(string secret, string guess)
    {
        int bull = 0, cow = 0;
        int[] secretCount = new int[10]; // 0 - 9
        int[] guessCount = new int[10]; // 0 - 9

        for (int i = 0; i < secret.Length; i++)
        {
            int s = secret[i] - '0';
            int g = guess[i] - '0';
            if (s == g)
                bull++;
            else
            {
                // count corresponding digit
                secretCount[s]++;
                guessCount[g]++;
            }
        }

        for (int i = 0; i < 10; i++)
        {
            cow += Math.Min(secretCount[i], guessCount[i]);
        }

        return string.Format("{0}A{1}B", bull, cow);
    }
}
// @lc code=end


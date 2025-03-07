/*
 * @lc app=leetcode id=2523 lang=csharp
 *
 * [2523] Closest Prime Numbers in Range
 *
 * https://leetcode.com/problems/closest-prime-numbers-in-range/description/
 *
 * algorithms
 * Medium (38.36%)
 * Likes:    396
 * Dislikes: 31
 * Total Accepted:    29.6K
 * Total Submissions: 74.4K
 * Testcase Example:  '10\n19'
 *
 * Given two positive integers left and right, find the two integers num1 and
 * num2 such that:
 * 
 * 
 * left <= num1 < num2 <= right .
 * Both num1 and num2 are prime numbers.
 * num2 - num1 is the minimum amongst all other pairs satisfying the above
 * conditions.
 * 
 * 
 * Return the positive integer array ans = [num1, num2]. If there are multiple
 * pairs satisfying these conditions, return the one with the smallest num1
 * value. If no such numbers exist, return [-1, -1].
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: left = 10, right = 19
 * Output: [11,13]
 * Explanation: The prime numbers between 10 and 19 are 11, 13, 17, and 19.
 * The closest gap between any pair is 2, which can be achieved by [11,13] or
 * [17,19].
 * Since 11 is smaller than 17, we return the first pair.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: left = 4, right = 6
 * Output: [-1,-1]
 * Explanation: There exists only one prime number in the given range, so the
 * conditions cannot be satisfied.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= left <= right <= 10^6
 * 
 * 
 * 
 * .spoilerbutton {display:block; border:dashed; padding: 0px 0px; margin:10px
 * 0px; font-size:150%; font-weight: bold; color:#000000;
 * background-color:cyan; outline:0; 
 * }
 * .spoiler {overflow:hidden;}
 * .spoiler > div {-webkit-transition: all 0s ease;-moz-transition: margin 0s
 * ease;-o-transition: all 0s ease;transition: margin 0s ease;}
 * .spoilerbutton[value="Show Message"] + .spoiler > div {margin-top:-500%;}
 * .spoilerbutton[value="Hide Message"] + .spoiler {padding:5px;}
 * 
 * 
 */
/*
 * Math Approach - Sieve of Eratosthenes
 * Time: O(R * log(log R) + (R - L)), Space: O(R)
 */

// @lc code=start
public partial class Solution
{
    public int[] ClosestPrimes(int left, int right)
    {
        // create bool[R + 1] to mark it as Prime or not
        bool[] isPrime = new bool[right + 1];
        Array.Fill(isPrime, true);
        // 0 and 1 are not Prime
        isPrime[0] = isPrime[1] = false;

        // Sieve of Eratosthenes Algorithm
        // Time: O(R * log(log R))
        for (int i = 2; i * i <= right; i++)
        {
            if (isPrime[i])
            {
                for (int j = i * i; j <= right; j += i)
                    isPrime[j] = false;
            }
        }

        // Find the min diff pair
        int next = 0, diff = Int32.MaxValue;
        // if not found or Prime number <= 1, return [-1, -1]
        int[] ans = new int[2] { -1, -1 };
        for (int i = right; i >= left; i--)
        {
            if (isPrime[i])
            {
                // update ans
                if (next != 0 && diff >= next - i)
                {
                    ans[0] = i;
                    ans[1] = next;
                    diff = next - i;
                }
                next = i;
            }
        }
        return ans;
    }
}
// @lc code=end


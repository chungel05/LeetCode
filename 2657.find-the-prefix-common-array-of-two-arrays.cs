/*
 * @lc app=leetcode id=2657 lang=csharp
 *
 * [2657] Find the Prefix Common Array of Two Arrays
 *
 * https://leetcode.com/problems/find-the-prefix-common-array-of-two-arrays/description/
 *
 * algorithms
 * Medium (81.63%)
 * Likes:    504
 * Dislikes: 19
 * Total Accepted:    49.5K
 * Total Submissions: 61.8K
 * Testcase Example:  '[1,3,2,4]\n[3,1,2,4]'
 *
 * You are given two 0-indexed integer permutations A and B of length n.
 * 
 * A prefix common array of A and B is an array C such that C[i] is equal to
 * the count of numbers that are present at or before the index i in both A and
 * B.
 * 
 * Return the prefix common array of A and B.
 * 
 * A sequence of n integers is called a permutation if it contains all integers
 * from 1 to n exactly once.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: A = [1,3,2,4], B = [3,1,2,4]
 * Output: [0,2,3,4]
 * Explanation: At i = 0: no number is common, so C[0] = 0.
 * At i = 1: 1 and 3 are common in A and B, so C[1] = 2.
 * At i = 2: 1, 2, and 3 are common in A and B, so C[2] = 3.
 * At i = 3: 1, 2, 3, and 4 are common in A and B, so C[3] = 4.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: A = [2,3,1], B = [3,1,2]
 * Output: [0,1,3]
 * Explanation: At i = 0: no number is common, so C[0] = 0.
 * At i = 1: only 3 is common in A and B, so C[1] = 1.
 * At i = 2: 1, 2, and 3 are common in A and B, so C[2] = 3.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= A.length == B.length == n <= 50
 * 1 <= A[i], B[i] <= n
 * It is guaranteed that A and B are both a permutation of n integers.
 * 
 * 
 */

// @lc code=start
using System.Numerics;

public partial class Solution
{
    // Occurrence Counting approach
    // Time: O(n), Space: O(n)
    /* public int[] FindThePrefixCommonArray(int[] A, int[] B)
    {
        // since the num from [1, n], so we need to have n + 1 array
        int[] freq = new int[A.Length + 1];
        int[] res = new int[A.Length];
        int count = 0;

        // loop array A and B
        for (int i = 0; i < A.Length; i++)
        {
            // count the occurrences
            freq[A[i]]++;
            // if we already seen the nums in B, count++
            if (freq[A[i]] == 2)
                count++;

            // count the occurrences
            freq[B[i]]++;
            // if we already seen the nums in A, count++
            if (freq[B[i]] == 2)
                count++;

            // running count is the result of each index i
            res[i] = count;
        }

        return res;
    } */

    // Bit Manipulation approach
    // Time: O(n), Space: O(1)
    public int[] FindThePrefixCommonArray(int[] A, int[] B)
    {
        // since the constraints of value in A/B are <= 50
        // so it is able to use ulong(64bit) to hold the bit we seen before
        ulong numA = 0, numB = 0;
        int[] res = new int[A.Length];
        for (int i = 0; i < A.Length; i++)
        {
            // to set the bit for A[i] and B[i] separately
            numA |= (ulong)1 << A[i];
            numB |= (ulong)1 << B[i];

            // count set bit for numA & numB (which is seen in both A and B)
            /* ulong tmp = numA & numB;
            while (tmp != 0)
            {
                res[i] += (int)(tmp & 1);
                tmp >>= 1;
            } */
            res[i] = BitOperations.PopCount(numA & numB);
        }
        return res;
    }
}
// @lc code=end


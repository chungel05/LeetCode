/*
 * @lc app=leetcode id=2145 lang=csharp
 *
 * [2145] Count the Hidden Sequences
 *
 * https://leetcode.com/problems/count-the-hidden-sequences/description/
 *
 * algorithms
 * Medium (39.13%)
 * Likes:    662
 * Dislikes: 59
 * Total Accepted:    43.7K
 * Total Submissions: 89.9K
 * Testcase Example:  '[1,-3,4]\n1\n6'
 *
 * You are given a 0-indexed array of n integers differences, which describes
 * the differences between each pair of consecutive integers of a hidden
 * sequence of length (n + 1). More formally, call the hidden sequence hidden,
 * then we have that differences[i] = hidden[i + 1] - hidden[i].
 * 
 * You are further given two integers lower and upper that describe the
 * inclusive range of values [lower, upper] that the hidden sequence can
 * contain.
 * 
 * 
 * For example, given differences = [1, -3, 4], lower = 1, upper = 6, the
 * hidden sequence is a sequence of length 4 whose elements are in between 1
 * and 6 (inclusive).
 * 
 * 
 * [3, 4, 1, 5] and [4, 5, 2, 6] are possible hidden sequences.
 * [5, 6, 3, 7] is not possible since it contains an element greater than
 * 6.
 * [1, 2, 3, 4] is not possible since the differences are not
 * correct.
 * 
 * 
 * 
 * 
 * Return the number of possible hidden sequences there are. If there are no
 * possible sequences, return 0.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: differences = [1,-3,4], lower = 1, upper = 6
 * Output: 2
 * Explanation: The possible hidden sequences are:
 * - [3, 4, 1, 5]
 * - [4, 5, 2, 6]
 * Thus, we return 2.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: differences = [3,-4,5,1,-2], lower = -4, upper = 5
 * Output: 4
 * Explanation: The possible hidden sequences are:
 * - [-3, 0, -4, 1, 2, 0]
 * - [-2, 1, -3, 2, 3, 1]
 * - [-1, 2, -2, 3, 4, 2]
 * - [0, 3, -1, 4, 5, 3]
 * Thus, we return 4.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: differences = [4,-7,2], lower = 3, upper = 6
 * Output: 0
 * Explanation: There are no possible hidden sequences. Thus, we return 0.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * n == differences.length
 * 1 <= n <= 10^5
 * -10^5 <= differences[i] <= 10^5
 * -10^5 <= lower <= upper <= 10^5
 * 
 * 
 */
/*
 * Prefix Sum Approach
 * Time: O(n), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    public int NumberOfArrays(int[] differences, int lower, int upper)
    {
        // For the fixed x, find the min num and max num regardless of lower and upper
        // For the given range [lower, upper], it need to fills:
        // lower <= min + d && max + d <= upper, where d is some constant
        // lower - min <= d <= upper - max
        // so the possible d is (upper - max) - (lower - min) + 1
        int min = 0, max = 0;
        // assume x = 0
        int num = 0;
        for (int i = 0; i < differences.Length; i++)
        {
            // for each num regardless of lower and upper
            num += differences[i];
            // find the min and max
            min = Math.Min(min, num);
            max = Math.Max(max, num);

            // lower - min must <= upper - max
            // so if lower - min > upper - max, no possible d
            if (lower - min > upper - max)
                return 0;
        }

        return (upper - max) - (lower - min) + 1;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=2429 lang=csharp
 *
 * [2429] Minimize XOR
 *
 * https://leetcode.com/problems/minimize-xor/description/
 *
 * algorithms
 * Medium (44.62%)
 * Likes:    564
 * Dislikes: 37
 * Total Accepted:    36K
 * Total Submissions: 71.5K
 * Testcase Example:  '3\n5'
 *
 * Given two positive integers num1 and num2, find the positive integer x such
 * that:
 * 
 * 
 * x has the same number of set bits as num2, and
 * The value x XOR num1 is minimal.
 * 
 * 
 * Note that XOR is the bitwise XOR operation.
 * 
 * Return the integer x. The test cases are generated such that x is uniquely
 * determined.
 * 
 * The number of set bits of an integer is the number of 1's in its binary
 * representation.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: num1 = 3, num2 = 5
 * Output: 3
 * Explanation:
 * The binary representations of num1 and num2 are 0011 and 0101, respectively.
 * The integer 3 has the same number of set bits as num2, and the value 3 XOR 3
 * = 0 is minimal.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: num1 = 1, num2 = 12
 * Output: 3
 * Explanation:
 * The binary representations of num1 and num2 are 0001 and 1100, respectively.
 * The integer 3 has the same number of set bits as num2, and the value 3 XOR 1
 * = 2 is minimal.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= num1, num2 <= 10^9
 * 
 * 
 */
/*
 * Bit Manipulation approach
 * Time: O(32), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    public int MinimizeXor(int num1, int num2)
    {
        // Count the no. of bits in num1 and num2
        int numOfBit1 = Int32.PopCount(num1);
        int numOfBit2 = Int32.PopCount(num2);

        // Initial, x = num1 because x XOR num1 = 0
        int x = num1;
        // In order to get the min(x XOR num1),
        // need to set or unset the bit in num1 to make numOfBit1 == numOfBit2
        // since ans need to be min, so we remain the leftmost bit and set/unset from right to left
        // Loop from right to left [0, 31] bit
        for (int i = 0; i < 32; i++)
        {
            // if numOfBit2 == numOfBit1, no need to continue
            if (numOfBit2 == numOfBit1)
                break;

            // if numOfBit2 > numOfBit1, need to set bit to 1
            if (numOfBit2 > numOfBit1 && ((1 << i) & num1) == 0)
            {
                x |= 1 << i;
                numOfBit2--;
            }
            // if numOfBit2 < numOfBit1, need to unset bit to 0
            else if (numOfBit2 < numOfBit1 && ((1 << i) & num1) > 0)
            {
                x ^= 1 << i;
                numOfBit2++;
            }
            // if current bit not fulfill the condition, we continue to move left
        }
        return x;
    }
}
// @lc code=end


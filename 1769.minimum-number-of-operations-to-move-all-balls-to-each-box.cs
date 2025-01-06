/*
 * @lc app=leetcode id=1769 lang=csharp
 *
 * [1769] Minimum Number of Operations to Move All Balls to Each Box
 *
 * https://leetcode.com/problems/minimum-number-of-operations-to-move-all-balls-to-each-box/description/
 *
 * algorithms
 * Medium (85.98%)
 * Likes:    2304
 * Dislikes: 95
 * Total Accepted:    141.1K
 * Total Submissions: 163.5K
 * Testcase Example:  '"110"'
 *
 * You have n boxes. You are given a binary string boxes of length n, where
 * boxes[i] is '0' if the i^th box is empty, and '1' if it contains one ball.
 * 
 * In one operation, you can move one ball from a box to an adjacent box. Box i
 * is adjacent to box j if abs(i - j) == 1. Note that after doing so, there may
 * be more than one ball in some boxes.
 * 
 * Return an array answer of size n, where answer[i] is the minimum number of
 * operations needed to move all the balls to the i^th box.
 * 
 * Each answer[i] is calculated considering the initial state of the boxes.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: boxes = "110"
 * Output: [1,1,3]
 * Explanation: The answer for each box is as follows:
 * 1) First box: you will have to move one ball from the second box to the
 * first box in one operation.
 * 2) Second box: you will have to move one ball from the first box to the
 * second box in one operation.
 * 3) Third box: you will have to move one ball from the first box to the third
 * box in two operations, and move one ball from the second box to the third
 * box in one operation.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: boxes = "001011"
 * Output: [11,8,5,4,3,4]
 * 
 * 
 * Constraints:
 * 
 * 
 * n == boxes.length
 * 1 <= n <= 2000
 * boxes[i] is either '0' or '1'.
 * 
 * 
 */
/*
 * Time: O(n), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    public int[] MinOperations(string boxes)
    {
        // use Prefix Sum to calc the total moves to position i
        // i.e. "0010[1]1", for position i = 4, there are 1 ball on left, total moves = 2
        int[] res = new int[boxes.Length];
        int ballCount = 0;
        int leftPrefixSum = 0;
        for (int i = 0; i < boxes.Length; i++)
        {
            res[i] += leftPrefixSum;

            // if current box have ball, we add the ball count
            if (boxes[i] == '1')
                ballCount++;

            // to calc the next position i + 1,
            // total move = leftPrefixSum + total balls on left move 1 step
            // i.e. "00101[1]", for position i = 5, there are 2 balls on left, total moves = 2 + 2 = 4
            leftPrefixSum += ballCount;
        }

        int rightPrefixSum = 0;
        // reset ballCount
        ballCount = 0;
        // start from right to left
        for (int i = boxes.Length - 1; i >= 0; i--)
        {
            // for position i, the min moves to i = leftPrefixSum at i + running right Prefix Sum
            res[i] += rightPrefixSum;

            // update rightPrefixSum for next element
            if (boxes[i] == '1')
                ballCount++;

            rightPrefixSum += ballCount;
        }
        return res;
    }
}
// @lc code=end


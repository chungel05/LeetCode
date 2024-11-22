/*
 * @lc app=leetcode id=85 lang=csharp
 *
 * [85] Maximal Rectangle
 *
 * https://leetcode.com/problems/maximal-rectangle/description/
 *
 * algorithms
 * Hard (51.85%)
 * Likes:    10804
 * Dislikes: 187
 * Total Accepted:    540K
 * Total Submissions: 1M
 * Testcase Example:  '[["1","0","1","0","0"],["1","0","1","1","1"],["1","1","1","1","1"],["1","0","0","1","0"]]'
 *
 * Given a rows x cols binary matrix filled with 0's and 1's, find the largest
 * rectangle containing only 1's and return its area.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: matrix =
 * [["1","0","1","0","0"],["1","0","1","1","1"],["1","1","1","1","1"],["1","0","0","1","0"]]
 * Output: 6
 * Explanation: The maximal rectangle is shown in the above picture.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: matrix = [["0"]]
 * Output: 0
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: matrix = [["1"]]
 * Output: 1
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * rows == matrix.length
 * cols == matrix[i].length
 * 1 <= row, cols <= 200
 * matrix[i][j] is '0' or '1'.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    private int LargestRectangleInHistogram(int[] height)
    {
        int res = 0;
        Stack<int> stack = new Stack<int>();

        // since our height have 1 additional element 0, so we do not need to care about it is out of range or not
        for (int i = 0; i < height.Length; i++)
        {
            // no need to check i == height.Length or not
            // if current bar is lower than top one, we pop it and calc the area except current bar
            while (stack.Count > 0 && height[stack.Peek()] > height[i])
            {
                // corresponding height
                int h = height[stack.Pop()];

                // if no stack, it means that prev bar is lowest before, so we get whole width = current index

                // if still have stack we get the width = i - prev low bar - 1
                // i.e. 3 7 8 5 4, as 7 and 8 already pop in 5
                // we have 3 - - 5 4, to calc area of height 5, we just get width between 4 and 3
                int w = stack.Count > 0 ? i - stack.Peek() - 1 : i;
                res = Math.Max(res, h * w);
            }
            stack.Push(i);
        }

        return res;
    }

    public int MaximalRectangle(char[][] matrix)
    {
        // set it as length + 1 because we need to calc the last case in histogram, which height is 0
        int[] height = new int[matrix[0].Length + 1];
        int max = 0;

        // break down the question to 84 - Largest Area in Histogram
        foreach (char[] row in matrix)
        {
            for (int i = 0; i < row.Length; i++)
            {
                // if it is continues 1, we add together
                // else we set it as 0
                height[i] = row[i] == '0' ? 0 : height[i] + 1;
            }
            max = Math.Max(max, LargestRectangleInHistogram(height));
        }
        return max;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=42 lang=csharp
 *
 * [42] Trapping Rain Water
 *
 * https://leetcode.com/problems/trapping-rain-water/description/
 *
 * algorithms
 * Hard (63.26%)
 * Likes:    32587
 * Dislikes: 545
 * Total Accepted:    2.4M
 * Total Submissions: 3.8M
 * Testcase Example:  '[0,1,0,2,1,0,1,3,2,1,2,1]'
 *
 * Given n non-negative integers representing an elevation map where the width
 * of each bar is 1, compute how much water it can trap after raining.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]
 * Output: 6
 * Explanation: The above elevation map (black section) is represented by array
 * [0,1,0,2,1,0,1,3,2,1,2,1]. In this case, 6 units of rain water (blue
 * section) are being trapped.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: height = [4,2,0,3,2,5]
 * Output: 9
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * n == height.length
 * 1 <= n <= 2 * 10^4
 * 0 <= height[i] <= 10^5
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int Trap(int[] height)
    {
        int l = 0, r = height.Length - 1;
        int area = 0;
        while (l < r)
        {
            if (height[l] < height[r])
            {
                int i = l + 1;
                int darkArea = 0;
                while (i < r && height[i] < height[l])
                {
                    darkArea += height[i];
                    i++;
                }
                area += (i - l - 1) * height[l] - darkArea;
                l = i;
            }
            else
            {
                int i = r - 1;
                int darkArea = 0;
                while (i > l && height[i] < height[r])
                {
                    darkArea += height[i];
                    i--;
                }
                area += (r - i - 1) * height[r] - darkArea;
                r = i;
            }
        }
        return area;
    }
}
// @lc code=end


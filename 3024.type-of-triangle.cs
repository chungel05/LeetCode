/*
 * @lc app=leetcode id=3024 lang=csharp
 *
 * [3024] Type of Triangle
 *
 * https://leetcode.com/problems/type-of-triangle/description/
 *
 * algorithms
 * Easy (38.33%)
 * Likes:    138
 * Dislikes: 21
 * Total Accepted:    68.2K
 * Total Submissions: 177.3K
 * Testcase Example:  '[3,3,3]'
 *
 * You are given a 0-indexed integer array nums of size 3 which can form the
 * sides of a triangle.
 * 
 * 
 * A triangle is called equilateral if it has all sides of equal length.
 * A triangle is called isosceles if it has exactly two sides of equal
 * length.
 * A triangle is called scalene if all its sides are of different lengths.
 * 
 * 
 * Return a string representing the type of triangle that can be formed or
 * "none" if it cannot form a triangle.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [3,3,3]
 * Output: "equilateral"
 * Explanation: Since all the sides are of equal length, therefore, it will
 * form an equilateral triangle.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [3,4,5]
 * Output: "scalene"
 * Explanation: 
 * nums[0] + nums[1] = 3 + 4 = 7, which is greater than nums[2] = 5.
 * nums[0] + nums[2] = 3 + 5 = 8, which is greater than nums[1] = 4.
 * nums[1] + nums[2] = 4 + 5 = 9, which is greater than nums[0] = 3. 
 * Since the sum of the two sides is greater than the third side for all three
 * cases, therefore, it can form a triangle.
 * As all the sides are of different lengths, it will form a scalene
 * triangle.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * nums.length == 3
 * 1 <= nums[i] <= 100
 * 
 * 
 */
/*
 * Sorting Approach
 * Time: O(1), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    public string TriangleType(int[] nums)
    {
        // sort the nums ascending
        Array.Sort(nums);
        // if sum of 2 smallest nums <= biggest num, then it is invalid
        if (nums[0] + nums[1] <= nums[2])
            return "none";
        // if smallest num == largest num, then 3 nums are equal
        else if (nums[0] == nums[2])
            return "equilateral";
        // if num0 == num1 or num1 == num2, then it is isosceles
        else if (nums[0] == nums[1] || nums[1] == nums[2])
            return "isosceles";
        // 3 nums are not equal, then it is scalene
        else
            return "scalene";
    }

    // Brute Force Approach
    // Time: O(1), Space: O(1)
    /* public string TriangleType(int[] nums)
    {
        int sum = nums[0] + nums[1] + nums[2];
        int e1 = nums[0] + nums[2];
        int e2 = nums[1] + nums[0];
        int e3 = nums[2] + nums[1];

        if (e1 * 2 <= sum || e2 * 2 <= sum || e3 * 2 <= sum)
            return "none";

        if (e1 == e2 && e2 == e3)
            return "equilateral";
        else if (e1 == e2 || e2 == e3 || e3 == e1)
            return "isosceles";
        else
            return "scalene";
    } */
}
// @lc code=end


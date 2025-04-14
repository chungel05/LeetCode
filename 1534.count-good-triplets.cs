/*
 * @lc app=leetcode id=1534 lang=csharp
 *
 * [1534] Count Good Triplets
 *
 * https://leetcode.com/problems/count-good-triplets/description/
 *
 * algorithms
 * Easy (81.50%)
 * Likes:    814
 * Dislikes: 1209
 * Total Accepted:    142.8K
 * Total Submissions: 173.9K
 * Testcase Example:  '[3,0,1,1,9,7]\n7\n2\n3'
 *
 * Given an array of integers arr, and three integers a, b and c. You need to
 * find the number of good triplets.
 * 
 * A triplet (arr[i], arr[j], arr[k]) is good if the following conditions are
 * true:
 * 
 * 
 * 0 <= i < j < k < arr.length
 * |arr[i] - arr[j]| <= a
 * |arr[j] - arr[k]| <= b
 * |arr[i] - arr[k]| <= c
 * 
 * 
 * Where |x| denotes the absolute value of x.
 * 
 * Return the number of good triplets.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: arr = [3,0,1,1,9,7], a = 7, b = 2, c = 3
 * Output: 4
 * Explanation: There are 4 good triplets: [(3,0,1), (3,0,1), (3,1,1),
 * (0,1,1)].
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: arr = [1,1,2,2,3], a = 0, b = 0, c = 1
 * Output: 0
 * Explanation: No triplet satisfies all conditions.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 3 <= arr.length <= 100
 * 0 <= arr[i] <= 1000
 * 0 <= a, b, c <= 1000
 * 
 */
/*
 * Brute Force Approach
 * Time: O(n^3), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    public int CountGoodTriplets(int[] arr, int a, int b, int c)
    {
        int count = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                // if the first condition fail, continue to next combination
                if (Math.Abs(arr[i] - arr[j]) > a)
                    continue;

                for (int k = j + 1; k < arr.Length; k++)
                {
                    if (Math.Abs(arr[j] - arr[k]) <= b && Math.Abs(arr[i] - arr[k]) <= c)
                        count++;
                }
            }
        }
        return count;
    }
}
// @lc code=end


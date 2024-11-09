/*
 * @lc app=leetcode id=4 lang=csharp
 *
 * [4] Median of Two Sorted Arrays
 *
 * https://leetcode.com/problems/median-of-two-sorted-arrays/description/
 *
 * algorithms
 * Hard (41.66%)
 * Likes:    28829
 * Dislikes: 3239
 * Total Accepted:    2.9M
 * Total Submissions: 7M
 * Testcase Example:  '[1,3]\n[2]'
 *
 * Given two sorted arrays nums1 and nums2 of size m and n respectively, return
 * the median of the two sorted arrays.
 * 
 * The overall run time complexity should be O(log (m+n)).
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums1 = [1,3], nums2 = [2]
 * Output: 2.00000
 * Explanation: merged array = [1,2,3] and median is 2.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums1 = [1,2], nums2 = [3,4]
 * Output: 2.50000
 * Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * nums1.length == m
 * nums2.length == n
 * 0 <= m <= 1000
 * 0 <= n <= 1000
 * 1 <= m + n <= 2000
 * -10^6 <= nums1[i], nums2[i] <= 10^6
 * 
 * 
 */
/*
 * Merge sort implementation
 * Merge two sorted array together and return the median
 * Time: O(n+m), Space: O(n+m)
 */

// @lc code=start
using System.Data;

public partial class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        List<int> res = new List<int>();
        int total = nums1.Length + nums2.Length;
        int i = 0, j = 0;

        while (i < nums1.Length && j < nums2.Length)
        {
            if (nums1[i] <= nums2[j])
            {
                res.Add(nums1[i]);
                i++;
            }
            else
            {
                res.Add(nums2[j]);
                j++;
            }
        }

        if (i >= nums1.Length)
            res.AddRange(nums2.Skip(j));
        else
            res.AddRange(nums1.Skip(i));

        if (total % 2 == 0)
            return (double)(res[total / 2 - 1] + res[total / 2]) / 2;
        else
            return res[total / 2];
    }
}
// @lc code=end


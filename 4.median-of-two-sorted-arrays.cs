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

// @lc code=start
using System.Data;

public partial class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int[] A, B;
        int Total = nums1.Length + nums2.Length;
        int half = (Total + 1) / 2;
        if (nums1.Length <= nums2.Length)
        {
            A = nums1;
            B = nums2;
        }
        else
        {
            A = nums2;
            B = nums1;
        }

        int l = 0, r = A.Length;
        while (l <= r)
        {
            int i = (l + r) / 2;
            int j = half - i;

            int Aleft = i - 1 >= 0 ? A[i - 1] : int.MinValue;
            int Aright = i < A.Length ? A[i] : int.MaxValue;
            int Bleft = j - 1 >= 0 ? B[j - 1] : int.MinValue;
            int Bright = j < B.Length ? B[j] : int.MaxValue;

            if (Aleft <= Bright && Bleft <= Aright)
            {
                if (Total % 2 != 0)
                    return Math.Max(Aleft, Bleft);
                else
                    return (Math.Max(Aleft, Bleft) + Math.Min(Aright, Bright)) / 2.0;
            }
            else if (Aleft > Bright)
                r = i - 1;
            else
                l = i + 1;
        }
        return -1;
    }
}
// @lc code=end


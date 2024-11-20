/*
 * @lc app=leetcode id=454 lang=csharp
 *
 * [454] 4Sum II
 *
 * https://leetcode.com/problems/4sum-ii/description/
 *
 * algorithms
 * Medium (57.39%)
 * Likes:    4943
 * Dislikes: 144
 * Total Accepted:    341.4K
 * Total Submissions: 595.1K
 * Testcase Example:  '[1,2]\n[-2,-1]\n[-1,2]\n[0,2]'
 *
 * Given four integer arrays nums1, nums2, nums3, and nums4 all of length n,
 * return the number of tuples (i, j, k, l) such that:
 * 
 * 
 * 0 <= i, j, k, l < n
 * nums1[i] + nums2[j] + nums3[k] + nums4[l] == 0
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums1 = [1,2], nums2 = [-2,-1], nums3 = [-1,2], nums4 = [0,2]
 * Output: 2
 * Explanation:
 * The two tuples are:
 * 1. (0, 0, 0, 1) -> nums1[0] + nums2[0] + nums3[0] + nums4[1] = 1 + (-2) +
 * (-1) + 2 = 0
 * 2. (1, 1, 0, 0) -> nums1[1] + nums2[1] + nums3[0] + nums4[0] = 2 + (-1) +
 * (-1) + 0 = 0
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums1 = [0], nums2 = [0], nums3 = [0], nums4 = [0]
 * Output: 1
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * n == nums1.length
 * n == nums2.length
 * n == nums3.length
 * n == nums4.length
 * 1 <= n <= 200
 * -2^28 <= nums1[i], nums2[i], nums3[i], nums4[i] <= 2^28
 * 
 * 
 */
/*
 * Dictionary approach
 * Time: O(n^2), Space: O(n^2)
 *
 * Two Pointer
 * We can use Two pointer as well but the time complexity will be higher, similar to 4 sum question
 * Time: O(n^3), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();

        int res = 0, n = nums1.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (!dict.ContainsKey(nums1[i] + nums2[j]))
                    dict[nums1[i] + nums2[j]] = 0;
                dict[nums1[i] + nums2[j]]++;
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int sum = nums3[i] + nums4[j];
                if (dict.ContainsKey(-sum))
                    res += dict[-sum];
            }
        }

        return res;
    }
}
// @lc code=end


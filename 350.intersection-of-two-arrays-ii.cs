/*
 * @lc app=leetcode id=350 lang=csharp
 *
 * [350] Intersection of Two Arrays II
 *
 * https://leetcode.com/problems/intersection-of-two-arrays-ii/description/
 *
 * algorithms
 * Easy (58.71%)
 * Likes:    7763
 * Dislikes: 982
 * Total Accepted:    1.5M
 * Total Submissions: 2.5M
 * Testcase Example:  '[1,2,2,1]\n[2,2]'
 *
 * Given two integer arrays nums1 and nums2, return an array of their
 * intersection. Each element in the result must appear as many times as it
 * shows in both arrays and you may return the result in any order.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums1 = [1,2,2,1], nums2 = [2,2]
 * Output: [2,2]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
 * Output: [4,9]
 * Explanation: [9,4] is also accepted.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums1.length, nums2.length <= 1000
 * 0 <= nums1[i], nums2[i] <= 1000
 * 
 * 
 * 
 * Follow up:
 * 
 * 
 * What if the given array is already sorted? How would you optimize your
 * algorithm?
 * What if nums1's size is small compared to nums2's size? Which algorithm is
 * better?
 * What if elements of nums2 are stored on disk, and the memory is limited such
 * that you cannot load all elements into the memory at once?
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        List<int> res = new List<int>();
        Dictionary<int, int> dict = new Dictionary<int, int>();

        for (int i = 0; i < nums1.Length; i++)
        {
            if (!dict.ContainsKey(nums1[i]))
                dict[nums1[i]] = 0;
            dict[nums1[i]]++;
        }

        for (int i = 0; i < nums2.Length; i++)
        {
            if (dict.ContainsKey(nums2[i]))
            {
                res.Add(nums2[i]);
                dict[nums2[i]]--;
                if (dict[nums2[i]] == 0)
                    dict.Remove(nums2[i]);
            }
        }
        return res.ToArray();
    }
}
// @lc code=end


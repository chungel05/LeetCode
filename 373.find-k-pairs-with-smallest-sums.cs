/*
 * @lc app=leetcode id=373 lang=csharp
 *
 * [373] Find K Pairs with Smallest Sums
 *
 * https://leetcode.com/problems/find-k-pairs-with-smallest-sums/description/
 *
 * algorithms
 * Medium (40.16%)
 * Likes:    6391
 * Dislikes: 456
 * Total Accepted:    332.2K
 * Total Submissions: 826.8K
 * Testcase Example:  '[1,7,11]\n[2,4,6]\n3'
 *
 * You are given two integer arrays nums1 and nums2 sorted in non-decreasing
 * order and an integer k.
 * 
 * Define a pair (u, v) which consists of one element from the first array and
 * one element from the second array.
 * 
 * Return the k pairs (u1, v1), (u2, v2), ..., (uk, vk) with the smallest
 * sums.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums1 = [1,7,11], nums2 = [2,4,6], k = 3
 * Output: [[1,2],[1,4],[1,6]]
 * Explanation: The first 3 pairs are returned from the sequence:
 * [1,2],[1,4],[1,6],[7,2],[7,4],[11,2],[7,6],[11,4],[11,6]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums1 = [1,1,2], nums2 = [1,2,3], k = 2
 * Output: [[1,1],[1,1]]
 * Explanation: The first 2 pairs are returned from the sequence:
 * [1,1],[1,1],[1,2],[2,1],[1,2],[2,2],[1,3],[1,3],[2,3]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums1.length, nums2.length <= 10^5
 * -10^9 <= nums1[i], nums2[i] <= 10^9
 * nums1 and nums2 both are sorted in non-decreasing order.
 * 1 <= k <= 10^4
 * k <= nums1.length * nums2.length
 * 
 * 
 */
/*
 * Time: O(klogk), Space = O(k)
 * max k nums need to select from each side to combine 
 */

// @lc code=start
public partial class Solution
{
    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
    {
        PriorityQueue<(int, int), int> minHeap = new PriorityQueue<(int, int), int>();
        List<IList<int>> res = new List<IList<int>>();

        for (int i = 0; i < Math.Min(k, nums1.Length); i++)
        {
            minHeap.Enqueue((i, 0), nums1[i] + nums2[0]);
        }

        while (k > 0)
        {
            var (i, j) = minHeap.Dequeue();
            res.Add(new List<int>() { nums1[i], nums2[j] });

            if (j + 1 < nums2.Length)
                minHeap.Enqueue((i, j + 1), nums1[i] + nums2[j + 1]);

            k--;
        }

        return res;
    }
}
// @lc code=end


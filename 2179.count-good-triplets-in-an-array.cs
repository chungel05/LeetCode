/*
 * @lc app=leetcode id=2179 lang=csharp
 *
 * [2179] Count Good Triplets in an Array
 *
 * https://leetcode.com/problems/count-good-triplets-in-an-array/description/
 *
 * algorithms
 * Hard (41.52%)
 * Likes:    680
 * Dislikes: 41
 * Total Accepted:    17.2K
 * Total Submissions: 33.4K
 * Testcase Example:  '[2,0,1,3]\n[0,1,2,3]'
 *
 * You are given two 0-indexed arrays nums1 and nums2 of length n, both of
 * which are permutations of [0, 1, ..., n - 1].
 * 
 * A good triplet is a set of 3 distinct values which are present in increasing
 * order by position both in nums1 and nums2. In other words, if we consider
 * pos1v as the index of the value v in nums1 and pos2v as the index of the
 * value v in nums2, then a good triplet will be a set (x, y, z) where 0 <= x,
 * y, z <= n - 1, such that pos1x < pos1y < pos1z and pos2x < pos2y < pos2z.
 * 
 * Return the total number of good triplets.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums1 = [2,0,1,3], nums2 = [0,1,2,3]
 * Output: 1
 * Explanation: 
 * There are 4 triplets (x,y,z) such that pos1x < pos1y < pos1z. They are
 * (2,0,1), (2,0,3), (2,1,3), and (0,1,3). 
 * Out of those triplets, only the triplet (0,1,3) satisfies pos2x < pos2y <
 * pos2z. Hence, there is only 1 good triplet.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums1 = [4,0,1,3,2], nums2 = [4,1,0,2,3]
 * Output: 4
 * Explanation: The 4 good triplets are (4,0,3), (4,0,2), (4,1,3), and
 * (4,1,2).
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * n == nums1.length == nums2.length
 * 3 <= n <= 10^5
 * 0 <= nums1[i], nums2[i] <= n - 1
 * nums1 and nums2 are permutations of [0, 1, ..., n - 1].
 * 
 * 
 */
/*
 * Fenwick Tree Approach
 * Time: O(n log n), Space: O(n)
 */

// @lc code=start
public class FenwickTreeForGoodTriplets
{
    private int[] tree;

    public FenwickTreeForGoodTriplets(int size)
    {
        // Fenwick Tree use [1, n]
        tree = new int[size + 1];
    }

    // Time: O(log n)
    public void Update(int i, int value)
    {
        // add 1 to index, because Fenwick Tree use [1, n]
        i++;
        while (i < tree.Length)
        {
            tree[i] += value;
            // flip the last bit
            i += i & -i;
        }
    }

    // Time: O(log n)
    public int Sum(int i)
    {
        i++;
        int res = 0;
        while (i > 0)
        {
            res += tree[i];
            // flip the last bit
            i -= i & -i;
        }
        return res;
    }
}

public partial class Solution
{
    public long GoodTriplets(int[] nums1, int[] nums2)
    {
        int n = nums1.Length;
        int[] pos2 = new int[n];

        // use pos2 to record the index of nums2 for each value [0, n - 1]
        for (int i = 0; i < n; i++)
            pos2[nums2[i]] = i;

        // use Fenwick Tree to dynamic update the prefix sum and get the corresponding sum in O(log n) time
        FenwickTreeForGoodTriplets tree = new FenwickTreeForGoodTriplets(n);
        long res = 0;
        for (int i = 0; i < n - 1; i++)
        {
            // pos = index of nums1[i] in nums2
            int pos = pos2[nums1[i]];

            // get the left prefix sum, which is prefixSum[1, pos] = no. of elements in nums1 before i and in nums2 before pos
            // i.e. [4,0,1,3,2] // [4,1,0,2,3]
            // nums1[2] = 1, which is nums2[1]
            // left = prefixSum[1, 2] = 1 which is [4] only, [0] is not counted because it is not in the prefixSum[1, 2]
            int left = tree.Sum(pos);

            // right = no. of elements in nums2 after pos - (no. of elements in nums1 before i - prefixSum[1, pos])
            // i.e. [4,0,1,3,2] // [4,1,0,2,3]
            // nums1[2] = 1, which is nums2[1]
            // no. of elements in nums2 after pos = n - pos - 1 = 5 - 1 - 1 = 3 which is [0,2,3]
            // no. of elements in nums1 before i = i = 2
            // prefixSum[1, pos] = prefixSum[1, 2] = 1
            // since prefixSum = 1, it means that possible elements before i and pos is 1 only, so another one (2 - 1) is on the right, which is [0]
            // so remaining right = 2, which is [2,3]
            int right = (n - pos - 1) - (i - left);

            // combination = left * right
            res += (long)left * right;

            // dynamic update the prefix sum, add 1 to indicate it
            tree.Update(pos, 1);
        }
        return res;
    }
}
// @lc code=end


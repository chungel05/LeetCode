/*
 * @lc app=leetcode id=2948 lang=csharp
 *
 * [2948] Make Lexicographically Smallest Array by Swapping Elements
 *
 * https://leetcode.com/problems/make-lexicographically-smallest-array-by-swapping-elements/description/
 *
 * algorithms
 * Medium (39.89%)
 * Likes:    828
 * Dislikes: 62
 * Total Accepted:    83.1K
 * Total Submissions: 139.2K
 * Testcase Example:  '[1,5,3,9,8]\n2'
 *
 * You are given a 0-indexed array of positive integers nums and a positive
 * integer limit.
 * 
 * In one operation, you can choose any two indices i and j and swap nums[i]
 * and nums[j] if |nums[i] - nums[j]| <= limit.
 * 
 * Return the lexicographically smallest array that can be obtained by
 * performing the operation any number of times.
 * 
 * An array a is lexicographically smaller than an array b if in the first
 * position where a and b differ, array a has an element that is less than the
 * corresponding element in b. For example, the array [2,10,3] is
 * lexicographically smaller than the array [10,2,3] because they differ at
 * index 0 and 2 < 10.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [1,5,3,9,8], limit = 2
 * Output: [1,3,5,8,9]
 * Explanation: Apply the operation 2 times:
 * - Swap nums[1] with nums[2]. The array becomes [1,3,5,9,8]
 * - Swap nums[3] with nums[4]. The array becomes [1,3,5,8,9]
 * We cannot obtain a lexicographically smaller array by applying any more
 * operations.
 * Note that it may be possible to get the same result by doing different
 * operations.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [1,7,6,18,2,1], limit = 3
 * Output: [1,6,7,18,1,2]
 * Explanation: Apply the operation 3 times:
 * - Swap nums[1] with nums[2]. The array becomes [1,6,7,18,2,1]
 * - Swap nums[0] with nums[4]. The array becomes [2,6,7,18,1,1]
 * - Swap nums[0] with nums[5]. The array becomes [1,6,7,18,1,2]
 * We cannot obtain a lexicographically smaller array by applying any more
 * operations.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: nums = [1,7,28,19,10], limit = 3
 * Output: [1,7,28,19,10]
 * Explanation: [1,7,28,19,10] is the lexicographically smallest array we can
 * obtain because we cannot apply the operation on any two indices.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 10^5
 * 1 <= nums[i] <= 10^9
 * 1 <= limit <= 10^9
 * 
 * 
 */
/*
 * Union Find Approach
 * Time: O(nlogn + n a(n)), Space: O(n)
 */

// @lc code=start
public partial class Solution
{
    // Union Find parent
    private Dictionary<int, int> parent;

    // Find function
    private int Find(int x)
    {
        if (parent[x] != x)
            parent[x] = Find(parent[x]);
        return parent[x];
    }

    // Union Function
    private bool Union(int x, int y)
    {
        int px = Find(x);
        int py = Find(y);
        if (px == py)
            return false;

        parent[py] = px;
        return true;
    }

    public int[] LexicographicallySmallestArray(int[] nums, int limit)
    {
        parent = new Dictionary<int, int>();
        int[] sortedNum = new int[nums.Length];

        // Set each nums' parent = itself
        for (int i = 0; i < nums.Length; i++)
        {
            parent[nums[i]] = nums[i];
        }

        // Copy nums array and sort
        Array.Copy(nums, sortedNum, nums.Length);
        Array.Sort(sortedNum);

        // Since the sortedNum is sorted, so we only need to compare with prev num
        for (int i = 1; i < sortedNum.Length; i++)
        {
            // Form a group if difference is <= limit
            if (sortedNum[i] - sortedNum[i - 1] <= limit)
                Union(sortedNum[i - 1], sortedNum[i]);
        }

        // Create group by using the parent result
        Dictionary<int, Queue<int>> group = new Dictionary<int, Queue<int>>();
        for (int i = 0; i < sortedNum.Length; i++)
        {
            // Find the parent
            int p = parent[sortedNum[i]];

            // Create new group if not exists
            if (!group.ContainsKey(p))
                group[p] = new Queue<int>();

            // Since the sortedNum is sorted, so we can use Queue to hold the num by correct seq
            group[p].Enqueue(sortedNum[i]);
        }

        // Based on original nums array
        int[] res = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            // parent = parent[nums[i]]
            // group = group[parent]
            // Dequeue the num to result
            res[i] = group[parent[nums[i]]].Dequeue();
        }
        return res;
    }
}
// @lc code=end


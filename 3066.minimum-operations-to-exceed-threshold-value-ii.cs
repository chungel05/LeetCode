/*
 * @lc app=leetcode id=3066 lang=csharp
 *
 * [3066] Minimum Operations to Exceed Threshold Value II
 *
 * https://leetcode.com/problems/minimum-operations-to-exceed-threshold-value-ii/description/
 *
 * algorithms
 * Medium (28.10%)
 * Likes:    111
 * Dislikes: 8
 * Total Accepted:    34K
 * Total Submissions: 112.8K
 * Testcase Example:  '[2,11,10,1,3]\n10'
 *
 * You are given a 0-indexed integer array nums, and an integer k.
 * 
 * In one operation, you will:
 * 
 * 
 * Take the two smallest integers x and y in nums.
 * Remove x and y from nums.
 * Add min(x, y) * 2 + max(x, y) anywhere in the array.
 * 
 * 
 * Note that you can only apply the described operation if nums contains at
 * least two elements.
 * 
 * Return the minimum number of operations needed so that all elements of the
 * array are greater than or equal to k.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [2,11,10,1,3], k = 10
 * Output: 2
 * Explanation: In the first operation, we remove elements 1 and 2, then add 1
 * * 2 + 2 to nums. nums becomes equal to [4, 11, 10, 3].
 * In the second operation, we remove elements 3 and 4, then add 3 * 2 + 4 to
 * nums. nums becomes equal to [10, 11, 10].
 * At this stage, all the elements of nums are greater than or equal to 10 so
 * we can stop.
 * It can be shown that 2 is the minimum number of operations needed so that
 * all elements of the array are greater than or equal to 10.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [1,1,2,4,9], k = 20
 * Output: 4
 * Explanation: After one operation, nums becomes equal to [2, 4, 9, 3].
 * After two operations, nums becomes equal to [7, 4, 9].
 * After three operations, nums becomes equal to [15, 9].
 * After four operations, nums becomes equal to [33].
 * At this stage, all the elements of nums are greater than 20 so we can stop.
 * It can be shown that 4 is the minimum number of operations needed so that
 * all elements of the array are greater than or equal to 20.
 * 
 * 
 * Constraints:
 * 
 * 
 * 2 <= nums.length <= 2 * 10^5
 * 1 <= nums[i] <= 10^9
 * 1 <= k <= 10^9
 * The input is generated such that an answer always exists. That is, there
 * exists some sequence of operations after which all elements of the array are
 * greater than or equal to k.
 * 
 * 
 */
/*
 * Heap Approach
 * Time: O(n log n), Space: O(n)
 */

// @lc code=start
public partial class Solution
{
    public int MinOperations(int[] nums, int k)
    {
        // since nums[i] <= 10^9, so x * 2 + y may > 2^31 - 1, use long instead of int
        PriorityQueue<long, long> minHeap = new PriorityQueue<long, long>();
        int operation = 0;

        // enqueue all nums into minHeap
        for (int i = 0; i < nums.Length; i++)
            minHeap.Enqueue(nums[i], nums[i]);

        // if minHeap has 2 elements and the smallest one is < k
        // we do the operation
        // until all elements >= k or minHeap only has 1 element
        while (minHeap.Count >= 2 && minHeap.Peek() < k)
        {
            long x = minHeap.Dequeue();
            long y = minHeap.Dequeue();
            minHeap.Enqueue(x * 2 + y, x * 2 + y);
            operation++;
        }
        return operation;
    }
}
// @lc code=end


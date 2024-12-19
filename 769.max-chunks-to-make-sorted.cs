/*
 * @lc app=leetcode id=769 lang=csharp
 *
 * [769] Max Chunks To Make Sorted
 *
 * https://leetcode.com/problems/max-chunks-to-make-sorted/description/
 *
 * algorithms
 * Medium (58.66%)
 * Likes:    3439
 * Dislikes: 328
 * Total Accepted:    197.1K
 * Total Submissions: 310.2K
 * Testcase Example:  '[4,3,2,1,0]'
 *
 * You are given an integer array arr of length n that represents a permutation
 * of the integers in the range [0, n - 1].
 * 
 * We split arr into some number of chunks (i.e., partitions), and individually
 * sort each chunk. After concatenating them, the result should equal the
 * sorted array.
 * 
 * Return the largest number of chunks we can make to sort the array.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: arr = [4,3,2,1,0]
 * Output: 1
 * Explanation:
 * Splitting into two or more chunks will not return the required result.
 * For example, splitting into [4, 3], [2, 1, 0] will result in [3, 4, 0, 1,
 * 2], which isn't sorted.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: arr = [1,0,2,3,4]
 * Output: 4
 * Explanation:
 * We can split into two chunks, such as [1, 0], [2, 3, 4].
 * However, splitting into [1, 0], [2], [3], [4] is the highest number of
 * chunks possible.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * n == arr.length
 * 1 <= n <= 10
 * 0 <= arr[i] < n
 * All the elements of arr are unique.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int MaxChunksToSorted(int[] arr)
    {
        // prefixSum is the sum according to the arr value
        // sum is the sum according to sorted value (i)
        int prefixSum = 0, sum = 0, count = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            prefixSum += arr[i];
            sum += i;
            if (prefixSum == sum)
                count++;
        }
        return count;
    }
}
// @lc code=end


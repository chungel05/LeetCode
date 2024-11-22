/*
 * @lc app=leetcode id=907 lang=csharp
 *
 * [907] Sum of Subarray Minimums
 *
 * https://leetcode.com/problems/sum-of-subarray-minimums/description/
 *
 * algorithms
 * Medium (37.24%)
 * Likes:    8261
 * Dislikes: 650
 * Total Accepted:    295.1K
 * Total Submissions: 792.3K
 * Testcase Example:  '[3,1,2,4]'
 *
 * Given an array of integers arr, find the sum of min(b), where b ranges over
 * every (contiguous) subarray of arr. Since the answer may be large, return
 * the answer modulo 10^9 + 7.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: arr = [3,1,2,4]
 * Output: 17
 * Explanation: 
 * Subarrays are [3], [1], [2], [4], [3,1], [1,2], [2,4], [3,1,2], [1,2,4],
 * [3,1,2,4]. 
 * Minimums are 3, 1, 2, 4, 1, 1, 2, 1, 1, 1.
 * Sum is 17.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: arr = [11,81,94,43,3]
 * Output: 444
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= arr.length <= 3 * 10^4
 * 1 <= arr[i] <= 3 * 10^4
 * 
 * 
 */
/*
 * Time: O(n), Space: O(n)
 */

// @lc code=start
public partial class Solution
{
    public int SumSubarrayMins(int[] arr)
    {
        Stack<int> stack = new Stack<int>();
        int[] left = new int[arr.Length];
        int[] right = new int[arr.Length];

        // cala the left side index which is closest num small or equal to arr[i]
        for (int i = 0; i < arr.Length; i++)
        {
            while (stack.Count > 0 && arr[stack.Peek()] > arr[i])
                stack.Pop();

            // if no more element small than arr[i]
            // we will have i + 1 cases, which index should set to -1
            left[i] = stack.Count > 0 ? stack.Peek() : -1;
            stack.Push(i);
        }

        stack.Clear();

        // calc the right side index which is closest num small than arr[i]
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            while (stack.Count > 0 && arr[stack.Peek()] >= arr[i])
                stack.Pop();

            // if no more element small than arr[i]
            // we will have arr.Length - i cases, which index should set to arr.Length
            right[i] = stack.Count > 0 ? stack.Peek() : arr.Length;
            stack.Push(i);
        }

        long sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            // at most total cases: (i + 1) * (arr.Length - i)
            sum += (long)(i - left[i]) * (right[i] - i) * arr[i];
        }
        return (int)(sum % (1e9 + 7));
    }
}
// @lc code=end

